using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PracticeGameDigitalTechnologyVer1._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//The first form of other forms, start up position in center screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//Lock the size of form and avoid the blare when expand
            MaximizeBox = false;//hide expansion button on top right hand side.
            MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Location = this.Location;//get location of the form;
            form2.StartPosition = FormStartPosition.CenterScreen;//Start up position of the code;
            form2.FormClosing += delegate { this.Show(); };//when current form closed, the form will back to menu;
            form2.Show(); //Showing the form
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.Location = this.Location;
            form3.StartPosition = FormStartPosition.CenterScreen;
            form3.FormClosing += delegate { this.Show(); };
            form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form4 = new Form4();
            form4.Location = this.Location;
            form4.StartPosition = FormStartPosition.CenterScreen;
            form4.FormClosing += delegate { this.Show(); };
            form4.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
