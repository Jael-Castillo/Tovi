Public Class EMP

  
    Private Sub EMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Timer1.Enabled = True
        Timer1.Interval = 5000
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        Me.Hide()
        USUARIO.Show()

        Timer1.Enabled = False

    End Sub
End Class