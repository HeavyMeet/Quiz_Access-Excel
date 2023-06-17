﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
namespace combi
{

    public partial class Form7M : Form
    {

        int i, j, tt;
        double[] x = new double[70];
        double[] xUp = new double[70];
        double[] xIns = new double[70];
        int[] insArray = new int[71];
        int[] notas = new int[10];
        int[] valUp = new int[71];
        int[] valUpU = new int[71];
        int[] valUp1 = new int[71];
        String[] preg = new String[70];
        String[] cumplio = new String[70];
        String[] cumplioUP = new String[70];
        String[] cumplioINS = new String[70];
        String[] ccc = new String[70];
        String[] ppp = new String[70];
        String[] ccc1 = new String[70];
        String[] ppp1 = new String[70];
    OleDbConnection conn = new OleDbConnection();
        Form1M o; int couu, co = 0, n=0; String ress;
        public Form7M(Form1M variables)
        {
            InitializeComponent();
            this.o = variables;
            // conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Franky Real\Desktop\matriz\Estacion_ideal.accdb;
            conn.ConnectionString = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\erick\Desktop\folder\Estacion_ideal.accdb;
            Persist Security Info=False";

            couu = this.o.cou;
            tt = this.o.h;
            this.o.h = this.o.f;
         

            var checkC = new List<CheckBox> { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox24, checkBox23, checkBox22, checkBox21, checkBox20, checkBox19, checkBox36, checkBox35, checkBox34, checkBox33, checkBox32, checkBox31, checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox60, checkBox59, checkBox58, checkBox57, checkBox56, checkBox55, checkBox72, checkBox71, checkBox70, checkBox69, checkBox68, checkBox67, checkBox84, checkBox83, checkBox82, checkBox81, checkBox80, checkBox79, checkBox96, checkBox95, checkBox94, checkBox93, checkBox92, checkBox91, checkBox108, checkBox107, checkBox106, checkBox105, checkBox104, checkBox103, checkBox120, checkBox119, checkBox118, checkBox117, checkBox116, checkBox115 };
            var checkP = new List<CheckBox> { checkBox12, checkBox11, checkBox10, checkBox9, checkBox8, checkBox7, checkBox18, checkBox17, checkBox16, checkBox15, checkBox14, checkBox13, checkBox30, checkBox29, checkBox28, checkBox27, checkBox26, checkBox25, checkBox42, checkBox41, checkBox40, checkBox39, checkBox38, checkBox37, checkBox54, checkBox53, checkBox52, checkBox51, checkBox50, checkBox49, checkBox66, checkBox65, checkBox64, checkBox63, checkBox62, checkBox61, checkBox78, checkBox77, checkBox76, checkBox75, checkBox74, checkBox73, checkBox90, checkBox89, checkBox88, checkBox87, checkBox86, checkBox85, checkBox102, checkBox101, checkBox100, checkBox99, checkBox98, checkBox97, checkBox114, checkBox113, checkBox112, checkBox111, checkBox110, checkBox109 };
            String[] vc = { "0", "1", "2", "3", "4", "5" }; String[] vp = { "0.1", "0.5", "1", "3", "6", "10" };
            i = 0; j = 61; int acum2 = 0, acumm = 0;
            bool b = true;


            for (int i = 0; this.o.uuu[i] != 0; i++)
            {
                for (int j = 61; j <= 70; j++)
                {
                    if (this.o.uuu[i] == j)
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

                        if (this.o.C_array[this.o.h].Equals("x"))
                        {
                            notas[n]= this.o.uuu[this.o.h]; n++; this.o.h++; acum2--; b = false;
                            if (this.o.uuu[this.o.h] == 0)
                                break;                         
                        }    
                           
                        if (this.o.C_array[this.o.h].Equals(vc[i]) && this.o.uuu[this.o.h] == j)
                        {
                            che.Checked = true;
                            this.o.h++; b = false; acumm++;
                 
                            if (acumm == acum2)
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
                i = 0; j = 61; acum2 = acum3;
                this.o.h = this.o.f; b = true; acumm = 0;
                foreach (var che in checkP)
                {
                    if (b)
                    {
                        if (this.o.P_array[this.o.h].Equals("x"))
                        {
                            this.o.h++; acum2--; b = false;
                            if (this.o.uuu[this.o.h] == 0)
                                break;
                            
                        }
                        if (this.o.P_array[this.o.h].Equals(vp[i]) && this.o.uuu[this.o.h] == j)
                        {
                            che.Checked = true;

                            this.o.h++; b = false; acumm++;
                           
                            if (acumm == acum2)
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
            this.o.f = this.o.h;

            i = 60; j = 0;
            var comms = new List<RichTextBox> { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };
            foreach (var com in comms)
            {
                if (notas[j]!=i+1)
                {
                   
                    com.Text = this.o.comment[i];
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
            picture1.Parent = pictureBox1;
            picture1.BackColor = Color.Transparent;
            var etiquetas = new List<Label> { label4, label7, label6, la, lab, prop, cons };
            foreach (var et in etiquetas)
            {
                et.Parent = pictureBox1;
                et.BackColor = Color.Transparent;
            }
            var groups = new List<GroupBox> { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8, groupBox8, groupBox9, groupBox10, groupBox11, groupBox12, groupBox13, groupBox14, groupBox15, groupBox16, groupBox17, groupBox18, groupBox19, groupBox20 };
            foreach (var gr in groups)
            {
                gr.Parent = pictureBox1;
                gr.BackColor = Color.Transparent;
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            int i = 60, j; this.o.h = tt;
            int a1 = 0, a2 = 0, a3 = 0, a4 = 0, a5 = 0, a6 = 0, a7 = 0, a8 = 0, a9 = 0, a10 = 0;

            var labels = new List<RichTextBox> { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };

            foreach (var label in labels)
            {

                if (label.Text != "")
                {
                    this.o.comment[i] = label.Text.ToString();
                }
                else { this.o.comment[i] = "NO APLICA"; }
              
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
                    this.o.c[this.o.h] = valor[i];

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
                    this.o.h++;
                }

                if (i == 5)
                {
                    i = -1;
                }
                i++;
                j++;
            }

            this.o.h = tt; i = 0; j = 0;
            foreach (var check in checksP)
            {

                if (check.Checked)
                {
                    this.o.p[this.o.h] = valor1[i];


                    if (j <= 5) { a1 += 1; this.o.u[this.o.h] = 61; }
                    else if (j > 5 && j <= 11) { a2 += 1; this.o.u[this.o.h] = 62; }
                    else if (j > 11 && j <= 17) { a3 += 1; this.o.u[this.o.h] = 63; }
                    else if (j > 17 && j <= 23) { a4 += 1; this.o.u[this.o.h] = 64; }
                    else if (j > 23 && j <= 29) { a5 += 1; this.o.u[this.o.h] = 65; }
                    else if (j > 29 && j <= 35) { a6 += 1; this.o.u[this.o.h] = 66; }
                    else if (j > 35 && j <= 41) { a7 += 1; this.o.u[this.o.h] = 67; }
                    else if (j > 41 && j <= 47) { a8 += 1; this.o.u[this.o.h] = 68; }
                    else if (j > 47 && j <= 53) { a9 += 1; this.o.u[this.o.h] = 69; }
                    else if (j > 53 && j <= 59) { a10 += 1; this.o.u[this.o.h] = 70; }
                    this.o.h++;
                }
                if (i == 5)
                {
                    i = -1;
                }
                i++;
                j++;
            }


            for (i = tt; i < this.o.h; i++)
            {
            if (this.o.c[i] == 0  && this.o.u[i] == 61 || this.o.c[i] == 0  && this.o.u[i] == 62
            || this.o.c[i] == 0  && this.o.u[i] == 63 || this.o.c[i] == 0  && this.o.u[i] == 66 || this.o.c[i] == 0 && this.o.u[i] == 67
             || this.o.c[i] == 0  && this.o.u[i] == 69 || this.o.c[i] == 0  && this.o.u[i] == 70)
             {
                    this.o.cou++;
             }
             else if (this.o.c[i] == 0 && this.o.u[i] == 65)
             {
                co = 1; this.o.cou++;
             }
            }

            if (a1 == 1 || a2 == 1 || a3 == 1 || a4 == 1 || a5 == 1 || a6 == 1 || a7 == 1 || a8 == 1 || a9 == 1 || a10 == 1)
            {
                MessageBox.Show("Falta llenar una opción de la consecuencia o probabilidad");
                if (couu == 27)
                    this.o.cou = 27;
                this.o.h = tt;
            }
            else
            {
                double acum1 = 0;
                for (i = 0; i < this.o.h; i++)
                {
                    x[i] = this.o.c[i] * this.o.p[i];

                    acum1 += (this.o.c[i] * this.o.p[i]);
                }

                acum1 = (acum1 * (double)this.o.h) / 70;

                for (i = 0; i < this.o.h; i++)
                {
                    if (x[i] > 5)
                    {
                        cumplio[i] = "NO";
                    }
                    else
                    {
                        cumplio[i] = "SI";
                    }
                }

                double ji = (35 * (double)this.o.h) / 70;
                double jci = (349 * (double)this.o.h) / 70;
                double jni = (3500 * (double)this.o.h) / 70;
                MessageBox.Show("Espere un momento. Oprima Aceptar");


                if (acum1 >= 0 && acum1 <= ji)
                {

                    ress = "Job ideal";
                }
                else if (acum1 > ji && acum1 <= jci)
                {
                    ress = "Job casi ideal";
                }
                else if (acum1 > jci && acum1 <= jni)
                {
                    ress = "Job no ideal";
                }

                String recom;

                if (this.o.cou == 35 && ress.Equals("Job ideal"))
                {
                    recom = "Gestante y/o M/H";
                }
                else if (co == 1 && ress.Equals("Job ideal"))
                {
                    recom = "Mujer u Hombre";
                }
                else if (!(ress.Equals("Job no ideal")))
                {
                    recom = "Hombre";
                }
                else
                {
                    recom = "Nadie";
                }

                DateTime now = DateTime.Now;
                string date = now.ToString("yyyy/MM/dd HH:mm:ss");
                float a = Convert.ToSingle(acum1);

                OleDbCommand coms = new OleDbCommand();

                try
                {
                    conn.Open();
                    coms.Connection = conn;
                    coms.CommandText = "UPDATE registroEstacion SET resultado = '" + ress + "',puntaje = " + a + ",recomendada = '"
                    + recom + "',fecha = '" + date + "' WHERE estacion = " + this.o.est1 + " AND job = '" + this.o.job1 + "'";
                    coms.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString());
                }
                conn.Close();

                int k = 0, k1 = 0, k2 = 0, k3 = 0; bool b = true;

                for (i = 0; this.o.u[i] != 0; i++)
                {
                    for (j = 0; this.o.uuu[j] != 0; j++)
                    {
                        if (this.o.uuu[j] == this.o.u[i])
                        {
                            valUpU[k3] = i;
                            k3++;
                            b = false;
                            break;
                        }
                        if (this.o.uuu[j] > this.o.u[i])
                        {
                            break;
                        }
                    }
                    if (b == true)
                    {
                        insArray[k] = this.o.u[i];
                        ccc[k] = ((decimal)this.o.c[i]).ToString();
                        ppp[k] = ((decimal)this.o.p[i]).ToString();
                        xIns[k] = x[i];
                        cumplioINS[k] = cumplio[i];
                        k++;
                    }
                    b = true;
                }

                for (i = 0; this.o.uuu[i] != 0; i++)
                {
                    for (j = 0; this.o.u[j] != 0; j++)
                    {
                        if (this.o.u[j] == this.o.uuu[i])
                        {
                            valUp[k1] = i;
                            k1++;
                            break;
                        }
                        if (this.o.uuu[i] < this.o.u[j])
                        {
                            valUp1[k2] = i;
                            k2++;
                            break;
                        }
                        if (this.o.u[j + 1] == 0)
                        {
                            valUp1[k2] = i;
                            k2++;
                            break;
                        }
                    }
                }

                for (i = 0; i < k1; i++)
                {
                    xUp[valUp[i]] = x[valUpU[i]];
                    cumplioUP[valUp[i]] = cumplio[valUpU[i]];
                    ccc1[valUp[i]] = ((decimal)this.o.c[valUpU[i]]).ToString();
                    ppp1[valUp[i]] = ((decimal)this.o.p[valUpU[i]]).ToString();
                }
                for (i = 0; i < k2; i++)
                {
                    xUp[valUp1[i]] = 0;
                    cumplioUP[valUp1[i]] = "NO APLICA";
                    ccc1[valUp1[i]] = "x";
                    ppp1[valUp1[i]] = "x";
                }
           
                int aux = k;

                k = 0;
                do
                {
                    try
                    {
                        OleDbDataReader dr = null;
                        conn.Open();
                        coms.Connection = conn;
                        String query = "select indicador from indicadores where ID=" + this.o.uuu[k];                      
                        OleDbCommand cos = new OleDbCommand(query, conn);
                        dr = cos.ExecuteReader();
                        dr.Read();
                        preg[k] = dr["indicador"].ToString();
                        coms.CommandText = "UPDATE registroJOB SET indicador = '" + preg[k] + "',cumple = '" + cumplioUP[k] + "',puntaje = " + xUp[k] +
                        ", observaciones = '" + this.o.comment[(this.o.uuu[k] - 1)] + "', fecha = '" + date +
                        "' WHERE job = '" + this.o.job1 + "' AND num = " + this.o.uuu[k] + "";
                            coms.ExecuteNonQuery();
                            k++;                        
                    }catch (Exception ex) 
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    conn.Close();

                } while (k < this.o.fh);

                k = 0;
                while (k < aux) 
                   {
                    try
                    {
                        OleDbDataReader dr = null;
                        conn.Open();
                        coms.Connection = conn;
                        String query = "select indicador from indicadores where ID=" + insArray[k];
                        OleDbCommand cos = new OleDbCommand(query, conn);
                        dr = cos.ExecuteReader();
                        dr.Read();
                        preg[k] = dr["indicador"].ToString();
                      
                        //MessageBox.Show(insArray[k] + " uuu " + x[k] + " x " + cumplio[k]);
                        coms.CommandText = "insert into registroJOB (ou,estacion,job,num,indicador,cumple,puntaje,observaciones,fecha)" +
                        "values ('" + this.o.ou1 + "'," + this.o.est1 + ",'" + this.o.job1 + "'," + insArray[k] + ",'" + preg[k] + "','"
                        + cumplioINS[k] + "'," + xIns[k] + ",'" + this.o.comment[insArray[k] - 1] +
                        "','" + date + "')";
                        coms.ExecuteNonQuery();
                        k++;
                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                       conn.Close();

                  }

                k = 0;
                do
                {
                    try
                    {
                        conn.Open();
                        coms.Connection = conn;
                        coms.CommandText = "UPDATE matriz SET c = '" + ccc1[k] + "', p = '" + ppp1[k] + "', fecha = '" + date +
                            "' WHERE job = '" + this.o.job1 + "' AND num = " + this.o.uuu[k] + "";
                        coms.ExecuteNonQuery();
                        k++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    conn.Close();

                } while (k < this.o.fh);

                k = 0;
                while (k < aux)
                {
                    try
                    {
                        conn.Open();
                        coms.Connection = conn;
                        coms.CommandText = "insert into matriz (num,c,p,job,fecha,ou,est) values" +
                        "(" + insArray[k] + ",'" + ccc[k] + "','" + ppp[k] + "','" + this.o.job1 + "','" + date + "','" + this.o.ou1 + "'," + this.o.est1 + ")";
                        coms.ExecuteNonQuery();
                        k++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    conn.Close();

                }

                MessageBox.Show("Su cuestionario ha sido registrado");
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

//if ((radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked || radioButton6.Checked) && (radioButton7.Checked || radioButton8.Checked || radioButton9.Checked || radioButton10.Checked || radioButton11.Checked || radioButton12.Checked))
//{
//    verif+=1;
//}

//if ((radioButton13.Checked || radioButton14.Checked || radioButton15.Checked || radioButton16.Checked || radioButton17.Checked || radioButton18.Checked) && (radioButton19.Checked || radioButton20.Checked || radioButton21.Checked || radioButton22.Checked || radioButton23.Checked || radioButton24.Checked)){
//     verif+=1;
//}
//   if ((radioButton25.Checked || radioButton26.Checked || radioButton27.Checked || radioButton28.Checked || radioButton29.Checked || radioButton30.Checked) && (radioButton31.Checked || radioButton32.Checked || radioButton33.Checked || radioButton34.Checked || radioButton35.Checked || radioButton36.Checked)) {

//   }
//if  ((radioButton37.Checked || radioButton38.Checked || radioButton39.Checked || radioButton40.Checked || radioButton41.Checked || radioButton42.Checked) && (radioButton43.Checked || radioButton44.Checked || radioButton45.Checked || radioButton46.Checked || radioButton47.Checked || radioButton48.Checked)) {}
// if ((radioButton49.Checked || radioButton50.Checked || radioButton51.Checked || radioButton52.Checked || radioButton53.Checked || radioButton54.Checked) && (radioButton55.Checked || radioButton56.Checked || radioButton57.Checked || radioButton58.Checked || radioButton59.Checked || radioButton60.Checked)) {}
//  if ((radioButton61.Checked || radioButton62.Checked || radioButton63.Checked || radioButton64.Checked || radioButton65.Checked || radioButton66.Checked) && (radioButton67.Checked || radioButton68.Checked || radioButton69.Checked || radioButton70.Checked || radioButton71.Checked || radioButton72.Checked)) {}
//  if ((radioButton73.Checked || radioButton74.Checked || radioButton75.Checked || radioButton76.Checked || radioButton77.Checked || radioButton78.Checked) && (radioButton79.Checked || radioButton80.Checked || radioButton81.Checked || radioButton82.Checked || radioButton83.Checked || radioButton84.Checked)) {}
//  if ((radioButton85.Checked || radioButton86.Checked || radioButton87.Checked || radioButton88.Checked || radioButton89.Checked || radioButton90.Checked) && (radioButton91.Checked || radioButton92.Checked || radioButton93.Checked || radioButton94.Checked || radioButton95.Checked || radioButton96.Checked)) {}
//  if ((radioButton97.Checked || radioButton98.Checked || radioButton99.Checked || radioButton100.Checked || radioButton101.Checked || radioButton102.Checked) && (radioButton103.Checked || radioButton104.Checked || radioButton105.Checked || radioButton106.Checked || radioButton107.Checked || radioButton108.Checked)) {}
//  if ((radioButton109.Checked || radioButton110.Checked || radioButton111.Checked || radioButton112.Checked || radioButton113.Checked || radioButton114.Checked) && (radioButton115.Checked || radioButton116.Checked || radioButton117.Checked || radioButton118.Checked || radioButton119.Checked || radioButton120.Checked)){}
    