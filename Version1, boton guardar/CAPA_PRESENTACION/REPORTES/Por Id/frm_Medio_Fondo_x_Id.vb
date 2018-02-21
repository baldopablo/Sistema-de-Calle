Public Class frm_Medio_Fondo_x_Id

    Public id_competencia As Integer

    Private Sub frm_Medio_Fondo_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reportemediofondo As New Medio_Fondo_x_Id
        reportemediofondo.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reportemediofondo
    End Sub
End Class