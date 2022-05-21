using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace RailTimeForms
{
    public partial class Timer : Form
    {
        int m, s, ms;
        public Timer()
        {
            InitializeComponent();
            timer1.Interval = 1000;
  
        }

        private void timer_Load(object sender, EventArgs e)
        {
          System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Form_Path.AddEllipse(0, 0, this.Width, this.Height);
            Region Form_Region = new Region(Form_Path);
            this.Region = Form_Region;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Budil budil = new Budil();
            budil.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            m = 0;
            s = 0;
            label1.Text = "00";
            label2.Text = "00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty && textBox2.Text == String.Empty)
            {
                MessageBox.Show("Введите значения");
                return;
            }
            s = Convert.ToInt32(textBox1.Text);
               m = Convert.ToInt32(textBox2.Text);
                if (s < 10)
                    label2.Text = "0" + s.ToString();
                else
                    label2.Text = s.ToString();
                if (m < 10)
                    label1.Text = "0" + m.ToString();
                else
                    label1.Text = m.ToString();

                timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s > 0)
            {
                s--;
                if (s < 10)
                    label2.Text = "0" + s.ToString();
                else
                    label2.Text = s.ToString();
            }
            else
            {
                if (m>0)
                {
                    m--;
                    if (m < 10)
                        label1.Text = "0" + m.ToString();
                    else
                        label1.Text = m.ToString();
                    s = 59;
                    label2.Text = "00";
                }
                else if(s == 0 && m == 0)
                {
                    timer1.Stop();
                    SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\admin\source\repos\RailTimeForms\RailTimeForms\obj\dindon1.wav");
                    simpleSound.Play();
                    MessageBox.Show("Таймер!");
                }
            }
        }
    }
}
