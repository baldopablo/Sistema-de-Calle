Public Class frm_Cross_Country_x_Id
    Public id_competencia As Integer
    Private Sub frm_Cross_Country_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reportecrosscountry As New Cross_Country_x_Id
        reportecrosscountry.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reportecrosscountry
    End Sub
End Class