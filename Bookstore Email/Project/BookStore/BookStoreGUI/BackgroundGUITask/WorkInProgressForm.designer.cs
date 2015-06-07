namespace BookStoreGUI
{
    partial class WorkInProgressForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkInProgressForm));
            this.pbOperationProgress = new System.Windows.Forms.ProgressBar();
            this.lbExplanation = new System.Windows.Forms.Label();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pbOperationProgress
            // 
            this.pbOperationProgress.Location = new System.Drawing.Point(12, 12);
            this.pbOperationProgress.Name = "pbOperationProgress";
            this.pbOperationProgress.Size = new System.Drawing.Size(268, 23);
            this.pbOperationProgress.TabIndex = 0;
            // 
            // lbExplanation
            // 
            this.lbExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbExplanation.Location = new System.Drawing.Point(12, 43);
            this.lbExplanation.Name = "lbExplanation";
            this.lbExplanation.Size = new System.Drawing.Size(268, 16);
            this.lbExplanation.TabIndex = 1;
            this.lbExplanation.Text = "Explanation label";
            // 
            // timerAnimation
            // 
            this.timerAnimation.Enabled = true;
            this.timerAnimation.Interval = 125;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // WorkInProgressForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(294, 64);
            this.ControlBox = false;
            this.Controls.Add(this.lbExplanation);
            this.Controls.Add(this.pbOperationProgress);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 70);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 70);
            this.Name = "WorkInProgressForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.WorkInProgressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbOperationProgress;
        private System.Windows.Forms.Label lbExplanation;
        private System.Windows.Forms.Timer timerAnimation;
    }
}
