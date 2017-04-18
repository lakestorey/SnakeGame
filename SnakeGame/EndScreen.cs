using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class EndScreen : UserControl
    {
        //bools for keypresses
        bool redButtonPressed = false;
        bool greenButtonPressed = false;

        //brushes and fonts
        SolidBrush letterBrush = new SolidBrush(Color.White);
        Font arial28 = new Font("Arial", 28);
        Font arial14 = new Font("Arial", 14);

        int buttonsize = 50;
        Bitmap greenButton;
        Bitmap redButton;


        public EndScreen()
        {
            InitializeComponent();

            greenButton = new Bitmap(Properties.Resources.greenButton, new Size(buttonsize, buttonsize));
            redButton = new Bitmap(Properties.Resources.redButton, new Size(buttonsize, buttonsize));

            endScreenTimer.Start();
        }

        private void EndScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    greenButtonPressed = true;
                    break;
                case Keys.M:
                    redButtonPressed = true;
                    break;
                default:
                    break;
            }
        }

        private void EndScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    greenButtonPressed = false;
                    break;
                case Keys.M:
                    redButtonPressed = false;
                    break;
                default:
                    break;
            }

        }

        private void endScreenTimer_Tick(object sender, EventArgs e)
        {
            if (greenButtonPressed == true)
            {
                endScreenTimer.Stop();
                Form1.ChangeScreen("GameScreen", this);
            }
            if (redButtonPressed == true)
            {
                endScreenTimer.Stop();
                Application.Exit();
            }
        }

        private void EndScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Game Over", arial28, letterBrush, 150, 12);
            e.Graphics.DrawString("Your Score Was " + GameScreen.scoreCount, arial14, letterBrush, 170, 50);
            e.Graphics.DrawString("restart", arial14, letterBrush, 250, 102);
            e.Graphics.DrawImage(greenButton, 200, 92);
            e.Graphics.DrawString("exit", arial14, letterBrush, 250, 192);
            e.Graphics.DrawImage(redButton, 200, 182);
        }
    }
}
