using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game15Csharp
{
    public partial class FormGame15 : Form
    {
        Game game;

        public FormGame15()
        {
            InitializeComponent();
            game = new Game(4);
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button0_Click(object sender, EventArgs e)
        {
            int position = Convert.ToInt16 (((Button)sender).Tag);
            game.Shift(position);
            GameRefresh();
            if(game.CheckMap())
            {
                MessageBox.Show("You have WIN!");
                StartGame();
            }
           
            //button(position).Text = position.ToString();
            //MessageBox.Show(position.ToString());

        }

        private Button Button (int position)
        {
            switch (position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame ()
        {
            game.Start();
            GameRefresh();
        }

        private void GameRefresh()
        {
            for (int position = 0; position <16; position++)
            {
                Button(position).Text = game.GetNumber(position).ToString();
                Button(position).Visible = (game.GetNumber(position) > 0);
            }
        }

        private void FormGame15_Load(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}
