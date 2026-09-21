Public Class FormPromocoes

    Public Sub New()
        InitializeComponent()
    End Sub

    Private admin As New AdminProdutos()

    Private Sub FormPromocoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarLista()
    End Sub

    Private Sub CarregarLista()
        dgvProdutos.DataSource = admin.ListarProdutos()

        If dgvProdutos.Columns.Contains("id") Then
            dgvProdutos.Columns("id").Visible = False
        End If
    End Sub

    Private Sub btnAtualizarLista_Click(sender As Object, e As EventArgs) Handles btnAtualizarLista.Click
        CarregarLista()
    End Sub

    ' Troca só a etiqueta (tag) do produto selecionado, mantendo o resto igual.
    Private Sub AplicarEtiqueta(novaTag As String)
        If dgvProdutos.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um produto na tabela primeiro.")
            Return
        End If

        Dim linha = dgvProdutos.SelectedRows(0)

        Dim id As Guid = CType(linha.Cells("id").Value, Guid)
        Dim nome As String = linha.Cells("name").Value?.ToString()
        Dim descricao As String = linha.Cells("description").Value?.ToString()
        Dim preco As Decimal = Convert.ToDecimal(linha.Cells("price").Value)
        Dim categoria As String = linha.Cells("category").Value?.ToString()
        Dim estoqueAtual As Integer = Convert.ToInt32(linha.Cells("stock").Value)
        Dim imagemAtual As String = linha.Cells("image_url").Value?.ToString()

        admin.AtualizarProduto(id, nome, descricao, preco, categoria, novaTag, estoqueAtual, imagemAtual)

        CarregarLista()
    End Sub

    Private Sub btnMarcarPromocao_Click(sender As Object, e As EventArgs) Handles btnMarcarPromocao.Click
        AplicarEtiqueta("Promoção")
    End Sub

    Private Sub btnMarcarNovo_Click(sender As Object, e As EventArgs) Handles btnMarcarNovo.Click
        AplicarEtiqueta("Novo")
    End Sub

    Private Sub btnRemoverEtiqueta_Click(sender As Object, e As EventArgs) Handles btnRemoverEtiqueta.Click
        AplicarEtiqueta(Nothing)
    End Sub

End Class
