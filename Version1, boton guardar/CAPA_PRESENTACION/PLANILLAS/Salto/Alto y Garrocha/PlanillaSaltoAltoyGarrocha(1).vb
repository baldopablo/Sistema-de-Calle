Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions

Public Class PlanillaSaltoenAltoyGarrocha
    Dim capanegocio As New CNCompetencias
    Dim capanegocio1 As New CNAtletas
    Dim capanegocio3 As New CNResultadoParcial
    Dim capanegocio4 As New CNAtletas_x_Competencia
    Public Property Id_Competencia As Int32

    Private Sub PLANILLASALTOENALTOYCONGARROCHA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Private Sub PrepararFormulario()
        btnAgregarAtleta.Enabled = True
        btnQuitar.Enabled = True
        btnImprimir.Enabled = False
        btnActualizar.Enabled = False
        btnGuardar.Enabled = False
        btnAltura.Enabled = False
        TextBox4.Enabled = False
        grbResultados.Enabled = False
        GroupBox1.Enabled = True
        cboCategoria.SelectedIndex = 0
        cboSexo.SelectedIndex = 0

        NuevoCodigoResultado()
    End Sub

    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)
        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        PlanillaSaltoenAltoyGarrocha.dgvAltoyGarrocha.Rows.Add(atleta.dorsal,
                                                               atleta.id_atleta,
                                                          atleta.Nombre_atleta, _
                                                          atleta.Apellido_atleta
                                                          )
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        LISTA_DE_ATLETAS.TipoDeFormulario = TipoFormulario.AgregarAtleta
        LISTA_DE_ATLETAS.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        dgvAltoyGarrocha.Rows.RemoveAt(dgvAltoyGarrocha.CurrentRow.Index)
    End Sub

    Private Sub btnVálido_Click(sender As System.Object, e As System.EventArgs)
        If txtAltura1.Text = "Altura 1" Then
            MsgBox("Debe ingresar una altura para poder continuar")
            TextBox4.Focus()
            Exit Sub
        End If
        If Me.dgvAltoyGarrocha.SelectedRows Is Nothing OrElse Me.dgvAltoyGarrocha.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar algo")
            Exit Sub
        End If
        Dim filaActual = Me.dgvAltoyGarrocha.SelectedRows(0)

        If MessageBox.Show("Confirma ingresar el salto conseguido..??: \n" + filaActual.Cells(2).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ' filaActual.Cells(4).Value = 0 'btnNulo.Text
            Dim valor As String
            valor = "O "
            CargarSiguienteCelda(filaActual, valor)
        End If
    End Sub


    Dim COLUMNA_PRIMER_ALTURA As Integer = 3
    Dim COLUMNA_SEGUNDA_ALTURA As Integer = 4
    Dim COLUMNA_TERCERA_ALTURA As Integer = 5
    Dim COLUMNA_CUARTA_ALTURA As Integer = 6
    Dim COLUMNA_QUINTA_ALTURA As Integer = 7
    Dim COLUMNA_SEXTA_ALTURA As Integer = 8
    Dim COLUMNA_SEPTIMA_ALTURA As Integer = 9
    Dim COLUMNA_OCTAVA_ALTURA As Integer = 10
    Dim COLUMNA_NOVENA_ALTURA As Integer = 11
    Dim COLUMNA_DECIMA_ALTURA As Integer = 12
    'Const COLUMNA_CLASIFICACION As Integer = 13

    Private Sub CargarSiguienteCelda(ByRef filaActual As DataGridViewRow, valorAponer As String)
        ' recorre las columnas 3 a 12 que corresponden a la cantidad de alturas
        For i As Integer = COLUMNA_PRIMER_ALTURA To COLUMNA_DECIMA_ALTURA
            ' valida que la posicion este vacia, si es asi agrega el valor
            If String.IsNullOrEmpty(filaActual.Cells(i).Value) Then 'busca la primer posición vacía
                filaActual.Cells(i).Value = valorAponer
                'CalcularMejor123(filaActual)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub btnNulo_Click(sender As System.Object, e As System.EventArgs)
        If txtAltura1.Text = "Altura 1" Then
            MsgBox("Debe ingresar una altura para poder continuar")
            TextBox4.Focus()
            Exit Sub
        End If
        If Me.dgvAltoyGarrocha.SelectedRows Is Nothing OrElse Me.dgvAltoyGarrocha.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar algo")
            Exit Sub
        End If
        Dim filaActual = Me.dgvAltoyGarrocha.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el salto conseguido..??: \n" + filaActual.Cells(2).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ' filaActual.Cells(4).Value = 0 'btnNulo.Text
            Dim valor As String
            valor = "X "
            CargarSiguienteCelda(filaActual, valor)
        End If
    End Sub

    Private Sub btnRehuso_Click(sender As System.Object, e As System.EventArgs)
        If txtAltura1.Text = "Altura 1" Then
            MsgBox("Debe ingresar una altura para poder continuar")
            TextBox4.Focus()
            Exit Sub
        End If
        If Me.dgvAltoyGarrocha.SelectedRows Is Nothing OrElse Me.dgvAltoyGarrocha.SelectedRows.Count = 0 Then
            MessageBox.Show("Debe seleccionar algo")
            Exit Sub
        End If
        Dim filaActual = Me.dgvAltoyGarrocha.SelectedRows(0)
        If MessageBox.Show("Confirma ingresar el salto conseguido..??: \n" + filaActual.Cells(2).Value, "Confirmar acción", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ' filaActual.Cells(4).Value = 0 'btnNulo.Text
            Dim valor As String
            valor = "= "
            CargarSiguienteCelda(filaActual, valor)
        End If
    End Sub

    Private Sub btnAltura_Click(sender As System.Object, e As System.EventArgs)
        If txtAltura1.Text = "Altura 1" Then
            If TextBox4.Text = "" Then
                MessageBox.Show("Debe ingresar una altura")
                TextBox4.Focus()
                Exit Sub
            End If
            txtAltura1.Text = TextBox4.Text
            TextBox4.Clear()
        End If

        If txtAltura1.Text = "Altura 2" Then
            If TextBox4.Text = "" Then
                MessageBox.Show("Debe ingresar una altura")
                TextBox4.Focus()
                Exit Sub
            End If
            txtAltura1.Text = TextBox4.Text
            TextBox4.Clear()
        End If

        If txtAltura1.Text = "Altura 3" Then
            If TextBox4.Text = "" Then
                MessageBox.Show("Debe ingresar una altura")
                TextBox4.Focus()
                Exit Sub
            End If
            txtAltura1.Text = TextBox4.Text
            TextBox4.Clear()
        End If

        If txtAltura1.Text = "Altura 4" Then
            If TextBox4.Text = "" Then
                MessageBox.Show("Debe ingresar una altura")
                TextBox4.Focus()
                Exit Sub
            End If
            txtAltura1.Text = TextBox4.Text
            TextBox4.Clear()
        End If
        If txtAltura1.Text = "Altura 5" Then
            If TextBox4.Text = "" Then
                MessageBox.Show("Debe ingresar una altura")
                TextBox4.Focus()
                Exit Sub
            End If
            txtAltura1.Text = TextBox4.Text
            TextBox4.Clear()
        End If
    End Sub

    Private Sub btnComenzar_Click(sender As System.Object, e As System.EventArgs) Handles btnComenzar.Click
        If Me.dgvAltoyGarrocha.Rows.Count = 0 Then
            MessageBox.Show("Debe ingresar atletas para poder comenzar a registrar las alturas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If

        btnAgregarAtleta.Enabled = False
        btnVálido.Enabled = True
        btnRehuso.Enabled = True
        btnNulo.Enabled = True
        btnImprimir.Enabled = True
        btnGuardar.Enabled = True
        btnQuitar.Enabled = False
        btnAltura.Enabled = True
        TextBox4.Enabled = True
        grbResultados.Enabled = True
        GroupBox1.Enabled = True
    End Sub

  

    Private Sub btnQuitar_Click(sender As System.Object, e As System.EventArgs)
        If dgvAltoyGarrocha.Rows.Count <> 0 Then
            dgvAltoyGarrocha.Rows.RemoveAt(dgvAltoyGarrocha.CurrentRow.Index)
        Else
            MessageBox.Show("No hay atletas cargados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If Me.dgvAltoyGarrocha.Rows.Count = 0 Then
            MessageBox.Show("Debe haber registros cargados para poder guardarlos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregarAtleta.Focus()
            Return
        End If
       
    End Sub

    Sub NuevoCodigoResultado()
        TextBox1.Text = capanegocio3.NuevoCodigoResultado
    End Sub

    Private Sub btnAgregarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarAtleta.Click
        'VALIDA QUE SE SELECCIONE SEXO Y CATEGORIA
        If cboSexo.Text = "--Seleccionar--" And cboCategoria.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar un Sexo y una Categoría", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboSexo.Focus()
            Return
        End If

        'VALIDA QUE SE SELECCIONE SEXO
        If cboSexo.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar un Sexo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboSexo.Focus()
            Return
        End If

        'VALIDA QUE SE SELECCIONE CATEGORIA
        If cboCategoria.Text = "--Seleccionar--" Then
            MessageBox.Show("Debe seleccionar una Categoría", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboCategoria.Focus()
            Return
        End If

        LISTA_DE_ATLETAS.TipoDeFormulario = TipoFormulario.DatosAdicionalesDelAtleta
        LISTA_DE_ATLETAS.ShowDialog()

        'cboCategoria.Enabled = False
        'cboSexo.Enabled = False
    End Sub

    
    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        frm_Pre_Salto.ShowDialog()
    End Sub
End Class
