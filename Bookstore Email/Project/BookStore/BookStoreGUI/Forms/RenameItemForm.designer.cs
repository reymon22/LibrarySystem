namespace BookStoreGUI
{
    partial class RenameItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameItemForm));
            this.btRenameItem = new System.Windows.Forms.Button();
            this.tbItemToRename = new System.Windows.Forms.TextBox();
            this.lbItemToRename = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRenameItem
            // 
            this.btRenameItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRenameItem.Location = new System.Drawing.Point(12, 45);
            this.btRenameItem.Name = "btRenameItem";
            this.btRenameItem.Size = new System.Drawing.Size(135, 25);
            this.btRenameItem.TabIndex = 1;
            this.btRenameItem.Text = "Rename item";
            this.btRenameItem.UseVisualStyleBackColor = true;
            this.btRenameItem.Click += new System.EventHandler(this.btRenameItem_Click);
            // 
            // tbItemToRename
            // 
            this.tbItemToRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbItemToRename.Location = new System.Drawing.Point(134, 8);
            this.tbItemToRename.MaxLength = 300;
            this.tbItemToRename.Name = "tbItemToRename";
            this.tbItemToRename.Size = new System.Drawing.Size(237, 21);
            this.tbItemToRename.TabIndex = 0;
            this.tbItemToRename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbItemToRename_KeyDown);
            // 
            // lbItemToRename
            // 
            this.lbItemToRename.AutoSize = true;
            this.lbItemToRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemToRename.Location = new System.Drawing.Point(9, 11);
            this.lbItemToRename.Name = "lbItemToRename";
            this.lbItemToRename.Size = new System.Drawing.Size(99, 16);
            this.lbItemToRename.TabIndex = 6;
            this.lbItemToRename.Text = "Item to rename:";
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(236, 45);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(135, 25);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // RenameItemForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(381, 82);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btRenameItem);
            this.Controls.Add(this.tbItemToRename);
            this.Controls.Add(this.lbItemToRename);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenameItemForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Rename";
            this.Load += new System.EventHandler(this.RenameItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRenameItem;
        private System.Windows.Forms.TextBox tbItemToRename;
        private System.Windows.Forms.Label lbItemToRename;
        private System.Windows.Forms.Button btCancel;
    }
}