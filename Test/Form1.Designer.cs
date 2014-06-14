namespace Test
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusRTK = new System.Windows.Forms.Panel();
            this.lblDevIdRTK = new System.Windows.Forms.Label();
            this.lblDevIdAF = new System.Windows.Forms.Label();
            this.statusAF = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCodeRTK = new System.Windows.Forms.Label();
            this.lblCodeAF = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusRTK.SuspendLayout();
            this.statusAF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Device,
            this.Code});
            this.dataGridView1.Location = new System.Drawing.Point(13, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(745, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCodeRTK);
            this.groupBox1.Controls.Add(this.lblDevIdRTK);
            this.groupBox1.Controls.Add(this.statusRTK);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Realtek Semiconductor Corp. (RTK)";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCodeAF);
            this.groupBox2.Controls.Add(this.lblDevIdAF);
            this.groupBox2.Controls.Add(this.statusAF);
            this.groupBox2.Location = new System.Drawing.Point(388, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 134);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ITE Tech. Inc. (IT) / Afatech Technologies, Inc. (AF)";
            this.groupBox2.UseCompatibleTextRendering = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Test.Properties.Resources.ico_realtek;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 59);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // statusRTK
            // 
            this.statusRTK.BackColor = System.Drawing.Color.Silver;
            this.statusRTK.Controls.Add(this.pictureBox1);
            this.statusRTK.Location = new System.Drawing.Point(26, 29);
            this.statusRTK.Name = "statusRTK";
            this.statusRTK.Size = new System.Drawing.Size(65, 65);
            this.statusRTK.TabIndex = 1;
            // 
            // lblDevIdRTK
            // 
            this.lblDevIdRTK.Location = new System.Drawing.Point(26, 97);
            this.lblDevIdRTK.Name = "lblDevIdRTK";
            this.lblDevIdRTK.Size = new System.Drawing.Size(65, 23);
            this.lblDevIdRTK.TabIndex = 2;
            this.lblDevIdRTK.Text = "n.a.";
            this.lblDevIdRTK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDevIdAF
            // 
            this.lblDevIdAF.Location = new System.Drawing.Point(27, 97);
            this.lblDevIdAF.Name = "lblDevIdAF";
            this.lblDevIdAF.Size = new System.Drawing.Size(65, 23);
            this.lblDevIdAF.TabIndex = 4;
            this.lblDevIdAF.Text = "n.a.";
            this.lblDevIdAF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // statusAF
            // 
            this.statusAF.BackColor = System.Drawing.Color.Silver;
            this.statusAF.Controls.Add(this.pictureBox2);
            this.statusAF.Location = new System.Drawing.Point(27, 29);
            this.statusAF.Name = "statusAF";
            this.statusAF.Size = new System.Drawing.Size(65, 65);
            this.statusAF.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Test.Properties.Resources.ico_it;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 59);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Device
            // 
            this.Device.HeaderText = "Device";
            this.Device.Name = "Device";
            this.Device.ReadOnly = true;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // lblCodeRTK
            // 
            this.lblCodeRTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCodeRTK.Location = new System.Drawing.Point(97, 61);
            this.lblCodeRTK.Name = "lblCodeRTK";
            this.lblCodeRTK.Size = new System.Drawing.Size(266, 23);
            this.lblCodeRTK.TabIndex = 3;
            this.lblCodeRTK.Text = "-";
            this.lblCodeRTK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCodeAF
            // 
            this.lblCodeAF.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCodeAF.Location = new System.Drawing.Point(98, 61);
            this.lblCodeAF.Name = "lblCodeAF";
            this.lblCodeAF.Size = new System.Drawing.Size(266, 23);
            this.lblCodeAF.TabIndex = 4;
            this.lblCodeAF.Text = "-";
            this.lblCodeAF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 518);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "RTK-IR Test Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusRTK.ResumeLayout(false);
            this.statusAF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel statusRTK;
        private System.Windows.Forms.Label lblDevIdRTK;
        private System.Windows.Forms.Label lblDevIdAF;
        private System.Windows.Forms.Panel statusAF;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Device;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.Label lblCodeRTK;
        private System.Windows.Forms.Label lblCodeAF;
    }
}

