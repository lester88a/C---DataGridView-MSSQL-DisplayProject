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
            ((System.ComponentModel.ISupportInitialize)(this.grdRepair)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRepair
            // 
            this.grdRepair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRepair.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdRepair.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdRepair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRepair.Location = new System.Drawing.Point(459, 42);
            this.grdRepair.Name = "grdRepair";
            this.grdRepair.ReadOnly = true;
            this.grdRepair.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdRepair.Size = new System.Drawing.Size(534, 588);
            this.grdRepair.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Yellow;
            this.lblHeader.Location = new System.Drawing.Point(459, 13);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(138, 24);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Priority Devices";
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPages.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTotalPages.Location = new System.Drawing.Point(710, 16);
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
            this.lblTotalRecords.Location = new System.Drawing.Point(834, 16);
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
            this.lblTotalRows.Location = new System.Drawing.Point(934, 15);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(60, 24);
            this.lblTotalRows.TabIndex = 4;
            this.lblTotalRows.Text = "label1";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1005, 642);
            this.Controls.Add(this.lblTotalRows);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.lblTotalPages);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.grdRepair);
            this.Name = "mainForm";
            this.Text = "Information Board";
            ((System.ComponentModel.ISupportInitialize)(this.grdRepair)).EndInit();
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
    }
}

