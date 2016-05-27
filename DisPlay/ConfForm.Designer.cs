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
            this.btnConfOk = new System.Windows.Forms.Button();
            this.btnConfCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Manufacturer";
            // 
            // cmboxManufacture
            // 
            this.cmboxManufacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboxManufacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboxManufacture.FormattingEnabled = true;
            this.cmboxManufacture.Location = new System.Drawing.Point(12, 74);
            this.cmboxManufacture.Name = "cmboxManufacture";
            this.cmboxManufacture.Size = new System.Drawing.Size(260, 24);
            this.cmboxManufacture.TabIndex = 3;
            // 
            // btnConfOk
            // 
            this.btnConfOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfOk.ForeColor = System.Drawing.Color.White;
            this.btnConfOk.Location = new System.Drawing.Point(196, 107);
            this.btnConfOk.Name = "btnConfOk";
            this.btnConfOk.Size = new System.Drawing.Size(75, 23);
            this.btnConfOk.TabIndex = 10;
            this.btnConfOk.Text = "OK";
            this.btnConfOk.UseVisualStyleBackColor = true;
            this.btnConfOk.Click += new System.EventHandler(this.btnConfOk_Click);
            // 
            // btnConfCancel
            // 
            this.btnConfCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfCancel.ForeColor = System.Drawing.Color.White;
            this.btnConfCancel.Location = new System.Drawing.Point(12, 107);
            this.btnConfCancel.Name = "btnConfCancel";
            this.btnConfCancel.Size = new System.Drawing.Size(75, 23);
            this.btnConfCancel.TabIndex = 11;
            this.btnConfCancel.Text = "Exit";
            this.btnConfCancel.UseVisualStyleBackColor = true;
            this.btnConfCancel.Click += new System.EventHandler(this.btnConfCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 9);
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
            this.lblStatus.Location = new System.Drawing.Point(10, 137);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status:";
            // 
            // ConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfCancel);
            this.Controls.Add(this.btnConfOk);
            this.Controls.Add(this.cmboxManufacture);
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
        private System.Windows.Forms.ComboBox cmboxManufacture;
        private System.Windows.Forms.Button btnConfOk;
        private System.Windows.Forms.Button btnConfCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
    }
}