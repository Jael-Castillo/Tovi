Public Class TIPOS
    Private Sub TIPOS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If USUARIO.TextBox1.Text = "ADMINISTRADOR" And USUARIO.TextBox2.Text = "3498VJRN" Then
            ACCESOS.Show()
            Me.Hide()

        Else
            MsgBox("NO PUEDES ACCEDER")

        End If


    End Sub

    Private Sub TIPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If USUARIO.TextBox1.Text = "ADMINISTRADOR" And USUARIO.TextBox2.Text = "3498VJRN" Then
            Button1.Enabled = True
            Button2.Enabled = False
        ElseIf USUARIO.TextBox1.Text = "INVITADO" And USUARIO.TextBox2.Text = "1937COYUCA1943" Then
            Button2.Enabled = True
            Button1.Enabled = False
        End If
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If USUARIO.TextBox1.Text = "INVITADO" And USUARIO.TextBox2.Text = "1937COYUCA1943" Then
            INVITADO.Show()
            Me.Hide()
        Else
            MsgBox("NO PUEDES ACCEDER")
        End If

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        End
    End Sub
End Class