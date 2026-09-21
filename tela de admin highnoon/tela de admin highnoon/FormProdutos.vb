Public Class FormProdutos

    Public Sub New()
        InitializeComponent()
    End Sub

    Private admin As New AdminProdutos()
    Private storage As New SupabaseStorage()
    Private idSelecionado As Guid? = Nothing
    Private caminhoImagemSelecionada As String = Nothing
    Private imagemAtualUrl As String = Nothing

    Private Sub FormProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarLista()
    End Sub

    Private Sub CarregarLista()
        dgvProdutos.DataSource = admin.ListarProdutos()

        ' Esconde a coluna de Id da visualização (mas ela continua nos dados)
        If dgvProdutos.Columns.Contains("id") Then
            dgvProdutos.Columns("id").Visible = False
        End If
    End Sub

    Private Sub btnAtualizarLista_Click(sender As Object, e As EventArgs) Handles btnAtualizarLista.Click
        CarregarLista()
    End Sub

    ' Ao clicar numa linha da tabela, preenche os campos pra edição
    Private Sub dgvProdutos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProdutos.SelectionChanged
        If dgvProdutos.SelectedRows.Count = 0 Then Return

        Dim linha = dgvProdutos.SelectedRows(0)

        idSelecionado = CType(linha.Cells("id").Value, Guid)
        txtNome.Text = linha.Cells("name").Value?.ToString()
        txtDescricao.Text = linha.Cells("description").Value?.ToString()
        txtPreco.Text = linha.Cells("price").Value?.ToString()
        cmbCategoria.Text = linha.Cells("category").Value?.ToString()
        numEstoque.Value = Convert.ToDecimal(linha.Cells("stock").Value)

        Dim tagAtual = linha.Cells("tag").Value?.ToString()
        If String.IsNullOrEmpty(tagAtual) Then
            cmbTag.SelectedItem = "(nenhuma)"
        Else
            cmbTag.SelectedItem = tagAtual
        End If

        caminhoImagemSelecionada = Nothing
        imagemAtualUrl = linha.Cells("image_url").Value?.ToString()
        MostrarPreview(imagemAtualUrl)
    End Sub

    ' Mostra a imagem no preview, seja de um arquivo local ou de uma URL já salva.
    Private Sub MostrarPreview(caminhoOuUrl As String)
        Try
            If String.IsNullOrEmpty(caminhoOuUrl) Then
                picPreview.Image = Nothing
                lblImagemSelecionada.Text = "Nenhuma imagem"
            ElseIf caminhoOuUrl.StartsWith("http") Then
                Using client As New System.Net.WebClient()
                    Dim bytes = client.DownloadData(caminhoOuUrl)
                    Using ms As New System.IO.MemoryStream(bytes)
                        picPreview.Image = Image.FromStream(ms)
                    End Using
                End Using
                lblImagemSelecionada.Text = "Imagem atual"
            Else
                picPreview.Image = Image.FromFile(caminhoOuUrl)
                lblImagemSelecionada.Text = System.IO.Path.GetFileName(caminhoOuUrl)
            End If
        Catch
            picPreview.Image = Nothing
            lblImagemSelecionada.Text = "(erro ao carregar preview)"
        End Try
    End Sub

    Private Sub btnEscolherImagem_Click(sender As Object, e As EventArgs) Handles btnEscolherImagem.Click
        Using dialogo As New OpenFileDialog()
            dialogo.Filter = "Imagens (*.png;*.jpg;*.jpeg;*.gif;*.webp)|*.png;*.jpg;*.jpeg;*.gif;*.webp"
            dialogo.Title = "Escolha a imagem do produto"

            If dialogo.ShowDialog() = DialogResult.OK Then
                caminhoImagemSelecionada = dialogo.FileName
                MostrarPreview(caminhoImagemSelecionada)
            End If
        End Using
    End Sub

    ' Lê os campos e valida antes de salvar/atualizar. Retorna False se algo estiver errado.
    Private Function ValidarCampos(ByRef preco As Decimal) As Boolean
        If String.IsNullOrWhiteSpace(txtNome.Text) Then
            MessageBox.Show("Preencha o nome do produto.")
            Return False
        End If

        If cmbCategoria.SelectedItem Is Nothing Then
            MessageBox.Show("Escolha uma categoria.")
            Return False
        End If

        If Not Decimal.TryParse(txtPreco.Text, preco) Then
            MessageBox.Show("Preço inválido. Use só números, ex: 79,90")
            Return False
        End If

        Return True
    End Function

    Private Function TagEscolhida() As String
        If cmbTag.SelectedItem Is Nothing OrElse cmbTag.SelectedItem.ToString() = "(nenhuma)" Then
            Return Nothing
        End If
        Return cmbTag.SelectedItem.ToString()
    End Function

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim preco As Decimal
        If Not ValidarCampos(preco) Then Return

        Dim urlImagem As String = Nothing

        If Not String.IsNullOrEmpty(caminhoImagemSelecionada) Then
            Try
                Me.Cursor = Cursors.WaitCursor
                urlImagem = storage.UploadImagem(caminhoImagemSelecionada)
            Catch ex As Exception
                MessageBox.Show("Não foi possível enviar a imagem: " & ex.Message)
                Return
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If

        admin.InserirProduto(txtNome.Text, txtDescricao.Text, preco, cmbCategoria.SelectedItem.ToString(), TagEscolhida(), CInt(numEstoque.Value), urlImagem)

        LimparCampos()
        CarregarLista()
    End Sub

    Private Sub btnAtualizar_Click(sender As Object, e As EventArgs) Handles btnAtualizar.Click
        If idSelecionado Is Nothing Then
            MessageBox.Show("Selecione um produto na tabela primeiro.")
            Return
        End If

        Dim preco As Decimal
        If Not ValidarCampos(preco) Then Return

        ' Se uma imagem NOVA foi escolhida, envia ela. Senão, mantém a que já estava salva.
        Dim urlImagem As String = imagemAtualUrl

        If Not String.IsNullOrEmpty(caminhoImagemSelecionada) Then
            Try
                Me.Cursor = Cursors.WaitCursor
                urlImagem = storage.UploadImagem(caminhoImagemSelecionada)
            Catch ex As Exception
                MessageBox.Show("Não foi possível enviar a imagem: " & ex.Message)
                Return
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If

        admin.AtualizarProduto(idSelecionado.Value, txtNome.Text, txtDescricao.Text, preco, cmbCategoria.SelectedItem.ToString(), TagEscolhida(), CInt(numEstoque.Value), urlImagem)

        CarregarLista()
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If idSelecionado Is Nothing Then
            MessageBox.Show("Selecione um produto na tabela primeiro.")
            Return
        End If

        Dim confirmacao = MessageBox.Show($"Excluir ""{txtNome.Text}""? Essa ação não pode ser desfeita.", "Confirmar exclusão", MessageBoxButtons.YesNo)
        If confirmacao <> DialogResult.Yes Then Return

        admin.ExcluirProduto(idSelecionado.Value)

        LimparCampos()
        CarregarLista()
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        LimparCampos()
    End Sub

    Private Sub LimparCampos()
        idSelecionado = Nothing
        txtNome.Clear()
        txtDescricao.Clear()
        txtPreco.Clear()
        cmbCategoria.SelectedIndex = -1
        cmbTag.SelectedIndex = -1
        numEstoque.Value = 0
        dgvProdutos.ClearSelection()
        caminhoImagemSelecionada = Nothing
        imagemAtualUrl = Nothing
        MostrarPreview(Nothing)
    End Sub

End Class
