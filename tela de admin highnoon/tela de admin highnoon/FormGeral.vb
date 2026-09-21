Public Class FormGeral

    Public Sub New()
        InitializeComponent()
    End Sub

    Private explorer As New BancoDeDadosExplorer()

    Private Sub FormGeral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbTabelas.Items.Clear()
        cmbTabelas.Items.AddRange(explorer.ListarTabelas().ToArray())

        If cmbTabelas.Items.Count > 0 Then
            cmbTabelas.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        If cmbTabelas.SelectedItem Is Nothing Then
            MessageBox.Show("Escolha uma tabela.")
            Return
        End If

        Dim tabelaEscolhida As String = cmbTabelas.SelectedItem.ToString()
        dgvDados.DataSource = explorer.AbrirTabela(tabelaEscolhida)
    End Sub

End Class
