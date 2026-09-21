<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnPedidos = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 48.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Snow
        Me.Label1.Location = New System.Drawing.Point(25, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(350, 85)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "High Noon"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Snow
        Me.Label2.Location = New System.Drawing.Point(354, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tela de administrador"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.SeaShell
        Me.Button1.Location = New System.Drawing.Point(40, 123)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(187, 41)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "+ PRODUTOS"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.SeaShell
        Me.Button2.Location = New System.Drawing.Point(40, 182)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(187, 41)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "+ PROMOÇÕES"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Black
        Me.Button3.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.SeaShell
        Me.Button3.Location = New System.Drawing.Point(40, 360)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(187, 41)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "GERAL"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Snow
        Me.Label3.Location = New System.Drawing.Point(590, 341)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(297, 100)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Página exclusiva para funcionários" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "administrativos da High Noon," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dedicada para " &
    "gerenciar itens," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "promoções e atualizações gerais no" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "catálogo do site."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.tela_de_admin_highnoon.My.Resources.Resources.ChatGPT_Image_8_de_set4
        Me.PictureBox1.Location = New System.Drawing.Point(594, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(291, 243)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'btnPedidos
        '
        Me.btnPedidos.BackColor = System.Drawing.Color.Black
        Me.btnPedidos.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPedidos.ForeColor = System.Drawing.Color.SeaShell
        Me.btnPedidos.Location = New System.Drawing.Point(40, 242)
        Me.btnPedidos.Name = "btnPedidos"
        Me.btnPedidos.Size = New System.Drawing.Size(187, 41)
        Me.btnPedidos.TabIndex = 7
        Me.btnPedidos.Text = "PEDIDOS"
        Me.btnPedidos.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Black
        Me.Button4.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.SeaShell
        Me.Button4.Location = New System.Drawing.Point(40, 301)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(187, 41)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "ENCOMENDAS"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(897, 450)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.btnPedidos)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "PÁGINA DE ADM HIGH NOON"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnPedidos As Button
    Friend WithEvents Button4 As Button
End Class
