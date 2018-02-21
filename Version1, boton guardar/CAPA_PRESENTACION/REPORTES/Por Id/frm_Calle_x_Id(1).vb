Public Class frm_Calle_x_Id

    Public id_competencia As Integer

    Private Sub frm_Calle_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reportecalle As New Calle_x_Id
        reportecalle.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reportecalle
    End Sub
End Class