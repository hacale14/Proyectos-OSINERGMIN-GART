Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class Torta
    Public Sub Render(ByVal chartData As DataSet, ByVal target As Stream)
        Dim dt As DataTable = chartData.Tables(0)
        'Se crea un nuevo grafico y se configura
        Dim bm As Bitmap = New Bitmap(400, 400)
        Dim g As Graphics = Graphics.FromImage(bm)
        Call g.Clear(Color.White) 'Pongo el fondo el blanco
        Call g.DrawString("Texto", New Font("arial", 20), Brushes.Black, 5, 3) 'Aquí pueden ingresar un texto que quieran

        Dim curAngle As Single = 0
        Dim totalAngle As Single = 0
        Dim i As Integer = 0
        Dim sumData As Single = 0
        Dim dr As DataRow
        For Each dr In dt.Rows
            sumData += Convert.ToSingle(dr(1))
        Next dr
        For i = 0 To dt.Rows.Count - 1
            curAngle = Convert.ToSingle(dt.Rows(i)(1)) / sumData * 360
            Call g.FillPie(New SolidBrush(ColorIm(i)), 100, 65, 200, 200, totalAngle, curAngle)
            Call g.DrawPie(Pens.Black, 100, 65, 200, 200, totalAngle, curAngle)
            totalAngle += curAngle
        Next i

        Dim rectY As Integer = 300
        Dim textY As Integer = 300
        Dim percent As Single = 0
        For i = 0 To dt.Rows.Count - 1
            g.FillRectangle(New SolidBrush(ColorIm(i)), 100, rectY, 20, 10)
            percent = Convert.ToSingle(dt.Rows(i)(1)) / sumData * 100
            g.DrawString(dt.Rows(i)(0).ToString() + " (" + percent.ToString("0") + "%)", New Font("Tahoma", 10), Brushes.Black, 130, textY)
            rectY = rectY + 20
            textY = textY + 20
        Next i

        bm.Save(target, ImageFormat.Gif)
        g.Dispose()
        bm.Dispose()
    End Sub


    Private Function ColorIm(ByVal itemIndex As Integer) As Color
        ' Esta función devuelve un color distinto para cada dato. Agregar mas 'cases' si se lo necesita.
        Dim NuevoColor As Color
        Select Case itemIndex
            Case 0
                NuevoColor = Color.Blue
            Case 1
                NuevoColor = Color.Green
            Case 2
                NuevoColor = Color.Red
            Case 3
                NuevoColor = Color.Yellow
        End Select
        Return NuevoColor
    End Function
End Class
