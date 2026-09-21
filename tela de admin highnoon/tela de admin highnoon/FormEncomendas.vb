Public Class FormEncomendas

    Public Sub New()
        InitializeComponent()
    End Sub

    Private admin As New AdminEncomendas()
    Private encomendaSelecionadaId As Guid? = Nothing

    Private Sub FormEncomendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarLista()
    End Sub

    Private Sub CarregarLista()
        dgvEncomendas.DataSource = admin.ListarEncomendas()

        If dgvEncomendas.Columns.Contains("id") Then
            dgvEncomendas.Columns("id").Visible = False
        End If
    End Sub

    Private Sub btnAtualizarLista_Click(sender As Object, e As EventArgs) Handles btnAtualizarLista.Click
        CarregarLista()
    End Sub

    Private Sub dgvEncomendas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEncomendas.SelectionChanged
        If dgvEncomendas.SelectedRows.Count = 0 Then Return

        Dim linha = dgvEncomendas.SelectedRows(0)
        encomendaSelecionadaId = CType(linha.Cells("id").Value, Guid)

        Dim valorAtual = linha.Cells("quoted_price").Value
        txtValor.Text = If(valorAtual Is DBNull.Value OrElse valorAtual Is Nothing, "", valorAtual.ToString())

        cmbStatus.SelectedItem = linha.Cells("status").Value?.ToString()

        ' Carrega as imagens de referência dessa encomenda
        Dim tabelaImagens = admin.ListarImagensDaEncomenda(encomendaSelecionadaId.Value)
        lstImagens.Items.Clear()
        For Each linhaImagem As DataRow In tabelaImagens.Rows
            lstImagens.Items.Add(linhaImagem("image_url").ToString())
        Next
    End Sub

    Private Sub btnAbrirImagem_Click(sender As Object, e As EventArgs) Handles btnAbrirImagem.Click
        If lstImagens.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione uma imagem na lista primeiro.")
            Return
        End If

        Process.Start(New ProcessStartInfo(lstImagens.SelectedItem.ToString()) With {.UseShellExecute = True})
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If encomendaSelecionadaId Is Nothing Then
            MessageBox.Show("Selecione uma encomenda na tabela primeiro.")
            Return
        End If

        If cmbStatus.SelectedItem Is Nothing Then
            MessageBox.Show("Escolha um status.")
            Return
        End If

        Dim valor As Decimal? = Nothing
        If Not String.IsNullOrWhiteSpace(txtValor.Text) Then
            Dim valorConvertido As Decimal
            If Not Decimal.TryParse(txtValor.Text, valorConvertido) Then
                MessageBox.Show("Valor do orçamento inválido. Use só números, ex: 149,90")
                Return
            End If
            valor = valorConvertido
        End If

        admin.AtualizarEncomenda(encomendaSelecionadaId.Value, valor, cmbStatus.SelectedItem.ToString())
        CarregarLista()
        MessageBox.Show("Encomenda atualizada!")
    End Sub

End Class
