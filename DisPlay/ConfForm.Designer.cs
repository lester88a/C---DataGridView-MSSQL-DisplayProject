namespace DisPlay
{
    partial class ConfForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmboxManufacture = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmboxPriorityDevices = new System.Windows.Forms.ComboBox();
            this.cmboxBKS = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmboxTech = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConfOk = new System.Windows.Forms.Button();
            this.btnConfCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manufacture";
            // 
            // cmboxManafacture
            // 
            this.cmboxManufacture.FormattingEnabled = true;
            this.cmboxManufacture.Location = new System.Drawing.Point(12, 32);
            this.cmboxManufacture.Name = "cmboxManafacture";
            this.cmboxManufacture.Size = new System.Drawing.Size(260, 21);
            this.cmboxManufacture.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Page Size of Priority Devices";
            // 
            // cmboxPriorityDevices
            // 
            this.cmboxPriorityDevices.FormattingEnabled = true;
            this.cmboxPriorityDevices.Items.AddRange(new object[] {
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25"});
            this.cmboxPriorityDevices.Location = new System.Drawing.Point(12, 96);
            this.cmboxPriorityDevices.Name = "cmboxPriorityDevices";
            this.cmboxPriorityDevices.Size = new System.Drawing.Size(260, 21);
            this.cmboxPriorityDevices.TabIndex = 5;
            // 
            // cmboxBKS
            // 
            this.cmboxBKS.FormattingEnabled = true;
            this.cmboxBKS.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmboxBKS.Location = new System.Drawing.Point(12, 157);
            this.cmboxBKS.Name = "cmboxBKS";
            this.cmboxBKS.Size = new System.Drawing.Size(260, 21);
            this.cmboxBKS.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Page Size of Back Order";
            // 
            // cmboxTech
            // 
            this.cmboxTech.FormattingEnabled = true;
            this.cmboxTech.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmboxTech.Location = new System.Drawing.Point(12, 222);
            this.cmboxTech.Name = "cmboxTech";
            this.cmboxTech.Size = new System.Drawing.Size(260, 21);
            this.cmboxTech.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Page Size of Technician";
            // 
            // btnConfOk
            // 
            this.btnConfOk.ForeColor = System.Drawing.Color.White;
            this.btnConfOk.Location = new System.Drawing.Point(197, 327);
            this.btnConfOk.Name = "btnConfOk";
            this.btnConfOk.Size = new System.Drawing.Size(75, 23);
            this.btnConfOk.TabIndex = 10;
            this.btnConfOk.Text = "OK";
            this.btnConfOk.UseVisualStyleBackColor = true;
            // 
            // btnConfCancel
            // 
            this.btnConfCancel.ForeColor = System.Drawing.Color.White;
            this.btnConfCancel.Location = new System.Drawing.Point(13, 327);
            this.btnConfCancel.Name = "btnConfCancel";
            this.btnConfCancel.Size = new System.Drawing.Size(75, 23);
            this.btnConfCancel.TabIndex = 11;
            this.btnConfCancel.Text = "Cancel";
            this.btnConfCancel.UseVisualStyleBackColor = true;
            this.btnConfCancel.Click += new System.EventHandler(this.btnConfCancel_Click);
            // 
            // ConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.btnConfCancel);
            this.Controls.Add(this.btnConfOk);
            this.Controls.Add(this.cmboxTech);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmboxBKS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmboxPriorityDevices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmboxManufacture);
            this.Controls.Add(this.label1);
            this.Name = "ConfForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboxManufacture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmboxPriorityDevices;
        private System.Windows.Forms.ComboBox cmboxBKS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmboxTech;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConfOk;
        private System.Windows.Forms.Button btnConfCancel;
    }
}