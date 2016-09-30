Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FormStrukPrint
    Public subtotal, diskon, kembali As String

    Private Sub FormStrukPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim cryrpt As New ReportDocument
        'cryrpt.Load("..\..\Transaksi\PrintNota\PrintNota.Rpt")

        'Dim crparameterdefinitions As ParameterFieldDefinitions
        'Dim crparameterdefinition As ParameterFieldDefinition
        'Dim cparametervalues As New ParameterValues()

        'Dim parameterdiscreatevalue As New ParameterDiscreteValue()
        'parameterdiscreatevalue.Value = NewLaundry.kodeTrans
        'parameterdiscreatevalue.Value = subtotal
        'parameterdiscreatevalue.Value = diskon
        'parameterdiscreatevalue.Value = kembali

        'crparameterdefinitions = cryrpt.DataDefinition.ParameterFields
        'crparameterdefinition = crparameterdefinitions("paramkode")
        'crparameterdefinition = crparameterdefinitions("subtotal")
        'crparameterdefinition = crparameterdefinitions("diskon")
        'crparameterdefinition = crparameterdefinitions("kembali")

        'cparametervalues = crparameterdefinition.CurrentValues
        'cparametervalues.Clear()
        'cparametervalues.Add(parameterdiscreatevalue)

        'crparameterdefinition.ApplyCurrentValues(cparametervalues)
        'CrystalReportViewer1.ReportSource = cryrpt
        'CrystalReportViewer1.Refresh()

        Dim rpt As New ReportDocument
        rpt.Load("..\..\Transaksi\PrintNota\PrintNota.rpt")

        'MsgBox(NewLaundry.kodeTrans)
        'MsgBox("subtotal : " & subtotal & vbNewLine & "diskon : " & diskon & vbNewLine & "kembali : " & kembali)
        rpt.SetDatabaseLogon(FormLogin.tb_username.Text, FormLogin.tb_password.Text)
        rpt.SetParameterValue("paramkode", NewLaundry.kodeTrans)
        rpt.SetParameterValue("subtotal", subtotal)
        rpt.SetParameterValue("diskon", diskon)
        rpt.SetParameterValue("kembali", kembali)
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()
    End Sub

End Class