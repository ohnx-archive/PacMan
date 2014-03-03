<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Winform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Winform))
        Me.congratsText = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Button
        Me.retryButton = New System.Windows.Forms.Button
        Me.textTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'congratsText
        '
        Me.congratsText.AutoSize = True
        Me.congratsText.Font = New System.Drawing.Font("Microsoft Sans Serif", 65.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.congratsText.Location = New System.Drawing.Point(69, 0)
        Me.congratsText.Name = "congratsText"
        Me.congratsText.Size = New System.Drawing.Size(650, 98)
        Me.congratsText.TabIndex = 0
        Me.congratsText.Text = "Congratulations"
        '
        'quitButton
        '
        Me.quitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quitButton.Location = New System.Drawing.Point(627, 101)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(185, 696)
        Me.quitButton.TabIndex = 2
        Me.quitButton.Text = "I'm gonna advance to the next level!"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'retryButton
        '
        Me.retryButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.retryButton.Location = New System.Drawing.Point(12, 101)
        Me.retryButton.Name = "retryButton"
        Me.retryButton.Size = New System.Drawing.Size(146, 696)
        Me.retryButton.TabIndex = 3
        Me.retryButton.Text = "I'm gonna beat this game again!"
        Me.retryButton.UseVisualStyleBackColor = True
        '
        'textTimer
        '
        Me.textTimer.Enabled = True
        Me.textTimer.Interval = 3000
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.PACMAN.My.Resources.Resources.edit1
        Me.PictureBox1.Location = New System.Drawing.Point(164, 105)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(457, 543)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(9, 629)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(784, 258)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'Winform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 809)
        Me.Controls.Add(Me.retryButton)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.congratsText)
        Me.Controls.Add(Me.PictureBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Winform"
        Me.Text = "You WIN!!!"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents congratsText As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents quitButton As System.Windows.Forms.Button
    Friend WithEvents retryButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents textTimer As System.Windows.Forms.Timer
End Class
