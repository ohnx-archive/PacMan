<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YouDie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YouDie))
        Me.monstername = New System.Windows.Forms.Label
        Me.Label = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.retryButton = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'monstername
        '
        Me.monstername.AutoSize = True
        Me.monstername.BackColor = System.Drawing.Color.White
        Me.monstername.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.monstername.Location = New System.Drawing.Point(12, 17)
        Me.monstername.Name = "monstername"
        Me.monstername.Size = New System.Drawing.Size(319, 76)
        Me.monstername.TabIndex = 1
        Me.monstername.Text = "Someone"
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.BackColor = System.Drawing.Color.White
        Me.Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.Location = New System.Drawing.Point(337, 17)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(328, 76)
        Me.Label.TabIndex = 2
        Me.Label.Text = "killed you!"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PACMAN.My.Resources.Resources.animateddeathsequence
        Me.PictureBox1.Location = New System.Drawing.Point(693, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(94, 91)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'retryButton
        '
        Me.retryButton.AutoSize = True
        Me.retryButton.BackColor = System.Drawing.Color.Transparent
        Me.retryButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.retryButton.ForeColor = System.Drawing.Color.Black
        Me.retryButton.Location = New System.Drawing.Point(3, 111)
        Me.retryButton.Name = "retryButton"
        Me.retryButton.Size = New System.Drawing.Size(830, 63)
        Me.retryButton.TabIndex = 6
        Me.retryButton.Text = "I'M GONNA BEAT THIS GAME!!"
        '
        'quitButton
        '
        Me.quitButton.AutoSize = True
        Me.quitButton.BackColor = System.Drawing.Color.Transparent
        Me.quitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quitButton.Location = New System.Drawing.Point(253, 720)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(303, 63)
        Me.quitButton.TabIndex = 7
        Me.quitButton.Text = "I fail. I quit."
        '
        'YouDie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PACMAN.My.Resources.Resources.edit
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(836, 792)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.retryButton)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.monstername)
        Me.Controls.Add(Me.PictureBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "YouDie"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "You Died..."
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents monstername As System.Windows.Forms.Label
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents retryButton As System.Windows.Forms.Label
    Friend WithEvents quitButton As System.Windows.Forms.Label

End Class
