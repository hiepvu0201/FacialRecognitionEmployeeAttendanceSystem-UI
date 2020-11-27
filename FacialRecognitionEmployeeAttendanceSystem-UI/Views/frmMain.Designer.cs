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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnManagementSystem = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAttendanceSystem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnManagementSystem
            // 
            this.btnManagementSystem.BackColor = System.Drawing.Color.Transparent;
            this.btnManagementSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnManagementSystem.BackgroundImage")));
            this.btnManagementSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnManagementSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnManagementSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnManagementSystem.Location = new System.Drawing.Point(517, 3);
            this.btnManagementSystem.Name = "btnManagementSystem";
            this.btnManagementSystem.Size = new System.Drawing.Size(508, 528);
            this.btnManagementSystem.TabIndex = 0;
            this.btnManagementSystem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManagementSystem.UseVisualStyleBackColor = false;
            this.btnManagementSystem.Click += new System.EventHandler(this.btnManagementSystem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnManagementSystem, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 584);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAttendanceSystem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 528);
            this.panel1.TabIndex = 1;
            // 
            // btnAttendanceSystem
            // 
            this.btnAttendanceSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAttendanceSystem.BackgroundImage")));
            this.btnAttendanceSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAttendanceSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAttendanceSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAttendanceSystem.Location = new System.Drawing.Point(0, 0);
            this.btnAttendanceSystem.Name = "btnAttendanceSystem";
            this.btnAttendanceSystem.Size = new System.Drawing.Size(508, 528);
            this.btnAttendanceSystem.TabIndex = 1;
            this.btnAttendanceSystem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAttendanceSystem.UseVisualStyleBackColor = true;
            this.btnAttendanceSystem.Click += new System.EventHandler(this.btnAttendanceSystem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click the image above to switch to Attendance Side";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(517, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(508, 50);
            this.label2.TabIndex = 3;
            this.label2.Text = "Click the image above to switch to Management Side";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 584);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facial Recognition Employee Attendance System";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnManagementSystem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAttendanceSystem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}