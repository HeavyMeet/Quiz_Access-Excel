using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using System.Collections.Generic;

namespace combi
{

    public partial class Principal : Form
    {
        int click1 = 0, click2 = 0; String b;
        OleDbConnection conn = new OleDbConnection();

        public Principal()
        {

            InitializeComponent();;
            conn.ConnectionString = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\erick\Desktop\folder\Estacion_ideal.accdb;
            Persist Security Info=False";

            try
            {
                conn.Open();
                string query = "select distinct(ou) from ou";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        OU_DropDown.Items.Add(dr["ou"]).ToString();
                    }
                }
            }
            catch (Exception xe)
            {
                MessageBox.Show("Error: " + xe);
            }
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Parent = pictureBox2;
            pictureBox1.BackColor = Color.Transparent;
            var etiquetas = new List<Label> { label1, label4, label5, label3};
            foreach (var et in etiquetas)
            {
                et.Parent = pictureBox2;
                et.BackColor = Color.Transparent;
            }
        }

        private void OU_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (click2 > 0)
            {
                EST_DropDown.Items.Clear();
                JOB_DropDown.Items.Clear();
                EST_DropDown.SelectedIndex = -1;
                JOB_DropDown.SelectedIndex = -1;
            }
            conn.Open();
            string loadest = "select distinct(est) from" +
            " ou where ou='" + OU_DropDown.Text + "'";
            OleDbCommand cmds = new OleDbCommand(loadest, conn);
            OleDbDataReader dr1 = cmds.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    EST_DropDown.Items.Add(dr1["est"]).ToString();
                }
            }
            click2++;
            conn.Close();


        }

        private void EST_DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (click1 > 0)
                {
                    JOB_DropDown.Items.Clear();
                    JOB_DropDown.SelectedIndex = -1;
                }
                conn.Open();

                string loadjob = "select job from ou where est='" + EST_DropDown.Text + "'";
                OleDbCommand cmd = new OleDbCommand(loadjob, conn);
                OleDbDataReader dr2 = cmd.ExecuteReader();

                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        JOB_DropDown.Items.Add(dr2["job"]).ToString();
                    }
               }
                click1++;
                conn.Close();
            
        }


        private void crear_Click(object sender, EventArgs e)
        {
            if (OU_DropDown.SelectedItem != null && EST_DropDown.SelectedItem != null && JOB_DropDown.SelectedItem != null)
            {

                String ou = OU_DropDown.Text;
                int est = Convert.ToInt32(EST_DropDown.Text);
                String job = JOB_DropDown.Text;

                Form here = new Form1(ou, est, job);
                here.Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show("Favor de llenar el OU, la estación y el num. de job");
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            if (OU_DropDown.SelectedItem != null && EST_DropDown.SelectedItem != null && JOB_DropDown.SelectedItem != null)
            {
                String ou = OU_DropDown.Text;
                int est = Convert.ToInt32(EST_DropDown.Text);
                String job = JOB_DropDown.Text;

                try
                {
                    OleDbDataReader dr = null;
                    conn.Open();
                    OleDbCommand coms = new OleDbCommand();
                    coms.Connection = conn;
                    string query = "SELECT * FROM registroEstacion where job = '" + job + "'";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    //String ff = dr["fecha"].ToString();
                    //MessageBox.Show(ff + " fecha");

                    if (dr.HasRows)
                    {
                        b = "0.1";
                    }
                    else
                    {
                        Console.WriteLine("No registros.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());


                }
                conn.Close();

                if (b != null)
                {
                    Form here = new Form1M(ou, est, job);
                    here.Show();
                    Visible = false;
                }
                else
                {
                    MessageBox.Show("No se puede modificar la job porque no ha sido llenada");
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar el OU, la estación y el num. de job");

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void btn_datos_Click(object sender, EventArgs e)
        {
            Datos here = new Datos();
            here.Show();
            Visible = false;
        }



    }

}    
