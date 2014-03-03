Public Class Form1
    Dim keycode As New Integer
    Dim mouthopen As Boolean = True
    Dim keypressed
    Dim monsters(NUMOFMONSTERS) As PictureBox
    Dim vertroads(NUMOFVERTROADS) As PictureBox
    Dim hozroads(NUMOFHOZROADS) As PictureBox
    Dim ghostAttribute(NUMOFMONSTERS) As MonsterAttribute
    Public monstername As String
    Const NUMOFVERTROADS = 4
    Const NUMOFHOZROADS = 2
    Const NUMOFMONSTERS = 4
    Const HOME As Integer = 0
    Const LEAVINGHOME As Integer = 1
    Const REGULAR As Integer = 2
    Const SCARED As Integer = 3
    Dim ghostNumber As Integer = 0
    Dim PowerPellets(NUMOFPOWERPELLETS) As PictureBox
    Const NUMOFPOWERPELLETS As Integer = 8
    Dim pellet(NUMOFPELLETS) As PictureBox
    Const NUMOFPELLETS As Integer = 85
    Dim pelletsAten As Integer = 0
    Dim lives(NUMOFLIVES) As PictureBox
    Const NUMOFLIVES As Integer = 3
    Dim deaths As Integer = 0
    Dim level As Int64 = 1
    Dim Waitinglist(NUMOFMONSTERS) As Integer
    Dim TimeGhostScared As Integer = 0
    Const HOWLONGGHOSTSCARED As Integer = 1125
    Private Sub ChasePacman(ByVal mcp As Integer) 'mcp stands for monster chasing pacman
        Dim xdistance As Integer
        Dim ydistance As Integer
        xdistance = Math.Abs(monsters(mcp).Left - pacman.Left)
        ydistance = Math.Abs(monsters(mcp).Top - pacman.Top)
        If xdistance > ydistance Then
            If pacman.Left < monsters(mcp).Left Then
                ghostAttribute(mcp).monsterDirection = Keys.Left
            ElseIf pacman.Left > monsters(mcp).Left Then
                ghostAttribute(mcp).monsterDirection = Keys.Right
            End If
        ElseIf pacman.Top < monsters(mcp).Top Then
            ghostAttribute(mcp).monsterDirection = Keys.Up
        ElseIf pacman.Top > monsters(mcp).Top Then
            ghostAttribute(mcp).monsterDirection = Keys.Down
        End If
        For index = 0 To NUMOFMONSTERS - 1
            If Check(monsters(mcp), monsters(index)) And index <> mcp Then
                If ghostAttribute(index).monsterDirection = ghostAttribute(mcp).monsterDirection Then
                    If xdistance < ydistance Then
                        If pacman.Left < monsters(mcp).Left Then
                            ghostAttribute(mcp).monsterDirection = Keys.Left
                            monsters(mcp).Left = monsters(index).Left - monsters(mcp).Width
                        Else
                            ghostAttribute(mcp).monsterDirection = Keys.Right
                            monsters(mcp).Left = monsters(index).Left + monsters(index).Width
                        End If
                    Else
                        If pacman.Top < monsters(mcp).Top Then
                            ghostAttribute(mcp).monsterDirection = Keys.Up
                            monsters(mcp).Top = monsters(index).Top - monsters(mcp).Height
                        Else
                            ghostAttribute(mcp).monsterDirection = Keys.Down
                            monsters(mcp).Top = monsters(index).Top + monsters(index).Height
                        End If
                    End If
                End If
            End If
        Next index
    End Sub

    Private Sub Form1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        gameTimer.Start()
        InitMonsters()
        InitVerRoads()
        InitHozRoads()
        InitMonsterdirections()
        InitPellets()
        InitLives()
        PlayAudio(0)
        InitPowerPellets()
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        keypressed = e.KeyCode
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
    Private Sub InitPellets()
        'For i = 0 To NUMOFPELLETS - 1
        '    pellets(i). = "PictureBox" & i
        'Next
        PelletSet()
    End Sub

    Private Sub gameTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gameTimer.Tick
        MovePacman()
        AnimatePacman()
        EatPowerPellet()
        GhostNotScared()
        For i = 0 To NUMOFMONSTERS - 1
            If ghostAttribute(i).ghostState = REGULAR Then
                MoveMonsters(i)
                If Atintersection(i) Then
                    ChasePacman(i)
                End If
            ElseIf ghostAttribute(i).ghostState = SCARED Then
                MoveMonsters(i)
                If Atintersection(i) Then
                    RunAwayFromPacman(i)
                End If
            Else
                Moveintogame()
            End If
            If Check(pacman, monsters(i)) And ghostAttribute(i).ghostState = REGULAR Then
                Killpacman(i)
            ElseIf Check(pacman, monsters(i)) And ghostAttribute(i).ghostState = SCARED Then
                monsters(i).Visible = False
                ghostAttribute(i).ghostState = HOME
            End If
        Next
        PelletEaten()
    End Sub
    Private Sub Moveup(ByVal itemmoving As PictureBox, ByVal Speed As Integer)
        itemmoving.Top -= Speed
        If itemmoving.Top < 0 Then
            itemmoving.Top = 583
        End If
    End Sub
    Private Sub AnimateUp()
        If mouthopen = True Then
            pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmUpC.bmp")
            mouthopen = False
        Else
            pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmUpO.bmp")
            mouthopen = True
        End If
    End Sub
    Private Sub Movedown(ByVal itemmoving As PictureBox, ByVal Speed As Integer)
        itemmoving.Top += Speed
        If itemmoving.Top > 583 Then
            itemmoving.Top = -5
        End If
    End Sub
    Private Sub AnimateDown()
        If mouthopen = True Then
            pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmDnC.bmp")
            mouthopen = False
        Else
            pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmDnO.bmp")
            mouthopen = True
        End If
    End Sub
    Private Sub Moveright(ByVal itemmoving As PictureBox, ByVal Speed As Integer)
        itemmoving.Left += Speed
        If itemmoving.Left > 789 Then
            itemmoving.Left = 0
        End If
    End Sub
    Private Sub Animateright()
        If mouthopen = True Then
            pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmRtC.bmp")
            mouthopen = False
        Else
            pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmRtO.bmp")
            mouthopen = True
        End If
    End Sub
    Private Sub Moveleft(ByVal itemmoving As PictureBox, ByVal Speed As Integer)
        itemmoving.Left -= Speed
        If itemmoving.Left < 0 Then
            itemmoving.Left = 789
        End If
    End Sub
    Private Sub Animateleft()
        If mouthopen = True Then
            pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmLtC.bmp")
            mouthopen = False
        Else
            pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmLtO.bmp")
            mouthopen = True
        End If
    End Sub
    Private Function Check(ByVal anobject As PictureBox, ByVal anotherobj As PictureBox)
        Return (anobject.Right > anotherobj.Left And anotherobj.Right > anobject.Left) And (anotherobj.Bottom > anobject.Top And anobject.Bottom > anotherobj.Top)
    End Function
    Private Sub InitMonsters()
        monsters(0) = monster0
        monsters(1) = monster1
        monsters(2) = monster2
        monsters(3) = monster3
    End Sub
    Private Sub InitVerRoads()
        vertroads(0) = Vroad0
        vertroads(1) = Vroad1
        vertroads(2) = Vroad2
        vertroads(3) = Vroad3
    End Sub
    Private Sub InitHozRoads()
        hozroads(0) = Hroad0
        hozroads(1) = Hroad1
    End Sub
    Private Sub MovePacman()
        Dim midPoint As Integer
        Dim midPac As Integer
        Dim offset As Integer
        For i = 0 To NUMOFHOZROADS - 1
            If Check(hozroads(i), pacman) Then
                If keypressed = 37 Then
                    Moveleft(pacman, 10)
                    midPoint = hozroads(i).Height / 2
                    offset = hozroads(i).Top + midPoint
                    midPac = pacman.Height / 2
                    pacman.Top = offset - midPac
                ElseIf keypressed = 39 Then
                    Moveright(pacman, 10)
                    midPoint = hozroads(i).Height / 2
                    offset = hozroads(i).Top + midPoint
                    midPac = pacman.Height / 2
                    pacman.Top = offset - midPac
                End If
            End If
        Next
        For i = 0 To NUMOFVERTROADS - 1
            If Check(pacman, vertroads(i)) Then
                If keypressed = 38 Then
                    Moveup(pacman, 10)
                    midPoint = vertroads(i).Width / 2
                    offset = vertroads(i).Left + midPoint
                    midPac = pacman.Height / 2
                    pacman.Left = offset - midPac
                ElseIf keypressed = 40 Then
                    Movedown(pacman, 10)
                    midPoint = vertroads(i).Width / 2
                    offset = vertroads(i).Left + midPoint
                    midPac = pacman.Height / 2
                    pacman.Left = offset - midPac
                End If
            End If
        Next
    End Sub
    Private Sub AnimatePacman()
        If Check(Hroad0, pacman) Or Check(Hroad1, pacman) Then
            If keypressed = 37 Then
                Animateleft()
            ElseIf keypressed = 39 Then
                Animateright()
            End If
        End If
        For i = 0 To 3
            If Check(pacman, vertroads(i)) Then
                If keypressed = 38 Then
                    AnimateUp()
                ElseIf keypressed = 40 Then
                    AnimateDown()
                End If
            End If
        Next
    End Sub
    Private Sub MoveMonsters(ByVal mm As Integer)
        Dim midPoint As Integer
        Dim midPac As Integer
        Dim offset As Integer
        For i = 0 To NUMOFHOZROADS - 1
            If Check(monsters(mm), hozroads(i)) Then
                If ghostAttribute(mm).monsterDirection = Keys.Left Then
                    Moveleft(monsters(mm), 9)
                    midPoint = hozroads(i).Height / 2
                    offset = hozroads(i).Top + midPoint
                    midPac = monsters(mm).Height / 2
                    monsters(mm).Top = offset - midPac
                ElseIf ghostAttribute(mm).monsterDirection = Keys.Right Then
                    Moveright(monsters(mm), 9)
                    midPoint = hozroads(i).Height / 2
                    offset = hozroads(i).Top + midPoint
                    midPac = monsters(mm).Height / 2
                    monsters(mm).Top = offset - midPac

                End If
            End If
        Next
        For i = 0 To NUMOFVERTROADS - 1
            If Check(monsters(mm), vertroads(i)) Then
                If ghostAttribute(mm).monsterDirection = Keys.Up Then
                    Moveup(monsters(mm), 9)
                    midPoint = vertroads(i).Width / 2
                    offset = vertroads(i).Left + midPoint
                    midPac = monsters(mm).Height / 2
                    monsters(mm).Left = offset - midPac
                ElseIf ghostAttribute(mm).monsterDirection = Keys.Down Then
                    Movedown(monsters(mm), 9)
                    midPoint = vertroads(i).Width / 2
                    offset = vertroads(i).Left + midPoint
                    midPac = monsters(mm).Height / 2
                    monsters(mm).Left = offset - midPac
                End If
            End If
        Next
    End Sub
    Private Sub InitMonsterdirections()
        ghostAttribute(0).monsterDirection = Keys.Left
        ghostAttribute(1).monsterDirection = Keys.Right
        ghostAttribute(2).monsterDirection = Keys.Left
        ghostAttribute(3).monsterDirection = Keys.Right
    End Sub
    Private Function Atintersection(ByVal mc As Integer) 'mc stands for monster checking
        For i = 0 To NUMOFVERTROADS - 1
            If Check(monsters(mc), Hroad0) And Check(monsters(mc), vertroads(i)) Then
                Return True
            ElseIf Check(monsters(mc), Hroad1) And Check(monsters(mc), vertroads(i)) Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub Killpacman(ByVal i As Integer)
        If deaths = NUMOFLIVES Then
            gameTimer.Stop()
            monstername = monsters(i).Name
            YouDie.Show()
            Hide()
            ResetLevel()
            ResetMonsters()
            PlayAudio(3)
        Else
            lives(deaths).Visible = False
            deaths += 1
            ResetLevel()
            ResetMonsters()
            PlayAudio(1)
        End If
    End Sub
    Private Sub Moveintogame()
        If ghostAttribute(ghostNumber).ghostState = HOME Then
            ghostAttribute(ghostNumber).ghostState = LEAVINGHOME
            monsters(ghostNumber).Location = New Point(353, 265)
        ElseIf ghostAttribute(ghostNumber).ghostState = LEAVINGHOME Then
            If monsters(ghostNumber).Top > 147 Then
                Moveup(monsters(ghostNumber), 3)
            Else
                ghostAttribute(ghostNumber).ghostState = REGULAR
                ghostNumber += 1
            End If
        End If
    End Sub
    Private Sub ResetLevel()
        ghostNumber = 0
        PacmanSet()
        MonsterSet()
        InitHozRoads()
        InitVerRoads()
        InitMonsterdirections()

    End Sub
    Private Sub PacmanSet()
        pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmRtO.bmp")
        mouthopen = True
        pacman.Left = 347
        pacman.Top = 418
    End Sub
    Private Sub MonsterSet()
        InitMonsterdirections()
        InitMonsters()
        ResetMonsters()
        Moveintogame()
    End Sub
    Private Sub ResetMonsters()
        monsters(0).Left = 320
        monsters(0).Top = 253
        monsters(0).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Ghosts\Ghost0L.bmp")
        monsters(1).Left = 379
        monsters(1).Top = 253
        monsters(1).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Ghosts\Ghost1R.bmp")
        monsters(2).Left = 320
        monsters(2).Top = 312
        monsters(2).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Ghosts\Ghost2L.bmp")
        monsters(3).Left = 379
        monsters(3).Top = 312
        monsters(3).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Ghosts\Ghost3R.bmp")
    End Sub
    Private Sub MonstersGoHOme()
        ghostAttribute(0).ghostState = HOME
        ghostAttribute(1).ghostState = HOME
        ghostAttribute(2).ghostState = HOME
        ghostAttribute(3).ghostState = HOME
    End Sub
    Private Sub PelletSet()
        pellet(0) = PictureBox1
        pellet(1) = PictureBox2
        pellet(2) = PictureBox3
        pellet(3) = PictureBox4
        pellet(4) = PictureBox5
        pellet(5) = PictureBox6
        pellet(6) = PictureBox7
        pellet(7) = PictureBox8
        pellet(8) = PictureBox9
        pellet(9) = PictureBox10
        pellet(10) = PictureBox11
        pellet(11) = PictureBox12
        pellet(12) = PictureBox13
        pellet(13) = PictureBox14
        pellet(14) = PictureBox15
        pellet(15) = PictureBox16
        pellet(16) = PictureBox17
        pellet(17) = PictureBox18
        pellet(18) = PictureBox19
        pellet(19) = PictureBox20
        pellet(20) = PictureBox21
        pellet(21) = PictureBox22
        pellet(22) = PictureBox23
        pellet(23) = PictureBox24
        pellet(24) = PictureBox25
        pellet(25) = PictureBox26
        pellet(26) = PictureBox27
        pellet(27) = PictureBox28
        pellet(28) = PictureBox29
        pellet(29) = PictureBox30
        pellet(30) = PictureBox31
        pellet(31) = PictureBox32
        pellet(32) = PictureBox33
        pellet(33) = PictureBox34
        pellet(34) = PictureBox35
        pellet(35) = PictureBox36
        pellet(36) = PictureBox37
        pellet(37) = PictureBox38
        pellet(38) = PictureBox39
        pellet(39) = PictureBox40
        pellet(40) = PictureBox41
        pellet(41) = PictureBox42
        pellet(42) = PictureBox43
        pellet(43) = PictureBox44
        pellet(44) = PictureBox45
        pellet(45) = PictureBox46
        pellet(46) = PictureBox47
        pellet(47) = PictureBox48
        pellet(48) = PictureBox49
        pellet(49) = PictureBox50
        pellet(50) = PictureBox51
        pellet(51) = PictureBox52
        pellet(52) = PictureBox53
        pellet(53) = PictureBox54
        pellet(54) = PictureBox55
        pellet(55) = PictureBox56
        pellet(56) = PictureBox57
        pellet(57) = PictureBox58
        pellet(58) = PictureBox59
        pellet(59) = PictureBox60
        pellet(60) = PictureBox61
        pellet(61) = PictureBox62
        pellet(62) = PictureBox63
        pellet(63) = PictureBox64
        pellet(64) = PictureBox65
        pellet(65) = PictureBox66
        pellet(66) = PictureBox67
        pellet(67) = PictureBox68
        pellet(68) = PictureBox69
        pellet(69) = PictureBox70
        pellet(70) = PictureBox71
        pellet(71) = PictureBox72
        pellet(72) = PictureBox73
        pellet(73) = PictureBox74
        pellet(74) = PictureBox75
        pellet(75) = PictureBox76
        pellet(76) = PictureBox77
        pellet(77) = PictureBox78
        pellet(78) = PictureBox79
        pellet(79) = PictureBox80
        pellet(80) = PictureBox81
        pellet(81) = PictureBox82
        pellet(82) = PictureBox83
        pellet(83) = PictureBox84
        pellet(84) = PictureBox85
    End Sub
    Private Function CheckWin()
        If pelletsAten = NUMOFPELLETS Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub PelletEaten()
        For i = 0 To NUMOFPELLETS - 1
            If Check(pellet(i), pacman) And pellet(i).Visible = True Then
                pellet(i).Visible = False
                pelletsAten += 1
                If CheckWin() Then
                    gameTimer.Stop()
                    PlayAudio(2)
                    Winform.Show()
                    pelletsAten = 0
                    Hide()
                    For j = 0 To NUMOFPELLETS - 1
                        pellet(j).Visible = True
                    Next
                    For j = 0 To NUMOFPOWERPELLETS - 1
                        PowerPellets(j).Visible = True
                    Next
                    ResetLevel()
                    ResetMonsters()
                    level += 1
                    LevelTxt.Text = level
                End If
            End If
        Next
    End Sub
    Private Sub InitLives()
        lives(0) = live0
        lives(1) = live1
        lives(2) = live2
    End Sub
    Private Sub PlayAudio(ByVal musicnum As Integer)
        If musicnum = 0 Then
            My.Computer.Audio.Play(My.Resources.pacmania, AudioPlayMode.BackgroundLoop)
        ElseIf musicnum = 1 Then
            My.Computer.Audio.Play(My.Resources.youDie, AudioPlayMode.Background)
        ElseIf musicnum = 2 Then
            My.Computer.Audio.Play(My.Resources.level, AudioPlayMode.Background)
        ElseIf musicnum = 3 Then
            My.Computer.Audio.Play(My.Resources.gameOver, AudioPlayMode.Background)
        End If
    End Sub
    Private Sub InitPowerPellets()
        PowerPellets(0) = pellet0
        PowerPellets(1) = pellet1
        PowerPellets(2) = pellet2
        PowerPellets(3) = pellet3
        PowerPellets(4) = pellet4
        PowerPellets(5) = pellet5
        PowerPellets(6) = pellet6
        PowerPellets(7) = pellet7
    End Sub
    Private Sub RunAwayFromPacman(ByVal mcp As Integer)
        Dim xdistance As Integer
        Dim ydistance As Integer
        xdistance = Math.Abs(monsters(mcp).Left - pacman.Left)
        ydistance = Math.Abs(monsters(mcp).Top - pacman.Top)
        If xdistance > ydistance Then
            If pacman.Left < monsters(mcp).Left Then
                ghostAttribute(mcp).monsterDirection = Keys.Right
            ElseIf pacman.Left > monsters(mcp).Left Then
                ghostAttribute(mcp).monsterDirection = Keys.Left
            End If
        ElseIf pacman.Top < monsters(mcp).Top Then
            ghostAttribute(mcp).monsterDirection = Keys.Down
        ElseIf pacman.Top > monsters(mcp).Top Then
            ghostAttribute(mcp).monsterDirection = Keys.Up
        End If
        For index = 0 To NUMOFMONSTERS - 1
            If Check(monsters(mcp), monsters(index)) And index <> mcp Then
                If ghostAttribute(index).monsterDirection = ghostAttribute(mcp).monsterDirection Then
                    If xdistance < ydistance Then
                        If pacman.Left < monsters(mcp).Left Then
                            ghostAttribute(mcp).monsterDirection = Keys.Left
                            monsters(mcp).Left = monsters(index).Left - monsters(mcp).Width
                        Else
                            ghostAttribute(mcp).monsterDirection = Keys.Right
                            monsters(mcp).Left = monsters(index).Left + monsters(index).Width
                        End If
                    Else
                        If pacman.Top < monsters(mcp).Top Then
                            ghostAttribute(mcp).monsterDirection = Keys.Up
                            monsters(mcp).Top = monsters(index).Top - monsters(mcp).Height
                        Else
                            ghostAttribute(mcp).monsterDirection = Keys.Down
                            monsters(mcp).Top = monsters(index).Top + monsters(index).Height
                        End If
                    End If
                End If
            End If
        Next index
    End Sub
    Private Sub EatPowerPellet()
        For i = 0 To NUMOFPOWERPELLETS - 1
            If Check(PowerPellets(i), pacman) And PowerPellets(i).Visible = True Then
                For j = 0 To NUMOFMONSTERS - 1
                    If ghostAttribute(j).ghostState = REGULAR Then
                        ghostAttribute(j).ghostState = SCARED
                        AnimatescaredGhost(j)
                    End If
                Next
                PowerPellets(i).Visible = False
            End If
        Next
    End Sub
    Private Sub AnimatescaredGhost(ByVal j As Integer)
        monsters(j).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Ghosts\GhostScared.bmp")
    End Sub
    Private Sub GhostNotScared()

        If TimeGhostScared < HOWLONGGHOSTSCARED Then
            TimeGhostScared += 1
        End If
        If TimeGhostScared = HOWLONGGHOSTSCARED Then
            ResetMonsters()
        End If
    End Sub
End Class
