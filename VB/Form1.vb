Imports System.Text
Imports System.Diagnostics
Imports System.Globalization
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
' ...

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' A path to export a report.
        Dim reportPath As String = "c:\\Test.csv"

        ' Create a report instance.
        Dim report As New XtraReport1()

        ' Get its CSV export options.
        Dim csvOptions As CsvExportOptions = report.ExportOptions.Csv

        ' Set CSV-specific export options.
        csvOptions.Encoding = Encoding.Unicode
        csvOptions.Separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator.ToString()

        ' Export the report to CSV.
        report.ExportToCsv(reportPath)

        ' Show the result.
        StartProcess(reportPath)
    End Sub

    ' Use this method if you want to automaically open
    ' the created CSV file in the default program.
    Public Sub StartProcess(ByVal path As String)
        Dim process As New Process()
        Try
            process.StartInfo.FileName = path
            process.Start()
            process.WaitForInputIdle()
        Catch
        End Try
    End Sub
End Class
