<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Informe_Final_Lanzamiento
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
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.dgvLanzamientoMaestro = New System.Windows.Forms.DataGridView()
        Me.dgvLanzamientoDetalle = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvLanzamientoMaestro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLanzamientoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnReporte
        '
        Me.btnReporte.Location = New System.Drawing.Point(497, 477)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(75, 23)
        Me.btnReporte.TabIndex = 108
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(578, 476)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 107
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'dgvLanzamientoMaestro
        '
        Me.dgvLanzamientoMaestro.AllowUserToAddRows = False
        Me.dgvLanzamientoMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLanzamientoMaestro.Location = New System.Drawing.Point(12, 46)
        Me.dgvLanzamientoMaestro.Name = "dgvLanzamientoMaestro"
        Me.dgvLanzamientoMaestro.Size = New System.Drawing.Size(641, 208)
        Me.dgvLanzamientoMaestro.TabIndex = 103
        '
        'dgvLanzamientoDetalle
        '
        Me.dgvLanzamientoDetalle.AllowUserToAddRows = False
        Me.dgvLanzamientoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLanzamientoDetalle.Location = New System.Drawing.Point(12, 303)
        Me.dgvLanzamientoDetalle.Name = "dgvLanzamientoDetalle"
        Me.dgvLanzamientoDetalle.Size = New System.Drawing.Size(641, 167)
        Me.dgvLanzamientoDetalle.TabIndex = 109
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(250, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 16)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Lista de Competencias"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(265, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Vista Preliminar"
        '
        'Informe_Final_Lanzamiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 511)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvLanzamientoDetalle)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.dgvLanzamientoMaestro)
        Me.Name = "Informe_Final_Lanzamiento"
        Me.Text = "Informe Final Lanzamiento"
        CType(Me.dgvLanzamientoMaestro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLanzamientoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents dgvLanzamientoMaestro As System.Windows.Forms.DataGridView
    Friend WithEvents dgvLanzamientoDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
