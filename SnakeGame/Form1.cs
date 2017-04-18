using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        public static void ChangeScreen(string screen, UserControl currentScreen)
        {
            //close current screen
            Form f = currentScreen.FindForm();
            f.Controls.Remove(currentScreen);

            if (screen == "EndScreen")
            {
                EndScreen ns = new EndScreen();
                f.Controls.Add(ns);
                ns.Location = new Point((f.Width - ns.Width) / 2, (f.Height - ns.Height) / 2);
                ns.Focus();
            }
            if (screen == "StartScreen")
            {
                StartScreen ns = new StartScreen();
                f.Controls.Add(ns);
                ns.Location = new Point((f.Width - ns.Width) / 2, (f.Height - ns.Height) / 2);
                ns.Focus();
            }
            if (screen == "GameScreen")
            {
                GameScreen ns = new GameScreen();
                f.Controls.Add(ns);
                ns.Location = new Point((f.Width - ns.Width) / 2, (f.Height - ns.Height) / 2);
                ns.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //open Main Screen
            StartScreen ns = new StartScreen();
            ns.Location = new Point((this.Width - ns.Width) / 2, (this.Height - ns.Height) / 2);
            this.Controls.Add(ns);
        }
    }
}
