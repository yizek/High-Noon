' ============================================================
' Gerencia os pedidos da High Noon: listar, ver itens de um
' pedido, e atualizar o status (pendente/enviado/entregue/cancelado).
' ============================================================

Imports Npgsql
Imports System.Data

Public Class AdminPedidos

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

    ' Lista todos os pedidos, com o e-mail do cliente incluído.
    Public Function ListarPedidos() As DataTable

        Dim tabela As New DataTable()

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "select id, customer_email, total, status, created_at from public.orders_admin"

            Using cmd As New NpgsqlCommand(sql, conn)
                Using reader = cmd.ExecuteReader()
                    tabela.Load(reader)
                End Using
            End Using
        End Using

        Return tabela

    End Function

    ' Lista os itens de um pedido específico.
    Public Function ListarItensDoPedido(orderId As Guid) As DataTable

        Dim tabela As New DataTable()

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "
                select product_name, unit_price, quantity, subtotal
                from public.order_items
                where order_id = @orderId
                order by product_name
            "

            Using cmd As New NpgsqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("orderId", orderId)
                Using reader = cmd.ExecuteReader()
                    tabela.Load(reader)
                End Using
            End Using
        End Using

        Return tabela

    End Function

    ' Muda o status de um pedido (pendente, enviado, entregue, cancelado).
    Public Sub AtualizarStatus(orderId As Guid, novoStatus As String)

        Using conn As New NpgsqlConnection(GetConnectionString())
            conn.Open()

            Dim sql As String = "update public.orders set status = @status where id = @orderId"

            Using cmd As New NpgsqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("orderId", orderId)
                cmd.Parameters.AddWithValue("status", novoStatus)
                cmd.ExecuteNonQuery()
            End Using
        End Using

    End Sub

End Class
