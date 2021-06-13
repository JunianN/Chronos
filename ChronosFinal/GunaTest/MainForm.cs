using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace GunaTest
{
    public partial class MainForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DIKA;Initial Catalog=db_chronos;Integrated Security=True");

        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        void bersih()
        {
            tb_nomor.Text = "";
            tb_title.Text = "";
            tb_desc.Text = "";
            tb_search.Text = "";
        }

        void refresh()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from tbl_mainreminder", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tbl_mainreminder");
                dataGridView_reminder.DataSource = ds;
                dataGridView_reminder.DataMember = "tbl_mainreminder";
                dataGridView_reminder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_reminder.AllowUserToAddRows = false;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        void cari_reminder()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from tbl_mainreminder where Judul like '%"+tb_search.Text+"%' or Deskripsi like '%"+tb_search.Text+"%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tbl_mainreminder");
                dataGridView_reminder.DataSource = ds;
                dataGridView_reminder.DataMember = "tbl_mainreminder";
                dataGridView_reminder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_reminder.AllowUserToAddRows = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public MainForm()
        {
            InitializeComponent();

            bersih();
            refresh();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            bersih();
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (tb_nomor.Text.Trim() == "" || tb_title.Text.Trim() == "" || tb_desc.Text.Trim() == "" )
            {
                MessageBox.Show(" Mohon Lengkapi Data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DIKA;Initial Catalog=db_chronos;Integrated Security=True");

                try
                {
                    cmd = new SqlCommand("insert into tbl_mainreminder values ('" + tb_nomor.Text + "', '" + tb_title.Text + "', '" + DateTimePicker.Text + "','" + tb_desc.Text + "' )", conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    refresh();
                    bersih();
                    btn_save.Enabled = true;
                }
                catch(Exception x)
                {
                    MessageBox.Show(x.ToString());
                }
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            cari_reminder();
        }

        private void dataGridView_reminder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
   
                DataGridViewRow row = this.dataGridView_reminder.Rows[e.RowIndex];
                tb_nomor.Text = row.Cells["No"].Value.ToString();
                tb_title.Text = row.Cells["Judul"].Value.ToString();
                DateTimePicker.Text = row.Cells["Tanggal"].Value.ToString();
                tb_desc.Text = row.Cells["Deskripsi"].Value.ToString();
                
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Yakin ingin menghapus reminder "+tb_title.Text + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DIKA;Initial Catalog=db_chronos;Integrated Security=True");

                {
                    cmd = new SqlCommand(" delete from tbl_mainreminder where Judul = '"+tb_title.Text+"'", conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    refresh();
                    bersih();
                }
            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tb_title_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
