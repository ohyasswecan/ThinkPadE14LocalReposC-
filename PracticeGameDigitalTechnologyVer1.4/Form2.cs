using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeGameDigitalTechnologyVer1._4
{
    public partial class Form2 : Form
    {
        bool surviveStatus = true;//This is indicator for the survive status of players
        int firePosition = 0;
        int bulletPosition;
        int Points = 0;//Player own points at current stage.
        int next=10;//reward for next shot.
        public Form2()
        {
            InitializeComponent();
            KeyPreview = true;
            button2_Click(null, null);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//Lock the size of form and avoid the blare when expand
            MaximizeBox = false;//hide expansion button on top right hand side.
            MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form4 = new Form4();
            form4.Location = this.Location;
            form4.StartPosition = FormStartPosition.CenterScreen;
            form4.FormClosing += delegate { this.Show(); };
            form4.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(surviveStatus == false)
            {
                button2_Click(sender, e);// if player is dead then auto-roll and revive.
            }
            firePosition++;
            RoulletStatus(firePosition);
            if (firePosition == bulletPosition)
            {
                pictureBox1.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources.DeathImage;
                surviveStatus = false;
                XmlEditor xmlEditor = new XmlEditor();
                xmlEditor.XmlWriter("russianroulett",Points,1);
                MessageBox.Show("You are dead.");
            }
            else
            {
                Points += next;
                label4.Text = "$" + Points;
                RewardCalculator(next);
                label3.Text = "$" + next;
            }
        }
        private void RewardCalculator(int next)
        {
            next += 10;
            //此处为奖励分数累加的算法，因为随着尝试次数的增加，危险系数急剧增加，因此奖励也应当依此机制依次累加。
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (surviveStatus == false)
            {
                surviveStatus = true;//revive function
                pictureBox1.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources.ImageFromFreeSource;
                Points = 0;//revive and clear old points record.
            }
            Random rand = new Random();
            bulletPosition = rand.Next(1, 6);
            firePosition = 0;
            RoulletStatus(firePosition);
        }

        private void RoulletStatus(int Status)
        {
            switch (Status)
            {
                case 0:
                    {
                        pictureBox2.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources._0fire;
                        break;
                    }
                case 1:
                    {
                        pictureBox2.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources._1fire;
                        break;
                    }
                case 2:
                    {
                        pictureBox2.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources._2fire;
                        break;
                    }
                case 3:
                    {
                        pictureBox2.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources._3fire;
                        break;
                    }
                case 4:
                    {
                        pictureBox2.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources._4fire;
                        break;
                    }
                case 5:
                    {
                        pictureBox2.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources._5fire;
                        break;
                    }
                case 6:
                    {
                        pictureBox2.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources._6fire;
                        break;
                    }
            }
        }

        private void l(object sender, KeyEventArgs e)//key binding
        {
            if (e.KeyCode == Keys.L)
            {
                button2_Click(sender,e);
            }
            else if(e.KeyCode == Keys.F)
            {
                pictureBox2_Click(sender, e);
            }
        }
    }
}
