namespace combi
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_datos = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.crear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.JOB_DropDown = new System.Windows.Forms.ComboBox();
            this.EST_DropDown = new System.Windows.Forms.ComboBox();
            this.OU_DropDown = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(256, 89);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 17);
            this.label19.TabIndex = 251;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(631, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 69);
            this.label2.TabIndex = 254;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(484, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(556, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Encuesta de estación de trabajo ideal.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_datos
            // 
            this.btn_datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_datos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_datos.Location = new System.Drawing.Point(1065, 596);
            this.btn_datos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_datos.Name = "btn_datos";
            this.btn_datos.Size = new System.Drawing.Size(160, 46);
            this.btn_datos.TabIndex = 263;
            this.btn_datos.Text = "Datos";
            this.btn_datos.UseVisualStyleBackColor = true;
            this.btn_datos.Click += new System.EventHandler(this.btn_datos_Click);
            // 
            // modificar
            // 
            this.modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.modificar.Location = new System.Drawing.Point(693, 596);
            this.modificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(160, 46);
            this.modificar.TabIndex = 262;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // crear
            // 
            this.crear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.crear.Location = new System.Drawing.Point(348, 596);
            this.crear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.crear.Name = "crear";
            this.crear.Size = new System.Drawing.Size(160, 46);
            this.crear.TabIndex = 261;
            this.crear.Text = "Crear";
            this.crear.UseVisualStyleBackColor = true;
            this.crear.Click += new System.EventHandler(this.crear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(77, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 29);
            this.label3.TabIndex = 260;
            this.label3.Text = "Job";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(77, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 29);
            this.label4.TabIndex = 259;
            this.label4.Text = "Estación";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(77, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 29);
            this.label5.TabIndex = 258;
            this.label5.Text = "OU";
            // 
            // JOB_DropDown
            // 
            this.JOB_DropDown.BackColor = System.Drawing.SystemColors.ControlLight;
            this.JOB_DropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JOB_DropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JOB_DropDown.FormattingEnabled = true;
            this.JOB_DropDown.Location = new System.Drawing.Point(219, 384);
            this.JOB_DropDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JOB_DropDown.Name = "JOB_DropDown";
            this.JOB_DropDown.Size = new System.Drawing.Size(1052, 37);
            this.JOB_DropDown.TabIndex = 256;
            // 
            // EST_DropDown
            // 
            this.EST_DropDown.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EST_DropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EST_DropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EST_DropDown.FormattingEnabled = true;
            this.EST_DropDown.Location = new System.Drawing.Point(219, 314);
            this.EST_DropDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EST_DropDown.Name = "EST_DropDown";
            this.EST_DropDown.Size = new System.Drawing.Size(108, 37);
            this.EST_DropDown.TabIndex = 257;
            this.EST_DropDown.SelectedIndexChanged += new System.EventHandler(this.EST_DropDown_SelectedIndexChanged);
            // 
            // OU_DropDown
            // 
            this.OU_DropDown.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OU_DropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OU_DropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OU_DropDown.FormattingEnabled = true;
            this.OU_DropDown.Location = new System.Drawing.Point(219, 252);
            this.OU_DropDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OU_DropDown.Name = "OU_DropDown";
            this.OU_DropDown.Size = new System.Drawing.Size(108, 37);
            this.OU_DropDown.TabIndex = 255;
            this.OU_DropDown.SelectedIndexChanged += new System.EventHandler(this.OU_DropDown_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(644, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(452, 53);
            this.pictureBox1.TabIndex = 252;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::combi.Properties.Resources.light_gray;
            this.pictureBox2.Location = new System.Drawing.Point(0, -2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1543, 725);
            this.pictureBox2.TabIndex = 264;
            this.pictureBox2.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 726);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_datos);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.crear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.JOB_DropDown);
            this.Controls.Add(this.EST_DropDown);
            this.Controls.Add(this.OU_DropDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estación Ideal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_datos;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Button crear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox JOB_DropDown;
        private System.Windows.Forms.ComboBox EST_DropDown;
        private System.Windows.Forms.ComboBox OU_DropDown;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

