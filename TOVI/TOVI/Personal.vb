Imports System.Data.OleDb
Public Class Personal
    Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & _
    Application.StartupPath + "\Pisos.mdb")

    Private Sub Personal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    Private Sub Personal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            comando = New OleDbCommand("INSERT INTO Personal(Nombre, Direccion, Banco, Cuenta, Numero_imss, Telefono, Curp)" & Chr(13) &
                                        "Values(TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7)", conn)

            comando.Parameters.AddWithValue("@Nombre", TextBox1.Text)
            comando.Parameters.AddWithValue("@Direccion", TextBox2.Text)
            comando.Parameters.AddWithValue("@Banco", TextBox3.Text)
            comando.Parameters.AddWithValue("@Cuenta", TextBox4.Text)
            comando.Parameters.AddWithValue("@Numero_imss", TextBox5.Text)
            comando.Parameters.AddWithValue("@Telefono", TextBox6.Text)
            comando.Parameters.AddWithValue("@Curp", TextBox7.Text)
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
            consul = "SELECT * FROM Personal WHERE Nombre='" & TextBox1.Text & "'"
            adaptador1 = New OleDbDataAdapter(consul, conn)
            registro1 = New DataSet
            adaptador1.Fill(registro1, "Personal")
            lista = registro1.Tables("Personal").Rows.Count
            If lista <> 0 Then
                Dim eliminar As String
                Dim si As Byte
                si = MsgBox("¿ESTÁ SEGURO DE ELIMINAR EL REGISTRO?", vbYesNo, "ADVERTENCIA")
                If si = vbYes Then
                    eliminar = "DELETE FROM Personal WHERE Nombre = '" & TextBox1.Text & " ' "
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

        buscar = "SELECT * FROM Personal"
        adaptador = New OleDbDataAdapter(buscar, conn)
        registro = New DataSet
        adaptador.Fill(registro, "Personal")
        DataGridView1.DataSource = registro
        DataGridView1.DataMember = "Personal"
    End Sub

    Dim registro3 As New DataSet
    Dim dt As New OleDbDataAdapter
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button5.Visible = True
        Button4.Visible = False
        MsgBox("INGRESA LOS NUEVOS DATOS")
        TextBox4.Enabled = False
        TextBox8.Visible = True
        Button8.Visible = True


        conn.Open()

        Dim own As String
        own = "SELECT * FROM Personal WHERE Cuenta = '" & TextBox4.Text & "'"
        dt = New OleDbDataAdapter(own, conn)
        registro3 = New DataSet
        dt.Fill(registro3, "Personal")
        For Each cuenta As DataRow In registro3.Tables("Personal").Rows
            TextBox1.Text = cuenta.Item("Nombre")
            TextBox2.Text = cuenta.Item("Direccion")
            TextBox3.Text = cuenta.Item("Banco")
            TextBox5.Text = cuenta.Item("Numero_imss")
            TextBox6.Text = cuenta.Item("Telefono")
            TextBox7.Text = cuenta.Item("Curp")
            TextBox8.Clear()
        Next

        conn.Close()



    End Sub

    Dim registro2 As New DataSet
    Dim adaptador As New OleDbDataAdapter
    Dim comi As New OleDbCommand
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        conn.Open()
        If TextBox4.Text = "" Then
            MsgBox("INGRESA NÚMERO DE CUENTA")
        Else

            Button5.Visible = False
            Button4.Visible = True
            TextBox4.Enabled = True
            TextBox8.Visible = False
            Button8.Visible = False


            Dim Consul As String
            Dim lista As Byte


            Consul = "SELECT * FROM Personal WHERE Cuenta='" & TextBox4.Text & "'"
            adaptador = New OleDbDataAdapter(Consul, conn)
            registro2 = New DataSet
            adaptador.Fill(registro2, "Personal")
            lista = registro2.Tables("Personal").Rows.Count
            If lista <> 0 Then
                Dim modificar As String
                modificar = "UPDATE Personal SET Nombre= '" & TextBox1.Text &
                    "', Direccion = '" & TextBox2.Text &
                    "', Banco = '" & TextBox3.Text &
                    "', Numero_imss = '" & TextBox5.Text &
                    "', Telefono = '" & TextBox6.Text &
                    "', Curp = '" & TextBox7.Text &
                    "', Cuenta = '" & TextBox8.Text &
                    "' WHERE Cuenta='" & TextBox4.Text & "'"
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
        TextBox7.Clear()

        TextBox1.Focus()

        Button5.Visible = False
        Button4.Visible = True
        TextBox4.Enabled = True
        TextBox8.Visible = False
        Button8.Visible = False

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ACCESOS.Show()
        Me.Hide()
    End Sub
End Class