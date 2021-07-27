using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeGameDigitalTechnologyVer1._4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            PennyGameLoader();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//Lock the size of form and avoid the blare when expand
            MaximizeBox = false;//hide expansion button on top right hand side.
            MinimizeBox = false;
        }
        private void PennyGameLoader()
        {
            int death = 0;
            int score = 0;
            XmlEditor xmlEditor = new XmlEditor();
            death += xmlEditor.XmlReader("russianroulett").Item1;
            death += xmlEditor.XmlReader("hangingman").Item1;
            score += xmlEditor.XmlReader("russianroulett").Item2;
            score += xmlEditor.XmlReader("hangingman").Item2;
            xmlEditor.XmlWriter("pennygame", score,death);
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            int death;
            int score;
            XmlEditor xmlEditor = new XmlEditor();
            death = xmlEditor.XmlReader("russianroulett").Item1;//need check whether the name is correct.
            score = xmlEditor.XmlReader("russianroulett").Item2;
            label6.Text = Convert.ToString(death);
            label7.Text = Convert.ToString(score);
            death=xmlEditor.XmlReader("hangingman").Item1;
            score=xmlEditor.XmlReader("hangingman").Item2;
            label8.Text = Convert.ToString(death);
            label9.Text = Convert.ToString(score);
            death=xmlEditor.XmlReader("pennygame").Item1;
            score=xmlEditor.XmlReader("pennygame").Item2;
            label10.Text = Convert.ToString(death);
            label11.Text = Convert.ToString(score);
        }
    }
}
