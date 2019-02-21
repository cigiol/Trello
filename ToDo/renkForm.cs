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
    public partial class renkForm : Form
    {
        Form1 f1 = new Form1(DateTime.Now,"sa");
        public renkForm(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
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
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.ToString() !="" && textBox2.Text.ToString() != "")
            {
                dbOpen();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conDataBase;
                Boolean nope = true;
                cmd.CommandText = "Update parameter set warningday='"+ Int32.Parse(textBox1.Text.ToString()) + "',dangerday='" + Int32.Parse(textBox2.Text.ToString()) + "'";
                cmd.ExecuteNonQuery();
                dbClose();
                f1.reflesh();
                label3.ForeColor = Color.Green;
                label3.Text = "Okke";
            }
            else if (textBox1.Text.ToString() != "" && textBox2.Text.ToString() == "")
            {
                dbOpen();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conDataBase;
                Boolean nope = true;
                cmd.CommandText = "Update parameter set warningday='" + Int32.Parse(textBox1.Text.ToString()) + "'";
                cmd.ExecuteNonQuery();
                dbClose();
                f1.reflesh();
                label3.ForeColor = Color.Green;
                label3.Text = "Okke";
            }
            else if (textBox1.Text.ToString() == "" && textBox2.Text.ToString() != "")
            {
                dbOpen();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conDataBase;
                Boolean nope = true;
                cmd.CommandText = "Update parameter set dangerday='" + Int32.Parse(textBox2.Text.ToString()) + "'";
                cmd.ExecuteNonQuery();
                dbClose();
                f1.reflesh();
                label3.ForeColor = Color.Green;
                label3.Text = "Okke";
            }
            else
            {
                MessageBox.Show("Hiç gün girmedin.");
            }
        }

        private void circularButton1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = circularButton1.BackColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                circularButton1.BackColor = MyDialog.Color;
            var hex = System.Drawing.ColorTranslator.ToHtml(MyDialog.Color);
            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            cmd.CommandText = "Update parameter set dangercolor='" + hex + "'";
            cmd.ExecuteNonQuery();
            dbClose();
            f1.reflesh();
        }

        private void circularButton2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = circularButton2.BackColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                circularButton2.BackColor = MyDialog.Color;
            var hex = System.Drawing.ColorTranslator.ToHtml(MyDialog.Color);
            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            cmd.CommandText = "Update parameter set warningcolor='" + hex + "'";
            cmd.ExecuteNonQuery();
            dbClose();
            f1.reflesh();
        }

        private void circularButton3_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = circularButton3.BackColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                circularButton3.BackColor = MyDialog.Color;
            var hex = System.Drawing.ColorTranslator.ToHtml(MyDialog.Color);
            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            cmd.CommandText = "Update parameter set normalcolor='" + hex + "'";
            cmd.ExecuteNonQuery();
            dbClose();
            f1.reflesh();
        }

        private void renkForm_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width - 150,
                                      workingArea.Bottom - Size.Height - 50);
            dbOpen();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conDataBase;
            cmd.CommandText = "Select * from parameter";
            NpgsqlDataReader read = cmd.ExecuteReader();
            int danger = 0;
            int warning = 0;
            var dangerc = "";
            var warningc = "";
            var normalc = "";
            if (read.Read())
            {
                danger = read.GetInt32(0);
                warning = read.GetInt32(1);
                dangerc = read.GetString(2);
                warningc = read.GetString(3);
                normalc = read.GetString(4);
            }
            textBox2.Text = ""+danger;
            textBox1.Text = "" + warning;
            circularButton1.BackColor = System.Drawing.ColorTranslator.FromHtml(dangerc);
            circularButton2.BackColor = System.Drawing.ColorTranslator.FromHtml(warningc);
            circularButton3.BackColor = System.Drawing.ColorTranslator.FromHtml(normalc);
            dbClose();
        }
    }
}
