using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo
{
    public partial class Form2 : Form
    {

        private Form1 f1;
        private int id;
        public Form2(int id,Form1 f1)
        {
            InitializeComponent();
            this.id = id;
            this.f1 = f1;
        }

        String constring = "Server=localhost;port=5432;username=postgres;password=104800;Database=ToDo";
        NpgsqlConnection conDataBase;
        private void Form2_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width-200,
                                      workingArea.Bottom - Size.Height-100);
            dateTimePicker1.MinDate = DateTime.Today;
            this.ActiveControl = textBox1;
        }


        private void dbOpen()
        {
            conDataBase = new NpgsqlConnection(constring);
            conDataBase.Open();
        }
        private void dbClose()
        {

            conDataBase.Close();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            //BURDAN DEĞİL BURDAN DEĞERLERİ AL DİĞER TARAFTAN UPDATE ET 

            /* dbOpen();
             NpgsqlCommand cmd = new NpgsqlCommand();
             cmd.Connection = conDataBase;
             //Boolean nope = true;
             cmd.CommandText = "Update todo set bitti='true',aciklama2='" + textBox1.Text.ToString() + "',b_tarih='" + dateTimePicker1.Value.ToShortDateString() + "' where id='" + id + "'";
             cmd.ExecuteNonQuery();
             dbClose();*/

            // f1.Form1_Load(f1 , EventArgs.Empty);


            f1.b2(dateTimePicker1.Value, textBox1.Text.ToString());
            f1.reflesh();
            this.Close();
            // f1.it();
            //f1.reflesh();
            //Application.Restart();

        }
    }
}
