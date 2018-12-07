Public Class Form1
    Dim speed As Integer
    Dim road(15) As PictureBox
    Dim score As Integer = 0
    Dim increase As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        speed = 1
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8
        road(8) = PictureBox9
        road(9) = PictureBox10
        road(10) = PictureBox11
        road(11) = PictureBox12
        road(12) = PictureBox13
        road(13) = PictureBox14
        road(14) = PictureBox15
    End Sub

    Private Sub MoveRoad_Tick(sender As Object, e As EventArgs) Handles MoveRoad.Tick
        Label1.Enabled = False
        For i As Integer = 0 To 14
            road(i).Top += speed
            If (road(i).Top >= 559) Then
                road(i).Top = -road(i).Height
            End If
            If (score < 10 And score >= 0) Then
                speed = 3
            End If
            If (score < 20 And score >= 10) Then
                speed = 4
            End If
            If (score < 30 And score >= 20) Then
                speed = 5
            End If
            If (score < 40 And score >= 30) Then
                speed = 6
            End If
            If (score < 50 And score >= 40) Then
                speed = 7
            End If
            If (score > 50) Then
                speed = 8
            End If

            Speed1.Text = "Speed " & speed
            If (MyCar.Bounds.IntersectsWith(test.Bounds)) Then
                GameOver(e)
            End If
            If (MyCar.Bounds.IntersectsWith(green_car.Bounds)) Then
                GameOver(e)
            End If
            If (MyCar.Bounds.IntersectsWith(yellow_car.Bounds)) Then
                GameOver(e)
            End If
            If (MyCar.Bounds.IntersectsWith(pink_car.Bounds)) Then
                GameOver(e)
            End If
        Next
    End Sub
    Sub GameOver(e As EventArgs)

        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
        Label1.Text = "Game Over
 Your score is " & score
        Label1.Visible = True
        timer_stop()
        score = 0
        speed = 0

        If increase = 1 Then
            Dim a = InputBox("Highest score " + vbNewLine + "Enter name: ")
            My.Settings.name = a

        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If MoveRoad.Enabled Then
            If e.KeyCode = Keys.Right Then
                MoveRight.Start()

            End If
            If e.KeyCode = Keys.Left Then
                MoveLeft.Start()
            End If
        End If
    End Sub

    Private Sub MoveRight_Tick(sender As Object, e As EventArgs) Handles MoveRight.Tick
        If (MyCar.Location.X < Me.Width) Then
            MyCar.Left += 3
        End If
    End Sub

    Private Sub MoveLeft_Tick(sender As Object, e As EventArgs) Handles MoveLeft.Tick
        If (MyCar.Location.X > -1) Then
            MyCar.Left -= 3
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        MoveRight.Stop()
        MoveLeft.Stop()

    End Sub
    Dim Generator As System.Random = New System.Random()
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Private Sub testing_Tick(sender As Object, e As EventArgs) Handles testing.Tick
        test.Top += speed + 2
        If (test.Top >= Me.Height) Then
            score = score + 1
            GameScore.Text = "Score " & score
            test.Top = 1
            ' green_car.Left = CInt(Math.Ceiling(Rnd() * 120)) + (50 + green_car.Height)
            test.Left = GetRandom(3, 75)
        End If
    End Sub
    Private Sub enemy1_move_Tick(sender As Object, e As EventArgs) Handles enemy1_move.Tick
        green_car.Top += speed + 1
        If (green_car.Top >= Me.Height) Then
            score = score + 1
            GameScore.Text = "Score " & score
            green_car.Top = 1
            ' green_car.Left = CInt(Math.Ceiling(Rnd() * 120)) + (50 + green_car.Height)
            green_car.Left = GetRandom(100, 160)
        End If
    End Sub

    Private Sub enemy2_move_Tick(sender As Object, e As EventArgs) Handles enemy2_move.Tick
        yellow_car.Top += speed + 3
        If (yellow_car.Top >= 559) Then
            score = score + 1
            GameScore.Text = "Score" & score
            'yellow_car.Top = -yellow_car.Height
            yellow_car.Top = 1
            yellow_car.Left = GetRandom(230, 280)
        End If
    End Sub

    Private Sub enemy3_move_Tick(sender As Object, e As EventArgs) Handles enemy3_move.Tick
        pink_car.Top += speed + 2
        If (pink_car.Top >= Me.Height) Then
            score = score + 1
            GameScore.Text = "Score " & score
            pink_car.Top = 1
            pink_car.Left = GetRandom(300, 380)
        End If
    End Sub



    Private Sub colors_timer_Tick(sender As Object, e As EventArgs) Handles colors_timer.Tick
        Label1.BackColor = Color.FromArgb(255 * Rnd(), 255 * Rnd(), 255 * Rnd())

    End Sub
    Private Sub timer_start()

        MoveRight.Start()
        MoveLeft.Start()
        testing.Start()
        enemy1_move.Start()
        enemy2_move.Start()
        enemy3_move.Start()
        Label1.Hide()
        t_keyPress.Start()
        MoveRoad.Start()
    End Sub
    Private Sub PlayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayToolStripMenuItem.Click
        timer_start()

    End Sub
    Private Sub timer_stop()
        MoveRoad.Stop()
        MoveRight.Stop()
        MoveLeft.Stop()
        testing.Stop()
        enemy1_move.Stop()
        enemy2_move.Stop()
        enemy3_move.Stop()
        t_keyPress.Stop()
    End Sub
    Private Sub PauseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PauseToolStripMenuItem.Click
        timer_stop()
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        score = 0
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        MsgBox("                 game control
                  'p' to play
                 'q' to quite
                 'r' to restart
                  space to pause
Developer : Romeo Sunil Sapkota :)
Report bug: sunilsapkota9@gmail.com :)
          : admin@sapkotasunil.com.np :)")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) > 1 Then
            lvlkey.Text = e.KeyChar
        End If
    End Sub

    Private Sub t_keyPress_Tick(sender As Object, e As EventArgs) Handles t_keyPress.Tick

    End Sub

    Private Sub lvlkey_Click(sender As Object, e As EventArgs) Handles lvlkey.Click

    End Sub

    Private Sub lvlkey_TextChanged(sender As Object, e As EventArgs) Handles lvlkey.TextChanged
        If lvlkey.Text = "p" Or lvlkey.Text = "P" Then
            PlayToolStripMenuItem_Click(e, e)
            lvlkey.Text = "a"
        End If
        If lvlkey.Text = "q" Or lvlkey.Text = "Q" Then
            Close()
            Application.Exit()
            End
        End If
        If lvlkey.Text = " " Then
            PauseToolStripMenuItem_Click(e, e)
            lvlkey.Text = "a"
        End If
        If lvlkey.Text = "r" Or lvlkey.Text = "R" Then
            score = 0
            Me.Controls.Clear()
            InitializeComponent()
            Form1_Load(e, e)
            lvlkey.Text = "p"
        End If
    End Sub

    Private Sub HighScoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighScoreToolStripMenuItem.Click
        MsgBox("name: " & My.Settings.name & vbNewLine & "The highest score is " & My.Settings.H_score)
    End Sub

    Private Sub t_hscore_Tick(sender As Object, e As EventArgs) Handles t_hscore.Tick

        If score > My.Settings.H_score Then
            My.Settings.H_score = score
            increase = 1
        End If
    End Sub
End Class