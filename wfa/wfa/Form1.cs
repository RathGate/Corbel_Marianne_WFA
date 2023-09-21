using System.Diagnostics;
using System.Media;
using System.Runtime.CompilerServices;

namespace wfa
{
    public partial class Form : System.Windows.Forms.Form
    {
        List<PictureBox> walls = new List<PictureBox>();
        private int currentRoom;
        private bool hasDashed;
        private HashSet<int> berryList;
        private int deaths;

        bool goLeft, goRight, jump, isGameOver;
        private bool goDown, goUp;

        private int jumpCountDown;
        private int jumpSpeed = 7;
        private int maxJumpHeight = 11;
        private bool hasPressedJumpKey = false;
        private int bewwies = 0;
        int force;
        int score = 0;
        int playerSpeed = 5;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        private enum Direction
        {
            Top,
            Right,
            Bottom,
            Left
        }


        public Form()
        {
            InitializeComponent();
            this.GetAllControlsWithParameters("wall");
            
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            test.Text = "bewwies: " + bewwies;
            if (goLeft == true)
            {
                MoveInDirection(Direction.Left, playerSpeed);
            }
            if (goRight == true)
            {
                MoveInDirection(Direction.Right, playerSpeed);
            }

            if (goUp == true)
            {
                MoveInDirection(Direction.Top, jumpSpeed);
            }

            if (jumpCountDown > 0)
            {
                MoveInDirection(Direction.Top, jumpSpeed);
                jumpCountDown--;
            }
            else
            {
                MoveInDirection(Direction.Bottom, jumpSpeed);
            }
            

            if (player.Bounds.IntersectsWith(exit.Bounds))
            {
                this.Controls.Add(new UserControl1());
            }

            //if (jump == true)
            //{
            //    player.Top -= 5;
            //    //jumpSpeed = -8;
            //    force -= 1;
            //}
            //else
            //{
            //    jumpSpeed = 1;
            //}

            foreach (Control c in this.Controls)
            {
                if (c is not PictureBox)
                {
                    return;
                }

                if (player.Bounds.IntersectsWith(c.Bounds) && c.Tag as string == "bewwy")
                {
                    if (c.Visible)
                    {
                        bewwies++;
                        c.Visible = false;
                    } 
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && !hasPressedJumpKey && isGrounded())
            {
                //jump = true;
                hasPressedJumpKey = true;
                jumpCountDown = maxJumpHeight;
            }


        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Space && hasPressedJumpKey)
            {
                //jump = false;
                hasPressedJumpKey = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

        }

        private bool isGrounded()
        {
            var theoreticalBounds = new Rectangle(player.Left, player.Top + 1, player.Width, player.Height);
            foreach (var wall in walls)
            {
                if (HasSideIntersecting(Direction.Bottom, theoreticalBounds, wall.Bounds))
                {
                    return true;
                }
            }

            return false;
        }

        private void ApplyGravity()
        {

            if (!DownInteraction())
            {
                player.Top = OverlapPosition(8);
            }
            
            
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

        public bool DownInteraction()
        {
            foreach (PictureBox wall in walls)
            {
                if (this.player.Bounds.IntersectsWith(wall.Bounds))
                {
                    return true;
                }
            }

            return false;
        }

        public int OverlapPosition(int distance)
        {
            var theoreticalBounds = new Rectangle(player.Left, player.Top + 10, player.Width, player.Height);
            foreach (var wall in walls)
            {
                if (HasSideIntersecting(Direction.Bottom, theoreticalBounds, wall.Bounds))
                {
                    return wall.Top - player.Height;
                }
            }

            return player.Top += distance;
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

        private string KillMe()
        {
            string intersectingSides = "";

            foreach (PictureBox wall in walls)
            {

                if (this.player.Bounds.IntersectsWith(wall.Bounds))
                {
                    intersectingSides += "   " + wall.Name + ": ";
                    foreach (var direction in Enum.GetValues<Direction>())
                    {
                        if (HasSideIntersecting(direction, player.Bounds, wall.Bounds))
                        {
                            intersectingSides += direction + ", ";
                        }
                    }

                    intersectingSides += "\n";
                }

            }


            return intersectingSides;

        }

        private void MoveInDirection(Direction direction, int distance)
        {


                

                //if (direction == Direction.Bottom && HasSideIntersecting(Direction.Bottom, player.Bounds, wall.Bounds))
                //{


                //    Debug.WriteLine(string.Format("{0} {1}", theoreticalBounds.Top, wall.Top));


                //}
                //    if (this.player.Bounds.IntersectsWith(wall.Bounds))
                //    {
                //        intersectingSides += "   " + wall.Name + ": ";
                //        foreach (var direction in Enum.GetValues<Direction>())
                //        {
                //            if (HasSideIntersecting(direction, player.Bounds, wall.Bounds))
                //            {
                //                intersectingSides += direction + ", ";
                //            }
                //        }

                //        intersectingSides += "\n";
                //    }



            

            Debug.WriteLine(distance);



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
    }
}