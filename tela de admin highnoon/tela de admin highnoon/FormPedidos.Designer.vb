Partial Class FormPedidos
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
        Me.dgvPedidos = New System.Windows.Forms.DataGridView()
        Me.btnAtualizarLista = New System.Windows.Forms.Button()
        Me.lblItens = New System.Windows.Forms.Label()
        Me.dgvItens = New System.Windows.Forms.DataGridView()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.btnSalvarStatus = New System.Windows.Forms.Button()
        CType(Me.dgvPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitulo.Text = "Pedidos"
        '
        'dgvPedidos
        '
        Me.dgvPedidos.AllowUserToAddRows = False
        Me.dgvPedidos.AllowUserToDeleteRows = False
        Me.dgvPedidos.BackgroundColor = System.Drawing.Color.White
        Me.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPedidos.Location = New System.Drawing.Point(28, 80)
        Me.dgvPedidos.MultiSelect = False
        Me.dgvPedidos.Name = "dgvPedidos"
        Me.dgvPedidos.ReadOnly = True
        Me.dgvPedidos.RowHeadersVisible = False
        Me.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPedidos.Size = New System.Drawing.Size(860, 280)
        Me.dgvPedidos.TabIndex = 1
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
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Snow
        Me.lblStatus.Location = New System.Drawing.Point(190, 377)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Status"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"pendente", "enviado", "entregue", "cancelado"})
        Me.cmbStatus.Location = New System.Drawing.Point(240, 373)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(140, 21)
        Me.cmbStatus.TabIndex = 4
        '
        'btnSalvarStatus
        '
        Me.btnSalvarStatus.BackColor = System.Drawing.Color.Black
        Me.btnSalvarStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvarStatus.ForeColor = System.Drawing.Color.SeaShell
        Me.btnSalvarStatus.Location = New System.Drawing.Point(390, 371)
        Me.btnSalvarStatus.Name = "btnSalvarStatus"
        Me.btnSalvarStatus.Size = New System.Drawing.Size(150, 26)
        Me.btnSalvarStatus.TabIndex = 5
        Me.btnSalvarStatus.Text = "Salvar status do pedido"
        Me.btnSalvarStatus.UseVisualStyleBackColor = False
        '
        'lblItens
        '
        Me.lblItens.AutoSize = True
        Me.lblItens.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblItens.ForeColor = System.Drawing.Color.Snow
        Me.lblItens.Location = New System.Drawing.Point(28, 415)
        Me.lblItens.Name = "lblItens"
        Me.lblItens.Size = New System.Drawing.Size(220, 21)
        Me.lblItens.TabIndex = 6
        Me.lblItens.Text = "Itens do pedido selecionado"
        '
        'dgvItens
        '
        Me.dgvItens.AllowUserToAddRows = False
        Me.dgvItens.AllowUserToDeleteRows = False
        Me.dgvItens.BackgroundColor = System.Drawing.Color.White
        Me.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItens.Location = New System.Drawing.Point(28, 445)
        Me.dgvItens.Name = "dgvItens"
        Me.dgvItens.ReadOnly = True
        Me.dgvItens.RowHeadersVisible = False
        Me.dgvItens.Size = New System.Drawing.Size(860, 180)
        Me.dgvItens.TabIndex = 7
        '
        'FormPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(916, 650)
        Me.Controls.Add(Me.dgvItens)
        Me.Controls.Add(Me.lblItens)
        Me.Controls.Add(Me.btnSalvarStatus)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnAtualizarLista)
        Me.Controls.Add(Me.dgvPedidos)
        Me.Controls.Add(Me.lblTitulo)
        Me.Name = "FormPedidos"
        Me.Text = "High Noon — Pedidos"
        CType(Me.dgvPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents dgvPedidos As DataGridView
    Friend WithEvents btnAtualizarLista As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents btnSalvarStatus As Button
    Friend WithEvents lblItens As Label
    Friend WithEvents dgvItens As DataGridView
End Class
