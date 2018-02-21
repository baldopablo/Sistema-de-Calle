﻿Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class PlanilladeMedioFondo

    Public Property TipoDeFormulario As TipoFormulario
    Shared Property CompetenciaSeleccionada As New CECompetencias

    Private Sub PlanilladeMedioFondo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()
    End Sub

    Private Sub btnAgregarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarAtleta.Click
        LISTA_DE_ATLETAS.TipoDeFormulario = TipoFormulario.AgregarAtleta
        LISTA_DE_ATLETAS.ShowDialog()

        Dim cantidad As DataGridView = CType(dgvPlanillaMedioFondo, DataGridView)
        If cantidad.Rows.Count >= 48 Then
            MessageBox.Show("Ha sido agregado el último atleta, no se permiten mas ingresos")
            btnAgregarAtleta.Enabled = False
            Return
        End If
    End Sub

    Private Sub btnQuitarAtleta_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitarAtleta.Click
        If Me.dgvPlanillaMedioFondo.Rows.Count = 0 Then
            MessageBox.Show("No hay atletas para eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            dgvPlanillaMedioFondo.Rows.RemoveAt(dgvPlanillaMedioFondo.CurrentRow.Index)
        End If
    End Sub

    Shared Sub AgregarRegistroAGrilla(atleta As CEAtletas)
        Dim Coleccion As DataGridViewSelectedRowCollection = LISTA_DE_ATLETAS.dgvlistaatletas.SelectedRows
        Dim cNegVarios = New CAPA_NEGOCIO.CNVarios
        Dim clubNombre As String = cNegVarios.NombreClubPorId(atleta.id_club_federacion)
        PlanilladeMedioFondo.dgvPlanillaMedioFondo.Rows.Add(0,
                                                            atleta.dorsal,
                                                          atleta.Apellido_atleta,
                                                          atleta.Nombre_atleta, _
                                                          clubNombre,
                                                          "",
                                                          "",
                                                          "")
    End Sub

    Private Sub PrepararFormulario()
        btnAgregarAtleta.Enabled = True
        btnQuitarAtleta.Enabled = True
        rbtSerie1.Enabled = False
        btnAgregarSerie1.Enabled = False
        rbtSerie2.Enabled = False
        btnAgregarSerie2.Enabled = False
        rbtSerie3.Enabled = False
        btnAgregarSerie3.Enabled = False
        btnImprimir.Enabled = False
        btnComenzar.Enabled = True
        btnGuardar.Enabled = False
        btnCerrar.Enabled = True
        btnAceptar.Enabled = True
        btnActualizar.Enabled = False
        btnAceptar.Enabled = False
    End Sub


    Private Sub btnComenzar_Click(sender As System.Object, e As System.EventArgs) Handles btnComenzar.Click
        If Me.dgvPlanillaMedioFondo.Rows.Count = 0 Then
            MessageBox.Show("Ingrese a los atletas que participarán de la competencia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Dim dgv As DataGridView = CType(dgvPlanillaMedioFondo, DataGridView)
        If dgv.Rows.Count >= 1 And dgv.Rows.Count <= 2 Then
            rbtSerie1.Enabled = True
            rbtSerie1.Checked = True
            btnAgregarSerie1.Enabled = True
            btnAceptar.Enabled = True

        ElseIf dgv.Rows.Count >= 3 And dgv.Rows.Count <= 4 Then
            rbtSerie2.Enabled = True
            rbtSerie1.Enabled = True
            btnAgregarSerie1.Enabled = True
            btnAgregarSerie2.Enabled = True
            btnAceptar.Enabled = True

        ElseIf dgv.Rows.Count >= 5 And dgv.Rows.Count <= 6 Then
            rbtSerie3.Enabled = True
            rbtSerie2.Enabled = True
            rbtSerie1.Enabled = True
            btnAgregarSerie1.Enabled = True
            btnAgregarSerie2.Enabled = True
            btnAgregarSerie3.Enabled = True
            btnAceptar.Enabled = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregarSerie1_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarSerie1.Click
        If rbtSerie1.Checked = True Then
            Dim FilasSeleccionadas As New List(Of DataGridViewRow)()
            For Each row As DataGridViewRow In dgvPlanillaMedioFondo.Rows
                Dim cellSelecion As DataGridViewCheckBoxCell = _
                TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)

                If Convert.ToBoolean(cellSelecion.Value) Then
                    FilasSeleccionadas.Add(row)
                End If
            Next
            For Each row As DataGridViewRow In FilasSeleccionadas
                PlanilladeSeriesdeMedioFondo.dgvSerie1.Rows.Add(row.Cells(1).Value, row.Cells(2).Value)
                dgvPlanillaMedioFondo.Rows.Remove(row)
            Next
        End If

        Dim nuevo As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvPlanillaMedioFondo.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cellSelecion.Value) Then
                nuevo.Add(row)
            End If
        Next
        For Each row As DataGridViewRow In nuevo
            PlanilladeSeriesdeMedioFondo.dgvSerie1.Rows.Add(New Object() {row.Cells(0).Value, row.Cells(1).Value})
        Next
    End Sub

    Private Sub btnAgregarSerie2_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarSerie2.Click
        If rbtSerie2.Checked = True Then

            'Se define una lista temporal de registro seleccionados
            Dim FilasSeleccionadas As New List(Of DataGridViewRow)()
            'Se recorre cada registro del grid de origen
            For Each row As DataGridViewRow In dgvPlanillaMedioFondo.Rows
                'Se recupera el campo que representa el checkbox,
                'se valida que esté seleccionado y agregándolo a la lista temporal
                Dim cellSelecion As DataGridViewCheckBoxCell = _
                TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)

                If Convert.ToBoolean(cellSelecion.Value) Then
                    FilasSeleccionadas.Add(row)
                End If
            Next
            'Se agrega el ítem seleccionado al grid de destino
            'eliminando la fila del grid original
            For Each row As DataGridViewRow In FilasSeleccionadas
                PlanilladeSeriesdeMedioFondo.dgvSerie2.Rows.Add(row.Cells(1).Value, row.Cells(2).Value)
                dgvPlanillaMedioFondo.Rows.Remove(row)
            Next
        End If

        Dim nuevo As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvPlanillaMedioFondo.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cellSelecion.Value) Then
                nuevo.Add(row)
            End If
        Next
        For Each row As DataGridViewRow In nuevo
            PlanilladeSeriesdeMedioFondo.dgvSerie2.Rows.Add(New Object() {row.Cells(0).Value, row.Cells(1).Value})
        Next

    End Sub

    Private Sub btnAgregarSerie3_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarSerie3.Click
        If rbtSerie3.Checked = True Then

            'Se define una lista temporal de registro seleccionados
            Dim FilasSeleccionadas As New List(Of DataGridViewRow)()
            'Se recorre cada registro del grid de origen
            For Each row As DataGridViewRow In dgvPlanillaMedioFondo.Rows
                'Se recupera el campo que representa el checkbox,
                'se valida que esté seleccionado y agregándolo a la lista temporal
                Dim cellSelecion As DataGridViewCheckBoxCell = _
                TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)

                If Convert.ToBoolean(cellSelecion.Value) Then
                    FilasSeleccionadas.Add(row)
                End If
            Next
            'Se agrega el ítem seleccionado al grid de destino
            'eliminando la fila del grid original
            For Each row As DataGridViewRow In FilasSeleccionadas
                PlanilladeSeriesdeMedioFondo.dgvSerie3.Rows.Add(row.Cells(1).Value, row.Cells(2).Value)
                dgvPlanillaMedioFondo.Rows.Remove(row)
            Next
        End If

        Dim nuevo As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvPlanillaMedioFondo.Rows
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Seleccionar"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cellSelecion.Value) Then
                nuevo.Add(row)
            End If
        Next
        For Each row As DataGridViewRow In nuevo
            PlanilladeSeriesdeMedioFondo.dgvSerie3.Rows.Add(New Object() {row.Cells(0).Value, row.Cells(1).Value})
        Next

    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        PlanilladeSeriesdeMedioFondo.ShowDialog()
    End Sub
End Class