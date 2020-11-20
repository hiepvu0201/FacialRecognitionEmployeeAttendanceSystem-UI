namespace FacialRecognitionEmployeeAttendanceSystem_UI.Views.ImageHandler
{
    partial class frmImageHandler
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
            this.pnlLiveWebcam = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartWebcam = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnReCapture = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pbLiveWebcam = new System.Windows.Forms.PictureBox();
            this.pbCaptureImg = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlLiveWebcam.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLiveWebcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptureImg)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlLiveWebcam, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlLiveWebcam
            // 
            this.pnlLiveWebcam.Controls.Add(this.tableLayoutPanel3);
            this.pnlLiveWebcam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLiveWebcam.Location = new System.Drawing.Point(3, 384);
            this.pnlLiveWebcam.Name = "pnlLiveWebcam";
            this.pnlLiveWebcam.Size = new System.Drawing.Size(794, 63);
            this.pnlLiveWebcam.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btnStartWebcam, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnConfirm, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCapture, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnReCapture, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(794, 63);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // btnStartWebcam
            // 
            this.btnStartWebcam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartWebcam.Location = new System.Drawing.Point(3, 3);
            this.btnStartWebcam.Name = "btnStartWebcam";
            this.btnStartWebcam.Size = new System.Drawing.Size(152, 57);
            this.btnStartWebcam.TabIndex = 0;
            this.btnStartWebcam.Text = "Start Webcam";
            this.btnStartWebcam.UseVisualStyleBackColor = true;
            this.btnStartWebcam.Click += new System.EventHandler(this.btnStartWebcam_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Location = new System.Drawing.Point(477, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(152, 57);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCapture.Location = new System.Drawing.Point(161, 3);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(152, 57);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnReCapture
            // 
            this.btnReCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReCapture.Location = new System.Drawing.Point(319, 3);
            this.btnReCapture.Name = "btnReCapture";
            this.btnReCapture.Size = new System.Drawing.Size(152, 57);
            this.btnReCapture.TabIndex = 2;
            this.btnReCapture.Text = "Re-Capture";
            this.btnReCapture.UseVisualStyleBackColor = true;
            this.btnReCapture.Click += new System.EventHandler(this.btnReCapture_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.pbLiveWebcam, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pbCaptureImg, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 375);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // pbLiveWebcam
            // 
            this.pbLiveWebcam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLiveWebcam.Location = new System.Drawing.Point(3, 3);
            this.pbLiveWebcam.Name = "pbLiveWebcam";
            this.pbLiveWebcam.Size = new System.Drawing.Size(391, 369);
            this.pbLiveWebcam.TabIndex = 0;
            this.pbLiveWebcam.TabStop = false;
            // 
            // pbCaptureImg
            // 
            this.pbCaptureImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCaptureImg.Location = new System.Drawing.Point(400, 3);
            this.pbCaptureImg.Name = "pbCaptureImg";
            this.pbCaptureImg.Size = new System.Drawing.Size(391, 369);
            this.pbCaptureImg.TabIndex = 1;
            this.pbCaptureImg.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(635, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 57);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmImageHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmImageHandler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Handler";
            this.Load += new System.EventHandler(this.ImageHandler_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlLiveWebcam.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLiveWebcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptureImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbLiveWebcam;
        private System.Windows.Forms.PictureBox pbCaptureImg;
        private System.Windows.Forms.Panel pnlLiveWebcam;
        private System.Windows.Forms.Button btnReCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnStartWebcam;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnCancel;
    }
}