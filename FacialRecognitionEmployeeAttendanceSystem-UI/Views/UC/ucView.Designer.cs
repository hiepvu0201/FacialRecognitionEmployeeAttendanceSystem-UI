namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.UC
{
    partial class ucView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvManagement = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagement)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManagement
            // 
            this.dgvManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvManagement.Location = new System.Drawing.Point(0, 0);
            this.dgvManagement.Name = "dgvManagement";
            this.dgvManagement.RowHeadersWidth = 51;
            this.dgvManagement.RowTemplate.Height = 24;
            this.dgvManagement.Size = new System.Drawing.Size(539, 380);
            this.dgvManagement.TabIndex = 0;
            this.dgvManagement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManagement_CellClick);
            // 
            // ucView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvManagement);
            this.Name = "ucView";
            this.Size = new System.Drawing.Size(539, 380);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvManagement;
    }
}
