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
            this.btnConfOk = new System.Windows.Forms.Button();
            this.btnConfCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxServerName = new System.Windows.Forms.TextBox();
            this.txtBoxDBName = new System.Windows.Forms.TextBox();
            this.txtBoxManufacturer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Manufacturer:";
            // 
            // btnConfOk
            // 
            this.btnConfOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfOk.ForeColor = System.Drawing.Color.White;
            this.btnConfOk.Location = new System.Drawing.Point(16, 286);
            this.btnConfOk.Name = "btnConfOk";
            this.btnConfOk.Size = new System.Drawing.Size(222, 26);
            this.btnConfOk.TabIndex = 5;
            this.btnConfOk.Text = "Start";
            this.btnConfOk.UseVisualStyleBackColor = true;
            this.btnConfOk.Click += new System.EventHandler(this.btnConfOk_Click);
            // 
            // btnConfCancel
            // 
            this.btnConfCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfCancel.ForeColor = System.Drawing.Color.White;
            this.btnConfCancel.Location = new System.Drawing.Point(228, 3);
            this.btnConfCancel.Name = "btnConfCancel";
            this.btnConfCancel.Size = new System.Drawing.Size(20, 20);
            this.btnConfCancel.TabIndex = 7;
            this.btnConfCancel.Text = "X";
            this.btnConfCancel.UseVisualStyleBackColor = true;
            this.btnConfCancel.Click += new System.EventHandler(this.btnConfCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Configuration";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(13, 315);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "SQL Server Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Database Name:";
            // 
            // txtBoxServerName
            // 
            this.txtBoxServerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxServerName.Location = new System.Drawing.Point(16, 104);
            this.txtBoxServerName.Name = "txtBoxServerName";
            this.txtBoxServerName.Size = new System.Drawing.Size(222, 22);
            this.txtBoxServerName.TabIndex = 0;
            // 
            // txtBoxDBName
            // 
            this.txtBoxDBName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDBName.Location = new System.Drawing.Point(18, 168);
            this.txtBoxDBName.Name = "txtBoxDBName";
            this.txtBoxDBName.Size = new System.Drawing.Size(220, 22);
            this.txtBoxDBName.TabIndex = 1;
            // 
            // txtBoxManufacturer
            // 
            this.txtBoxManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxManufacturer.Location = new System.Drawing.Point(16, 235);
            this.txtBoxManufacturer.Name = "txtBoxManufacturer";
            this.txtBoxManufacturer.Size = new System.Drawing.Size(222, 22);
            this.txtBoxManufacturer.TabIndex = 2;
            // 
            // ConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(250, 350);
            this.Controls.Add(this.txtBoxManufacturer);
            this.Controls.Add(this.txtBoxDBName);
            this.Controls.Add(this.txtBoxServerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfCancel);
            this.Controls.Add(this.btnConfOk);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfOk;
        private System.Windows.Forms.Button btnConfCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxServerName;
        private System.Windows.Forms.TextBox txtBoxDBName;
        private System.Windows.Forms.TextBox txtBoxManufacturer;
    }
}