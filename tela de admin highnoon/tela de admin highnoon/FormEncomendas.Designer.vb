Partial Class FormEncomendas
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
        Me.dgvEncomendas = New System.Windows.Forms.DataGridView()
        Me.btnAtualizarLista = New System.Windows.Forms.Button()
        Me.lblImagens = New System.Windows.Forms.Label()
        Me.lstImagens = New System.Windows.Forms.ListBox()
        Me.btnAbrirImagem = New System.Windows.Forms.Button()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        CType(Me.dgvEncomendas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.Snow
        Me.lblTitulo.Location = New System.Drawing.Point(24, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(280, 37)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Encomendas Personalizadas"
        '
        'dgvEncomendas
        '
        Me.dgvEncomendas.AllowUserToAddRows = False
        Me.dgvEncomendas.AllowUserToDeleteRows = False
        Me.dgvEncomendas.BackgroundColor = System.Drawing.Color.White
        Me.dgvEncomendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEncomendas.Location = New System.Drawing.Point(28, 80)
        Me.dgvEncomendas.MultiSelect = False
        Me.dgvEncomendas.Name = "dgvEncomendas"
        Me.dgvEncomendas.ReadOnly = True
        Me.dgvEncomendas.RowHeadersVisible = False
        Me.dgvEncomendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEncomendas.Size = New System.Drawing.Size(1000, 280)
        Me.dgvEncomendas.TabIndex = 1
        '
        'btnAtualizarLista
        '
        Me.btnAtualizarLista.BackColor = System.Drawing.Color.Black
        Me.btnAtualizarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAtualizarLista.ForeColor = System.Drawing.Color.SeaShell
        Me.btnAtualizarLista.Location = New System.Drawing.Point(28, 370)
        Me.btnAtualizarLista.Name = "btnAtualizarLista"
        Me.btnAtualizarLista.Size = New System.Drawing.Size(140, 30)
        Me.btnAtualizarLista.TabIndex = 2
        Me.btnAtualizarLista.Text = "Atualizar lista"
        Me.btnAtualizarLista.UseVisualStyleBackColor = False
        '
        'lblImagens
        '
        Me.lblImagens.AutoSize = True
        Me.lblImagens.ForeColor = System.Drawing.Color.Snow
        Me.lblImagens.Location = New System.Drawing.Point(28, 420)
        Me.lblImagens.Name = "lblImagens"
        Me.lblImagens.Size = New System.Drawing.Size(150, 13)
        Me.lblImagens.TabIndex = 3
        Me.lblImagens.Text = "Imagens de referência"
        '
        'lstImagens
        '
        Me.lstImagens.FormattingEnabled = True
        Me.lstImagens.Location = New System.Drawing.Point(28, 440)
        Me.lstImagens.Name = "lstImagens"
        Me.lstImagens.Size = New System.Drawing.Size(560, 95)
        Me.lstImagens.TabIndex = 4
        '
        'btnAbrirImagem
        '
        Me.btnAbrirImagem.BackColor = System.Drawing.Color.Black
        Me.btnAbrirImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrirImagem.ForeColor = System.Drawing.Color.SeaShell
        Me.btnAbrirImagem.Location = New System.Drawing.Point(28, 542)
        Me.btnAbrirImagem.Name = "btnAbrirImagem"
        Me.btnAbrirImagem.Size = New System.Drawing.Size(200, 30)
        Me.btnAbrirImagem.TabIndex = 5
        Me.btnAbrirImagem.Text = "Abrir imagem selecionada"
        Me.btnAbrirImagem.UseVisualStyleBackColor = False
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.ForeColor = System.Drawing.Color.Snow
        Me.lblValor.Location = New System.Drawing.Point(620, 420)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(120, 13)
        Me.lblValor.TabIndex = 6
        Me.lblValor.Text = "Valor do orçamento"
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(623, 440)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(180, 20)
        Me.txtValor.TabIndex = 7
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Snow
        Me.lblStatus.Location = New System.Drawing.Point(620, 475)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 8
        Me.lblStatus.Text = "Status"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"pendente", "em_analise", "orcamento_enviado", "aprovado", "em_producao", "concluido", "recusado"})
        Me.cmbStatus.Location = New System.Drawing.Point(623, 493)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(180, 21)
        Me.cmbStatus.TabIndex = 9
        '
        'btnSalvar
        '
        Me.btnSalvar.BackColor = System.Drawing.Color.Black
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.ForeColor = System.Drawing.Color.SeaShell
        Me.btnSalvar.Location = New System.Drawing.Point(623, 542)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(180, 30)
        Me.btnSalvar.TabIndex = 10
        Me.btnSalvar.Text = "Salvar orçamento/status"
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'FormEncomendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1056, 610)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.lblValor)
        Me.Controls.Add(Me.btnAbrirImagem)
        Me.Controls.Add(Me.lstImagens)
        Me.Controls.Add(Me.lblImagens)
        Me.Controls.Add(Me.btnAtualizarLista)
        Me.Controls.Add(Me.dgvEncomendas)
        Me.Controls.Add(Me.lblTitulo)
        Me.Name = "FormEncomendas"
        Me.Text = "High Noon — Encomendas Personalizadas"
        CType(Me.dgvEncomendas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents dgvEncomendas As DataGridView
    Friend WithEvents btnAtualizarLista As Button
    Friend WithEvents lblImagens As Label
    Friend WithEvents lstImagens As ListBox
    Friend WithEvents btnAbrirImagem As Button
    Friend WithEvents lblValor As Label
    Friend WithEvents txtValor As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents btnSalvar As Button
End Class
