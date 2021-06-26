Public Class Form1
    Dim vspeed As Double = 1
    Dim hright As Boolean
    Dim hleft As Boolean
    Dim hup As Boolean
    Dim hdown As Boolean
    Dim hspeed As Double = 2
    Dim bspeed As Double = 4

    Dim touchvillian1 As Boolean
    Dim touchvillian2 As Boolean
    Dim touchvillian3 As Boolean
    Dim touchvillian4 As Boolean
    Dim life As Integer = 5
    Public score As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        start()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Up Then
            hup = True
            hdown = False
            hright = False
            hleft = False
        End If
        If e.KeyValue = Keys.Down Then
            hdown = True
            hup = False
            hright = False
            hleft = False
        End If
        If e.KeyValue = Keys.Right Then
            hright = True
            hup = False
            hdown = False
            hleft = False
        End If
        If e.KeyValue = Keys.Left Then
            hleft = True
            hup = False
            hdown = False
            hright = False
        End If
        If e.KeyValue = Keys.Space And Button1.Enabled = True Then
            start()
        End If

        If e.KeyValue = Keys.X And bullet.Visible = False Then
            bullet.Visible = True
            bullet.Top = hero.Top
            bullet.Left = hero.Left + (hero.Width / 2) - (bullet.Width / 2)
        End If

        If bullet.Visible = True And e.KeyValue = Keys.X And bullet1.Visible = False Then
            bullet1.Visible = True
            bullet1.Top = hero.Top
            bullet1.Left = hero.Left + (hero.Width / 2) - (bullet.Width / 2)
        End If
    End Sub

    Private Sub time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles time.Tick
        move_villian()
        movehero()
        checkhit()
        movebullet()
        lblscore.Text = score
        checklevel()
        redrop()
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        hleft = False
        hup = False
        hdown = False
        hright = False
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.nickelback, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub info_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles info.Click
        MessageBox.Show("Use the Spacebar to Start and Restart" + vbCrLf + "Use the X button to Shoot" + vbCrLf + "Use the D-Pad to move" + vbCrLf + "" + vbCrLf + "Designed and Developed by" + vbCrLf + "Ebuka Odini" + vbCrLf + "" + vbCrLf + "Music by" + vbCrLf + "Nickelback (Burn it to the ground)", "Game Control", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub movehero()
        If hero.Bottom >= Panel1.Bottom Then
            hup = True
            hdown = False
            hright = False
            hleft = False
        End If
        If hero.Right + hero.Width >= Panel1.Right Then
            hleft = True
            hup = False
            hdown = False
            hright = False
        End If
        If hero.Left + hero.Width <= Panel1.Left Then
            hright = True
            hup = False
            hdown = False
            hleft = False
        End If
        If hero.Top + hero.Height <= Panel1.Top Then
            hdown = True
            hup = False
            hright = False
            hleft = False
        End If

        If hright = True Then
            hero.Left += hspeed
        End If
        If hleft = True Then
            hero.Left -= hspeed
        End If
        If hup = True Then
            hero.Top -= hspeed
        End If
        If hdown = True Then
            hero.Top += hspeed
        End If
    End Sub

    Private Sub move_villian()
        If villian1.Top + villian1.Height >= Panel1.Bottom Then
            villian1.Top = Panel1.Top - 20
            score = score - 2
        End If
        If villian2.Top + villian2.Height >= Panel1.Bottom Then
            villian2.Top = Panel1.Top - 20
            score = score - 2
        End If
        If villian3.Top + villian3.Height >= Panel1.Bottom Then
            villian3.Top = Panel1.Top - 20
            score = score - 2
        End If
        If villian4.Top + villian4.Height >= Panel1.Bottom Then
            villian4.Top = Panel1.Top - 20
            score = score - 2
        End If

        villian1.Top += vspeed
        villian2.Top += vspeed
        villian3.Top += vspeed
        villian4.Top += vspeed
    End Sub

    Private Sub start()
        level.Text = "1"
        time.Enabled = True
        hero.Image = My.Resources.happy
        Button1.Enabled = False
    End Sub

    Private Sub checkhit()
        If ((hero.Top + hero.Height >= villian1.Top) And (hero.Top <= villian1.Top + villian1.Height) And (hero.Left + hero.Width >= villian1.Left) And (hero.Left <= villian1.Left + villian1.Width)) Then
            hero.Image = My.Resources.angry
            Beep()
            time.Enabled = False
            Button1.Enabled = True

            touchvillian1 = True
            touchvillian2 = False
            touchvillian3 = False
            touchvillian4 = False

            redrop()
            life = life - 1
            checklife()
        End If
        If ((hero.Top + hero.Height >= villian2.Top) And (hero.Top <= villian2.Top + villian2.Height) And (hero.Left + hero.Width >= villian2.Left) And (hero.Left <= villian2.Left + villian2.Width)) Then
            hero.Image = My.Resources.angry
            Beep()
            time.Enabled = False
            Button1.Enabled = True

            touchvillian2 = True
            touchvillian3 = False
            touchvillian1 = False
            touchvillian4 = False

            redrop()
            life = life - 1
            checklife()
        End If

        If ((hero.Top + hero.Height >= villian3.Top) And (hero.Top <= villian3.Top + villian3.Height) And (hero.Left + hero.Width >= villian3.Left) And (hero.Left <= villian3.Left + villian3.Width)) Then
            hero.Image = My.Resources.angry
            Beep()
            time.Enabled = False
            Button1.Enabled = True

            touchvillian3 = True
            touchvillian2 = False
            touchvillian1 = False
            touchvillian4 = False

            redrop()
            life = life - 1
            checklife()
        End If
        If ((hero.Top + hero.Height >= villian4.Top) And (hero.Top <= villian4.Top + villian4.Height) And (hero.Left + hero.Width >= villian4.Left) And (hero.Left <= villian4.Left + villian4.Width)) Then
            hero.Image = My.Resources.angry
            Beep()
            time.Enabled = False
            Button1.Enabled = True

            touchvillian4 = True
            touchvillian3 = False
            touchvillian2 = False
            touchvillian1 = False

            redrop()
            life = life - 1
            checklife()
        End If

        'This is for the bullet
        If ((bullet.Top + bullet.Height >= villian1.Top) And (bullet.Top <= villian1.Top + villian1.Height) And (bullet.Left + bullet.Width >= villian1.Left) And (bullet.Left <= villian1.Left + villian1.Width) And bullet.Visible = True) Then
            bullet.Visible = False
            score = score + 5

            touchvillian1 = True
            touchvillian2 = False
            touchvillian3 = False
            touchvillian4 = False
            redrop()
        End If
        If ((bullet.Top + bullet.Height >= villian2.Top) And (bullet.Top <= villian2.Top + villian2.Height) And (bullet.Left + bullet.Width >= villian2.Left) And (bullet.Left <= villian2.Left + villian2.Width) And bullet.Visible = True) Then
            bullet.Visible = False
            score = score + 5

            touchvillian2 = True
            touchvillian3 = False
            touchvillian1 = False
            touchvillian4 = False
            redrop()
        End If
        If ((bullet.Top + bullet.Height >= villian3.Top) And (bullet.Top <= villian3.Top + villian3.Height) And (bullet.Left + bullet.Width >= villian3.Left) And (bullet.Left <= villian3.Left + villian3.Width) And bullet.Visible = True) Then
            bullet.Visible = False
            score = score + 5

            touchvillian3 = True
            touchvillian2 = False
            touchvillian1 = False
            touchvillian4 = False
            redrop()
        End If
        If ((bullet.Top + bullet.Height >= villian4.Top) And (bullet.Top <= villian4.Top + villian4.Height) And (bullet.Left + bullet.Width >= villian4.Left) And (bullet.Left <= villian4.Left + villian4.Width) And bullet.Visible = True) Then
            bullet.Visible = False
            score = score + 5

            touchvillian4 = True
            touchvillian3 = False
            touchvillian2 = False
            touchvillian1 = False
            redrop()
        End If

        'This is for bullet1
        If ((bullet1.Top + bullet1.Height >= villian1.Top) And (bullet1.Top <= villian1.Top + villian1.Height) And (bullet1.Left + bullet1.Width >= villian1.Left) And (bullet1.Left <= villian1.Left + villian1.Width) And bullet1.Visible = True) Then
            bullet1.Visible = False
            score = score + 5

            touchvillian1 = True
            touchvillian2 = False
            touchvillian3 = False
            touchvillian4 = False
            redrop()
        End If
        If ((bullet1.Top + bullet1.Height >= villian2.Top) And (bullet1.Top <= villian2.Top + villian2.Height) And (bullet1.Left + bullet1.Width >= villian2.Left) And (bullet1.Left <= villian2.Left + villian2.Width) And bullet1.Visible = True) Then
            bullet1.Visible = False
            score = score + 5

            touchvillian2 = True
            touchvillian3 = False
            touchvillian1 = False
            touchvillian4 = False
            redrop()
        End If
        If ((bullet1.Top + bullet1.Height >= villian3.Top) And (bullet1.Top <= villian3.Top + villian3.Height) And (bullet1.Left + bullet1.Width >= villian3.Left) And (bullet1.Left <= villian3.Left + villian3.Width) And bullet1.Visible = True) Then
            bullet1.Visible = False
            score = score + 5

            touchvillian3 = True
            touchvillian2 = False
            touchvillian1 = False
            touchvillian4 = False
            redrop()
        End If
        If ((bullet1.Top + bullet1.Height >= villian4.Top) And (bullet1.Top <= villian4.Top + villian4.Height) And (bullet1.Left + bullet1.Width >= villian4.Left) And (bullet1.Left <= villian4.Left + villian4.Width) And bullet1.Visible = True) Then
            bullet1.Visible = False
            score = score + 5

            touchvillian4 = True
            touchvillian3 = False
            touchvillian2 = False
            touchvillian1 = False
            redrop()
        End If
    End Sub

    Private Sub redrop()
        If touchvillian1 = True Then
            villian1.Location = Panel1.Location
            villian1.Left += 190
        End If
        If touchvillian2 = True Then
            villian2.Location = Panel1.Location
            villian2.Left += 110
        End If
        If touchvillian3 = True Then
            villian3.Location = Panel1.Location
            villian3.Left -= 40
        End If
        If touchvillian4 = True Then
            villian4.Location = Panel1.Location
            villian4.Left += 30
        End If
    End Sub

    Private Sub checklife()
        If life = 5 Then
            life1.BackColor = Color.Green
            life2.BackColor = Color.Green
            life3.BackColor = Color.Green
            life4.BackColor = Color.Green
            life5.BackColor = Color.Green
        ElseIf life = 4 Then
            life1.BackColor = Color.Red
        ElseIf life = 3 Then
            life2.BackColor = Color.Red
        ElseIf life = 2 Then
            life3.BackColor = Color.Red
        ElseIf life = 1 Then
            life4.BackColor = Color.Red
        ElseIf life = 0 Then
            life5.BackColor = Color.Red

            time.Enabled = False
            status.Visible = True
            status.Text = "Game Over"
            status.ForeColor = Color.Red
            Button1.Enabled = False

            score = CInt(score)
            MessageBox.Show("Your score is  " & score & ".", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If (MessageBox.Show("Play Again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes) Then
                time.Enabled = False
                Button1.Enabled = False
                restart()
            Else
                MessageBox.Show("Please confirm exit", "Exit", MessageBoxButtons.OK)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub restart()
        life1.BackColor = Color.Green
        life2.BackColor = Color.Green
        life3.BackColor = Color.Green
        life4.BackColor = Color.Green
        life5.BackColor = Color.Green

        hero.Left = 118
        hero.Top = 269
        villian1.Top = 14
        villian1.Left = 237
        villian2.Top = -1
        villian2.Left = 151
        villian3.Top = -16
        villian3.Left = 8
        villian4.Top = 39
        villian4.Left = 74

        vspeed = 1
        hspeed = 2
        bspeed = 4

        status.Visible = False
        time.Enabled = True
        Button1.Enabled = True
        hero.Image = My.Resources.happy
        life = 5
        score = 0
        checkhit()
        level.Text = "1"
    End Sub

    Private Sub movebullet()
        If bullet.Visible = True Then
            bullet.Top -= bspeed
        End If
        If bullet.Top + bullet.Height < Panel1.Top Then
            bullet.Visible = False
        End If
        If bullet1.Visible = True Then
            bullet1.Top -= bspeed
        End If
        If bullet1.Top + bullet.Height < Panel1.Top Then
            bullet1.Visible = False
        End If
    End Sub

    Private Sub checklevel()
        If score > 100 And score <= 300 Then
            level.Text = "2"
            vspeed = vspeed + 0.0001
            hspeed = hspeed + 0.0002
            bspeed = bspeed + 0.0002
        End If
        If score > 300 And score <= 600 Then
            level.Text = "3"
            vspeed = vspeed + 0.0001
            hspeed = hspeed + 0.0002
            bspeed = bspeed + 0.0002
        End If
        If score > 600 And score <= 1000 Then
            level.Text = "4"
            vspeed = vspeed + 0.0001
            hspeed = hspeed + 0.0002
            bspeed = bspeed + 0.0002
        End If
        If score > 1000 And score <= 1500 Then
            level.Text = "5"
            vspeed = vspeed + 0.0001
            hspeed = hspeed + 0.0002
            bspeed = bspeed + 0.0002
        End If
        If score > 1500 And score <= 2100 Then
            level.Text = "6"
            vspeed = vspeed + 0.0001
            hspeed = hspeed + 0.0002
            bspeed = bspeed + 0.0002
        End If
        If score > 2100 And score <= 2800 Then
            level.Text = "7"
            vspeed = vspeed + 0.0001
            hspeed = hspeed + 0.0002
            bspeed = bspeed + 0.0002
        End If
        If score > 2800 And score <= 3500 Then
            level.Text = "8"
            vspeed = vspeed + 0.0001
            hspeed = hspeed + 0.0002
            bspeed = bspeed + 0.0002
        End If
        If score > 3500 And score <= 4400 Then
            level.Text = "9"
            vspeed = vspeed + 0.0001
            hspeed = hspeed + 0.0002
            bspeed = bspeed + 0.0002
        End If
        If score > 4400 And score <= 5500 Then
            level.Text = "10"
            vspeed = vspeed + 0.0001
            hspeed = hspeed + 0.0002
            bspeed = bspeed + 0.0002
        End If
        If score >= 5500 Then
            time.Enabled = False
            status.Visible = True
            status.ForeColor = Color.Green
            status.Text = "Congratulxations Hero"
            Button1.Enabled = False

            score = CInt(score)
            MessageBox.Show("Your score is  " & score & ".", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If (MessageBox.Show("Play Again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes) Then
                time.Enabled = False
                Button1.Enabled = False
                restart()
            Else
                MessageBox.Show("Please confirm exit", "Exit", MessageBoxButtons.OK)
                Me.Close()
            End If
        End If
    End Sub

End Class
