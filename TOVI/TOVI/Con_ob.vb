Imports System.Data.OleDb
Public Class Con_ob
    Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & _
   Application.StartupPath + "\Pisos.mdb")

    Private Sub Con_ob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    Private Sub Con_ob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            MsgBox("Conectado", vbInformation, "Correcto")

        Catch ex As Exception
            MsgBox("Error al conectar", vbInformation, "Sin conexion")

        End Try
        conn.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim buscar As String
        Dim adaptador As New OleDbDataAdapter
        Dim registro As New DataSet

        buscar = "SELECT * FROM Obras"
        adaptador = New OleDbDataAdapter(buscar, conn)
        registro = New DataSet
        adaptador.Fill(registro, "Obras")
        DataGridView1.DataSource = registro
        DataGridView1.DataMember = "Obras"
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        INVITADO.Show()
        Me.Hide()
    End Sub
End Class