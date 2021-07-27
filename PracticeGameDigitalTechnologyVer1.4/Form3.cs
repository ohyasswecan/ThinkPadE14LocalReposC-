using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeGameDigitalTechnologyVer1._4
{
    public partial class Form3 : Form
    {
        bool surviveStatus = true;
        int Status = 0;
        int Point = 0;
        string Hint_0 = "Please Answer Here";
        StreamReader streamReader = new StreamReader(@"Resources\QuestionAndAnswer.txt");
       
        public Form3()
        {
            InitializeComponent();
            textBox1.Text = Hint_0;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//Lock the size of form and avoid the blare when expand
            MaximizeBox = false;//hide expansion button on top right hand side.
            MinimizeBox = false;
            label2.Text = streamReader.ReadLine();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string question;
            string answer;
            if (label2.Text == ".....")
            {
                question = label2.Text;
                answer = streamReader.ReadLine();
                label2.Text = question;
                textBox1.Text = "";
            }
            else
            {
                question = label2.Text;
                answer = streamReader.ReadLine();
                if (textBox1.Text != "")
                {



                    if (surviveStatus == false)
                    {
                        var form4 = new Form4();
                        form4.Location = this.Location;
                        form4.StartPosition = FormStartPosition.CenterScreen;
                        form4.FormClosing += delegate { this.Show(); };
                        form4.Show();
                        this.Hide();
                    }
                    if (question == null)
                    {
                        question = streamReader.ReadLine();
                        MessageBox.Show("Hahaha, how do you feel right now.");
                        var form4 = new Form4();
                        form4.Location = this.Location;
                        form4.StartPosition = FormStartPosition.CenterScreen;
                        form4.FormClosing += delegate { this.Show(); };
                        form4.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (answer != textBox1.Text)
                        {
                            listBox1.Items.Add(label2.Text);
                            listBox1.Items.Add(textBox1.Text);
                            listBox1.Items.Add("Wrong");
                            textBox1.Text = "";
                            Status++;
                            Event_StatusCounter(Status);
                            question = streamReader.ReadLine();
                            label2.Text = question;
                        }
                        else
                        {
                            listBox1.Items.Add(label2.Text);
                            listBox1.Items.Add(textBox1.Text);
                            listBox1.Items.Add("Correct");
                            Point += 10;
                            label5.Text = "$" + Point;
                            textBox1.Text = "";
                            question = streamReader.ReadLine();
                            label2.Text = question;
                        }
                    }
                }
            }
        }
        //This is a death func for our quiz;
        private void death_Func()
        {
            surviveStatus = false;
            XmlEditor xmlEditor = new XmlEditor();
            xmlEditor.XmlWriter("hangingman", Point,1);
            MessageBox.Show("You are dead.");
            var form4 = new Form4();
            form4.Location = this.Location;
            form4.StartPosition = FormStartPosition.CenterScreen;
            form4.FormClosing += delegate { this.Show(); };
            form4.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        private void Event_StatusCounter(int status)
        {
            switch (status)
            {
                case 0:
                    {
                        pictureBox1.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources.Excution00;
                        break;
                    }
                case 1:
                    {
                        pictureBox1.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources.Excution01;
                        break;
                    }
                case 2:
                    {
                        pictureBox1.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources.Excution02;
                        break;
                    }
                case 3:
                    {
                        pictureBox1.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources.Excution03;
                        break;
                    }
                case 4:
                    {
                        pictureBox1.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources.Excution04;
                        break;
                    }
                case 5:
                    {
                        pictureBox1.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources.Excution05;
                        break;
                    }
                case 6:
                    {
                        pictureBox1.Image = global::PracticeGameDigitalTechnologyVer1._4.Properties.Resources.Excution06;
                        death_Func();
                        break;
                    }
            }
        }
        private void enter_preview(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
            else if(e.KeyCode == Keys.C)
            {
                button2_Click(sender, e);
            }
        }
    }
}
