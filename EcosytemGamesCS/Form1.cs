using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcosytemGamesCS
{
 
    public partial class Form1 : Form
    {
        int lionSpeed;
        int[] lapinSpeed = new int[7];
        PictureBox[] lapin;
        PictureBox[] carrot;
        PictureBox lac;

        Random rnd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lionSpeed = 2;
            rnd = new Random();

            for (int i = 0; i < lapinSpeed.Length; i++)
            {
                lapinSpeed[i] = rnd.Next(1, 6);
            }

            Image lapinPic = Image.FromFile(@"photo\lapin.png");
            Image carrotPic = Image.FromFile(@"photo\carrot.png");
            Image lacPic = Image.FromFile(@"photo\lac.png");

            lapin = new PictureBox[7];
            carrot = new PictureBox[10];
            
            lac = new PictureBox();
            lac.Image = lacPic;
            lac.Size = new Size(200, 200);
            lac.SizeMode = PictureBoxSizeMode.Zoom;
            lac.BorderStyle = BorderStyle.None;
            lac.Visible = Visible;

            do
            {
                lac.Location = new Point(rnd.Next(100, 800), rnd.Next(100, 600));
            } while (isOverlap(lion, lac));

            this.Controls.Add(lac);

            for (int i = 0; i < lapin.Length; i++)
            {
                PictureBox newLapin = new PictureBox();
                newLapin.Size = new Size(30, 30);
                newLapin.SizeMode = PictureBoxSizeMode.Zoom;
                newLapin.BorderStyle = BorderStyle.None;
                newLapin.Visible = Visible;
                do
                {
                    newLapin.Location = new Point(rnd.Next(0, 600), rnd.Next(0, 600));
                }
                while (isOverlap(newLapin, lac) == true ||
                       isOverlap(newLapin, lion) == true ||
                       isOverlapGroup(newLapin, lapin) == true);

                lapin[i] = newLapin;
                this.Controls.Add(lapin[i]);
            }

            for (int i = 0; i < lapin.Length; i++)
            {
                lapin[i].Image = lapinPic;
            }

            for (int i = 0; i < carrot.Length; i++)
            {
                PictureBox newCarrot = new PictureBox();
                newCarrot.Size = new Size(25, 25);
                newCarrot.SizeMode = PictureBoxSizeMode.Zoom;
                newCarrot.BorderStyle = BorderStyle.None;
                newCarrot.Visible = Visible;

                do
                {
                    newCarrot.Location = new Point(rnd.Next(0, 600), rnd.Next(0, 600));
                }
                while (isOverlap(newCarrot, lac) == true ||
                       isOverlap(newCarrot, lion) == true ||
                       isOverlapGroup(newCarrot, lapin) == true ||
                       isOverlapGroup(newCarrot, carrot));

                carrot[i] = newCarrot;
                this.Controls.Add(carrot[i]);
            }

            for (int i = 0; i < carrot.Length; i++)
            {
                carrot[i].Image = carrotPic;
            }
        }

        private void moveLeftTmr_Tick(object sender, EventArgs e)
        {
            if (lion.Left > 0)
            {
                lion.Left -= lionSpeed;
            }
        }

        private void moveRightTmr_Tick(object sender, EventArgs e)
        {
            if (lion.Right < 1000)
            {
                lion.Left += lionSpeed;
            }
        }

        private void moveUpTmr_Tick(object sender, EventArgs e)
        {
            if (lion.Top > 10)
            {
                lion.Top -= lionSpeed;
            }
        }

        private void moveDownTmr_Tick(object sender, EventArgs e)
        {
            if (lion.Top < 600)
            {
                lion.Top += lionSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                moveRightTmr.Start();
            }
            if (e.KeyCode == Keys.Left)
            {
                moveLeftTmr.Start();
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUpTmr.Start();
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDownTmr.Start();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            moveRightTmr.Stop();
            moveLeftTmr.Stop();
            moveUpTmr.Stop();
            moveDownTmr.Stop();
        }
        
        bool isOverlap(PictureBox p1, PictureBox p2)
        {
            if(p1.Bounds.IntersectsWith(p2.Bounds))
            {
                return true;
            }
            return false;
        }

        bool isOverlapGroup(PictureBox p1, PictureBox[] group)
        {
            for(int i = 0; i < group.Length; i++)
            {
                if (group[i] != null && p1.Bounds.IntersectsWith(group[i].Bounds))
                {
                    return true;
                }
            }        
            return false;
        }

        private void moveLapinTmr_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < lapin.Length; i++)
            {
                switch(lionClose(lapin[i]))
                {
                    case 1: // Left
                        if (lionClose(lapin[i]) == 1)
                        {
                            lapin[i].Left = lapin[i].Left + lapinSpeed[i];
                            lapin[i].Top = lapin[i].Top + lapinSpeed[i];
                        }
                        else if (carrotClose(carrot[i], lapin[i]) == 1)
                            lapin[i].Left = lapin[i].Left + lapinSpeed[i];
                        else
                            lapin[i].Left = lapin[i].Left - lapinSpeed[i];
                        break;
                    case 2: // Right
                        if (lionClose(lapin[i]) == 2)
                        {
                            lapin[i].Left = lapin[i].Left - lapinSpeed[i];
                            lapin[i].Top = lapin[i].Top + lapinSpeed[i];
                        }
                        else if (carrotClose(carrot[i], lapin[i]) == 2)
                            lapin[i].Left = lapin[i].Left - lapinSpeed[i];
                        else lapin[i].Left = lapin[i].Left + lapinSpeed[i];
                        break;
                    case 3: // Up
                        if(lionClose(lapin[i]) == 3)
                        {
                            lapin[i].Top = lapin[i].Top - lapinSpeed[i];
                            lapin[i].Left = lapin[i].Left + lapinSpeed[i];
                        }
                        else if (carrotClose(carrot[i], lapin[i]) == 3)
                                lapin[i].Top = lapin[i].Top - lapinSpeed[i];
                           else lapin[i].Top = lapin[i].Top - lapinSpeed[i];
                        break;
                    case 4: // Down
                        if(lionClose(lapin[i]) == 4)
                        {
                            lapin[i].Top = lapin[i].Top - lapinSpeed[i];
                            lapin[i].Left = lapin[i].Left - lapinSpeed[i];
                        }
                        else if (carrotClose(carrot[i], lapin[i]) == 4)
                                 lapin[i].Top = lapin[i].Top - lapinSpeed[i];
                            else lapin[i].Top = lapin[i].Top + lapinSpeed[i];
                        break;
                }
            }

            for (int i = 0; i < lapin.Length; i++)
            {
                switch (rnd.Next(1, 4))
                {
                    case 1: // Left
                        if (carrotClose(carrot[i], lapin[i]) == 1)
                            lapin[i].Left = lapin[i].Left - lapinSpeed[i];
                        else
                            lapin[i].Left = lapin[i].Left + lapinSpeed[i];
                        break;
                    case 2: // Right
                        if (carrotClose(carrot[i], lapin[i]) == 2)
                            lapin[i].Left = lapin[i].Left + lapinSpeed[i];
                        else
                            lapin[i].Left = lapin[i].Left - lapinSpeed[i];
                        break;
                    case 3: // Up
                        if (carrotClose(carrot[i], lapin[i]) == 3)
                            lapin[i].Top = lapin[i].Top - lapinSpeed[i];
                        else
                            lapin[i].Top = lapin[i].Top + lapinSpeed[i];
                        break;
                    case 4: // Down
                        if (carrotClose(carrot[i], lapin[i]) == 4)
                            lapin[i].Top = lapin[i].Top + lapinSpeed[i];
                        else
                            lapin[i].Top = lapin[i].Top - lapinSpeed[i];
                        break;
                }
            }
        }

        private int lionClose(PictureBox lapin)
        {
            if (lion.Left < lapin.Left && lapin.Left - lion.Left < 100 && lion.Top < lapin.Top &&
                lapin.Top - lion.Top < 100)
            {
                return 1; // lion close to the Topleft
            }
            else if (lion.Right > lapin.Right && lion.Right - lapin.Right < 100 && lion.Top < lapin.Top &&
                lapin.Top - lion.Top < 100)
            {
                return 2; // lion close to the Topright
            }
            else if (lion.Bottom > lapin.Bottom && lion.Bottom - lapin.Bottom < 100 && lion.Left < lapin.Left &&
                lapin.Left - lion.Left < 100)
            {
                return 3; // lion close to the bottomLeft
            }
            else if (lion.Bottom > lapin.Bottom && lion.Bottom - lapin.Bottom < 100 &&
                lion.Right > lapin.Right && lion.Right - lapin.Right < 100)
            {
                return 4; // lion close to the bottomRight
            }
            else
            {
                return 0;
            }
        }

        private int carrotClose(PictureBox carrot, PictureBox lapin)
        {
            if (carrot.Left < lapin.Left && lapin.Left - carrot.Left < 200)
            {
                return 1; // carrot close to the left
            }
            else if (carrot.Left > lapin.Left && carrot.Left - lapin.Left < 200)
            {
                return 2; // carrot close to the right
            }
            else if (carrot.Top < lapin.Top && lapin.Top - carrot.Top < 200)
            {
                return 3; // carrot close to the top
            }
            else if (carrot.Top > lapin.Top && carrot.Top - lapin.Top < 200)
            {
                return 4; // carrot close to the bottom
            }
            return 0;
        }

        private void collisionLionLapin()
        {
            for(int i = 0; i < lapin.Length; i++)
            {
                if (lapin[i].Bounds.IntersectsWith(lion.Bounds))
                {
                    lapin[i].Visible = false;
                    lionSpeed++;
                }
            }
        }

        private void collisionLionCarrot()
        {
            for (int i = 0; i < carrot.Length; i++)
            {
                if (carrot[i].Bounds.IntersectsWith(lion.Bounds))
                {
                    carrot[i].Visible = false;
                    lionSpeed--;
                }
            }
        }

        private void lion_Click(object sender, EventArgs e)
        {

        }
    }
}
