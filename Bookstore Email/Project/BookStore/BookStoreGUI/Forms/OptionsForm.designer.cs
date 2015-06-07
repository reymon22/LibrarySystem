namespace BookStoreGUI
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.btSelectDatabaseFolder = new System.Windows.Forms.Button();
            this.tbDatabaseFolder = new System.Windows.Forms.TextBox();
            this.lbDatabaseFolder = new System.Windows.Forms.Label();
            this.lbTempFolder = new System.Windows.Forms.Label();
            this.tbTempFolder = new System.Windows.Forms.TextBox();
            this.btSelectTempFolder = new System.Windows.Forms.Button();
            this.btConfirmSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btSelectDatabaseFolder
            // 
            this.btSelectDatabaseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectDatabaseFolder.Location = new System.Drawing.Point(278, 14);
            this.btSelectDatabaseFolder.Name = "btSelectDatabaseFolder";
            this.btSelectDatabaseFolder.Size = new System.Drawing.Size(100, 25);
            this.btSelectDatabaseFolder.TabIndex = 0;
            this.btSelectDatabaseFolder.Text = "Select";
            this.btSelectDatabaseFolder.UseVisualStyleBackColor = true;
            this.btSelectDatabaseFolder.Click += new System.EventHandler(this.btSelectDatabaseFolder_Click);
            // 
            // tbDatabaseFolder
            // 
            this.tbDatabaseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDatabaseFolder.Location = new System.Drawing.Point(15, 49);
            this.tbDatabaseFolder.MaxLength = 600;
            this.tbDatabaseFolder.Name = "tbDatabaseFolder";
            this.tbDatabaseFolder.ReadOnly = true;
            this.tbDatabaseFolder.Size = new System.Drawing.Size(363, 22);
            this.tbDatabaseFolder.TabIndex = 1;
            // 
            // lbDatabaseFolder
            // 
            this.lbDatabaseFolder.AutoSize = true;
            this.lbDatabaseFolder.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatabaseFolder.Location = new System.Drawing.Point(12, 18);
            this.lbDatabaseFolder.Name = "lbDatabaseFolder";
            this.lbDatabaseFolder.Size = new System.Drawing.Size(118, 16);
            this.lbDatabaseFolder.TabIndex = 10;
            this.lbDatabaseFolder.Text = "Database folder:";
            // 
            // lbTempFolder
            // 
            this.lbTempFolder.AutoSize = true;
            this.lbTempFolder.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTempFolder.Location = new System.Drawing.Point(12, 108);
            this.lbTempFolder.Name = "lbTempFolder";
            this.lbTempFolder.Size = new System.Drawing.Size(126, 16);
            this.lbTempFolder.TabIndex = 13;
            this.lbTempFolder.Text = "Temporary folder:";
            // 
            // tbTempFolder
            // 
            this.tbTempFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTempFolder.Location = new System.Drawing.Point(15, 139);
            this.tbTempFolder.MaxLength = 600;
            this.tbTempFolder.Name = "tbTempFolder";
            this.tbTempFolder.ReadOnly = true;
            this.tbTempFolder.Size = new System.Drawing.Size(363, 22);
            this.tbTempFolder.TabIndex = 3;
            // 
            // btSelectTempFolder
            // 
            this.btSelectTempFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectTempFolder.Location = new System.Drawing.Point(278, 104);
            this.btSelectTempFolder.Name = "btSelectTempFolder";
            this.btSelectTempFolder.Size = new System.Drawing.Size(100, 25);
            this.btSelectTempFolder.TabIndex = 2;
            this.btSelectTempFolder.Text = "Select";
            this.btSelectTempFolder.UseVisualStyleBackColor = true;
            this.btSelectTempFolder.Click += new System.EventHandler(this.btSelectTempFolder_Click);
            // 
            // btConfirmSelection
            // 
            this.btConfirmSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmSelection.Location = new System.Drawing.Point(125, 211);
            this.btConfirmSelection.Name = "btConfirmSelection";
            this.btConfirmSelection.Size = new System.Drawing.Size(140, 25);
            this.btConfirmSelection.TabIndex = 4;
            this.btConfirmSelection.Text = "Confirm selection";
            this.btConfirmSelection.UseVisualStyleBackColor = true;
            this.btConfirmSelection.Click += new System.EventHandler(this.btConfirmSelection_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(390, 268);
            this.Controls.Add(this.btConfirmSelection);
            this.Controls.Add(this.lbTempFolder);
            this.Controls.Add(this.tbTempFolder);
            this.Controls.Add(this.btSelectTempFolder);
            this.Controls.Add(this.lbDatabaseFolder);
            this.Controls.Add(this.tbDatabaseFolder);
            this.Controls.Add(this.btSelectDatabaseFolder);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Store Application Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSelectDatabaseFolder;
        private System.Windows.Forms.TextBox tbDatabaseFolder;
        private System.Windows.Forms.Label lbDatabaseFolder;
        private System.Windows.Forms.Label lbTempFolder;
        private System.Windows.Forms.TextBox tbTempFolder;
        private System.Windows.Forms.Button btSelectTempFolder;
        private System.Windows.Forms.Button btConfirmSelection;
    }
}