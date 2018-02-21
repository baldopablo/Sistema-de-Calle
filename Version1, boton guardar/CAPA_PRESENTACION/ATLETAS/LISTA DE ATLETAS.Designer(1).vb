<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LISTA_DE_ATLETAS
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbltotalatletas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvlistaatletas = New System.Windows.Forms.DataGridView()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAgregarACompetencia = New System.Windows.Forms.Button()
        Me.btnAgregarNuevo = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        CType(Me.dgvlistaatletas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbltotalatletas
        '
        Me.lbltotalatletas.AutoSize = True
        Me.lbltotalatletas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltotalatletas.Location = New System.Drawing.Point(724, 417)
        Me.lbltotalatletas.Name = "lbltotalatletas"
        Me.lbltotalatletas.Size = New System.Drawing.Size(2, 15)
        Me.lbltotalatletas.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(619, 419)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Total de Atletas"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(6, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(169, 20)
        Me.TextBox1.TabIndex = 20
        '
        'dgvlistaatletas
        '
        Me.dgvlistaatletas.AllowUserToAddRows = False
        Me.dgvlistaatletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlistaatletas.Location = New System.Drawing.Point(33, 85)
        Me.dgvlistaatletas.Name = "dgvlistaatletas"
        Me.dgvlistaatletas.ReadOnly = True
        Me.dgvlistaatletas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvlistaatletas.Size = New System.Drawing.Size(739, 301)
        Me.dgvlistaatletas.TabIndex = 18
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(289, 449)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 38)
        Me.btnEliminar.TabIndex = 90
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(532, 449)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 38)
        Me.btnModificar.TabIndex = 89
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(40, 448)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 38)
        Me.btnImprimir.TabIndex = 88
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(703, 448)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 38)
        Me.btnCerrar.TabIndex = 87
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAgregarACompetencia
        '
        Me.btnAgregarACompetencia.Enabled = False
        Me.btnAgregarACompetencia.Location = New System.Drawing.Point(613, 449)
        Me.btnAgregarACompetencia.Name = "btnAgregarACompetencia"
        Me.btnAgregarACompetencia.Size = New System.Drawing.Size(84, 38)
        Me.btnAgregarACompetencia.TabIndex = 91
        Me.btnAgregarACompetencia.Text = "Agregar a Competencia"
        Me.btnAgregarACompetencia.UseVisualStyleBackColor = True
        '
        'btnAgregarNuevo
        '
        Me.btnAgregarNuevo.Location = New System.Drawing.Point(451, 449)
        Me.btnAgregarNuevo.Name = "btnAgregarNuevo"
        Me.btnAgregarNuevo.Size = New System.Drawing.Size(75, 38)
        Me.btnAgregarNuevo.TabIndex = 92
        Me.btnAgregarNuevo.Text = "Agregar Nuevo"
        Me.btnAgregarNuevo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 67)
        Me.GroupBox1.TabIndex = 93
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Ingrese DNI"
        '
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(370, 449)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 38)
        Me.btnVer.TabIndex = 96
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(245, 29)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 38)
        Me.btnBuscar.TabIndex = 97
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'LISTA_DE_ATLETAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(798, 499)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAgregarNuevo)
        Me.Controls.Add(Me.btnAgregarACompetencia)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.lbltotalatletas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvlistaatletas)
        Me.Name = "LISTA_DE_ATLETAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Atletas registrados"
        CType(Me.dgvlistaatletas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbltotalatletas As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvlistaatletas As System.Windows.Forms.DataGridView
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarACompetencia As System.Windows.Forms.Button
    Friend WithEvents btnAgregarNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
