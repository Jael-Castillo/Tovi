Imports System.Data.OleDb
Public Class Obras
    Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & _
   Application.StartupPath + "\Pisos.mdb")

    Private Sub Obras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    Private Sub Obras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            MsgBox("Conectado", vbInformation, "Correcto")

        Catch ex As Exception
            MsgBox("Error al conectar", vbInformation, "Sin conexion")

        End Try
        conn.Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim comando As New OleDbCommand
        conn.Open()
        Try
            comando = New OleDbCommand("INSERT INTO Obras(Num_obra, Nom_obra, Ubicacion, Inicio, Fin, Monto)" & Chr(13) &
                                        "Values(TextBox1, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7)", conn)

            comando.Parameters.AddWithValue("@Num_obra", TextBox1.Text)
            comando.Parameters.AddWithValue("@Nom_obra", TextBox3.Text)
            comando.Parameters.AddWithValue("@Ubicacion", TextBox4.Text)
            comando.Parameters.AddWithValue("@Inicio", TextBox5.Text)
            comando.Parameters.AddWithValue("@Fin", TextBox6.Text)
            comando.Parameters.AddWithValue("@Monto", TextBox7.Text)
            comando.ExecuteNonQuery()
            MsgBox("OK", vbInformation, "Correcto")

        Catch ex As Exception
            MsgBox("Error", vbInformation, "Sin conexion")
        End Try
        conn.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox1.Focus()
    End Sub

    Dim omi As OleDbCommand
    Dim adaptador1 As New OleDbDataAdapter
    Dim registro1 As New DataSet
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conn.Open()
        Dim consul As String
        Dim lista As Byte
        If TextBox1.Text = "" Then
            MsgBox("INGRESE REGISTRO PARA PODER ELIMINAR")
        ElseIf TextBox1.Text <> "" Then
            consul = "SELECT * FROM Obras WHERE Num_obra='" & TextBox1.Text & "'"
            adaptador1 = New OleDbDataAdapter(consul, conn)
            registro1 = New DataSet
            adaptador1.Fill(registro1, "Obras")
            lista = registro1.Tables("Obras").Rows.Count
            If lista <> 0 Then
                Dim eliminar As String
                Dim si As Byte
                si = MsgBox("¿ESTÁ SEGURO DE ELIMINAR EL REGISTRO?", vbYesNo, "ADVERTENCIA")
                If si = vbYes Then
                    eliminar = "DELETE FROM Obras WHERE Num_obra = '" & TextBox1.Text & " ' "
                    omi = New OleDbCommand(eliminar, conn)
                    omi.ExecuteNonQuery()
                    DataGridView1.Update()
                Else
                End If
            Else
                MsgBox("EL NOMBRE QUE DESEA ELIMINAR, NO EXISTE, FAVOR DE VERIFICARLO")
            End If
        End If
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

    Dim registro3 As New DataSet
    Dim dt As New OleDbDataAdapter
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button5.Visible = True
        Button4.Visible = False
        MsgBox("INGRESA LOS NUEVOS DATOS")
        TextBox1.Enabled = False
        TextBox2.Visible = True
        Button8.Visible = True


        conn.Open()

        Dim own As String
        own = "SELECT * FROM Obras WHERE Num_obra = '" & TextBox1.Text & "'"
        dt = New OleDbDataAdapter(own, conn)
        registro3 = New DataSet
        dt.Fill(registro3, "Obras")
        For Each cuenta As DataRow In registro3.Tables("Obras").Rows
            TextBox3.Text = cuenta.Item("Nom_obra")
            TextBox4.Text = cuenta.Item("Ubicacion")
            TextBox5.Text = cuenta.Item("Inicio")
            TextBox6.Text = cuenta.Item("Fin")
            TextBox7.Text = cuenta.Item("Monto")
            TextBox2.Clear()
        Next

        conn.Close()



    End Sub

    Dim registro2 As New DataSet
    Dim adaptador As New OleDbDataAdapter
    Dim comi As New OleDbCommand
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        conn.Open()
        If TextBox1.Text = "" Then
            MsgBox("INGRESA NÚMERO DE OBRA")
        Else

            Button5.Visible = False
            Button4.Visible = True
            TextBox1.Enabled = True
            TextBox2.Visible = False
            Button8.Visible = False


            Dim Consul As String
            Dim lista As Byte


            Consul = "SELECT * FROM Obras WHERE Num_obra ='" & TextBox6.Text & "'"
            adaptador = New OleDbDataAdapter(Consul, conn)
            registro2 = New DataSet
            adaptador.Fill(registro2, "Obras")
            lista = registro2.Tables("Obras").Rows.Count
            If lista <> 0 Then
                Dim modificar As String
                modificar = "UPDATE Obras SET Num_obra= '" & TextBox1.Text &
                    "', Nom_obra = '" & TextBox3.Text &
                    "', Ubicacion = '" & TextBox4.Text &
                    "', Inicio = '" & TextBox5.Text &
                    "', Fin = '" & TextBox6.Text &
                    "', Monto = '" & TextBox7.Text &
                    "' WHERE Num_obra='" & TextBox2.Text & "'"
                comi = New OleDbCommand(modificar, conn)
                comi.ExecuteNonQuery()

            Else
                MsgBox("NO HAY REGISTRO EXISTENTE")
            End If

        End If
        conn.Close()

    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()

        TextBox1.Focus()

        Button5.Visible = False
        Button4.Visible = True
        TextBox1.Enabled = True
        TextBox2.Visible = False
        Button8.Visible = False

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ACCESOS.Show()
        Me.Hide()
    End Sub
End Class