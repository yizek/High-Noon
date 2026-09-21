Partial Class FormPromocoes
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
        Me.lblAjuda = New System.Windows.Forms.Label()
        Me.dgvProdutos = New System.Windows.Forms.DataGridView()
        Me.btnMarcarPromocao = New System.Windows.Forms.Button()
        Me.btnMarcarNovo = New System.Windows.Forms.Button()
        Me.btnRemoverEtiqueta = New System.Windows.Forms.Button()
        Me.btnAtualizarLista = New System.Windows.Forms.Button()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.Snow
        Me.lblTitulo.Location = New System.Drawing.Point(24, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(220, 37)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Promoções"
        '
        'lblAjuda
        '
        Me.lblAjuda.AutoSize = True
        Me.lblAjuda.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblAjuda.Location = New System.Drawing.Point(28, 64)
        Me.lblAjuda.Name = "lblAjuda"
        Me.lblAjuda.Size = New System.Drawing.Size(330, 13)
        Me.lblAjuda.TabIndex = 1
        Me.lblAjuda.Text = "Selecione um produto na tabela e escolha a etiqueta dele."
        '
        'dgvProdutos
        '
        Me.dgvProdutos.AllowUserToAddRows = False
        Me.dgvProdutos.AllowUserToDeleteRows = False
        Me.dgvProdutos.BackgroundColor = System.Drawing.Color.White
        Me.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdutos.Location = New System.Drawing.Point(31, 90)
        Me.dgvProdutos.MultiSelect = False
        Me.dgvProdutos.Name = "dgvProdutos"
        Me.dgvProdutos.ReadOnly = True
        Me.dgvProdutos.RowHeadersVisible = False
        Me.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProdutos.Size = New System.Drawing.Size(700, 360)
        Me.dgvProdutos.TabIndex = 2
        '
        'btnMarcarPromocao
        '
        Me.btnMarcarPromocao.BackColor = System.Drawing.Color.Black
        Me.btnMarcarPromocao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarcarPromocao.ForeColor = System.Drawing.Color.SeaShell
        Me.btnMarcarPromocao.Location = New System.Drawing.Point(31, 465)
        Me.btnMarcarPromocao.Name = "btnMarcarPromocao"
        Me.btnMarcarPromocao.Size = New System.Drawing.Size(160, 34)
        Me.btnMarcarPromocao.TabIndex = 3
        Me.btnMarcarPromocao.Text = "Marcar como Promoção"
        Me.btnMarcarPromocao.UseVisualStyleBackColor = False
        '
        'btnMarcarNovo
        '
        Me.btnMarcarNovo.BackColor = System.Drawing.Color.Black
        Me.btnMarcarNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarcarNovo.ForeColor = System.Drawing.Color.SeaShell
        Me.btnMarcarNovo.Location = New System.Drawing.Point(201, 465)
        Me.btnMarcarNovo.Name = "btnMarcarNovo"
        Me.btnMarcarNovo.Size = New System.Drawing.Size(120, 34)
        Me.btnMarcarNovo.TabIndex = 4
        Me.btnMarcarNovo.Text = "Marcar como Novo"
        Me.btnMarcarNovo.UseVisualStyleBackColor = False
        '
        'btnRemoverEtiqueta
        '
        Me.btnRemoverEtiqueta.BackColor = System.Drawing.Color.Black
        Me.btnRemoverEtiqueta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoverEtiqueta.ForeColor = System.Drawing.Color.SeaShell
        Me.btnRemoverEtiqueta.Location = New System.Drawing.Point(331, 465)
        Me.btnRemoverEtiqueta.Name = "btnRemoverEtiqueta"
        Me.btnRemoverEtiqueta.Size = New System.Drawing.Size(140, 34)
        Me.btnRemoverEtiqueta.TabIndex = 5
        Me.btnRemoverEtiqueta.Text = "Remover etiqueta"
        Me.btnRemoverEtiqueta.UseVisualStyleBackColor = False
        '
        'btnAtualizarLista
        '
        Me.btnAtualizarLista.BackColor = System.Drawing.Color.Black
        Me.btnAtualizarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAtualizarLista.ForeColor = System.Drawing.Color.SeaShell
        Me.btnAtualizarLista.Location = New System.Drawing.Point(571, 465)
        Me.btnAtualizarLista.Name = "btnAtualizarLista"
        Me.btnAtualizarLista.Size = New System.Drawing.Size(160, 34)
        Me.btnAtualizarLista.TabIndex = 6
        Me.btnAtualizarLista.Text = "Atualizar lista"
        Me.btnAtualizarLista.UseVisualStyleBackColor = False
        '
        'FormPromocoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(760, 530)
        Me.Controls.Add(Me.btnAtualizarLista)
        Me.Controls.Add(Me.btnRemoverEtiqueta)
        Me.Controls.Add(Me.btnMarcarNovo)
        Me.Controls.Add(Me.btnMarcarPromocao)
        Me.Controls.Add(Me.dgvProdutos)
        Me.Controls.Add(Me.lblAjuda)
        Me.Controls.Add(Me.lblTitulo)
        Me.Name = "FormPromocoes"
        Me.Text = "High Noon — Promoções"
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblAjuda As Label
    Friend WithEvents dgvProdutos As DataGridView
    Friend WithEvents btnMarcarPromocao As Button
    Friend WithEvents btnMarcarNovo As Button
    Friend WithEvents btnRemoverEtiqueta As Button
    Friend WithEvents btnAtualizarLista As Button
End Class
