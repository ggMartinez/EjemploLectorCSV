Public Class Form1
    Private Sub btnExplorar_Click(sender As Object, e As EventArgs) Handles btnExplorar.Click
        OpenFileDialog1.ShowDialog()
        txtRuta.Text = OpenFileDialog1.FileName

    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If txtRuta.Text = "" Then
            MsgBox("Por favor, seleccione un archivo", MsgBoxStyle.Critical, "Error")
        Else


            Using archivo As New Microsoft.VisualBasic.
                      FileIO.TextFieldParser(
                        txtRuta.Text)

                archivo.TextFieldType = FileIO.FieldType.Delimited
                archivo.SetDelimiters(",")
                Dim currentRow As String()
                While Not archivo.EndOfData
                    Try
                        currentRow = archivo.ReadFields()
                        Dim linea As String() = currentRow.ToArray()
                        MsgBox(
                                   "Nombre: " + linea(1) +
                                   Environment.NewLine +
                                   "Apellido: " + linea(2) +
                                   Environment.NewLine +
                                   "Email: " + linea(3) +
                                   Environment.NewLine +
                                   "Sexo: " + linea(4)
                               )
                    Catch ex As Microsoft.VisualBasic.
                                FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message &
                        "is not valid and will be skipped.")
                    End Try
                End While
            End Using
        End If

    End Sub
End Class
