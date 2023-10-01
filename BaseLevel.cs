using PICO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PICO
{
    public partial class BaseLevel : Base
    {
        public BaseLevel()
        {
            InitializeComponent();
            pauseOptions = new List<Panel>() { pauseOption0, pauseOption1 };
            
            this.Deaths = 0;
            this.Berries = 0;
            this.timerTicks = 0;
            HidePauseMenu();
        }

        // General
        private bool isPaused;

        private int _currentPauseOption = 0;
        private int currentPauseOption
        {
            get { return _currentPauseOption; }
            set
            {
                _currentPauseOption = value < 0 ? 1 : value > 1 ? 0 : value;
            }
        }
        private int pauseChangeCooldown = 0;
        private List<Panel> pauseOptions;


        //private bool isLocked = false;
        private bool hasHitEscape;
        protected int timerTicks = 0;

        // Collectibles
        private int _berries = 0;
        private int _deaths = 0;

        public int Berries
        {
            get { return _berries; }
            set
            {
                _berries = value;
                berryCount.Text = value + " x";
            }
        }
        public int Deaths
        {
            get { return _deaths; }
            set
            {
                _deaths = value;
                deathCount.Text = value + " x";
            }
        }

        private List<PictureBox> walls = new List<PictureBox>();

        // Direction and control variables
        private int facingRight;
        private int inputX = 0;
        private int inputY = 0;
        private UserInputs userInputs = new();

        // Speed, gravity, velocity ?
        //private int maxRunningSpeed = 7;
        //private int maxFallingSpeed = 7;
        //private int speedX;
        //private int speedY;

        // Jump related
        private int currentJumpFrame;
        private int jumpDuration = 25;
        // WallJump related
        //private int currentWJumpFrame = 0;
        //private int dJumpDuration;
        private bool isWallJumping = false;
        private Direction wallJumpDirection;

        private bool willRestart = false;
        private int restartCountdown;

        private int snowBallSpeed = -8;
        private bool snowBallHasBeenTriggered = false;
        private int snowBallCooldown = -1;

        private enum Direction
        {
            Top,
            Right,
            Bottom,
            Left
        }

        // Temporary
        private float gravity = 0.8f;
        private float jumpSpeed = 7f;
        private bool hasHitApex;
        private bool hasPressedJumpKey;
        //private bool hasPressedDashKey;

        private string[] menuOptions = { "", "Reset Pico-8" };


        public void GetAllControlsWithParameters(string cTag)
        {
            foreach (Control c in this.Controls)
            {
                if (c is not PictureBox)
                {
                    continue;
                }

                if (c.Tag as string == "wall")
                {
                    walls.Add((PictureBox)c);
                }
            }
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            if (isPaused)
            {
                ShowPauseMenu();
                return;
            }

            timerTicks++;
            timeElapsed.Text = GetElapsedTime(timerTicks);
            UpdateDirectionValues();
            player.IsGrounded = isAgainstControl(Direction.Bottom, player);

            if (willRestart)
            {
                if (restartCountdown > 0)
                {
                    restartCountdown--;
                    return;
                }
                else
                {
                    restartCountdown = 0;
                    willRestart = false;
                    player.Location = player.SpawnPoint;
                    player.Visible = true;
                    isWallJumping = false;
                    currentJumpFrame = 0;
                    snowball.Top = player.Top;
                    return;
                }
            }

            if (isIdle())
            {
                player.Animate(0, 0, facingRight);
            }
            else if (player.IsGrounded)
            {
                if (inputY == 1)
                {
                    player.Animate(5, 5, facingRight);
                }
                else if (inputY == -1)
                {
                    player.Animate(4, 4, facingRight);
                }
                else if (inputX != 0)
                {
                    player.Animate(0, 3, facingRight);
                }
            }
            else
            {
                player.Animate(0, 0, facingRight);
            }

            if (inputX != 0 && !isWallJumping)
            {
                MoveInDirection(inputX > 0 ? Direction.Right : Direction.Left, 5);
            }

            if (currentJumpFrame != 0)
            {
                Jump();
            }
            else if (inputX != 0 && !player.IsGrounded &&
                       isAgainstControl(inputX == 1 ? Direction.Right : Direction.Left, player))
            {
                MoveInDirection(Direction.Bottom, (int)Math.Floor(jumpSpeed / 2));
                player.Animate(6, 6, facingRight);
            }
            else
            {
                MoveInDirection(Direction.Bottom, (int)Math.Ceiling(jumpSpeed));
            }



            if (inputX != 0 && snowBallCooldown == -1 && currentRoom != 4)
            {
                snowBallCooldown = 0;
            }

            if (snowBallCooldown == 0)
            {
                if (!snowBallHasBeenTriggered)
                {
                    snowball.Top = player.Top;
                    snowBallHasBeenTriggered = true;
                }
                snowball.Visible = true;
                snowball.Left += snowBallSpeed;
                if (snowball.Left + snowball.Width < 0)
                {
                    snowBallCooldown = 30;
                    snowball.Left = 513;
                    snowball.Visible = false;
                    snowBallHasBeenTriggered = false;
                }
            }
            else if (snowBallCooldown > 0)
            {
                snowBallCooldown--;
            }

            if (!player.IsGrounded && isAboveSnowball())
            {
                currentJumpFrame = 1;
                isWallJumping = false;
            }
            else if (player.Bounds.IntersectsWith(snowball.Bounds))
            {
                Deaths++;
                player.Visible = false;
                willRestart = true;
                restartCountdown = 20;
                snowball.Visible = false;
                snowBallCooldown = -1;
                snowball.Left = 513;
            }

            if (player.Top > 512 - player.Height)
            {
                Deaths++;
                player.Visible = false;
                willRestart = true;
                restartCountdown = 20;
                snowball.Visible = false;
                snowBallCooldown = -1;
                snowball.Left = 513;
                return;
            } else if (player.Top < 0 && currentRoom != 4)
            {
                OpenNextWindow(currentRoom + 1, timerTicks, Deaths, Berries);
                return;
            }

            foreach (Control c in this.Controls)
            {
                if (c is not PictureBox)
                {
                    continue;
                }

                if (player.Bounds.IntersectsWith(c.Bounds) && c.Tag as string == "golden" && currentRoom == 4)
                {
                    OpenNextWindow(currentRoom + 1, timerTicks, Deaths, Berries);
                }
                if (player.Bounds.IntersectsWith(c.Bounds) && c.Tag as string == "berry")
                {
                    if (c.Visible)
                    {
                        Berries++;
                        c.Visible = false;
                    }
                }
                if (player.Bounds.IntersectsWith(c.Bounds) && (c.Tag as string == "spikes"))
                {
                    Deaths++;
                    player.Visible = false;
                    willRestart = true;
                    restartCountdown = 20;
                    snowball.Visible = false;
                    snowBallCooldown = -1;
                    snowball.Left = 513;
                }
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q || e.KeyCode == Keys.Left)
            {
                userInputs.Left = true;
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                userInputs.Right = true;
            }

            if (e.KeyCode == Keys.Z || e.KeyCode == Keys.Up)
            {
                userInputs.Up = true;
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                userInputs.Down = true;
            }
            if (e.KeyCode == Keys.Space && !hasPressedJumpKey && player.IsGrounded)
            {
                hasPressedJumpKey = true;
                currentJumpFrame = 1;
                isWallJumping = false;
            }
            if (e.KeyCode == Keys.Space && !hasPressedJumpKey && isAgainstControl(inputX > 0 ? Direction.Right : Direction.Left, player) && !player.IsGrounded)
            {
                hasPressedJumpKey = true;
                currentJumpFrame = 1;
                isWallJumping = true;
                wallJumpDirection = inputX > 0 ? Direction.Left : Direction.Right;
            }

            if (e.KeyCode == Keys.Enter && !hasHitEscape)
            {
                hasHitEscape = true;
                if (currentPauseOption == 1 && isPaused)
                {
                    OpenNextWindow(0);
                }
                isPaused = !isPaused;
            }

            if (e.KeyCode == Keys.Escape && !hasHitEscape)
            {
                hasHitEscape = true;
                isPaused = !isPaused;
            }
        }



        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q || e.KeyCode == Keys.Left)
            {
                userInputs.Left = false;
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                userInputs.Right = false;
            }

            if (e.KeyCode == Keys.Z || e.KeyCode == Keys.Up)
            {
                userInputs.Up = false;
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                userInputs.Down = false;
            }
            if (e.KeyCode == Keys.Space && hasPressedJumpKey)
            {
                hasPressedJumpKey = false;
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                hasHitEscape = false;
            }
        }




        private void MoveInDirection(Direction direction, int distance)
        {
            Rectangle theoreticalBounds;
            switch (direction)
            {
                case Direction.Right:
                    theoreticalBounds = new Rectangle(player.Left + distance, player.Top, player.Width,
                        player.Height);
                    foreach (var wall in walls)
                    {

                        if (HasSideIntersecting(Direction.Right, theoreticalBounds, wall.Bounds))
                        {
                            distance = wall.Left - (player.Left + player.Width);
                        }
                        else if (theoreticalBounds.Right > 512)
                        {
                            distance = 512 - (player.Left + player.Width);
                        }
                    }

                    player.Left += distance;
                    break;
                case Direction.Left:
                    theoreticalBounds = new Rectangle(player.Left - distance, player.Top, player.Width,
                        player.Height);
                    foreach (var wall in walls)
                    {

                        if (HasSideIntersecting(Direction.Left, theoreticalBounds, wall.Bounds))
                        {
                            distance = player.Left - (wall.Left + wall.Width);
                        }
                        else if (theoreticalBounds.Left < 0)
                        {
                            distance = player.Left;
                        }
                    }
                    player.Left -= distance;
                    break;
                case Direction.Top:
                    theoreticalBounds = new Rectangle(player.Left, player.Top - distance, player.Width,
                        player.Height);
                    foreach (var wall in walls)
                    {

                        if (HasSideIntersecting(Direction.Top, theoreticalBounds, wall.Bounds))
                        {
                            distance = player.Top - (wall.Top + wall.Height);
                            currentJumpFrame = jumpDuration;
                            isWallJumping = false;
                        }
                        else if (theoreticalBounds.Top < 0 && currentRoom == 4)
                        {
                            distance = player.Top;
                        }
                    }
                    player.Top -= distance;
                    break;

                case Direction.Bottom:
                    theoreticalBounds = new Rectangle(player.Left, player.Top + distance, player.Width,
                        player.Height);
                    foreach (var wall in walls)
                    {
                        if (HasSideIntersecting(Direction.Bottom, theoreticalBounds, wall.Bounds))
                        {
                            distance = wall.Top - player.Top - player.Height;
                        }
                    }

                    if (HasSideIntersecting(Direction.Bottom, theoreticalBounds, snowball.Bounds))
                    {
                        distance = snowball.Top - player.Top - player.Height;
                    }
                    player.Top += distance;
                    break;
            }

        }

        private bool isIdle()
        {
            return inputX == 0 && inputY == 0;
        }

        private static bool HasSideIntersecting(Direction direction, Rectangle source, Rectangle target)
        {
            if (!source.IntersectsWith(target))
            {
                return false;
            }
            if (direction == Direction.Top)
            {
                return source.Top >= target.Top && source.Top <= target.Bottom + 1;
            }

            if (direction == Direction.Left)
            {
                return source.Left >= target.Left && source.Left <= target.Right + 1;
            }

            if (direction == Direction.Right)
            {
                return source.Right >= target.Left - 1 && source.Right <= target.Right;
            }

            return source.Bottom >= target.Top - 1 && source.Bottom <= target.Bottom;
        }

        private bool HasSideIntersectingWithAny(Direction direction, Rectangle source, string tag = "wall")
        {
            foreach (Control c in Controls)
            {
                if (c is not PictureBox || c.Tag as string != tag)
                {
                    continue;
                }

                if (HasSideIntersecting(direction, source, c.Bounds))
                {

                    return true;
                }
            }
            return false;
        }

        public class UserInputs
        {
            public bool Up;
            public bool Down;
            public bool Left;
            public bool Right;
            public bool Dash;
            public bool Jump;
            public bool isLocked;

            public UserInputs()
            {
                Up = Down = Left = Right = Dash = Jump = false;
            }

        }

        public class Player : PictureBox
        {
            public Point DefaultLocation, SpawnPoint;
            public bool IsLocked = true;

            protected int WalkingAnimationFrameRate = 4;
            protected int CurrentSlowDownFrame = 0;
            protected int CurrentAnimationStep = 0;

            public bool IsGrounded;




            public Player()
            {
                BackColor = System.Drawing.Color.Transparent;
                Image = Resources.maddy_4;
                TabStop = false;

                DefaultLocation = new Point(32, 512);
                //SpawnPoint = new Point(32, 384);
                Location = SpawnPoint;
                TabIndex = 1;
                MinimumSize = new System.Drawing.Size(32, 32);
                Size = new System.Drawing.Size(32, 32);

                Name = "player";
                Tag = "player";
            }

            public void SetSpawnPoint(Point Point)
            {
                Location = Point;
                SpawnPoint = Point;
            }

            public void SwitchAnimation(string resourceName)
            {
                if (Resources.ResourceManager.GetObject(resourceName) is not Image img || this.Image == img)
                {
                    return;
                }
                this.Image = img;
            }

            public void Animate(int start, int end, int lookingLeft)
            {
                // Multi frame animation is walking
                if (end > start)
                {
                    CurrentSlowDownFrame += 1;
                    if (CurrentSlowDownFrame == WalkingAnimationFrameRate)
                    {
                        CurrentAnimationStep++;
                        CurrentSlowDownFrame = 0;
                    }

                    if (CurrentAnimationStep > end || CurrentAnimationStep < start)
                    {
                        CurrentAnimationStep = start;
                    }
                }
                else
                {
                    CurrentAnimationStep = start;
                }

                SwitchAnimation($"maddy_{CurrentAnimationStep + (lookingLeft * 7)}");
            }
        };


        public void UpdateDirectionValues()
        {
            inputY = userInputs.Down ? 1 : userInputs.Up ? -1 : 0;
            inputX = userInputs.Right ? 1 : userInputs.Left ? -1 : 0;
            facingRight = inputX == -1 ? 0 : inputX == 1 ? 1 : facingRight;
        }

        public void Jump()
        {
            int risingThreshHold = (int)(jumpDuration * gravity / 2);
            int midPoint = (int)Math.Ceiling(jumpDuration / 2.0);
            int slowInterval = midPoint - risingThreshHold - 1;


            if (currentJumpFrame > 0 && currentJumpFrame <= risingThreshHold)
            {
                MoveInDirection(Direction.Top, (int)Math.Ceiling(jumpSpeed));
                if (isWallJumping)
                {
                    MoveInDirection(wallJumpDirection, 5);
                }
                currentJumpFrame++;
                return;
            }
            else if (currentJumpFrame == midPoint)
            {
                if (isWallJumping)
                {
                    MoveInDirection(inputX == -1 ? Direction.Left : Direction.Right, 5);
                }
                currentJumpFrame++;
                isWallJumping = false;
                return;

            }
            else if (currentJumpFrame > risingThreshHold && currentJumpFrame < midPoint)
            {
                MoveInDirection(Direction.Top,
                    (int)Math.Round(jumpSpeed / (2 * (currentJumpFrame - risingThreshHold))));
                currentJumpFrame++;
                return;

            }
            else if (currentJumpFrame > midPoint && currentJumpFrame <= midPoint + slowInterval)
            {
                MoveInDirection(Direction.Top,
                    (int)Math.Round(jumpSpeed / (2 * (midPoint + slowInterval + 1 - currentJumpFrame))));
                currentJumpFrame++;
                return;
            }

            currentJumpFrame = 0;
        }

        private bool isAboveSnowball()
        {
            Rectangle temp = new Rectangle(player.Left, player.Top + 1, player.Width, player.Height);
            return (!player.Bounds.IntersectsWith(snowball.Bounds) && temp.IntersectsWith(snowball.Bounds));

        }
        private bool isAgainstControl(Direction direction, PictureBox source)
        {
            Rectangle temp = new Rectangle(player.Location, player.Size);
            switch (direction)
            {
                case Direction.Top:
                    temp.Y -= 1;
                    break;
                case Direction.Left:
                    temp.X -= 1;
                    break;
                case Direction.Right:
                    temp.X += 1;
                    break;
                default:
                    temp.Y += 1;
                    break;
            }

            return HasSideIntersectingWithAny(direction, temp);
        }

        private void pauseTimer_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                HidePauseMenu();
            }
            UpdateDirectionValues();

            pauseChangeCooldown = pauseChangeCooldown < 0 ? 0 : pauseChangeCooldown - 1;
            if (pauseChangeCooldown == 0 && inputY != 0)
            {
                if (inputY > 0)
                {
                    currentPauseOption++;
                }
                else
                {
                    currentPauseOption--;
                }

                pauseChangeCooldown = 4;
                UpdatePauseOption();
            }
        }

        private void UpdatePauseOption()
        {
            for (int i = 0; i < pauseOptions.Count; i++)
            {
                if (i == currentPauseOption)
                {
                    pauseOptions[i].Controls.OfType<Label>().First().ForeColor = Color.White;
                    continue;
                }
                pauseOptions[i].Controls.OfType<Label>().First().ForeColor = Color.FromArgb(96, 96, 96);
            }
        }

        private void ShowPauseMenu()
        {
            pausePanel.Visible = true;
            mainTimer.Stop();
            pauseTimer.Start();
        }

        private void HidePauseMenu()
        {
            pausePanel.Visible = false;
            pauseTimer.Stop();
            mainTimer.Start();
            currentPauseOption = 0;
            UpdatePauseOption();
        }

        private void berryCount_TextChanged(object sender, EventArgs e)
        {
            berryCount.Location = new Point(468 - berryCount.Width, berryCount.Top);
        }

        private void deathCount_TextChanged(object sender, EventArgs e)
        {
            deathCount.Location = new Point(468 - deathCount.Width, deathCount.Top);
        }

        private void pausa_TextChanged(object sender, EventArgs e)
        {
            pausa.Location = new Point(110, pausa.Top);
        }

        protected void ReorderControls()
        {
            foreach (Control c in Controls)
            {
                if (c == player || c == pausePanel || c == snowball || c == timeElapsed)
                {
                    c.BringToFront();
                }
            }
        }
    }
}
