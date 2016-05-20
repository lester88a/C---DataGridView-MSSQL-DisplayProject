namespace DisPlay
{
    partial class mainForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grdRepair = new System.Windows.Forms.DataGridView();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.lblRepOutput = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdBKSum = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBKSTotalRows = new System.Windows.Forms.Label();
            this.lblTotalRecordsBKS = new System.Windows.Forms.Label();
            this.lblTotalPagesBKS = new System.Windows.Forms.Label();
            this.lblAllAging = new System.Windows.Forms.Label();
            this.blbRepOut07 = new System.Windows.Forms.Label();
            this.grdTechOutput = new System.Windows.Forms.DataGridView();
            this.lblTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdRepair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBKSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTechOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRepair
            // 
            this.grdRepair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRepair.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdRepair.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdRepair.BackgroundColor = System.Drawing.Color.Black;
            this.grdRepair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRepair.Location = new System.Drawing.Point(715, 58);
            this.grdRepair.Name = "grdRepair";
            this.grdRepair.ReadOnly = true;
            this.grdRepair.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdRepair.Size = new System.Drawing.Size(534, 651);
            this.grdRepair.TabIndex = 0;
            this.grdRepair.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdRepair_CellFormatting);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Yellow;
            this.lblHeader.Location = new System.Drawing.Point(710, 25);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(180, 29);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Priority Devices";
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPages.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalPages.Location = new System.Drawing.Point(898, 30);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(60, 24);
            this.lblTotalPages.TabIndex = 2;
            this.lblTotalPages.Text = "label1";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalRecords.Location = new System.Drawing.Point(1022, 30);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(60, 24);
            this.lblTotalRecords.TabIndex = 3;
            this.lblTotalRecords.Text = "label1";
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRows.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalRows.Location = new System.Drawing.Point(1190, 30);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(60, 24);
            this.lblTotalRows.TabIndex = 4;
            this.lblTotalRows.Text = "label1";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Location = new System.Drawing.Point(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 5;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblRepOutput
            // 
            this.lblRepOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRepOutput.AutoSize = true;
            this.lblRepOutput.BackColor = System.Drawing.Color.Transparent;
            this.lblRepOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepOutput.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRepOutput.Location = new System.Drawing.Point(290, 420);
            this.lblRepOutput.Name = "lblRepOutput";
            this.lblRepOutput.Size = new System.Drawing.Size(45, 16);
            this.lblRepOutput.TabIndex = 8;
            this.lblRepOutput.Text = "label1";
            this.lblRepOutput.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(17, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tech Repair Output";
            // 
            // grdBKSum
            // 
            this.grdBKSum.AllowUserToAddRows = false;
            this.grdBKSum.AllowUserToDeleteRows = false;
            this.grdBKSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBKSum.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdBKSum.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdBKSum.BackgroundColor = System.Drawing.Color.Black;
            this.grdBKSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBKSum.Location = new System.Drawing.Point(17, 182);
            this.grdBKSum.Name = "grdBKSum";
            this.grdBKSum.ReadOnly = true;
            this.grdBKSum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdBKSum.Size = new System.Drawing.Size(688, 115);
            this.grdBKSum.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(17, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Back Order Summary";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(17, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Overall Aging";
            // 
            // lblBKSTotalRows
            // 
            this.lblBKSTotalRows.AutoSize = true;
            this.lblBKSTotalRows.BackColor = System.Drawing.Color.Transparent;
            this.lblBKSTotalRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBKSTotalRows.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBKSTotalRows.Location = new System.Drawing.Point(407, 153);
            this.lblBKSTotalRows.Name = "lblBKSTotalRows";
            this.lblBKSTotalRows.Size = new System.Drawing.Size(45, 16);
            this.lblBKSTotalRows.TabIndex = 14;
            this.lblBKSTotalRows.Text = "label1";
            // 
            // lblTotalRecordsBKS
            // 
            this.lblTotalRecordsBKS.AutoSize = true;
            this.lblTotalRecordsBKS.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRecordsBKS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsBKS.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalRecordsBKS.Location = new System.Drawing.Point(332, 153);
            this.lblTotalRecordsBKS.Name = "lblTotalRecordsBKS";
            this.lblTotalRecordsBKS.Size = new System.Drawing.Size(45, 16);
            this.lblTotalRecordsBKS.TabIndex = 15;
            this.lblTotalRecordsBKS.Text = "label1";
            // 
            // lblTotalPagesBKS
            // 
            this.lblTotalPagesBKS.AutoSize = true;
            this.lblTotalPagesBKS.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPagesBKS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagesBKS.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalPagesBKS.Location = new System.Drawing.Point(266, 153);
            this.lblTotalPagesBKS.Name = "lblTotalPagesBKS";
            this.lblTotalPagesBKS.Size = new System.Drawing.Size(45, 16);
            this.lblTotalPagesBKS.TabIndex = 16;
            this.lblTotalPagesBKS.Text = "label1";
            // 
            // lblAllAging
            // 
            this.lblAllAging.AutoSize = true;
            this.lblAllAging.BackColor = System.Drawing.Color.Transparent;
            this.lblAllAging.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllAging.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAllAging.Location = new System.Drawing.Point(16, 58);
            this.lblAllAging.Name = "lblAllAging";
            this.lblAllAging.Size = new System.Drawing.Size(86, 31);
            this.lblAllAging.TabIndex = 17;
            this.lblAllAging.Text = "label1";
            // 
            // blbRepOut07
            // 
            this.blbRepOut07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.blbRepOut07.AutoSize = true;
            this.blbRepOut07.BackColor = System.Drawing.Color.Transparent;
            this.blbRepOut07.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blbRepOut07.ForeColor = System.Drawing.SystemColors.Control;
            this.blbRepOut07.Location = new System.Drawing.Point(19, 420);
            this.blbRepOut07.Name = "blbRepOut07";
            this.blbRepOut07.Size = new System.Drawing.Size(45, 16);
            this.blbRepOut07.TabIndex = 18;
            this.blbRepOut07.Text = "label1";
            this.blbRepOut07.Visible = false;
            // 
            // grdTechOutput
            // 
            this.grdTechOutput.AllowUserToAddRows = false;
            this.grdTechOutput.AllowUserToDeleteRows = false;
            this.grdTechOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grdTechOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTechOutput.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdTechOutput.BackgroundColor = System.Drawing.Color.Black;
            this.grdTechOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTechOutput.Location = new System.Drawing.Point(17, 332);
            this.grdTechOutput.Name = "grdTechOutput";
            this.grdTechOutput.ReadOnly = true;
            this.grdTechOutput.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdTechOutput.Size = new System.Drawing.Size(688, 377);
            this.grdTechOutput.TabIndex = 19;
            this.grdTechOutput.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdTechOutput_CellFormatting);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Lime;
            this.lblTime.Location = new System.Drawing.Point(902, 7);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(347, 23);
            this.lblTime.TabIndex = 20;
            this.lblTime.Text = "label4";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1261, 721);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.blbRepOut07);
            this.Controls.Add(this.lblRepOutput);
            this.Controls.Add(this.lblAllAging);
            this.Controls.Add(this.lblTotalPagesBKS);
            this.Controls.Add(this.lblTotalRecordsBKS);
            this.Controls.Add(this.lblBKSTotalRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdBKSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTotalRows);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.lblTotalPages);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.grdRepair);
            this.Controls.Add(this.grdTechOutput);
            this.Name = "mainForm";
            this.Text = "Information Board";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRepair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBKSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTechOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView grdRepair;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Label lblRepOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdBKSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBKSTotalRows;
        private System.Windows.Forms.Label lblTotalRecordsBKS;
        private System.Windows.Forms.Label lblTotalPagesBKS;
        private System.Windows.Forms.Label lblAllAging;
        private System.Windows.Forms.Label blbRepOut07;
        private System.Windows.Forms.DataGridView grdTechOutput;
        private System.Windows.Forms.Label lblTime;
    }
}

