using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace combi
{

    public partial class Datos : Form
    {
        int click1 = 0, click2 = 0;
        String b;

        OleDbConnection conn = new OleDbConnection();
        OleDbCommand command = new OleDbCommand();
        public Datos()
        {
            InitializeComponent();   
            conn.ConnectionString = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\erick\Desktop\folder\Estacion_ideal.accdb;  
            Persist Security Info=False";

            try
            {
                conn.Open();
                
                command.Connection = conn;
                string query1 = "select ou,estacion,job,resultado,puntaje,recomendada from registroEstacion order by puntaje";
                command.CommandText = query1;
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView.DataSource = dt;

                string query = "select distinct(ou) from ou";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            comboBox1.Items.Add(dr["ou"]).ToString();
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
            var etiquetas = new List<Label> { label4, label5, label6};
            foreach (var et in etiquetas)
            {
                et.Parent = pictureBox1;
                et.BackColor = Color.Transparent;
            }

        }

        private void comboBox1_SelectedIndexChanged_1
        (object sender, EventArgs e)
        {
            if (click2 > 0)
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
            conn.Open();
         string loadest = "select distinct(est) from" +
         " ou where ou='" + comboBox1.Text + "'";
        OleDbCommand cmds = new OleDbCommand(loadest, conn);
        OleDbDataReader dr1 = cmds.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    comboBox2.Items.Add(dr1["est"]).ToString();
                }
            }
            click2++;

            command.Connection = conn;
            string query2 = "select ou,estacion,job,resultado,puntaje,recomendada" +
                "from registroEstacion where ou LIKE '" + comboBox1.Text + "' order by puntaje";
            command.CommandText = query2;
            OleDbDataAdapter daa = new OleDbDataAdapter(command);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            GridView.DataSource = dtt;
            conn.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (click1 > 0)
            {
                comboBox3.Items.Clear();
                comboBox3.SelectedIndex = -1;
            }
            conn.Open();

            string loadjob = "select job from ou where est = '" + comboBox2.Text + "'";
            OleDbCommand cmd = new OleDbCommand(loadjob, conn);
            OleDbDataReader dr2 = cmd.ExecuteReader();

                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        comboBox3.Items.Add(dr2["job"]).ToString();
                    }
                }
            click1++;

            command.Connection = conn;
            string query2 = "select ou,estacion,job,resultado,puntaje,recomendada from" +
                "registroEstacion where estacion LIKE '" + comboBox2.Text + "' order by puntaje";
            command.CommandText = query2;
            OleDbDataAdapter daa = new OleDbDataAdapter(command);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            GridView.DataSource = dtt;

            conn.Close();
        }



        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            command.Connection = conn;
            string query2 = "select ou,estacion,job,resultado,puntaje,recomendada" +
                "from registroEstacion where job LIKE '" + comboBox3.Text + "' order by puntaje";
            command.CommandText = query2;
            OleDbDataAdapter daa = new OleDbDataAdapter(command);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            GridView.DataSource = dtt;

            conn.Close();
        }

        private void GridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                DataGridView dgv = sender as DataGridView;
                if (dgv.Columns[e.ColumnIndex].Name.Equals("resultado"))
                {
                    if (e.Value != null && e.Value.ToString().Trim() == "Job ideal")
                    {
                        dgv.Rows[e.RowIndex].Cells["resultado"].Style.BackColor = Color.Green;
                    }
                    else if (e.Value != null && e.Value.ToString().Trim() == "Job casi ideal")
                    {
                        dgv.Rows[e.RowIndex].Cells["resultado"].Style.BackColor = Color.Goldenrod;
                    }
                    else
                    {
                        dgv.Rows[e.RowIndex].Cells["resultado"].Style.BackColor = Color.Red;
                    }
                }  
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                command.Connection = conn;
                string query2 = "select ou,estacion,job,resultado,puntaje,recomendada" +
                    "from registroEstacion order by puntaje";
                command.CommandText = query2;
                OleDbDataAdapter daa = new OleDbDataAdapter(command);
                DataTable dtt = new DataTable();
                daa.Fill(dtt);
                GridView.DataSource = dtt;
            }
            catch (Exception xe)
            {
                MessageBox.Show("Error: " + xe);
            }
            conn.Close();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            Form here = new Principal();
            here.Show();
            Visible = false;
        }

        private void btn_exportar_Click_1(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            if (workbook.Name == "Hoja1")
            {
                worksheet = workbook.Sheets["Hoja1"];
            }
            if (workbook.Name == "Sheet1")
            {
                worksheet = workbook.Sheets["Sheet1"];
            }
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "registroEstacion";

            for (int i = 1; i < GridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = GridView.Columns[i - 1].HeaderText;

            }
            var w = new Form() { Size = new Size(0, 0) };
            Task.Delay(TimeSpan.FromSeconds(2))
                .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

            MessageBox.Show(w, "Espere un momento", " ");

            for (int i = 0; i < GridView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < GridView.Columns.Count; j++)
                {
                    if (GridView.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = GridView.Rows[i].Cells[j].Value.ToString();
                        if (GridView.Rows[i].Cells[j].Value.ToString().Equals("Job ideal"))
                        {
                            worksheet.Cells[i + 2, j + 1].Interior.Color = ColorTranslator.ToOle(Color.Green);
                        }
                        else if (GridView.Rows[i].Cells[j].Value.ToString().Equals("Job casi ideal"))
                        {
                            worksheet.Cells[i + 2, j + 1].Interior.Color = ColorTranslator.ToOle(Color.Goldenrod);
                        }
                        else if (GridView.Rows[i].Cells[j].Value.ToString().Equals("Job no ideal"))
                        {
                            worksheet.Cells[i + 2, j + 1].Interior.Color = ColorTranslator.ToOle(Color.Red);
                        }
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
      }
    }

