using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ToDo
{
    public partial class Form1 : Form
    {

        /*POPUP OLARAK BİLDİRİM YOLLAMA KODU
         
              PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.if_system_lock_screen_118795;
            popup.TitleText = "Ekranı Kilitle";
            popup.ContentText = "WİNDOWS + L";
            popup.Popup();
             
             */

        //var firebase = new FirebaseClient(“https://dinosaur-facts.firebaseio.com/"); 
        private DateTime time;
        private string st;
        public Form1(DateTime time,string st)
        {
            InitializeComponent();
            this.st = st;
            this.time = time;
        }
        String constring = "Server=localhost;port=5432;username=postgres;password=104800;Database=ToDo";
        NpgsqlConnection conDataBase;

        public void dbOpen()
        {
            conDataBase = new NpgsqlConnection(constring);
            conDataBase.Open();
        }
        public void dbClose()
        {
            
            conDataBase.Close();
        }
        public void refleshDataGrid1()
        {
            dbOpen();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sql = "SELECT t.id, t.aciklama as Yapilacak, p.name as Proje,b_tarih as Bitiş FROM todo t,proje p  WHERE bitti='false' and t.ait_id=p.id";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conDataBase);
            // i always reset DataSet before i do
            // something with it.... i don't know why :-)
            ds.Reset();
            // filling DataSet with result from NpgsqlDataAdapter
            da.Fill(ds);
            // since it C# DataSet can handle multiple tables, we will select first
            dt = ds.Tables[0];
            // connect grid to DataTable
            dataGridView1.DataSource = dt;
            dbClose();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Yapılacak İş";
            dataGridView1.Columns[2].HeaderText = "Üst Proje";
            dataGridView1.Columns[3].HeaderText = "Bitiş Tarihi";
            //MessageBox.Show("hi");
        }
        public void refleshCombo()
        {

            dbOpen();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sql = "SELECT name from proje";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conDataBase);
            // i always reset DataSet before i do
            // something with it.... i don't know why :-)
            ds.Reset();
            // filling DataSet with result from NpgsqlDataAdapter
            da.Fill(ds);
            // since it C# DataSet can handle multiple tables, we will select first
            dt = ds.Tables[0];
            // connect grid to DataTable
            comboBox1.ValueMember = dt.Columns[0].ToString();
            comboBox1.DisplayMember = dt.Columns[0].ToString();
            comboBox1.DataSource = dt;
            comboBox2.ValueMember = dt.Columns[0].ToString();
            comboBox2.DisplayMember = dt.Columns[0].ToString();
            comboBox2.DataSource = dt;
            dbClose();
            /*
             
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
             dt.Columns.Add("customerid", typeof(string));
             dt.Columns.Add("contactname", typeof(string));
                dt.Load(reader);

                comboBox1.ValueMember = "customerid";
                comboBox1.DisplayMember = "contactname";
                comboBox1.DataSource = dt;

                conn.Close();
             */
        }
        public void it()
        {
            MessageBox.Show("sa");
        }
        public void refleshDataGrid2()
        {

            dbOpen();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sql = "SELECT t.id,t.aciklama2, t.aciklama , p.name ,b_tarih  FROM todo t,proje p  WHERE t.bitti='true' and t.aktif='true' and t.ait_id=p.id ";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conDataBase);
            // i always reset DataSet before i do
            // something with it.... i don't know why :-)
            ds.Reset();
            // filling DataSet with result from NpgsqlDataAdapter
            da.Fill(ds);
            // since it C# DataSet can handle multiple tables, we will select first
            dt = ds.Tables[0];
            // connect grid to DataTable
            dataGridView2.DataSource = dt;
            dbClose();
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].HeaderText="Bitirme Açıklaması";
            dataGridView2.Columns[2].HeaderText = "Yapılacak İş";
            dataGridView2.Columns[3].HeaderText = "Üst Proje";
            dataGridView2.Columns[4].HeaderText = "Bitiş Tarihi";
        }
        int danger = 0;
        int warning = 0;
        string dangerc = "";
        string warningc = "";
        string normalc = "";
        internal void Renklendir()
        {
            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            cmd.CommandText = "Select * from parameter";
            NpgsqlDataReader read = cmd.ExecuteReader();
            
            if (read.Read())
            {
                danger = read.GetInt32(0);
                warning = read.GetInt32(1);
                dangerc = read.GetString(2);
                warningc = read.GetString(3);
                normalc = read.GetString(4);
            }
            
            dbClose();
        }
        internal void Form1_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            //dateTimePicker1.MinDate = DateTime.Today;
            reflesh();
            once();
            reflesh();
            //--------INSERT KOMUTU-----------
            /* NpgsqlCommand cmd = new NpgsqlCommand();
             cmd.Connection = conDataBase;
             cmd.CommandText = "Insert into todo (aciklama,aciklama2,o_tarih,b_tarih) values ('sa','','" + DateTime.Now + "','" + DateTime.Now + "')";
             cmd.ExecuteNonQuery();
             textBox1.Text = "oldu";*/





        }
        private void Form1_Resize(object sender,EventArgs e)
        {
            if(this.WindowState== FormWindowState.Minimized)
            {
                
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        public void reflesh()
        {
            Renklendir();
            refleshDataGrid1();
            refleshDataGrid2();
            
            refleshCombo();
            int i = -1;
            //MessageBox.Show("OL ARTIK");
             foreach (DataGridViewRow rows in dataGridView1.Rows)
             {
                 i++;
                 if ((DateTime.Parse(rows.Cells[3].Value.ToString()) - DateTime.Now).TotalDays <= warning)
                 {
                     dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(warningc);
                 }
                 if ((DateTime.Parse(rows.Cells[3].Value.ToString()) - DateTime.Now).TotalDays < danger)
                 {

                     dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(dangerc);
                 }
                 if((DateTime.Parse(rows.Cells[3].Value.ToString()) - DateTime.Now).TotalDays > warning)
                 {

                     dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(normalc);
                     //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                 }


             }
            i = -1;
            foreach (DataGridViewRow rows in dataGridView2.Rows)
            {
                i++;
                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
            }

            
        }
        private void once()//5 gnü geçince table da gösterme
        {
            int i = -1;
            foreach (DataGridViewRow rows in dataGridView2.Rows)
            {
                i++;
                //dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                if ((DateTime.Parse(rows.Cells[4].Value.ToString()) - DateTime.Now).TotalDays > 5)
                {
                    dbOpen();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = conDataBase;
                    cmd.CommandText = "Update todo set aktif='false' where id='" + Convert.ToInt32(rows.Cells[0].Value) + "'";
                    cmd.ExecuteNonQuery();
                    dbClose();

                }


            }
        }

        private int idBul()
        {

            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            cmd.CommandText = "Select id,name from proje where name='"+ comboBox2.SelectedValue.ToString() + "'";
            NpgsqlDataReader read = cmd.ExecuteReader();
            int a = 0;
            if (read.Read())
            {
               a=read.GetInt32(0);
            }

            dbClose();
            return a;

        }
        public void button1_Click(object sender, EventArgs e)
        {

            Form1 f1 = new Form1(DateTime.Now,"sa");
            f1.StartPosition = FormStartPosition.CenterScreen;
            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            Boolean nope = false;
            //projenin id sini ekle
            int a=idBul();
            cmd.CommandText = "Insert into todo (aciklama,aciklama2,o_tarih,b_tarih,ait_id,bitti,aktif) values ('" + textBox3.Text.ToString() + "','','" + DateTime.Now + "','" + dateTimePicker2.Value.ToShortDateString() + "','"+ a +"','"+ nope +"','true')";
            cmd.ExecuteNonQuery();
            dbClose();
            reflesh();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            Boolean nope = true;
            cmd.CommandText = "Update todo set bitti='false' where id='" + Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value) + "'";
            cmd.ExecuteNonQuery();
            dbClose();
            reflesh();
        }
        public void b2(DateTime time, string st)
        {

            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            Boolean nope = true;
            cmd.CommandText = "Update todo set bitti='true',aciklama2='" + st + "',b_tarih='" + time + "' where id='" + id + "'";
            //cmd.CommandText = "Update todo set bitti='true' where id='"+ Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) +"'";
            cmd.ExecuteNonQuery();
            dbClose();
            reflesh();
            refleshDataGrid1();
        }

        public int id = 1;
   
        public void button2_Click(object sender, EventArgs e)
        {
             
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            Form2 f2 = new Form2(id,this);
            f2.Show();
            // MessageBox.Show(""+id);

            /*  dbOpen();
              NpgsqlCommand cmd = new NpgsqlCommand();
              cmd.Connection = conDataBase;
              Boolean nope = true;
             cmd.CommandText = "Update todo set bitti='true',aciklama2='" + st + "',b_tarih='" + time + "' where id='" + id + "'";
             //cmd.CommandText = "Update todo set bitti='true' where id='"+ Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) +"'";
             cmd.ExecuteNonQuery();
              dbClose();
              reflesh();*/

            //MessageBox.Show("" + (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
        }
        
     

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            cmd.CommandText = "Select name from proje";
            NpgsqlDataReader read = cmd.ExecuteReader();
            int a = 0;
            while (read.Read())
            {
                if (textBox2.Text.ToString() == read.GetString(0))
                {
                    a++;
                    
                    
                }
            }
            if (a != 0)
            {
                NpgsqlCommand cmd2 = new NpgsqlCommand();
                cmd2.Connection = conDataBase;
                cmd2.CommandText = "Insert into proje (name) values ('" + textBox2.Text.ToString() + "')";
                cmd2.ExecuteNonQuery();
                dbClose();
            }

            else
            {
                MessageBox.Show("Bu kayıt zaten var.");
                dbClose();
            }*/

            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            Boolean nope = true;
            cmd.CommandText = "Insert into proje (name) values ('" + textBox2.Text.ToString() + "')";
            cmd.ExecuteNonQuery();
            dbClose();
            reflesh();
        }

        private void circularButton1_Click(object sender, EventArgs e)
        {

            renkForm renk = new renkForm(this);
            renk.Show();
            /*ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = textBox1.ForeColor;
            

            // Hex to Control Color
            var myColor = "#[color from database]";
            var myControlColor = System.Drawing.ColorTranslator.FromHtml(myColor);

            // Control Color to Hex
            var colorBlue = System.Drawing.Color.Blue;
            var hexBlue = System.Drawing.ColorTranslator.ToHtml(colorBlue);
            var myColor = "#ffffff";
            circularButton1.BackColor = System.Drawing.ColorTranslator.FromHtml(myColor);

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                textBox1.ForeColor = MyDialog.Color;
           var hex= System.Drawing.ColorTranslator.ToHtml(MyDialog.Color);
            MessageBox.Show(""+hex);*/

        }


        private int rowIndex = 0;
        private void circularButton2_Click(object sender, EventArgs e)
        {
            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            cmd.CommandText = "DELETE FROM todo where id='" + Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value) + "'";
            cmd.ExecuteNonQuery();
            dbClose();
            reflesh();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //textBox1.Text = "" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value;
            //dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());
            //comboBox1.Text=""+ dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value;
            //MessageBox.Show("" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
            //SEÇİLİNCE YUKARI UPDATE KISMINA VERİLER GİTMİYOR GİDİYORDU AMA TABCONTROL YAPINCA ARTIK GİTMİYOR WTF??!!

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            int a = idBul();
            cmd.CommandText = "Update todo set aciklama='" + textBox1.Text.ToString() + "',b_tarih='"+ dateTimePicker1.Value.ToShortDateString() +"' , ait_id='"+ a +"'  where id='" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "'";
            cmd.ExecuteNonQuery();
            dbClose();
            reflesh();
        }

       
    }
}
