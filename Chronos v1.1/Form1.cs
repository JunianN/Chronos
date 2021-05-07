using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chronos
{
    public partial class Form1 : Form
    {
        Remindtb remind = new Remindtb();
        public Form1()
        {
            InitializeComponent();
        }

        string currenttime;
        string messagetime;
        
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            currenttime = DateTime.Now.ToString("hh:mm:ss tt");
            label1.Text = currenttime;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            messagetime = tbTime.Text + " " + comboBoxAM.Text;
            label4.Text = "Reminder set for : " + messagetime;
            if(currenttime == messagetime)
            {
                timer2.Stop();
                MessageBox.Show(tbMessage.Text);
                btnStart.Enabled = true;
                btnStop.Enabled = false;

                label4.Text = " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            label4.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
            notifyIcon1.ShowBalloonTip(5000);
            notifyIcon1.Icon = SystemIcons.Application;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            remind.Date = tbTime.Text;
            remind.Notes = tbMessage.Text;
            using (ChronosDBEntities db = new ChronosDBEntities())
            {
                db.Remindtbs.Add(remind);
                db.SaveChanges();
            }
            MessageBox.Show("Berhasil disimpan");
        }
    }
}
