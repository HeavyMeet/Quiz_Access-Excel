﻿using System;
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

    public partial class Form1M : Form
    {
        public double[] c { get; set; }
        public double[] p { get; set; }
        public int[] uuu { get; set; }
        public int[] u { get; set; }
        public int est1 { get; private set; }
        public int h { get; set; }
        public int cou { get; set; }

        int[] notas = new int[10];
        public int fh { get; set; }
        public int f { get; set; }
        public String[] comment { get; set; }
        public String[] C_array { get; set; }
        public String[] P_array { get; set; }
        public String ou1 { get; private set; }
        public String job1 { get; private set; }
        String[] comments = new String[70];
        int[] uuux = new int[70];

        int i, j, n;
        
        OleDbConnection conn = new OleDbConnection();

        public Form1M(String ou, int est, String job)
        {

            InitializeComponent();
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Franky Real\Desktop\matriz\Estacion_ideal.accdb;
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\erick\Desktop\folder\Estacion_ideal.accdb;
            Persist Security Info=False";
            c = new double[70];
            p = new double[70];
            comment = new String[70];
            uuu = new int[71];

            u = new int[71];
            C_array = new String[70];
            P_array = new String[70];
            f = 0; 
            ou1 = ou;
            est1 = est;
            job1 = job;

            try
            {
                OleDbDataReader dr = null;
                OleDbDataReader dr1 = null;
                conn.Open();
                OleDbCommand coms = new OleDbCommand();
                coms.Connection = conn;
                string query = "SELECT * FROM matriz where job = '" + job + "'";
                string query1 = "SELECT * FROM registroJOB where job = '" + job + "'";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbCommand cmdd = new OleDbCommand(query1, conn);
                dr = cmd.ExecuteReader();
                dr1 = cmdd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                            uuu[f] = Convert.ToInt32(dr["num"].ToString());
                            C_array[f] = dr["c"].ToString();
                            P_array[f] = dr["p"].ToString();
                            f++;                    
                    }
                }

                f = 0;
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                            uuux[f] = Convert.ToInt32(dr1["num"].ToString());
                            comments[f] = dr1["observaciones"].ToString();
                            f++;
                    }
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            conn.Close();
           
            int aux = 0;
            String auxc = "", auxp = "", auxcom = "";
            for (int i = 0; i < f-1; i++)
            {
                for (int j = 0; j < f-1; j++)
                {
                    if (uuu[j] > uuu[j + 1])
                    {
                        aux = uuu[j];
                        auxc = C_array[j];
                        auxp = P_array[j];
                        uuu[j] = uuu[j + 1];
                        C_array[j] = C_array[j + 1];
                        P_array[j] = P_array[j + 1];
                        C_array[j + 1] = auxc;
                        P_array[j + 1] = auxp;
                        uuu[j + 1] = aux;
                    }
                }
            }

            aux = 0;  
            for (int i = 0; i < f-1; i++)
            {
                for (int j = 0; j < f-1; j++)
                {
                    if (uuux[j] > uuux[j + 1])
                    {
                        aux = uuux[j];
                        auxcom = comments[j];
                        uuux[j] = uuux[j+1];
                        comments[j] = comments[j+1];
                        uuux[j+1] = aux;
                        comments[j+1] = auxcom;
                       
                    }
                }
            }

            for (int i = 0; i < f; i++)
            {
                comment[uuux[i] - 1] = comments[i];
            }
       
            int h = 0;

            var checkC = new List<CheckBox> { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox24, checkBox23, checkBox22, checkBox21, checkBox20, checkBox19, checkBox36, checkBox35, checkBox34, checkBox33, checkBox32, checkBox31, checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox60, checkBox59, checkBox58, checkBox57, checkBox56, checkBox55, checkBox72, checkBox71, checkBox70, checkBox69, checkBox68, checkBox67, checkBox84, checkBox83, checkBox82, checkBox81, checkBox80, checkBox79, checkBox96, checkBox95, checkBox94, checkBox93, checkBox92, checkBox91, checkBox108, checkBox107, checkBox106, checkBox105, checkBox104, checkBox103, checkBox120, checkBox119, checkBox118, checkBox117, checkBox116, checkBox115 };
            var checkP = new List<CheckBox> { checkBox12, checkBox11, checkBox10, checkBox9, checkBox8, checkBox7, checkBox18, checkBox17, checkBox16, checkBox15, checkBox14, checkBox13, checkBox30, checkBox29, checkBox28, checkBox27, checkBox26, checkBox25, checkBox42, checkBox41, checkBox40, checkBox39, checkBox38, checkBox37, checkBox54, checkBox53, checkBox52, checkBox51, checkBox50, checkBox49, checkBox66, checkBox65, checkBox64, checkBox63, checkBox62, checkBox61, checkBox78, checkBox77, checkBox76, checkBox75, checkBox74, checkBox73, checkBox90, checkBox89, checkBox88, checkBox87, checkBox86, checkBox85, checkBox102, checkBox101, checkBox100, checkBox99, checkBox98, checkBox97, checkBox114, checkBox113, checkBox112, checkBox111, checkBox110, checkBox109 };
            String[] vc = { "0", "1", "2", "3", "4", "5" }; String[] vp = { "0.1", "0.5", "1", "3", "6", "10" };
            i = 0; j = 1; int acum2=0, acum=0;
            bool b = true;
            for (int i = 0; uuu[i] != 0; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (uuu[i]==j)
                    {
                        acum2++;
                    }
                }
            }
            int acum3 = acum2;
            if (acum2 != 0)
            {
                foreach (var che in checkC)
                {
                    if (b)
                    {
                        if (C_array[h].Equals("x"))
                        { 
                            if (acum == acum2)
                            { break; }
                            notas[n] = uuu[h]; n++; h++; acum2--; b = false;                        
                        }
                        if (C_array[h].Equals(vc[i]) && uuu[h] == j)
                        {
                            che.Checked = true; acum++; h++; b = false;

                            if (acum == acum2)
                            {
                                break;
                            }
                        }
                    }
                    i++;
                    if (i == 6)
                    {
                        i = 0; b = true; j++;
                    }
                }
              
                i = 0; j = 1;
                h = 0; b = true; acum2 = acum3; acum = 0;
                foreach (var che in checkP)
                {
                    if (b)
                    {
                        if (P_array[h].Equals("x"))
                        {
                            if (acum == acum2)
                            { break; }
                                h++; acum2--; b = false;
                        }
                        if (P_array[h].Equals(vp[i]) && uuu[h] == j)
                        {
                            che.Checked = true; acum++;
                            h++; b = false;

                            if (acum == acum2)
                            {
                                break;
                            }
                        }
                    }
                    i++;
                    if (i == 6)
                    {
                        i = 0; b = true; j++;
                    }
                }
            }
             fh = f;
             f = h;
       
            i = 0; j = 0;
            var comms = new List<RichTextBox> { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };
            foreach (var com in comms)
            {
                if (notas[j] != i + 1)
                {
                    com.Text = comment[i];
                }
                else
                {
                    j++;
                }
                i++;

            }
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            picture1.Parent = pictureBox2;
            picture1.BackColor = Color.Transparent;
            var etiquetas = new List<Label> { label4, label7, label6, la, lab, prop, cons };
            foreach (var et in etiquetas)
            {
                et.Parent = pictureBox2;
                et.BackColor = Color.Transparent;
            }
            var groups = new List<GroupBox> { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8, groupBox8, groupBox9, groupBox10, groupBox11, groupBox12, groupBox13, groupBox14, groupBox15, groupBox16, groupBox17, groupBox18, groupBox19, groupBox20 };
            foreach (var gr in groups)
            {
                gr.Parent = pictureBox2;
                gr.BackColor = Color.Transparent;
            }
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            h = 0; int i = 0, j;
            int a1 = 0, a2 = 0, a3 = 0, a4 = 0, a5 = 0, a6 = 0, a7 = 0, a8 = 0, a9 = 0, a10 = 0;

            var labels = new List<RichTextBox> { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };

            foreach (var label in labels)
            {

                if (label.Text != "")
                {
                    comment[i] = label.Text.ToString();
                }
                else
                {
                    comment[i] = "NO APLICA";
                }
                i++;
            }

            var checksC = new List<CheckBox> { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox24, checkBox23, checkBox22, checkBox21, checkBox20, checkBox19, checkBox36, checkBox35, checkBox34, checkBox33, checkBox32, checkBox31, checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox60, checkBox59, checkBox58, checkBox57, checkBox56, checkBox55, checkBox72, checkBox71, checkBox70, checkBox69, checkBox68, checkBox67, checkBox84, checkBox83, checkBox82, checkBox81, checkBox80, checkBox79, checkBox96, checkBox95, checkBox94, checkBox93, checkBox92, checkBox91, checkBox108, checkBox107, checkBox106, checkBox105, checkBox104, checkBox103, checkBox120, checkBox119, checkBox118, checkBox117, checkBox116, checkBox115 };
            var checksP = new List<CheckBox> { checkBox12, checkBox11, checkBox10, checkBox9, checkBox8, checkBox7, checkBox18, checkBox17, checkBox16, checkBox15, checkBox14, checkBox13, checkBox30, checkBox29, checkBox28, checkBox27, checkBox26, checkBox25, checkBox42, checkBox41, checkBox40, checkBox39, checkBox38, checkBox37, checkBox54, checkBox53, checkBox52, checkBox51, checkBox50, checkBox49, checkBox66, checkBox65, checkBox64, checkBox63, checkBox62, checkBox61, checkBox78, checkBox77, checkBox76, checkBox75, checkBox74, checkBox73, checkBox90, checkBox89, checkBox88, checkBox87, checkBox86, checkBox85, checkBox102, checkBox101, checkBox100, checkBox99, checkBox98, checkBox97, checkBox114, checkBox113, checkBox112, checkBox111, checkBox110, checkBox109 };
            int[] valor = { 0, 1, 2, 3, 4, 5 };
            double[] valor1 = { 0.1, 0.5, 1, 3, 6, 10 };

            i = 0; j = 0;
            foreach (var check in checksC)
            {

                if (check.Checked)
                {
                    c[h] = valor[i];

                    if (j <= 5) { a1 += 1; }
                    else if (j > 5 && j <= 11) { a2 += 1; }
                    else if (j > 11 && j <= 17) { a3 += 1; }
                    else if (j > 17 && j <= 23) { a4 += 1; }
                    else if (j > 23 && j <= 29) { a5 += 1; }
                    else if (j > 29 && j <= 35) { a6 += 1; }
                    else if (j > 35 && j <= 41) { a7 += 1; }
                    else if (j > 41 && j <= 47) { a8 += 1; }
                    else if (j > 47 && j <= 53) { a9 += 1; }
                    else if (j > 53 && j <= 59) { a10 += 1; }
                    h++;
                }

                if (i == 5)
                {
                    i = -1;
                }
                i++;
                j++;
            }

            h = 0; i = 0; j = 0;
            foreach (var check in checksP)
            {

                if (check.Checked)
                {
                    p[h] = valor1[i];


                    if (j <= 5) { a1 += 1; u[h] = 1; }
                    else if (j > 5 && j <= 11) { a2 += 1; u[h] = 2; }
                    else if (j > 11 && j <= 17) { a3 += 1; u[h] = 3; }
                    else if (j > 17 && j <= 23) { a4 += 1; u[h] = 4; }
                    else if (j > 23 && j <= 29) { a5 += 1; u[h] = 5; }
                    else if (j > 29 && j <= 35) { a6 += 1; u[h] = 6; }
                    else if (j > 35 && j <= 41) { a7 += 1; u[h] = 7; }
                    else if (j > 41 && j <= 47) { a8 += 1; u[h] = 8; }
                    else if (j > 47 && j <= 53) { a9 += 1; u[h] = 9; }
                    else if (j > 53 && j <= 59) { a10 += 1; u[h] = 10; }
                    h++;
                }
                if (i == 5)
                {
                    i = -1;
                }
                i++;
                j++;
            }

            for (i = 0; i < h; i++)
            {
                if (c[i] == 0 && u[i] == 1 || c[i] == 0 && u[i] == 2
                || c[i] == 0 && u[i] == 3 || c[i] == 0 && u[i] == 4
                || c[i] == 0 && u[i] == 5 || c[i] == 0 && u[i] == 6||
                c[i] == 0 && u[i] == 9)
                {
                    cou++;

                }
            }

            if (a1 == 1 || a2 == 1 || a3 == 1 || a4 == 1 || a5 == 1 || a6 == 1 || a7 == 1 || a8 == 1 || a9 == 1 || a10 == 1)
            {
                    MessageBox.Show("Falta llenar una opción de la consecuencia o probabilidad");
                    cou = 0;
                   }else{
                Form here = new Form2M(this);
                    here.Show();
                    Visible = false;
                   }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Form here = new Principal();
            here.Show();
            Visible = false;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        } 


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox1.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                checkBox11.Checked = false;
                checkBox10.Checked = false;
                checkBox9.Checked = false;
                checkBox8.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                checkBox10.Checked = false;
                checkBox12.Checked = false;
                checkBox9.Checked = false;
                checkBox8.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox9.Checked = false;
                checkBox8.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                checkBox11.Checked = false;
                checkBox10.Checked = false;
                checkBox12.Checked = false;
                checkBox8.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                checkBox11.Checked = false;
                checkBox10.Checked = false;
                checkBox9.Checked = false;
                checkBox12.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox11.Checked = false;
                checkBox10.Checked = false;
                checkBox9.Checked = false;
                checkBox8.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox18.Checked == true)
            {
                checkBox17.Checked = false;
                checkBox16.Checked = false;
                checkBox15.Checked = false;
                checkBox14.Checked = false;
                checkBox13.Checked = false;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true)
            {
                checkBox18.Checked = false;
                checkBox16.Checked = false;
                checkBox15.Checked = false;
                checkBox14.Checked = false;
                checkBox13.Checked = false;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true)
            {
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox15.Checked = false;
                checkBox14.Checked = false;
                checkBox13.Checked = false;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                checkBox17.Checked = false;
                checkBox16.Checked = false;
                checkBox18.Checked = false;
                checkBox14.Checked = false;
                checkBox13.Checked = false;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                checkBox17.Checked = false;
                checkBox16.Checked = false;
                checkBox15.Checked = false;
                checkBox18.Checked = false;
                checkBox13.Checked = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                checkBox17.Checked = false;
                checkBox16.Checked = false;
                checkBox15.Checked = false;
                checkBox14.Checked = false;
                checkBox18.Checked = false;
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked == true)
            {
                checkBox23.Checked = false;
                checkBox22.Checked = false;
                checkBox21.Checked = false;
                checkBox20.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == true)
            {
                checkBox22.Checked = false;
                checkBox21.Checked = false;
                checkBox20.Checked = false;
                checkBox19.Checked = false;
                checkBox24.Checked = false;
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                checkBox23.Checked = false;
                checkBox24.Checked = false;
                checkBox21.Checked = false;
                checkBox20.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked == true)
            {
                checkBox23.Checked = false;
                checkBox22.Checked = false;
                checkBox24.Checked = false;
                checkBox20.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                checkBox23.Checked = false;
                checkBox22.Checked = false;
                checkBox21.Checked = false;
                checkBox24.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                checkBox23.Checked = false;
                checkBox22.Checked = false;
                checkBox21.Checked = false;
                checkBox20.Checked = false;
                checkBox24.Checked = false;
            }
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
               if (checkBox36.Checked == true)
            {
                checkBox35.Checked = false;
                checkBox34.Checked = false;
                checkBox33.Checked = false;
                checkBox32.Checked = false;
                checkBox31.Checked = false;
            }
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
               if (checkBox31.Checked == true)
            {
                checkBox32.Checked = false;
                checkBox33.Checked = false;
                checkBox34.Checked = false;
                checkBox35.Checked = false;
                checkBox36.Checked = false;
            }
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
               if (checkBox32.Checked == true)
            {
                checkBox31.Checked = false;
                checkBox33.Checked = false;
                checkBox34.Checked = false;
                checkBox35.Checked = false;
                checkBox36.Checked = false;
            }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox33.Checked == true)
            {
                checkBox32.Checked = false;
                checkBox31.Checked = false;
                checkBox34.Checked = false;
                checkBox35.Checked = false;
                checkBox36.Checked = false;
            }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox34.Checked == true)
            {
                checkBox32.Checked = false;
                checkBox33.Checked = false;
                checkBox31.Checked = false;
                checkBox35.Checked = false;
                checkBox36.Checked = false;
            }
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox35.Checked == true)
            {
                checkBox32.Checked = false;
                checkBox33.Checked = false;
                checkBox34.Checked = false;
                checkBox31.Checked = false;
                checkBox36.Checked = false;
            }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked == true)
            {
                checkBox29.Checked = false;
                checkBox28.Checked = false;
                checkBox27.Checked = false;
                checkBox26.Checked = false;
                checkBox25.Checked = false;
            }
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked == true)
            {
                checkBox28.Checked = false;
                checkBox27.Checked = false;
                checkBox26.Checked = false;
                checkBox25.Checked = false;
                checkBox30.Checked = false;
            }
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked == true)
            {
                checkBox29.Checked = false;
                checkBox27.Checked = false;
                checkBox26.Checked = false;
                checkBox25.Checked = false;
                checkBox30.Checked = false;
            }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked == true)
            {
                checkBox28.Checked = false;
                checkBox30.Checked = false;
                checkBox26.Checked = false;
                checkBox25.Checked = false;
                checkBox29.Checked = false;
            }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked == true)
            {
                checkBox30.Checked = false;
                checkBox29.Checked = false;
                checkBox28.Checked = false;
                checkBox27.Checked = false;
                checkBox25.Checked = false;
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == true)
            {
                checkBox30.Checked = false;
                checkBox29.Checked = false;
                checkBox28.Checked = false;
                checkBox27.Checked = false;
                checkBox26.Checked = false;
            }
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox42.Checked == true)
            {
                checkBox41.Checked = false;
                checkBox40.Checked = false;
                checkBox39.Checked = false;
                checkBox38.Checked = false;
                checkBox37.Checked = false;
            }
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox41.Checked == true)
            {
                checkBox42.Checked = false;
                checkBox40.Checked = false;
                checkBox39.Checked = false;
                checkBox38.Checked = false;
                checkBox37.Checked = false;
            }
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox40.Checked == true)
            {
                checkBox39.Checked = false;
                checkBox38.Checked = false;
                checkBox37.Checked = false;
                checkBox41.Checked = false;
                checkBox42.Checked = false;
            }
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox39.Checked == true)
            {
                checkBox38.Checked = false;
                checkBox37.Checked = false;
                checkBox40.Checked = false;
                checkBox41.Checked = false;
                checkBox42.Checked = false;
            }
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox38.Checked == true)
            {
                checkBox37.Checked = false;
                checkBox40.Checked = false;
                checkBox41.Checked = false;
                checkBox42.Checked = false;
                checkBox39.Checked = false;
            }
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox37.Checked == true)
            {
                checkBox38.Checked = false;
                checkBox39.Checked = false;
                checkBox40.Checked = false;
                checkBox41.Checked = false;
                checkBox42.Checked = false;
            }
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox48.Checked == true)
            {
                checkBox47.Checked = false;
                checkBox46.Checked = false;
                checkBox45.Checked = false;
                checkBox44.Checked = false;
                checkBox43.Checked = false;
            }
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox47.Checked == true)
            {
                checkBox48.Checked = false;
                checkBox46.Checked = false;
                checkBox45.Checked = false;
                checkBox44.Checked = false;
                checkBox43.Checked = false;
            }
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox46.Checked == true)
            {
                checkBox47.Checked = false;
                checkBox48.Checked = false;
                checkBox45.Checked = false;
                checkBox44.Checked = false;
                checkBox43.Checked = false;
            }
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox45.Checked == true)
            {
                checkBox47.Checked = false;
                checkBox46.Checked = false;
                checkBox48.Checked = false;
                checkBox44.Checked = false;
                checkBox43.Checked = false;
            }
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox44.Checked == true)
            {
                checkBox47.Checked = false;
                checkBox48.Checked = false;
                checkBox45.Checked = false;
                checkBox46.Checked = false;
                checkBox43.Checked = false;
            }
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox43.Checked == true)
            {
                checkBox47.Checked = false;
                checkBox48.Checked = false;
                checkBox45.Checked = false;
                checkBox44.Checked = false;
                checkBox46.Checked = false;
            }
        }

        private void checkBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox54.Checked == true)
            {
                checkBox53.Checked = false;
                checkBox52.Checked = false;
                checkBox51.Checked = false;
                checkBox50.Checked = false;
                checkBox49.Checked = false;
            }
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox53.Checked == true)
            {
                checkBox52.Checked = false;
                checkBox51.Checked = false;
                checkBox50.Checked = false;
                checkBox49.Checked = false;
                checkBox54.Checked = false;
            }
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox52.Checked == true)
            {
                checkBox53.Checked = false;
                checkBox54.Checked = false;
                checkBox51.Checked = false;
                checkBox50.Checked = false;
                checkBox49.Checked = false;
            }
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox51.Checked == true)
            {
                checkBox53.Checked = false;
                checkBox52.Checked = false;
                checkBox54.Checked = false;
                checkBox50.Checked = false;
                checkBox49.Checked = false;
            }
        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox50.Checked == true)
            {
                checkBox53.Checked = false;
                checkBox52.Checked = false;
                checkBox51.Checked = false;
                checkBox54.Checked = false;
                checkBox49.Checked = false;
            }
        }

        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox49.Checked == true)
            {
                checkBox53.Checked = false;
                checkBox52.Checked = false;
                checkBox51.Checked = false;
                checkBox50.Checked = false;
                checkBox54.Checked = false;
            }
        }

        private void checkBox60_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox60.Checked == true)
            {
                checkBox59.Checked = false;
                checkBox58.Checked = false;
                checkBox57.Checked = false;
                checkBox56.Checked = false;
                checkBox55.Checked = false;
            }
        }

        private void checkBox59_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox59.Checked == true)
            {
                checkBox58.Checked = false;
                checkBox57.Checked = false;
                checkBox56.Checked = false;
                checkBox55.Checked = false;
                checkBox60.Checked = false;
            }
        }

        private void checkBox58_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox58.Checked == true)
            {
                checkBox59.Checked = false;
                checkBox60.Checked = false;
                checkBox57.Checked = false;
                checkBox56.Checked = false;
                checkBox55.Checked = false;
            }
        }

        private void checkBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox57.Checked == true)
            {
                checkBox59.Checked = false;
                checkBox58.Checked = false;
                checkBox60.Checked = false;
                checkBox56.Checked = false;
                checkBox55.Checked = false;
            }
        }

        private void checkBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox56.Checked == true)
            {
                checkBox59.Checked = false;
                checkBox58.Checked = false;
                checkBox57.Checked = false;
                checkBox60.Checked = false;
                checkBox55.Checked = false;
            }
        }

        private void checkBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox55.Checked == true)
            {
                checkBox59.Checked = false;
                checkBox58.Checked = false;
                checkBox57.Checked = false;
                checkBox56.Checked = false;
                checkBox60.Checked = false;
            }
        }

        private void checkBox72_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox72.Checked == true)
            {
                checkBox71.Checked = false;
                checkBox70.Checked = false;
                checkBox69.Checked = false;
                checkBox68.Checked = false;
                checkBox67.Checked = false;
            }
        }

        private void checkBox71_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox71.Checked == true)
            {
                checkBox70.Checked = false;
                checkBox69.Checked = false;
                checkBox68.Checked = false;
                checkBox67.Checked = false;
                checkBox72.Checked = false;
            }
        }

        private void checkBox70_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox70.Checked == true)
            {
                checkBox71.Checked = false;
                checkBox72.Checked = false;
                checkBox69.Checked = false;
                checkBox68.Checked = false;
                checkBox67.Checked = false;
            }
        }

        private void checkBox69_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox69.Checked == true)
            {
                checkBox71.Checked = false;
                checkBox70.Checked = false;
                checkBox72.Checked = false;
                checkBox68.Checked = false;
                checkBox67.Checked = false;
            }
        }

        private void checkBox68_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox68.Checked == true)
            {
                checkBox71.Checked = false;
                checkBox70.Checked = false;
                checkBox69.Checked = false;
                checkBox72.Checked = false;
                checkBox67.Checked = false;
            }
        }

        private void checkBox67_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox67.Checked == true)
            {
                checkBox71.Checked = false;
                checkBox70.Checked = false;
                checkBox69.Checked = false;
                checkBox68.Checked = false;
                checkBox72.Checked = false;
            }
        }

        private void checkBox66_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox66.Checked == true)
            {
                checkBox65.Checked = false;
                checkBox64.Checked = false;
                checkBox63.Checked = false;
                checkBox62.Checked = false;
                checkBox61.Checked = false;
            }
        }

        private void checkBox65_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox65.Checked == true)
            {
                checkBox66.Checked = false;
                checkBox64.Checked = false;
                checkBox63.Checked = false;
                checkBox62.Checked = false;
                checkBox61.Checked = false;
            }
        }

        private void checkBox64_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox64.Checked == true)
            {
                checkBox66.Checked = false;
                checkBox65.Checked = false;
                checkBox63.Checked = false;
                checkBox62.Checked = false;
                checkBox61.Checked = false;
            }
        }

        private void checkBox63_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox63.Checked == true)
            {
                checkBox66.Checked = false;
                checkBox64.Checked = false;
                checkBox65.Checked = false;
                checkBox62.Checked = false;
                checkBox61.Checked = false;
            }
        }

        private void checkBox62_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox62.Checked == true)
            {
                checkBox65.Checked = false;
                checkBox64.Checked = false;
                checkBox63.Checked = false;
                checkBox66.Checked = false;
                checkBox61.Checked = false;
            }
        }

        private void checkBox61_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox61.Checked == true)
            {
                checkBox66.Checked = false;
                checkBox64.Checked = false;
                checkBox63.Checked = false;
                checkBox62.Checked = false;
                checkBox65.Checked = false;
            }
        }

        private void checkBox84_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox84.Checked == true)
            {
                checkBox83.Checked = false;
                checkBox82.Checked = false;
                checkBox81.Checked = false;
                checkBox80.Checked = false;
                checkBox79.Checked = false;
            }
        }

        private void checkBox83_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox83.Checked == true)
            {
                checkBox84.Checked = false;
                checkBox82.Checked = false;
                checkBox81.Checked = false;
                checkBox80.Checked = false;
                checkBox79.Checked = false;
            }
        }

        private void checkBox82_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox82.Checked == true)
            {
                checkBox84.Checked = false;
                checkBox83.Checked = false;
                checkBox81.Checked = false;
                checkBox80.Checked = false;
                checkBox79.Checked = false;
            }
        }

        private void checkBox81_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox81.Checked == true)
            {
                checkBox84.Checked = false;
                checkBox82.Checked = false;
                checkBox83.Checked = false;
                checkBox80.Checked = false;
                checkBox79.Checked = false;
            }
        }

        private void checkBox80_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox80.Checked == true)
            {
                checkBox84.Checked = false;
                checkBox82.Checked = false;
                checkBox81.Checked = false;
                checkBox83.Checked = false;
                checkBox79.Checked = false;
            }
        }

        private void checkBox79_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox79.Checked == true)
            {
                checkBox84.Checked = false;
                checkBox82.Checked = false;
                checkBox81.Checked = false;
                checkBox80.Checked = false;
                checkBox83.Checked = false;
            }
        }

        private void checkBox78_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox78.Checked == true)
            {
                checkBox77.Checked = false;
                checkBox76.Checked = false;
                checkBox75.Checked = false;
                checkBox74.Checked = false;
                checkBox73.Checked = false;
            }
        }

        private void checkBox77_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox77.Checked == true)
            {
                checkBox76.Checked = false;
                checkBox75.Checked = false;
                checkBox74.Checked = false;
                checkBox73.Checked = false;
                checkBox78.Checked = false;
            }
        }

        private void checkBox76_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox76.Checked == true)
            {
                checkBox75.Checked = false;
                checkBox74.Checked = false;
                checkBox73.Checked = false;
                checkBox78.Checked = false;
                checkBox77.Checked = false;
            }
        }

        private void checkBox75_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox75.Checked == true)
            {
                checkBox77.Checked = false;
                checkBox78.Checked = false;
                checkBox74.Checked = false;
                checkBox73.Checked = false;
                checkBox76.Checked = false;
            }
        }

        private void checkBox74_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox74.Checked == true)
            {
                checkBox77.Checked = false;
                checkBox76.Checked = false;
                checkBox75.Checked = false;
                checkBox78.Checked = false;
                checkBox73.Checked = false;
            }
        }

        private void checkBox73_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox73.Checked == true)
            {
                checkBox77.Checked = false;
                checkBox76.Checked = false;
                checkBox75.Checked = false;
                checkBox74.Checked = false;
                checkBox78.Checked = false;
            }
        }

        private void checkBox96_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox96.Checked == true)
            {
                checkBox95.Checked = false;
                checkBox94.Checked = false;
                checkBox93.Checked = false;
                checkBox92.Checked = false;
                checkBox91.Checked = false;
            }
        }

        private void checkBox95_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox95.Checked == true)
            {
                checkBox96.Checked = false;
                checkBox94.Checked = false;
                checkBox93.Checked = false;
                checkBox92.Checked = false;
                checkBox91.Checked = false;
            }
        }

        private void checkBox94_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox94.Checked == true)
            {
                checkBox96.Checked = false;
                checkBox95.Checked = false;
                checkBox93.Checked = false;
                checkBox92.Checked = false;
                checkBox91.Checked = false;
            }
        }

        private void checkBox93_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox93.Checked == true)
            {
                checkBox95.Checked = false;
                checkBox94.Checked = false;
                checkBox96.Checked = false;
                checkBox92.Checked = false;
                checkBox91.Checked = false;
            }
        }

        private void checkBox92_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox92.Checked == true)
            {
                checkBox95.Checked = false;
                checkBox94.Checked = false;
                checkBox93.Checked = false;
                checkBox96.Checked = false;
                checkBox91.Checked = false;
            }
        }

        private void checkBox91_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox91.Checked == true)
            {
                checkBox95.Checked = false;
                checkBox94.Checked = false;
                checkBox93.Checked = false;
                checkBox92.Checked = false;
                checkBox96.Checked = false;
            }
        }

        private void checkBox90_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox90.Checked == true)
            {
                checkBox89.Checked = false;
                checkBox88.Checked = false;
                checkBox87.Checked = false;
                checkBox86.Checked = false;
                checkBox85.Checked = false;
            }
        }

        private void checkBox89_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox89.Checked == true)
            {
                checkBox88.Checked = false;
                checkBox87.Checked = false;
                checkBox86.Checked = false;
                checkBox85.Checked = false;
                checkBox90.Checked = false;
            }
        }

        private void checkBox88_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox88.Checked == true)
            {
                checkBox86.Checked = false;
                checkBox87.Checked = false;
                checkBox89.Checked = false;
                checkBox85.Checked = false;
                checkBox90.Checked = false;
            }
        }

        private void checkBox87_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox87.Checked == true)
            {
                checkBox88.Checked = false;
                checkBox89.Checked = false;
                checkBox86.Checked = false;
                checkBox85.Checked = false;
                checkBox90.Checked = false;
            }
        }


        private void checkBox86_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox86.Checked == true)
            {
                checkBox88.Checked = false;
                checkBox87.Checked = false;
                checkBox89.Checked = false;
                checkBox85.Checked = false;
                checkBox90.Checked = false;
            }
        }

        private void checkBox85_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox85.Checked == true)
            {
                checkBox88.Checked = false;
                checkBox87.Checked = false;
                checkBox86.Checked = false;
                checkBox89.Checked = false;
                checkBox90.Checked = false;
            }
        }

        private void checkBox108_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox108.Checked == true)
            {
                checkBox107.Checked = false;
                checkBox106.Checked = false;
                checkBox105.Checked = false;
                checkBox104.Checked = false;
                checkBox103.Checked = false;
            }
        }

        private void checkBox107_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox107.Checked == true)
            {
                checkBox108.Checked = false;
                checkBox106.Checked = false;
                checkBox105.Checked = false;
                checkBox104.Checked = false;
                checkBox103.Checked = false;
            }
        }

        private void checkBox106_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox106.Checked == true)
            {
                checkBox108.Checked = false;
                checkBox107.Checked = false;
                checkBox105.Checked = false;
                checkBox104.Checked = false;
                checkBox103.Checked = false;
            }
        }

        private void checkBox105_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox105.Checked == true)
            {
                checkBox108.Checked = false;
                checkBox106.Checked = false;
                checkBox107.Checked = false;
                checkBox104.Checked = false;
                checkBox103.Checked = false;
            }
        }

        private void checkBox104_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox104.Checked == true)
            {
                checkBox108.Checked = false;
                checkBox106.Checked = false;
                checkBox105.Checked = false;
                checkBox107.Checked = false;
                checkBox103.Checked = false;
            }
        }

        private void checkBox103_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox103.Checked == true)
            {
                checkBox108.Checked = false;
                checkBox106.Checked = false;
                checkBox105.Checked = false;
                checkBox104.Checked = false;
                checkBox107.Checked = false;
            }
        }

        private void checkBox102_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox102.Checked == true)
            {
                checkBox101.Checked = false;
                checkBox100.Checked = false;
                checkBox99.Checked = false;
                checkBox98.Checked = false;
                checkBox97.Checked = false;
            }
        }

        private void checkBox101_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox101.Checked == true)
            {
                checkBox102.Checked = false;
                checkBox100.Checked = false;
                checkBox99.Checked = false;
                checkBox98.Checked = false;
                checkBox97.Checked = false;
            }
        }

        private void checkBox100_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox100.Checked == true)
            {
                checkBox101.Checked = false;
                checkBox102.Checked = false;
                checkBox99.Checked = false;
                checkBox98.Checked = false;
                checkBox97.Checked = false;
            }
        }

        private void checkBox99_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox99.Checked == true)
            {
                checkBox101.Checked = false;
                checkBox100.Checked = false;
                checkBox102.Checked = false;
                checkBox98.Checked = false;
                checkBox97.Checked = false;
            }
        }

        private void checkBox98_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox98.Checked == true)
            {
                checkBox101.Checked = false;
                checkBox100.Checked = false;
                checkBox99.Checked = false;
                checkBox102.Checked = false;
                checkBox97.Checked = false;
            }
        }

        private void checkBox97_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox97.Checked == true)
            {
                checkBox101.Checked = false;
                checkBox100.Checked = false;
                checkBox99.Checked = false;
                checkBox98.Checked = false;
                checkBox102.Checked = false;
            }
        }

        private void checkBox120_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox120.Checked == true)
            {
                checkBox119.Checked = false;
                checkBox118.Checked = false;
                checkBox117.Checked = false;
                checkBox116.Checked = false;
                checkBox115.Checked = false;
            }
        }

        private void checkBox119_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox119.Checked == true)
            {
                checkBox120.Checked = false;
                checkBox118.Checked = false;
                checkBox117.Checked = false;
                checkBox116.Checked = false;
                checkBox115.Checked = false;
            }
        }

        private void checkBox118_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox118.Checked == true)
            {
                checkBox120.Checked = false;
                checkBox119.Checked = false;
                checkBox117.Checked = false;
                checkBox116.Checked = false;
                checkBox115.Checked = false;
            }
        }

        private void checkBox117_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox117.Checked == true)
            {
                checkBox120.Checked = false;
                checkBox118.Checked = false;
                checkBox119.Checked = false;
                checkBox116.Checked = false;
                checkBox115.Checked = false;
            }
        }

        private void checkBox116_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox116.Checked == true)
            {
                checkBox120.Checked = false;
                checkBox118.Checked = false;
                checkBox117.Checked = false;
                checkBox119.Checked = false;
                checkBox115.Checked = false;
            }
        }

        private void checkBox115_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox115.Checked == true)
            {
                checkBox120.Checked = false;
                checkBox118.Checked = false;
                checkBox117.Checked = false;
                checkBox116.Checked = false;
                checkBox119.Checked = false;
            }
        }

        private void checkBox114_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox114.Checked == true)
            {
                checkBox113.Checked = false;
                checkBox112.Checked = false;
                checkBox111.Checked = false;
                checkBox110.Checked = false;
                checkBox109.Checked = false;
            }
        }

        private void checkBox113_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox113.Checked == true)
            {
                checkBox112.Checked = false;
                checkBox111.Checked = false;
                checkBox110.Checked = false;
                checkBox114.Checked = false;
                checkBox109.Checked = false;
            }
        }

        private void checkBox112_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox112.Checked == true)
            {
                checkBox113.Checked = false;
                checkBox111.Checked = false;
                checkBox110.Checked = false;
                checkBox114.Checked = false;
                checkBox109.Checked = false;
            }
        }

        private void checkBox111_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox111.Checked == true)
            {
                checkBox113.Checked = false;
                checkBox112.Checked = false;
                checkBox110.Checked = false;
                checkBox114.Checked = false;
                checkBox109.Checked = false;
            }
        }

        private void checkBox110_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox110.Checked == true)
            {
                checkBox113.Checked = false;
                checkBox111.Checked = false;
                checkBox112.Checked = false;
                checkBox114.Checked = false;
                checkBox109.Checked = false;
            }
        }

        private void checkBox109_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox109.Checked == true)
            {
                checkBox113.Checked = false;
                checkBox111.Checked = false;
                checkBox110.Checked = false;
                checkBox114.Checked = false;
                checkBox112.Checked = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
















      }
    }
