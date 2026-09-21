Partial Class FormGeral
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
        Me.lblTabela = New System.Windows.Forms.Label()
        Me.cmbTabelas = New System.Windows.Forms.ComboBox()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.dgvDados = New System.Windows.Forms.DataGridView()
        CType(Me.dgvDados, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitulo.Text = "Banco de Dados — Geral"
        '
        'lblTabela
        '
        Me.lblTabela.AutoSize = True
        Me.lblTabela.ForeColor = System.Drawing.Color.Snow
        Me.lblTabela.Location = New System.Drawing.Point(28, 74)
        Me.lblTabela.Name = "lblTabela"
        Me.lblTabela.Size = New System.Drawing.Size(45, 13)
        Me.lblTabela.TabIndex = 1
        Me.lblTabela.Text = "Tabela"
        '
        'cmbTabelas
        '
        Me.cmbTabelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTabelas.FormattingEnabled = True
        Me.cmbTabelas.Location = New System.Drawing.Point(31, 92)
        Me.cmbTabelas.Name = "cmbTabelas"
        Me.cmbTabelas.Size = New System.Drawing.Size(260, 21)
        Me.cmbTabelas.TabIndex = 2
        '
        'btnAbrir
        '
        Me.btnAbrir.BackColor = System.Drawing.Color.Black
        Me.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrir.ForeColor = System.Drawing.Color.SeaShell
        Me.btnAbrir.Location = New System.Drawing.Point(300, 90)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(120, 25)
        Me.btnAbrir.TabIndex = 3
        Me.btnAbrir.Text = "Abrir tabela"
        Me.btnAbrir.UseVisualStyleBackColor = False
        '
        'dgvDados
        '
        Me.dgvDados.AllowUserToAddRows = False
        Me.dgvDados.AllowUserToDeleteRows = False
        Me.dgvDados.BackgroundColor = System.Drawing.Color.White
        Me.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDados.Location = New System.Drawing.Point(31, 130)
        Me.dgvDados.Name = "dgvDados"
        Me.dgvDados.ReadOnly = True
        Me.dgvDados.RowHeadersVisible = False
        Me.dgvDados.Size = New System.Drawing.Size(860, 420)
        Me.dgvDados.TabIndex = 4
        '
        'FormGeral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(920, 580)
        Me.Controls.Add(Me.dgvDados)
        Me.Controls.Add(Me.btnAbrir)
        Me.Controls.Add(Me.cmbTabelas)
        Me.Controls.Add(Me.lblTabela)
        Me.Controls.Add(Me.lblTitulo)
        Me.Name = "FormGeral"
        Me.Text = "High Noon — Banco de Dados"
        CType(Me.dgvDados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblTabela As Label
    Friend WithEvents cmbTabelas As ComboBox
    Friend WithEvents btnAbrir As Button
    Friend WithEvents dgvDados As DataGridView
End Class
