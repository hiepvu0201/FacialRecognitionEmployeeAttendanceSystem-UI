
namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.ManagementSystem
{
    partial class frmMonthlyAttendanceAndSalary
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTableOfAttendance = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportSalary = new System.Windows.Forms.Button();
            this.btnSearchSpecificSalary = new System.Windows.Forms.Button();
            this.dtpMonthlySalary = new System.Windows.Forms.DateTimePicker();
            this.txtSearchSpecificNameForSalary = new System.Windows.Forms.TextBox();
            this.btnSearchSalary = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportAttendance = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dtpAttendanceDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearchAttendance = new System.Windows.Forms.Button();
            this.txtSearchAttendance = new System.Windows.Forms.TextBox();
            this.btnSearchSpecificAttendance = new System.Windows.Forms.Button();
            this.dgvMonthlySalary = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableOfAttendance)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlySalary)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvTableOfAttendance, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvMonthlySalary, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(869, 546);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvTableOfAttendance
            // 
            this.dgvTableOfAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableOfAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableOfAttendance.Location = new System.Drawing.Point(3, 39);
            this.dgvTableOfAttendance.Name = "dgvTableOfAttendance";
            this.dgvTableOfAttendance.Size = new System.Drawing.Size(863, 231);
            this.dgvTableOfAttendance.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel2.Controls.Add(this.btnExportSalary, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearchSpecificSalary, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpMonthlySalary, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSearchSpecificNameForSalary, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearchSalary, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 276);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(863, 30);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnExportSalary
            // 
            this.btnExportSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportSalary.Location = new System.Drawing.Point(745, 3);
            this.btnExportSalary.Name = "btnExportSalary";
            this.btnExportSalary.Size = new System.Drawing.Size(115, 24);
            this.btnExportSalary.TabIndex = 2;
            this.btnExportSalary.Text = "Export To Excel";
            this.btnExportSalary.UseVisualStyleBackColor = true;
            this.btnExportSalary.Click += new System.EventHandler(this.btnExportSalary_Click);
            // 
            // btnSearchSpecificSalary
            // 
            this.btnSearchSpecificSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchSpecificSalary.Location = new System.Drawing.Point(494, 3);
            this.btnSearchSpecificSalary.Name = "btnSearchSpecificSalary";
            this.btnSearchSpecificSalary.Size = new System.Drawing.Size(84, 24);
            this.btnSearchSpecificSalary.TabIndex = 4;
            this.btnSearchSpecificSalary.Text = "Search";
            this.btnSearchSpecificSalary.UseVisualStyleBackColor = true;
            this.btnSearchSpecificSalary.Click += new System.EventHandler(this.btnSearchSpecificSalary_Click);
            // 
            // dtpMonthlySalary
            // 
            this.dtpMonthlySalary.CustomFormat = "MM/yyyy";
            this.dtpMonthlySalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpMonthlySalary.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthlySalary.Location = new System.Drawing.Point(3, 3);
            this.dtpMonthlySalary.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpMonthlySalary.Name = "dtpMonthlySalary";
            this.dtpMonthlySalary.Size = new System.Drawing.Size(84, 20);
            this.dtpMonthlySalary.TabIndex = 0;
            // 
            // txtSearchSpecificNameForSalary
            // 
            this.txtSearchSpecificNameForSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchSpecificNameForSalary.Location = new System.Drawing.Point(344, 3);
            this.txtSearchSpecificNameForSalary.Multiline = true;
            this.txtSearchSpecificNameForSalary.Name = "txtSearchSpecificNameForSalary";
            this.txtSearchSpecificNameForSalary.Size = new System.Drawing.Size(144, 24);
            this.txtSearchSpecificNameForSalary.TabIndex = 3;
            // 
            // btnSearchSalary
            // 
            this.btnSearchSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchSalary.Location = new System.Drawing.Point(93, 3);
            this.btnSearchSalary.Name = "btnSearchSalary";
            this.btnSearchSalary.Size = new System.Drawing.Size(84, 24);
            this.btnSearchSalary.TabIndex = 1;
            this.btnSearchSalary.Text = "Search";
            this.btnSearchSalary.UseVisualStyleBackColor = true;
            this.btnSearchSalary.Click += new System.EventHandler(this.btnSearchSalary_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 9;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel3.Controls.Add(this.btnExportAttendance, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBack, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpAttendanceDate, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSearchAttendance, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSearchAttendance, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSearchSpecificAttendance, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(863, 30);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnExportAttendance
            // 
            this.btnExportAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportAttendance.Location = new System.Drawing.Point(577, 3);
            this.btnExportAttendance.Name = "btnExportAttendance";
            this.btnExportAttendance.Size = new System.Drawing.Size(114, 24);
            this.btnExportAttendance.TabIndex = 2;
            this.btnExportAttendance.Text = "Export To Excel";
            this.btnExportAttendance.UseVisualStyleBackColor = true;
            this.btnExportAttendance.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Location = new System.Drawing.Point(774, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 24);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.CustomFormat = "MM/yyyy";
            this.dtpAttendanceDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpAttendanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAttendanceDate.Location = new System.Drawing.Point(3, 3);
            this.dtpAttendanceDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Size = new System.Drawing.Size(84, 20);
            this.dtpAttendanceDate.TabIndex = 0;
            // 
            // btnSearchAttendance
            // 
            this.btnSearchAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchAttendance.Location = new System.Drawing.Point(93, 3);
            this.btnSearchAttendance.Name = "btnSearchAttendance";
            this.btnSearchAttendance.Size = new System.Drawing.Size(84, 24);
            this.btnSearchAttendance.TabIndex = 1;
            this.btnSearchAttendance.Text = "Search";
            this.btnSearchAttendance.UseVisualStyleBackColor = true;
            this.btnSearchAttendance.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchAttendance
            // 
            this.txtSearchAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchAttendance.Location = new System.Drawing.Point(260, 3);
            this.txtSearchAttendance.Multiline = true;
            this.txtSearchAttendance.Name = "txtSearchAttendance";
            this.txtSearchAttendance.Size = new System.Drawing.Size(144, 24);
            this.txtSearchAttendance.TabIndex = 4;
            // 
            // btnSearchSpecificAttendance
            // 
            this.btnSearchSpecificAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchSpecificAttendance.Location = new System.Drawing.Point(410, 3);
            this.btnSearchSpecificAttendance.Name = "btnSearchSpecificAttendance";
            this.btnSearchSpecificAttendance.Size = new System.Drawing.Size(84, 24);
            this.btnSearchSpecificAttendance.TabIndex = 5;
            this.btnSearchSpecificAttendance.Text = "Search";
            this.btnSearchSpecificAttendance.UseVisualStyleBackColor = true;
            this.btnSearchSpecificAttendance.Click += new System.EventHandler(this.btnSearchSpecificAttendance_Click);
            // 
            // dgvMonthlySalary
            // 
            this.dgvMonthlySalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonthlySalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonthlySalary.Location = new System.Drawing.Point(3, 312);
            this.dgvMonthlySalary.Name = "dgvMonthlySalary";
            this.dgvMonthlySalary.Size = new System.Drawing.Size(863, 231);
            this.dgvMonthlySalary.TabIndex = 5;
            // 
            // frmMonthlyAttendanceAndSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 546);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMonthlyAttendanceAndSalary";
            this.Text = "Monthly Attendance And Salary";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableOfAttendance)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlySalary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExportAttendance;
        private System.Windows.Forms.Button btnSearchAttendance;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate;
        private System.Windows.Forms.DataGridView dgvTableOfAttendance;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExportSalary;
        private System.Windows.Forms.Button btnSearchSalary;
        private System.Windows.Forms.DateTimePicker dtpMonthlySalary;
        private System.Windows.Forms.Button btnSearchSpecificSalary;
        private System.Windows.Forms.TextBox txtSearchSpecificNameForSalary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtSearchAttendance;
        private System.Windows.Forms.Button btnSearchSpecificAttendance;
        private System.Windows.Forms.DataGridView dgvMonthlySalary;
    }
}