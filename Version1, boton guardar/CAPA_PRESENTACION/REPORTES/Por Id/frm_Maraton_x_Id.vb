Public Class frm_Maraton_x_Id
    Public id_competencia As Integer
    Private Sub frm_Maraton_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reportemaraton As New Maraton_x_Id
        reportemaraton.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reportemaraton
    End Sub
End Class