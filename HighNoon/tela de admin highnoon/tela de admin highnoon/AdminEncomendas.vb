' ============================================================
' Gerencia as encomendas personalizadas — a marca registrada
' da High Noon. Listar, ver imagens de referência, definir
' orçamento e mudar status.
' ============================================================

Imports Npgsql
Imports System.Data

Public Class AdminEncomendas

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

    ' Lista todas as encomendas, com produto e e-mail do cliente incluídos.
    Public Function ListarEncomendas() As DataTable

        Dim tabela As New DataTable()

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "select id, customer_email, product_name, details, quoted_price, status, created_at from public.custom_orders_admin"

            Using cmd As New NpgsqlCommand(sql, conn)
                Using reader = cmd.ExecuteReader()
                    tabela.Load(reader)
                End Using
            End Using
        End Using

        Return tabela

    End Function

    ' Lista as URLs das imagens de referência de uma encomenda.
    Public Function ListarImagensDaEncomenda(encomendaId As Guid) As DataTable

        Dim tabela As New DataTable()

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "select image_url from public.custom_order_images where custom_order_id = @id"

            Using cmd As New NpgsqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("id", encomendaId)
                Using reader = cmd.ExecuteReader()
                    tabela.Load(reader)
                End Using
            End Using
        End Using

        Return tabela

    End Function

    ' Define o valor do orçamento e/ou muda o status da encomenda.
    Public Sub AtualizarEncomenda(encomendaId As Guid, valorOrcamento As Decimal?, novoStatus As String)

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "
                update public.custom_orders
                set quoted_price = @valor,
                    status = @status
                where id = @id
            "

            Using cmd As New NpgsqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("id", encomendaId)
                cmd.Parameters.AddWithValue("status", novoStatus)

                If valorOrcamento.HasValue Then
                    cmd.Parameters.AddWithValue("valor", valorOrcamento.Value)
                Else
                    cmd.Parameters.AddWithValue("valor", DBNull.Value)
                End If

                cmd.ExecuteNonQuery()
            End Using
        End Using

    End Sub

End Class
