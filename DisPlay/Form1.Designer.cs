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
            this.label2 = new System.Windows.Forms.Label();
            this.grdBKSum = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBKSTotalRows = new System.Windows.Forms.Label();
            this.lblTotalRecordsBKS = new System.Windows.Forms.Label();
            this.lblTotalPagesBKS = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grdTechOutput = new System.Windows.Forms.DataGridView();
            this.lblTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAg1 = new System.Windows.Forms.Label();
            this.lblAg2 = new System.Windows.Forms.Label();
            this.lblAg3 = new System.Windows.Forms.Label();
            this.lblAg4 = new System.Windows.Forms.Label();
            this.lblAg5 = new System.Windows.Forms.Label();
            this.lblAg6 = new System.Windows.Forms.Label();
            this.lblAg7 = new System.Windows.Forms.Label();
            this.grdTechOutput2 = new System.Windows.Forms.DataGridView();
            this.lblTechOutTotalRows = new System.Windows.Forms.Label();
            this.lblManufacture = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.label0 = new System.Windows.Forms.Label();
            this.lblOverAllAgingTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdRepair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBKSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTechOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTechOutput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(17, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tech Daily Repair Output";
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
            this.lblBKSTotalRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBKSTotalRows.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBKSTotalRows.Location = new System.Drawing.Point(491, 153);
            this.lblBKSTotalRows.Name = "lblBKSTotalRows";
            this.lblBKSTotalRows.Size = new System.Drawing.Size(51, 20);
            this.lblBKSTotalRows.TabIndex = 14;
            this.lblBKSTotalRows.Text = "label1";
            // 
            // lblTotalRecordsBKS
            // 
            this.lblTotalRecordsBKS.AutoSize = true;
            this.lblTotalRecordsBKS.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRecordsBKS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsBKS.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalRecordsBKS.Location = new System.Drawing.Point(331, 151);
            this.lblTotalRecordsBKS.Name = "lblTotalRecordsBKS";
            this.lblTotalRecordsBKS.Size = new System.Drawing.Size(51, 20);
            this.lblTotalRecordsBKS.TabIndex = 15;
            this.lblTotalRecordsBKS.Text = "label1";
            // 
            // lblTotalPagesBKS
            // 
            this.lblTotalPagesBKS.AutoSize = true;
            this.lblTotalPagesBKS.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPagesBKS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagesBKS.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalPagesBKS.Location = new System.Drawing.Point(263, 151);
            this.lblTotalPagesBKS.Name = "lblTotalPagesBKS";
            this.lblTotalPagesBKS.Size = new System.Drawing.Size(51, 20);
            this.lblTotalPagesBKS.TabIndex = 16;
            this.lblTotalPagesBKS.Text = "label1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(16, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(526, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Days:     0        1        2       3       4       5       6       7+";
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
            this.grdTechOutput.Size = new System.Drawing.Size(339, 377);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(16, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 29);
            this.label4.TabIndex = 22;
            this.label4.Text = "Qty:";
            // 
            // lblAg1
            // 
            this.lblAg1.AutoSize = true;
            this.lblAg1.BackColor = System.Drawing.Color.Transparent;
            this.lblAg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAg1.ForeColor = System.Drawing.Color.Lime;
            this.lblAg1.Location = new System.Drawing.Point(159, 104);
            this.lblAg1.Name = "lblAg1";
            this.lblAg1.Size = new System.Drawing.Size(52, 29);
            this.lblAg1.TabIndex = 23;
            this.lblAg1.Text = "000";
            // 
            // lblAg2
            // 
            this.lblAg2.AutoSize = true;
            this.lblAg2.BackColor = System.Drawing.Color.Transparent;
            this.lblAg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAg2.ForeColor = System.Drawing.Color.Red;
            this.lblAg2.Location = new System.Drawing.Point(217, 104);
            this.lblAg2.Name = "lblAg2";
            this.lblAg2.Size = new System.Drawing.Size(52, 29);
            this.lblAg2.TabIndex = 24;
            this.lblAg2.Text = "000";
            // 
            // lblAg3
            // 
            this.lblAg3.AutoSize = true;
            this.lblAg3.BackColor = System.Drawing.Color.Transparent;
            this.lblAg3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAg3.ForeColor = System.Drawing.Color.Red;
            this.lblAg3.Location = new System.Drawing.Point(276, 104);
            this.lblAg3.Name = "lblAg3";
            this.lblAg3.Size = new System.Drawing.Size(52, 29);
            this.lblAg3.TabIndex = 25;
            this.lblAg3.Text = "000";
            // 
            // lblAg4
            // 
            this.lblAg4.AutoSize = true;
            this.lblAg4.BackColor = System.Drawing.Color.Transparent;
            this.lblAg4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAg4.ForeColor = System.Drawing.Color.Red;
            this.lblAg4.Location = new System.Drawing.Point(330, 104);
            this.lblAg4.Name = "lblAg4";
            this.lblAg4.Size = new System.Drawing.Size(52, 29);
            this.lblAg4.TabIndex = 26;
            this.lblAg4.Text = "000";
            // 
            // lblAg5
            // 
            this.lblAg5.AutoSize = true;
            this.lblAg5.BackColor = System.Drawing.Color.Transparent;
            this.lblAg5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAg5.ForeColor = System.Drawing.Color.Red;
            this.lblAg5.Location = new System.Drawing.Point(386, 104);
            this.lblAg5.Name = "lblAg5";
            this.lblAg5.Size = new System.Drawing.Size(52, 29);
            this.lblAg5.TabIndex = 27;
            this.lblAg5.Text = "000";
            // 
            // lblAg6
            // 
            this.lblAg6.AutoSize = true;
            this.lblAg6.BackColor = System.Drawing.Color.Transparent;
            this.lblAg6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAg6.ForeColor = System.Drawing.Color.Red;
            this.lblAg6.Location = new System.Drawing.Point(442, 104);
            this.lblAg6.Name = "lblAg6";
            this.lblAg6.Size = new System.Drawing.Size(52, 29);
            this.lblAg6.TabIndex = 28;
            this.lblAg6.Text = "000";
            // 
            // lblAg7
            // 
            this.lblAg7.AutoSize = true;
            this.lblAg7.BackColor = System.Drawing.Color.Transparent;
            this.lblAg7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAg7.ForeColor = System.Drawing.Color.Red;
            this.lblAg7.Location = new System.Drawing.Point(499, 104);
            this.lblAg7.Name = "lblAg7";
            this.lblAg7.Size = new System.Drawing.Size(52, 29);
            this.lblAg7.TabIndex = 29;
            this.lblAg7.Text = "000";
            // 
            // grdTechOutput2
            // 
            this.grdTechOutput2.AllowUserToAddRows = false;
            this.grdTechOutput2.AllowUserToDeleteRows = false;
            this.grdTechOutput2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grdTechOutput2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTechOutput2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdTechOutput2.BackgroundColor = System.Drawing.Color.Black;
            this.grdTechOutput2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTechOutput2.Location = new System.Drawing.Point(362, 332);
            this.grdTechOutput2.Name = "grdTechOutput2";
            this.grdTechOutput2.ReadOnly = true;
            this.grdTechOutput2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdTechOutput2.Size = new System.Drawing.Size(347, 377);
            this.grdTechOutput2.TabIndex = 30;
            this.grdTechOutput2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdTechOutput_CellFormatting);
            // 
            // lblTechOutTotalRows
            // 
            this.lblTechOutTotalRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTechOutTotalRows.AutoSize = true;
            this.lblTechOutTotalRows.BackColor = System.Drawing.Color.Transparent;
            this.lblTechOutTotalRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTechOutTotalRows.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTechOutTotalRows.Location = new System.Drawing.Point(305, 307);
            this.lblTechOutTotalRows.Name = "lblTechOutTotalRows";
            this.lblTechOutTotalRows.Size = new System.Drawing.Size(51, 20);
            this.lblTechOutTotalRows.TabIndex = 31;
            this.lblTechOutTotalRows.Text = "label1";
            // 
            // lblManufacture
            // 
            this.lblManufacture.AutoSize = true;
            this.lblManufacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManufacture.ForeColor = System.Drawing.Color.White;
            this.lblManufacture.Location = new System.Drawing.Point(520, 78);
            this.lblManufacture.Name = "lblManufacture";
            this.lblManufacture.Size = new System.Drawing.Size(0, 24);
            this.lblManufacture.TabIndex = 32;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(552, 30);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(152, 105);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 33;
            this.pictureBox.TabStop = false;
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
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.BackColor = System.Drawing.Color.Transparent;
            this.label0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label0.ForeColor = System.Drawing.Color.Lime;
            this.label0.Location = new System.Drawing.Point(101, 104);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(52, 29);
            this.label0.TabIndex = 34;
            this.label0.Text = "000";
            // 
            // lblOverAllAgingTotal
            // 
            this.lblOverAllAgingTotal.AutoSize = true;
            this.lblOverAllAgingTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblOverAllAgingTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverAllAgingTotal.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOverAllAgingTotal.Location = new System.Drawing.Point(181, 34);
            this.lblOverAllAgingTotal.Name = "lblOverAllAgingTotal";
            this.lblOverAllAgingTotal.Size = new System.Drawing.Size(51, 20);
            this.lblOverAllAgingTotal.TabIndex = 35;
            this.lblOverAllAgingTotal.Text = "label1";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1261, 721);
            this.Controls.Add(this.lblOverAllAgingTotal);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.lblManufacture);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblTechOutTotalRows);
            this.Controls.Add(this.grdTechOutput2);
            this.Controls.Add(this.lblAg7);
            this.Controls.Add(this.lblAg6);
            this.Controls.Add(this.lblAg5);
            this.Controls.Add(this.lblAg4);
            this.Controls.Add(this.lblAg3);
            this.Controls.Add(this.lblAg2);
            this.Controls.Add(this.lblAg1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label5);
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
            ((System.ComponentModel.ISupportInitialize)(this.grdBKSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTechOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTechOutput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdBKSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBKSTotalRows;
        private System.Windows.Forms.Label lblTotalRecordsBKS;
        private System.Windows.Forms.Label lblTotalPagesBKS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdTechOutput;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAg1;
        private System.Windows.Forms.Label lblAg2;
        private System.Windows.Forms.Label lblAg3;
        private System.Windows.Forms.Label lblAg4;
        private System.Windows.Forms.Label lblAg5;
        private System.Windows.Forms.Label lblAg6;
        private System.Windows.Forms.Label lblAg7;
        private System.Windows.Forms.DataGridView grdTechOutput2;
        private System.Windows.Forms.Label lblTechOutTotalRows;
        private System.Windows.Forms.Label lblManufacture;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label lblOverAllAgingTotal;
    }
}

