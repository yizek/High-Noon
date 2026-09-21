' ============================================================
' Exemplo de tela administrativa em VB.NET para a High Noon.
' Insere um produto direto na tabela "products" do Supabase.
'
' PRÉ-REQUISITO: instalar o pacote NuGet "Npgsql" no projeto
'   Console/Package Manager: Install-Package Npgsql
'   ou pelo NuGet Package Manager do Visual Studio
' ============================================================

Imports Npgsql
Imports System.Data

Public Class AdminProdutos

    ' Pegue o HOST e a SENHA no painel do Supabase:
    ' Project Settings > Database > Connection string
    ' (a senha só aparece na hora que você cria o projeto ou reseta ela;
    '  se perdeu, tem um botão "Reset database password" lá)
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

    ' Insere um novo produto. Chame isso quando o usuário
    ' clicar em "Salvar" na tela de admin.
    Public Sub InserirProduto(nome As String, descricao As String, preco As Decimal, categoria As String, tag As String, estoque As Integer, Optional imageUrl As String = Nothing)

        ' categoria precisa ser uma destas: cartas, fichas, mesas, acessorios
        ' tag pode ser "Promoção", "Novo" ou Nothing (sem etiqueta)

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "
                insert into public.products (name, description, price, category, tag, image_url, stock)
                values (@nome, @descricao, @preco, @categoria, @tag, @imageUrl, @estoque)
            "

            Using cmd As New NpgsqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("nome", nome)
                cmd.Parameters.AddWithValue("descricao", If(descricao, CObj(DBNull.Value)))
                cmd.Parameters.AddWithValue("preco", preco)
                cmd.Parameters.AddWithValue("categoria", categoria)
                cmd.Parameters.AddWithValue("imageUrl", If(imageUrl, CObj(DBNull.Value)))
                cmd.Parameters.AddWithValue("estoque", estoque)

                If String.IsNullOrEmpty(tag) Then
                    cmd.Parameters.AddWithValue("tag", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("tag", tag)
                End If

                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Produto adicionado! Já deve aparecer no site em alguns segundos.")

    End Sub

    ' Lista os produtos atuais — útil pra preencher um DataGridView na tela de admin.
    Public Function ListarProdutos() As DataTable

        Dim tabela As New DataTable()

        Using connection As New NpgsqlConnection(GetConnectionString())
            connection.Open()

            Dim sql As String = "select id, name, description, price, category, tag, image_url, stock, created_at from public.products order by created_at desc"

            Using cmd As New NpgsqlCommand(sql, connection)
                Using reader = cmd.ExecuteReader()
                    tabela.Load(reader)
                End Using
            End Using
        End Using

        Return tabela

    End Function

    ' Atualiza um produto existente (mudar preço, nome, descrição, categoria, tag ou imagem).
    Public Sub AtualizarProduto(id As Guid, nome As String, descricao As String, preco As Decimal, categoria As String, tag As String, estoque As Integer, Optional imageUrl As String = Nothing)

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "
                update public.products
                set name = @nome,
                    description = @descricao,
                    price = @preco,
                    category = @categoria,
                    tag = @tag,
                    image_url = @imageUrl,
                    stock = @estoque
                where id = @id
            "

            Using cmd As New NpgsqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("id", id)
                cmd.Parameters.AddWithValue("nome", nome)
                cmd.Parameters.AddWithValue("descricao", If(descricao, CObj(DBNull.Value)))
                cmd.Parameters.AddWithValue("preco", preco)
                cmd.Parameters.AddWithValue("categoria", categoria)
                cmd.Parameters.AddWithValue("imageUrl", If(imageUrl, CObj(DBNull.Value)))
                cmd.Parameters.AddWithValue("estoque", estoque)

                If String.IsNullOrEmpty(tag) Then
                    cmd.Parameters.AddWithValue("tag", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("tag", tag)
                End If

                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Produto atualizado! A mudança já reflete no site.")

    End Sub

    ' Exclui um produto pelo Id (Guid).
    Public Sub ExcluirProduto(id As Guid)

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "delete from public.products where id = @id"

            Using cmd As New NpgsqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using

    End Sub

End Class

' ============================================================
' Exemplo de uso, no clique de um botão "Salvar" na sua Form:
'
' Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
'     Dim admin As New AdminProdutos()
'     admin.InserirProduto(
'         txtNome.Text,
'         txtDescricao.Text,
'         Decimal.Parse(txtPreco.Text),
'         cmbCategoria.SelectedItem.ToString(),
'         cmbTag.SelectedItem?.ToString()
'     )
' End Sub
' ============================================================
