Partial Class FormProdutos
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.lblDescricao = New System.Windows.Forms.Label()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.lblPreco = New System.Windows.Forms.Label()
        Me.txtPreco = New System.Windows.Forms.TextBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.lblTag = New System.Windows.Forms.Label()
        Me.cmbTag = New System.Windows.Forms.ComboBox()
        Me.lblEstoque = New System.Windows.Forms.Label()
        Me.numEstoque = New System.Windows.Forms.NumericUpDown()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnAtualizar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.dgvProdutos = New System.Windows.Forms.DataGridView()
        Me.btnAtualizarLista = New System.Windows.Forms.Button()
        Me.btnEscolherImagem = New System.Windows.Forms.Button()
        Me.lblImagemSelecionada = New System.Windows.Forms.Label()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.Snow
        Me.lblTitulo.Location = New System.Drawing.Point(24, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(150, 37)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Produtos"
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.ForeColor = System.Drawing.Color.Snow
        Me.lblNome.Location = New System.Drawing.Point(28, 80)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(42, 13)
        Me.lblNome.TabIndex = 1
        Me.lblNome.Text = "Nome"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(31, 98)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(260, 20)
        Me.txtNome.TabIndex = 2
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.ForeColor = System.Drawing.Color.Snow
        Me.lblDescricao.Location = New System.Drawing.Point(28, 130)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(58, 13)
        Me.lblDescricao.TabIndex = 3
        Me.lblDescricao.Text = "Descrição"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(31, 148)
        Me.txtDescricao.Multiline = True
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(260, 60)
        Me.txtDescricao.TabIndex = 4
        '
        'lblPreco
        '
        Me.lblPreco.AutoSize = True
        Me.lblPreco.ForeColor = System.Drawing.Color.Snow
        Me.lblPreco.Location = New System.Drawing.Point(28, 220)
        Me.lblPreco.Name = "lblPreco"
        Me.lblPreco.Size = New System.Drawing.Size(38, 13)
        Me.lblPreco.TabIndex = 5
        Me.lblPreco.Text = "Preço"
        '
        'txtPreco
        '
        Me.txtPreco.Location = New System.Drawing.Point(31, 238)
        Me.txtPreco.Name = "txtPreco"
        Me.txtPreco.Size = New System.Drawing.Size(260, 20)
        Me.txtPreco.TabIndex = 6
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.ForeColor = System.Drawing.Color.Snow
        Me.lblCategoria.Location = New System.Drawing.Point(28, 270)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(56, 13)
        Me.lblCategoria.TabIndex = 7
        Me.lblCategoria.Text = "Categoria"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Items.AddRange(New Object() {"cartas", "fichas", "mesas", "acessorios"})
        Me.cmbCategoria.Location = New System.Drawing.Point(31, 288)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(260, 21)
        Me.cmbCategoria.TabIndex = 8
        '
        'lblTag
        '
        Me.lblTag.AutoSize = True
        Me.lblTag.ForeColor = System.Drawing.Color.Snow
        Me.lblTag.Location = New System.Drawing.Point(28, 320)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(60, 13)
        Me.lblTag.TabIndex = 9
        Me.lblTag.Text = "Etiqueta"
        '
        'cmbTag
        '
        Me.cmbTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTag.FormattingEnabled = True
        Me.cmbTag.Items.AddRange(New Object() {"(nenhuma)", "Promoção", "Novo"})
        Me.cmbTag.Location = New System.Drawing.Point(31, 338)
        Me.cmbTag.Name = "cmbTag"
        Me.cmbTag.Size = New System.Drawing.Size(260, 21)
        Me.cmbTag.TabIndex = 10
        '
        'lblEstoque
        '
        Me.lblEstoque.AutoSize = True
        Me.lblEstoque.ForeColor = System.Drawing.Color.Snow
        Me.lblEstoque.Location = New System.Drawing.Point(28, 362)
        Me.lblEstoque.Name = "lblEstoque"
        Me.lblEstoque.Size = New System.Drawing.Size(50, 13)
        Me.lblEstoque.TabIndex = 10
        Me.lblEstoque.Text = "Estoque"
        '
        'numEstoque
        '
        Me.numEstoque.Location = New System.Drawing.Point(31, 380)
        Me.numEstoque.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numEstoque.Name = "numEstoque"
        Me.numEstoque.Size = New System.Drawing.Size(100, 20)
        Me.numEstoque.TabIndex = 10
        '
        'btnEscolherImagem
        '
        Me.btnEscolherImagem.BackColor = System.Drawing.Color.Black
        Me.btnEscolherImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEscolherImagem.ForeColor = System.Drawing.Color.SeaShell
        Me.btnEscolherImagem.Location = New System.Drawing.Point(31, 409)
        Me.btnEscolherImagem.Name = "btnEscolherImagem"
        Me.btnEscolherImagem.Size = New System.Drawing.Size(150, 30)
        Me.btnEscolherImagem.TabIndex = 11
        Me.btnEscolherImagem.Text = "Escolher imagem..."
        Me.btnEscolherImagem.UseVisualStyleBackColor = False
        '
        'lblImagemSelecionada
        '
        Me.lblImagemSelecionada.AutoSize = True
        Me.lblImagemSelecionada.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblImagemSelecionada.Location = New System.Drawing.Point(191, 416)
        Me.lblImagemSelecionada.MaximumSize = New System.Drawing.Size(100, 0)
        Me.lblImagemSelecionada.Name = "lblImagemSelecionada"
        Me.lblImagemSelecionada.Size = New System.Drawing.Size(100, 13)
        Me.lblImagemSelecionada.TabIndex = 12
        Me.lblImagemSelecionada.Text = "Nenhuma imagem"
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.Color.White
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPreview.Location = New System.Drawing.Point(31, 445)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(90, 90)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPreview.TabIndex = 13
        Me.picPreview.TabStop = False
        '
        'btnSalvar
        '
        Me.btnSalvar.BackColor = System.Drawing.Color.Black
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.ForeColor = System.Drawing.Color.SeaShell
        Me.btnSalvar.Location = New System.Drawing.Point(140, 449)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(150, 34)
        Me.btnSalvar.TabIndex = 14
        Me.btnSalvar.Text = "Salvar novo"
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'btnAtualizar
        '
        Me.btnAtualizar.BackColor = System.Drawing.Color.Black
        Me.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAtualizar.ForeColor = System.Drawing.Color.SeaShell
        Me.btnAtualizar.Location = New System.Drawing.Point(140, 489)
        Me.btnAtualizar.Name = "btnAtualizar"
        Me.btnAtualizar.Size = New System.Drawing.Size(150, 34)
        Me.btnAtualizar.TabIndex = 15
        Me.btnAtualizar.Text = "Atualizar selecionado"
        Me.btnAtualizar.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.Color.Black
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.ForeColor = System.Drawing.Color.SeaShell
        Me.btnExcluir.Location = New System.Drawing.Point(31, 554)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(120, 34)
        Me.btnExcluir.TabIndex = 16
        Me.btnExcluir.Text = "Excluir selecionado"
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'btnLimpar
        '
        Me.btnLimpar.BackColor = System.Drawing.Color.Black
        Me.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpar.ForeColor = System.Drawing.Color.SeaShell
        Me.btnLimpar.Location = New System.Drawing.Point(171, 554)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(120, 34)
        Me.btnLimpar.TabIndex = 17
        Me.btnLimpar.Text = "Limpar campos"
        Me.btnLimpar.UseVisualStyleBackColor = False
        '
        'dgvProdutos
        '
        Me.dgvProdutos.AllowUserToAddRows = False
        Me.dgvProdutos.AllowUserToDeleteRows = False
        Me.dgvProdutos.BackgroundColor = System.Drawing.Color.White
        Me.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdutos.Location = New System.Drawing.Point(320, 80)
        Me.dgvProdutos.MultiSelect = False
        Me.dgvProdutos.Name = "dgvProdutos"
        Me.dgvProdutos.ReadOnly = True
        Me.dgvProdutos.RowHeadersVisible = False
        Me.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProdutos.Size = New System.Drawing.Size(560, 514)
        Me.dgvProdutos.TabIndex = 15
        '
        'btnAtualizarLista
        '
        Me.btnAtualizarLista.BackColor = System.Drawing.Color.Black
        Me.btnAtualizarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAtualizarLista.ForeColor = System.Drawing.Color.SeaShell
        Me.btnAtualizarLista.Location = New System.Drawing.Point(320, 604)
        Me.btnAtualizarLista.Name = "btnAtualizarLista"
        Me.btnAtualizarLista.Size = New System.Drawing.Size(140, 34)
        Me.btnAtualizarLista.TabIndex = 18
        Me.btnAtualizarLista.Text = "Atualizar lista"
        Me.btnAtualizarLista.UseVisualStyleBackColor = False
        '
        'FormProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(908, 664)
        Me.Controls.Add(Me.btnAtualizarLista)
        Me.Controls.Add(Me.dgvProdutos)
        Me.Controls.Add(Me.picPreview)
        Me.Controls.Add(Me.lblImagemSelecionada)
        Me.Controls.Add(Me.btnEscolherImagem)
        Me.Controls.Add(Me.numEstoque)
        Me.Controls.Add(Me.lblEstoque)
        Me.Controls.Add(Me.btnLimpar)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnAtualizar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.cmbTag)
        Me.Controls.Add(Me.lblTag)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.txtPreco)
        Me.Controls.Add(Me.lblPreco)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.lblDescricao)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.lblNome)
        Me.Controls.Add(Me.lblTitulo)
        Me.Name = "FormProdutos"
        Me.Text = "High Noon — Produtos"
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblNome As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents lblDescricao As Label
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents lblPreco As Label
    Friend WithEvents txtPreco As TextBox
    Friend WithEvents lblCategoria As Label
    Friend WithEvents cmbCategoria As ComboBox
    Friend WithEvents lblTag As Label
    Friend WithEvents cmbTag As ComboBox
    Friend WithEvents lblEstoque As Label
    Friend WithEvents numEstoque As NumericUpDown
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnAtualizar As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents btnLimpar As Button
    Friend WithEvents dgvProdutos As DataGridView
    Friend WithEvents btnAtualizarLista As Button
    Friend WithEvents btnEscolherImagem As Button
    Friend WithEvents lblImagemSelecionada As Label
    Friend WithEvents picPreview As PictureBox
End Class
