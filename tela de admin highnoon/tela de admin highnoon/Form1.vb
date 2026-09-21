Public Class Form1
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    ' + PRODUTOS
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tela As New FormProdutos()
        tela.ShowDialog()
    End Sub

    ' + PROMOÇÕES
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tela As New FormPromocoes()
        tela.ShowDialog()
    End Sub

    ' GERAL (banco de dados inteiro)
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim tela As New FormGeral()
        tela.ShowDialog()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnPedidos_Click(sender As Object, e As EventArgs) Handles btnPedidos.Click
        Dim tela As New FormPedidos()
        tela.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tela As New FormEncomendas()
        tela.ShowDialog()
    End Sub
End Class