' ============================================================
' Explorador genérico do banco de dados — a parte "abrir o banco
' inteiro pela tela do VB.NET" que seu professor pediu.
'
' Ideia de uso na Form de admin:
'   1. Um ComboBox (cmbTabelas) listando as tabelas do banco
'   2. Um DataGridView (dgvDados) mostrando o conteúdo da tabela escolhida
'   3. Um botão "Atualizar" que recarrega os dados
'
' Usa a mesma DB_HOST / DB_PASSWORD do AdminProdutos.vb — se
' preferir, uma única classe de conexão compartilhada é melhor
' (dá pra refatorar depois, isso aqui já funciona pra entregar).
' ============================================================

Imports Npgsql
Imports System.Data

Public Class BancoDeDadosExplorer

    Private Const DB_HOST As String = "db.pbqooeovnkbrtvevkbse.supabase.co"
    Private Const DB_PORT As String = "5432"
    Private Const DB_NAME As String = "postgres"
    Private Const DB_USER As String = "vbnet_admin"
    Private Const DB_PASSWORD As String = "HighNoon2026SaloonDb!"

    Private Function GetConnectionString() As String
        Dim builder As New NpgsqlConnectionStringBuilder()
        builder.Host = DB_HOST
        builder.Port = Convert.ToInt32(DB_PORT)
        builder.Database = DB_NAME
        builder.Username = DB_USER
        builder.Password = DB_PASSWORD
        builder.SslMode = SslMode.Require
        builder.TrustServerCertificate = True
        Return builder.ConnectionString
    End Function

    ' Lista os nomes de todas as tabelas do schema "public"
    ' (esse é o schema onde ficam as tabelas "normais" do projeto).
    ' Use isso pra preencher o cmbTabelas.
    Public Function ListarTabelas() As List(Of String)

        Dim tabelas As New List(Of String)

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "
                select table_name
                from information_schema.tables
                where table_schema = 'public'
                order by table_name
            "

            Using cmd As New NpgsqlCommand(sql, conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        tabelas.Add(reader.GetString(0))
                    End While
                End Using
            End Using
        End Using

        Return tabelas

    End Function

    ' Traz TODAS as colunas e linhas de uma tabela — pronto pra
    ' jogar direto num DataGridView.DataSource.
    '
    ' ATENÇÃO: o nome da tabela vem de um ComboBox que você mesmo
    ' preenche com ListarTabelas(), nunca de texto digitado livre
    ' pelo usuário — isso evita SQL injection, já que não dá pra
    ' usar parâmetro (@nome) no lugar de um nome de tabela em SQL.
    Public Function AbrirTabela(nomeTabela As String) As DataTable

        Dim tabela As New DataTable()

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            ' Colchetes/aspas duplas protegem contra nomes de tabela
            ' com maiúsculas ou caracteres especiais.
            Dim sql As String = $"select * from public.""{nomeTabela}"" order by 1"

            Using cmd As New NpgsqlCommand(sql, conn)
                Using reader = cmd.ExecuteReader()
                    tabela.Load(reader)
                End Using
            End Using
        End Using

        Return tabela

    End Function

    ' Roda uma consulta SQL qualquer, só leitura (SELECT).
    ' Útil se você quiser fazer filtros mais específicos direto
    ' da tela de admin, tipo "produtos com preço acima de X".
    Public Function ExecutarConsulta(sqlSelect As String) As DataTable

        Dim tabela As New DataTable()

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Using cmd As New NpgsqlCommand(sqlSelect, conn)
                Using reader = cmd.ExecuteReader()
                    tabela.Load(reader)
                End Using
            End Using
        End Using

        Return tabela

    End Function

End Class

' ============================================================
' Exemplo de uso na Form (supondo cmbTabelas, dgvDados, btnAbrir):
'
' Private explorer As New BancoDeDadosExplorer()
'
' Private Sub FrmAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'     cmbTabelas.Items.Clear()
'     cmbTabelas.Items.AddRange(explorer.ListarTabelas().ToArray())
' End Sub
'
' Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
'     Dim tabelaEscolhida As String = cmbTabelas.SelectedItem.ToString()
'     dgvDados.DataSource = explorer.AbrirTabela(tabelaEscolhida)
' End Sub
' ============================================================
