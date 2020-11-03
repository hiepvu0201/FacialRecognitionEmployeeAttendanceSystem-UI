namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views
{
    partial class frmMain
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
            this.btnAttendanceSystem = new System.Windows.Forms.Button();
            this.btnManagementSystem = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAttendanceSystem
            // 
            this.btnAttendanceSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAttendanceSystem.Location = new System.Drawing.Point(3, 3);
            this.btnAttendanceSystem.Name = "btnAttendanceSystem";
            this.btnAttendanceSystem.Size = new System.Drawing.Size(325, 288);
            this.btnAttendanceSystem.TabIndex = 0;
            this.btnAttendanceSystem.Text = "Attendance System";
            this.btnAttendanceSystem.UseVisualStyleBackColor = true;
            this.btnAttendanceSystem.Click += new System.EventHandler(this.btnAttendanceSystem_Click);
            // 
            // btnManagementSystem
            // 
            this.btnManagementSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnManagementSystem.Location = new System.Drawing.Point(334, 3);
            this.btnManagementSystem.Name = "btnManagementSystem";
            this.btnManagementSystem.Size = new System.Drawing.Size(325, 288);
            this.btnManagementSystem.TabIndex = 0;
            this.btnManagementSystem.Text = "Management System";
            this.btnManagementSystem.UseVisualStyleBackColor = true;
            this.btnManagementSystem.Click += new System.EventHandler(this.btnManagementSystem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnAttendanceSystem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnManagementSystem, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(662, 294);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 294);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAttendanceSystem;
        private System.Windows.Forms.Button btnManagementSystem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}