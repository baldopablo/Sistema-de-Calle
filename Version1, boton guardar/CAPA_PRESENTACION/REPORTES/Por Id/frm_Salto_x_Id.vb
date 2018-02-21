Public Class frm_Salto_x_Id

    Public id_competencia As Integer

    Private Sub frm_Salto_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reportesalto As New Salto_x_Id
        reportesalto.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reportesalto
    End Sub
End Class