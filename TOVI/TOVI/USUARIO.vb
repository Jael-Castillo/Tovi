Public Class USUARIO


    Private Sub USUARIO_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Val(TextBox1.Text = "ADMINISTRADOR" And TextBox2.Text = "3498VJRN") Then
            MsgBox("¡BIENVENIDO!")
            TIPOS.Show()
            Me.Hide()
        ElseIf Val(TextBox1.Text = "INVITADO" And TextBox2.Text = "1937COYUCA1943") Then
            MsgBox("¡BIENVENIDO!")
            TIPOS.Show()
            Me.Hide()

        Else
            MsgBox("VUELVA A INTENTARLO")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub


End Class