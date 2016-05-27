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
            this.label3 = new System.Windows.Forms.Label();
            this.cboxSerName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSetDatabase = new System.Windows.Forms.Button();
            this.cboxDatabaseName = new System.Windows.Forms.ComboBox();
            this.btnSetServerName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Manufacturer:";
            // 
            // cmboxManufacture
            // 
            this.cmboxManufacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboxManufacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboxManufacture.FormattingEnabled = true;
            this.cmboxManufacture.Location = new System.Drawing.Point(16, 267);
            this.cmboxManufacture.Name = "cmboxManufacture";
            this.cmboxManufacture.Size = new System.Drawing.Size(153, 24);
            this.cmboxManufacture.TabIndex = 4;
            // 
            // btnConfOk
            // 
            this.btnConfOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfOk.ForeColor = System.Drawing.Color.White;
            this.btnConfOk.Location = new System.Drawing.Point(175, 268);
            this.btnConfOk.Name = "btnConfOk";
            this.btnConfOk.Size = new System.Drawing.Size(113, 23);
            this.btnConfOk.TabIndex = 5;
            this.btnConfOk.Text = "Start";
            this.btnConfOk.UseVisualStyleBackColor = true;
            this.btnConfOk.Click += new System.EventHandler(this.btnConfOk_Click);
            // 
            // btnConfCancel
            // 
            this.btnConfCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfCancel.ForeColor = System.Drawing.Color.White;
            this.btnConfCancel.Location = new System.Drawing.Point(268, 9);
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
            // cboxSerName
            // 
            this.cboxSerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxSerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSerName.FormattingEnabled = true;
            this.cboxSerName.Location = new System.Drawing.Point(16, 103);
            this.cboxSerName.Name = "cboxSerName";
            this.cboxSerName.Size = new System.Drawing.Size(153, 24);
            this.cboxSerName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Database Name:";
            // 
            // btnSetDatabase
            // 
            this.btnSetDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetDatabase.ForeColor = System.Drawing.Color.White;
            this.btnSetDatabase.Location = new System.Drawing.Point(175, 186);
            this.btnSetDatabase.Name = "btnSetDatabase";
            this.btnSetDatabase.Size = new System.Drawing.Size(113, 23);
            this.btnSetDatabase.TabIndex = 3;
            this.btnSetDatabase.Text = "Set Database";
            this.btnSetDatabase.UseVisualStyleBackColor = true;
            this.btnSetDatabase.Click += new System.EventHandler(this.btnSetDatabase_Click);
            // 
            // cboxDatabaseName
            // 
            this.cboxDatabaseName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxDatabaseName.FormattingEnabled = true;
            this.cboxDatabaseName.Location = new System.Drawing.Point(16, 185);
            this.cboxDatabaseName.Name = "cboxDatabaseName";
            this.cboxDatabaseName.Size = new System.Drawing.Size(153, 24);
            this.cboxDatabaseName.TabIndex = 2;
            // 
            // btnSetServerName
            // 
            this.btnSetServerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetServerName.ForeColor = System.Drawing.Color.White;
            this.btnSetServerName.Location = new System.Drawing.Point(175, 104);
            this.btnSetServerName.Name = "btnSetServerName";
            this.btnSetServerName.Size = new System.Drawing.Size(113, 23);
            this.btnSetServerName.TabIndex = 1;
            this.btnSetServerName.Text = "Set Server";
            this.btnSetServerName.UseVisualStyleBackColor = true;
            this.btnSetServerName.Click += new System.EventHandler(this.btnSetServerName_Click);
            // 
            // ConfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Controls.Add(this.btnSetServerName);
            this.Controls.Add(this.cboxDatabaseName);
            this.Controls.Add(this.btnSetDatabase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboxSerName);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxSerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSetDatabase;
        private System.Windows.Forms.ComboBox cboxDatabaseName;
        private System.Windows.Forms.Button btnSetServerName;
    }
}