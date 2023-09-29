using System.Diagnostics;
using System.Media;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.ApplicationServices;
using PICO.Properties;
using Image = System.Drawing.Image;
using Timer = System.Threading.Timer;

namespace PICO
{
    public partial class Form1 : Form
    {

        private SoundPlayer backgroundmusic = new SoundPlayer(@"D:\System\Bureau\level.wav");
        // General
        private bool isPaused = false;
        private bool isLocked = false;
        private bool hasHitEscape = false;
        private int timerTicks = 0;

        // Collectibles
        private int berries = 0;
        private int deaths = 0;


        private List<PictureBox> walls = new List<PictureBox>();

        // Direction and control variables
        private int facingRight;
        private int inputX = 0;
        private int inputY = 0;
        private UserInputs userInputs= new();

        // Speed, gravity, velocity ?
        private int maxRunningSpeed = 7;
        private int maxFallingSpeed = 7;
        private int speedX;
        private int speedY;

        // Jump related
        private int currentJumpFrame = 0;
        private int jumpDuration = 25;
        // WallJump related
        private int currentWJumpFrame = 0;
        private int dJumpDuration;
        private bool isWallJumping = false;
        private Direction wallJumpDirection;

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
        private bool hasHitApex = false;
        private bool hasPressedJumpKey = false;
        private bool hasPressedDashKey = false;

        private string[] menuOptions = new[] { "", "Reset Pico-8" };


        public Form1()
        {

            InitializeComponent();
            backgroundmusic.PlayLooping();
            this.GetAllControlsWithParameters("wall");
            pauseTimer.Stop();
            pausa.Visible = false;
            pauseBackground.Visible = false;
            berryCount.Visible = false;
            BerryIcon.Visible = false;
            deathIcon.Visible = false;
            deathCount.Visible = false;
        }
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

        private string getElapsedTime()
        {
            int interval = gameTimer.Interval;
            TimeSpan t = TimeSpan.FromMilliseconds((timerTicks * 25));
            return $"{t.Hours:00}:{t.Minutes:00}:{t.Seconds:00}";
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            if (isPaused)
            {
                gameTimer.Stop();
                pauseTimer.Start();
                pausa.Visible = true;
                
                berryCount.Visible = true;
                BerryIcon.Visible = true;
                deathIcon.Visible = true;
                deathCount.Visible = true;
                pauseBackground.Visible = true;
                Debug.WriteLine(berryCount.Visible);
                return;
            }

            timerTicks++;
            timeElapsed.Text = getElapsedTime();
            UpdateDirectionValues();
            player.IsGrounded = isAgainstControl(Direction.Bottom, player);
            if (isIdle())
            {
                player.Animate(0, 0, facingRight);
            }
            else if (player.IsGrounded)
            {
                if (inputY == 1)
                {
                    player.Animate(5, 5, facingRight);
                } else if (inputY == -1)
                {
                    player.Animate(4, 4, facingRight);
                } else if (inputX != 0)
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
                MoveInDirection(Direction.Bottom, (int)Math.Floor(jumpSpeed/2));
                player.Animate(6, 6, facingRight);
            }
            else
            {
                MoveInDirection(Direction.Bottom, (int)Math.Ceiling(jumpSpeed));
            }

            if (player.Top < 0)
            {
                pauseTimer.Stop();
                gameTimer.Stop();
                pausa.Text = "You won !";
                pausa.Visible = true;
                berryCount.Visible = true;
                BerryIcon.Visible = true;
                deathIcon.Visible = true;
                deathCount.Visible = true;
                pauseBackground.Visible = true;
            }

            foreach (Control c in this.Controls)
            {
                if (c is not PictureBox)
                {
                    continue;
                }
                if (player.Bounds.IntersectsWith(c.Bounds) && c.Tag as string == "berry")
                {
                    if (c.Visible)
                    {
                        berries++;
                        berryCount.Text = "1 x";
                        c.Visible = false;
                    }
                }
                if (player.Bounds.IntersectsWith(c.Bounds) && c.Tag as string == "spikes")
                {
                    deaths++;
                    deathCount.Text = $"{deaths} x";
                    player.Location = new Point(32, 384);
                }
            }

        }

            private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                userInputs.Left = true;
            }

            if (e.KeyCode == Keys.D)
            {
                userInputs.Right = true;
            }

            if (e.KeyCode == Keys.Z)
            {
                userInputs.Up = true;
            }

            if (e.KeyCode == Keys.S)
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

            if (e.KeyCode == Keys.Escape && !hasHitEscape)
            {
                hasHitEscape = true;
                isPaused = !isPaused;
            }
        }


        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                userInputs.Left = false;
            }

            if (e.KeyCode == Keys.D)
            {
                userInputs.Right = false;
            }

            if (e.KeyCode == Keys.Z)
            {
                userInputs.Up = false;
            }

            if (e.KeyCode == Keys.S)
            {
                userInputs.Down = false;
            }
            if (e.KeyCode == Keys.Space && hasPressedJumpKey)
            {
                hasPressedJumpKey = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                hasHitEscape = false;
            }
        }




        private void MoveInDirection(Direction direction, int distance)
        {
            switch (direction)
            {
                case Direction.Right:
                    foreach (var wall in walls)
                    {
                        var theoreticalBounds = new Rectangle(player.Left + distance, player.Top, player.Width,
                            player.Height);
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
                    foreach (var wall in walls)
                    {
                        var theoreticalBounds = new Rectangle(player.Left - distance, player.Top, player.Width,
                            player.Height);
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
                    foreach (var wall in walls)
                    {
                        var theoreticalBounds = new Rectangle(player.Left, player.Top - distance, player.Width,
                            player.Height);
                        if (HasSideIntersecting(Direction.Top, theoreticalBounds, wall.Bounds))
                        {
                            distance = player.Top - (wall.Top + wall.Height);
                            Debug.WriteLine(currentJumpFrame);
                            currentJumpFrame = jumpDuration;
                            isWallJumping = false;
                            Debug.WriteLine(currentJumpFrame);

                        }
                    }
                    player.Top -= distance;
                    break;

                case Direction.Bottom:
                    foreach (var wall in walls)
                    {

                        var theoreticalBounds = new Rectangle(player.Left, player.Top + distance, player.Width,
                             player.Height);
                        if (HasSideIntersecting(Direction.Bottom, theoreticalBounds, wall.Bounds))
                        {
                            distance = wall.Top - player.Top - player.Height;
                        }

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

        private bool HasSideIntersectingWithAny(Direction direction, Rectangle source, string tag="wall"){
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
            protected Point DefaultLocation, SpawnPoint;
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
                hasHitApex = true;
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
                pauseTimer.Stop();
                gameTimer.Start();
                pausa.Visible = false;
                pauseBackground.Visible = false;
                berryCount.Visible = false;
                BerryIcon.Visible = false;
                deathIcon.Visible = false;
                deathCount.Visible = false;
            }
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
    }
}
