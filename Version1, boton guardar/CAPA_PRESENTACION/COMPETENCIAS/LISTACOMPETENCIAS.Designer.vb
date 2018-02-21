<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LISTACOMPETENCIAS
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
        Me.dgvCompetencias = New System.Windows.Forms.DataGridView()
        Me.lbltotalcompetencias = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditarListaCompetencia = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.rbtDistancia = New System.Windows.Forms.RadioButton()
        Me.rbtDisciplina = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtTodas = New System.Windows.Forms.RadioButton()
        CType(Me.dgvCompetencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCompetencias
        '
        Me.dgvCompetencias.AllowUserToAddRows = False
        Me.dgvCompetencias.AllowUserToDeleteRows = False
        Me.dgvCompetencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompetencias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCompetencias.Location = New System.Drawing.Point(12, 123)
        Me.dgvCompetencias.MultiSelect = False
        Me.dgvCompetencias.Name = "dgvCompetencias"
        Me.dgvCompetencias.ReadOnly = True
        Me.dgvCompetencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompetencias.Size = New System.Drawing.Size(653, 257)
        Me.dgvCompetencias.TabIndex = 20
        '
        'lbltotalcompetencias
        '
        Me.lbltotalcompetencias.AutoSize = True
        Me.lbltotalcompetencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltotalcompetencias.Location = New System.Drawing.Point(638, 393)
        Me.lbltotalcompetencias.Name = "lbltotalcompetencias"
        Me.lbltotalcompetencias.Size = New System.Drawing.Size(2, 15)
        Me.lbltotalcompetencias.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(506, 393)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Total de Competencias"
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(428, 423)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 41)
        Me.btnEliminar.TabIndex = 90
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnEditarListaCompetencia
        '
        Me.btnEditarListaCompetencia.Location = New System.Drawing.Point(509, 423)
        Me.btnEditarListaCompetencia.Name = "btnEditarListaCompetencia"
        Me.btnEditarListaCompetencia.Size = New System.Drawing.Size(75, 40)
        Me.btnEditarListaCompetencia.TabIndex = 89
        Me.btnEditarListaCompetencia.Text = "Modificar "
        Me.btnEditarListaCompetencia.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(12, 423)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 40)
        Me.btnImprimir.TabIndex = 88
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(590, 423)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 40)
        Me.btnCerrar.TabIndex = 87
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'rbtDistancia
        '
        Me.rbtDistancia.AutoSize = True
        Me.rbtDistancia.Location = New System.Drawing.Point(6, 56)
        Me.rbtDistancia.Name = "rbtDistancia"
        Me.rbtDistancia.Size = New System.Drawing.Size(48, 17)
        Me.rbtDistancia.TabIndex = 93
        Me.rbtDistancia.TabStop = True
        Me.rbtDistancia.Text = "Calle"
        Me.rbtDistancia.UseVisualStyleBackColor = True
        '
        'rbtDisciplina
        '
        Me.rbtDisciplina.AutoSize = True
        Me.rbtDisciplina.Location = New System.Drawing.Point(6, 79)
        Me.rbtDisciplina.Name = "rbtDisciplina"
        Me.rbtDisciplina.Size = New System.Drawing.Size(92, 17)
        Me.rbtDisciplina.TabIndex = 94
        Me.rbtDisciplina.TabStop = True
        Me.rbtDisciplina.Text = "Pista y Campo"
        Me.rbtDisciplina.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtTodas)
        Me.GroupBox1.Controls.Add(Me.rbtDisciplina)
        Me.GroupBox1.Controls.Add(Me.rbtDistancia)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(653, 105)
        Me.GroupBox1.TabIndex = 96
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar por"
        '
        'rbtTodas
        '
        Me.rbtTodas.AutoSize = True
        Me.rbtTodas.Location = New System.Drawing.Point(6, 33)
        Me.rbtTodas.Name = "rbtTodas"
        Me.rbtTodas.Size = New System.Drawing.Size(55, 17)
        Me.rbtTodas.TabIndex = 95
        Me.rbtTodas.TabStop = True
        Me.rbtTodas.Text = "Todas"
        Me.rbtTodas.UseVisualStyleBackColor = True
        '
        'LISTACOMPETENCIAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(685, 475)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditarListaCompetencia)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.lbltotalcompetencias)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvCompetencias)
        Me.Name = "LISTACOMPETENCIAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Competencias registradas"
        CType(Me.dgvCompetencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCompetencias As System.Windows.Forms.DataGridView
    Friend WithEvents lbltotalcompetencias As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnEditarListaCompetencia As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents rbtDistancia As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDisciplina As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtTodas As System.Windows.Forms.RadioButton
End Class
