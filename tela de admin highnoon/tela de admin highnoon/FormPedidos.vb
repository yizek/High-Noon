Public Class FormPedidos

    Public Sub New()
        InitializeComponent()
    End Sub

    Private admin As New AdminPedidos()
    Private pedidoSelecionadoId As Guid? = Nothing

    Private Sub FormPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarLista()
    End Sub

    Private Sub CarregarLista()
        dgvPedidos.DataSource = admin.ListarPedidos()

        If dgvPedidos.Columns.Contains("id") Then
            dgvPedidos.Columns("id").Visible = False
        End If
    End Sub

    Private Sub btnAtualizarLista_Click(sender As Object, e As EventArgs) Handles btnAtualizarLista.Click
        CarregarLista()
    End Sub

    Private Sub dgvPedidos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPedidos.SelectionChanged
        If dgvPedidos.SelectedRows.Count = 0 Then Return

        Dim linha = dgvPedidos.SelectedRows(0)
        pedidoSelecionadoId = CType(linha.Cells("id").Value, Guid)
        cmbStatus.SelectedItem = linha.Cells("status").Value?.ToString()

        dgvItens.DataSource = admin.ListarItensDoPedido(pedidoSelecionadoId.Value)
    End Sub

    Private Sub btnSalvarStatus_Click(sender As Object, e As EventArgs) Handles btnSalvarStatus.Click
        If pedidoSelecionadoId Is Nothing Then
            MessageBox.Show("Selecione um pedido na tabela primeiro.")
            Return
        End If

        If cmbStatus.SelectedItem Is Nothing Then
            MessageBox.Show("Escolha um status.")
            Return
        End If

        admin.AtualizarStatus(pedidoSelecionadoId.Value, cmbStatus.SelectedItem.ToString())
        CarregarLista()
        MessageBox.Show("Status atualizado!")
    End Sub

End Class
