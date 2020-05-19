Imports System.Data.OleDb

Public Class Form3

    Dim provider As String
    Dim ficheiro As String
    Dim connString As String
    Dim ligacao As OleDbConnection = New OleDbConnection

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click

        provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb "
        ficheiro = "C\Users\Paulo\Documents\preis\Escola\Aulas\2017/2018\PSI\M18\Users.accdb"
        connString = provider & ficheiro

        ligacao.ConnectionString = connString

        ligacao.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM Utilizadores WHERE username = '" & txtLogin.Text & "' AND password = '" & txtSenha.Text & "'", ligacao)

Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim encontrou As Boolean = False

        Dim strNome As String = ""
        Dim strApelido As String = ""

        While dr.Read
            encontrou = True
            strNome = dr("nome").ToString
            strApelido = dr("apelido").ToString
        End While

        ligacao.Close()

        If encontrou = True Then

            Me.Close()
            Form1.Show()

            Form2.Label1.Text = "Bem vindo(a) " & strNome & " " & strApelido
        Else
            Dim msg As String = "Não encontrado." & vbNewLine & "Utilizador ou senha incorretos."
            Dim titulo As String = "Aviso!"
            Dim botoes = MessageBoxButtons.OK
            Dim icone = MessageBoxIcon.Exclamation
            MessageBox.Show(msg, titulo, botoes, icone)
        End If

    End Sub

End Class