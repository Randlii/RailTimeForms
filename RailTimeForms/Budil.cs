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

    public partial class Budil : Form
    {
        DateTime myDate;
        int check = 0;
        public Budil()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void Budil_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Form_Path.AddEllipse(0, 0, this.Width, this.Height);
            Region Form_Region = new Region(Form_Path);
            this.Region = Form_Region;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            if (localDate.CompareTo(myDate) > 0 && check != 0)
            {
                check = 0;
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\admin\source\repos\RailTimeForms\RailTimeForms\obj\dindon1.wav");
                simpleSound.Play();
                MessageBox.Show("БУДИЛЬНИК!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            myDate = dateTimePicker2.Value.Date + dateTimePicker1.Value.TimeOfDay;
            if (localDate.CompareTo(myDate) > 0)
                MessageBox.Show("Эта дата уже прошла");
            else
                check = 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            check = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Timer timer = new Timer();
            timer.Show();
        }
    }
}
