Public Class Form1
    Private Sub UtilizadoresBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles UsersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.UsersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DatabaseDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'UsersDataSet.Utilizadores' table. You can move, or remove it, as needed.
        Me.UsersTableAdapter.Fill(Me.DatabaseDataSet.Users)
        BindingNavigatorAddNewItem.Enabled = True
        BindingNavigatorDeleteItem.Enabled = True

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click

        Me.Validate()
        Me.UsersBindingSource.EndEdit()

        UsersTableAdapter.Insert(CDec(IDTextBox.Text), UsernameTextBox.Text,
        PasswordTextBox.Text, NomeTextBox.Text, apelidoTextBox.Text)

        Me.UsersTableAdapter.Fill(Me.DatabaseDataSet.Users)


    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click

        Me.Validate()
        Me.UsersBindingSource.EndEdit()

        UsersTableAdapter.Delete(CDec(IDTextBox.Text), UsernameTextBox.Text,
        PasswordTextBox.Text, NomeTextBox.Text, apelidoTextBox.Text)

        Me.UsersTableAdapter.Fill(Me.DatabaseDataSet.Users)


    End Sub
End Class