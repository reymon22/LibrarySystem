namespace BookStoreGUI
{
    partial class MultipleInstancesErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleInstancesErrorForm));
            this.lbErrorMessage1 = new System.Windows.Forms.Label();
            this.lbErrorMessage2 = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.pbError = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).BeginInit();
            this.SuspendLayout();
            // 
            // lbErrorMessage1
            // 
            this.lbErrorMessage1.AutoSize = true;
            this.lbErrorMessage1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorMessage1.Location = new System.Drawing.Point(66, 19);
            this.lbErrorMessage1.Name = "lbErrorMessage1";
            this.lbErrorMessage1.Size = new System.Drawing.Size(241, 18);
            this.lbErrorMessage1.TabIndex = 0;
            this.lbErrorMessage1.Text = "There is already an instance";
            // 
            // lbErrorMessage2
            // 
            this.lbErrorMessage2.AutoSize = true;
            this.lbErrorMessage2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorMessage2.Location = new System.Drawing.Point(74, 49);
            this.lbErrorMessage2.Name = "lbErrorMessage2";
            this.lbErrorMessage2.Size = new System.Drawing.Size(226, 18);
            this.lbErrorMessage2.TabIndex = 1;
            this.lbErrorMessage2.Text = "of the application running.";
            // 
            // btOK
            // 
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Location = new System.Drawing.Point(140, 85);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 25);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // pbError
            // 
            this.pbError.ErrorImage = null;
            this.pbError.Image = ((System.Drawing.Image)(resources.GetObject("pbError.Image")));
            this.pbError.Location = new System.Drawing.Point(6, 19);
            this.pbError.Name = "pbError";
            this.pbError.Size = new System.Drawing.Size(50, 50);
            this.pbError.TabIndex = 3;
            this.pbError.TabStop = false;
            // 
            // MultipleInstancesErrorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(309, 126);
            this.Controls.Add(this.pbError);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.lbErrorMessage2);
            this.Controls.Add(this.lbErrorMessage1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultipleInstancesErrorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multiple Instances Error";
            this.Load += new System.EventHandler(this.MultipleProcessErrorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbErrorMessage1;
        private System.Windows.Forms.Label lbErrorMessage2;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.PictureBox pbError;
    }
}