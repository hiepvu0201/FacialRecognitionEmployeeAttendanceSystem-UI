namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.ManagementSystem
{
    partial class frmAttendanceAndSalary
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpAttendanceHistory = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchDateAttendance = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnSearchSpecificAttendance = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvCheckAttendanceHistory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPayslips = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpPayslipsHistory = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchDatePayslip = new System.Windows.Forms.Button();
            this.ExportToExcelPayslip = new System.Windows.Forms.Button();
            this.btnSearchSpecificSalary = new System.Windows.Forms.Button();
            this.txtSearchPayslips = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckAttendanceHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayslips)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 755);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvCheckAttendanceHistory, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvPayslips, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 755);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.Controls.Add(this.dtpAttendanceHistory, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearchDateAttendance, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExportExcel, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearchSpecificAttendance, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSearch, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBack, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1002, 37);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dtpAttendanceHistory
            // 
            this.dtpAttendanceHistory.AllowDrop = true;
            this.dtpAttendanceHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpAttendanceHistory.Location = new System.Drawing.Point(40, 2);
            this.dtpAttendanceHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dtpAttendanceHistory.Name = "dtpAttendanceHistory";
            this.dtpAttendanceHistory.Size = new System.Drawing.Size(184, 20);
            this.dtpAttendanceHistory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearchDateAttendance
            // 
            this.btnSearchDateAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchDateAttendance.Location = new System.Drawing.Point(228, 2);
            this.btnSearchDateAttendance.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchDateAttendance.Name = "btnSearchDateAttendance";
            this.btnSearchDateAttendance.Size = new System.Drawing.Size(86, 33);
            this.btnSearchDateAttendance.TabIndex = 2;
            this.btnSearchDateAttendance.Text = "Search";
            this.btnSearchDateAttendance.UseVisualStyleBackColor = true;
            this.btnSearchDateAttendance.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportExcel.Location = new System.Drawing.Point(824, 2);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(86, 33);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnSearchSpecificAttendance
            // 
            this.btnSearchSpecificAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchSpecificAttendance.Location = new System.Drawing.Point(735, 3);
            this.btnSearchSpecificAttendance.Name = "btnSearchSpecificAttendance";
            this.btnSearchSpecificAttendance.Size = new System.Drawing.Size(84, 31);
            this.btnSearchSpecificAttendance.TabIndex = 6;
            this.btnSearchSpecificAttendance.Text = "Search";
            this.btnSearchSpecificAttendance.UseVisualStyleBackColor = true;
            this.btnSearchSpecificAttendance.Click += new System.EventHandler(this.btnSearchSpecificAttendance_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(409, 3);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(320, 31);
            this.txtSearch.TabIndex = 7;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Location = new System.Drawing.Point(915, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(84, 31);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvCheckAttendanceHistory
            // 
            this.dgvCheckAttendanceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckAttendanceHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckAttendanceHistory.Location = new System.Drawing.Point(2, 43);
            this.dgvCheckAttendanceHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCheckAttendanceHistory.Name = "dgvCheckAttendanceHistory";
            this.dgvCheckAttendanceHistory.RowHeadersWidth = 51;
            this.dgvCheckAttendanceHistory.RowTemplate.Height = 24;
            this.dgvCheckAttendanceHistory.Size = new System.Drawing.Size(1002, 312);
            this.dgvCheckAttendanceHistory.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1000, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "Payslips Section";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPayslips
            // 
            this.dgvPayslips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayslips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayslips.Location = new System.Drawing.Point(3, 442);
            this.dgvPayslips.Name = "dgvPayslips";
            this.dgvPayslips.Size = new System.Drawing.Size(1000, 310);
            this.dgvPayslips.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.Controls.Add(this.dtpPayslipsHistory, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSearchDatePayslip, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.ExportToExcelPayslip, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSearchSpecificSalary, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSearchPayslips, 4, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 400);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1002, 37);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // dtpPayslipsHistory
            // 
            this.dtpPayslipsHistory.AllowDrop = true;
            this.dtpPayslipsHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPayslipsHistory.Location = new System.Drawing.Point(40, 2);
            this.dtpPayslipsHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dtpPayslipsHistory.Name = "dtpPayslipsHistory";
            this.dtpPayslipsHistory.Size = new System.Drawing.Size(184, 20);
            this.dtpPayslipsHistory.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(2, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearchDatePayslip
            // 
            this.btnSearchDatePayslip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchDatePayslip.Location = new System.Drawing.Point(228, 2);
            this.btnSearchDatePayslip.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchDatePayslip.Name = "btnSearchDatePayslip";
            this.btnSearchDatePayslip.Size = new System.Drawing.Size(86, 33);
            this.btnSearchDatePayslip.TabIndex = 2;
            this.btnSearchDatePayslip.Text = "Search";
            this.btnSearchDatePayslip.UseVisualStyleBackColor = true;
            this.btnSearchDatePayslip.Click += new System.EventHandler(this.btnSearchDatePayslip_Click);
            // 
            // ExportToExcelPayslip
            // 
            this.ExportToExcelPayslip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExportToExcelPayslip.Location = new System.Drawing.Point(914, 2);
            this.ExportToExcelPayslip.Margin = new System.Windows.Forms.Padding(2);
            this.ExportToExcelPayslip.Name = "ExportToExcelPayslip";
            this.ExportToExcelPayslip.Size = new System.Drawing.Size(86, 33);
            this.ExportToExcelPayslip.TabIndex = 3;
            this.ExportToExcelPayslip.Text = "Export Excel";
            this.ExportToExcelPayslip.UseVisualStyleBackColor = true;
            this.ExportToExcelPayslip.Click += new System.EventHandler(this.ExportToExcelPayslip_Click);
            // 
            // btnSearchSpecificSalary
            // 
            this.btnSearchSpecificSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchSpecificSalary.Location = new System.Drawing.Point(825, 3);
            this.btnSearchSpecificSalary.Name = "btnSearchSpecificSalary";
            this.btnSearchSpecificSalary.Size = new System.Drawing.Size(84, 31);
            this.btnSearchSpecificSalary.TabIndex = 6;
            this.btnSearchSpecificSalary.Text = "Search";
            this.btnSearchSpecificSalary.UseVisualStyleBackColor = true;
            this.btnSearchSpecificSalary.Click += new System.EventHandler(this.btnSearchSpecificSalary_Click);
            // 
            // txtSearchPayslips
            // 
            this.txtSearchPayslips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchPayslips.Location = new System.Drawing.Point(409, 3);
            this.txtSearchPayslips.Multiline = true;
            this.txtSearchPayslips.Name = "txtSearchPayslips";
            this.txtSearchPayslips.Size = new System.Drawing.Size(410, 31);
            this.txtSearchPayslips.TabIndex = 7;
            // 
            // frmAttendanceAndSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 755);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAttendanceAndSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance And Salary";
            this.Load += new System.EventHandler(this.frmCheckAttendanceHistory_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckAttendanceHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayslips)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAttendanceHistory;
        private System.Windows.Forms.DataGridView dgvCheckAttendanceHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSearchDateAttendance;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvPayslips;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchSpecificAttendance;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker dtpPayslipsHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchDatePayslip;
        private System.Windows.Forms.Button ExportToExcelPayslip;
        private System.Windows.Forms.Button btnSearchSpecificSalary;
        private System.Windows.Forms.TextBox txtSearchPayslips;
        private System.Windows.Forms.Button btnBack;
    }
}