namespace BookStoreGUI
{
    partial class AddNewItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewItemForm));
            this.btAddItem = new System.Windows.Forms.Button();
            this.tbNewItem = new System.Windows.Forms.TextBox();
            this.lbNewItem = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAddItem
            // 
            this.btAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddItem.Location = new System.Drawing.Point(12, 45);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(130, 25);
            this.btAddItem.TabIndex = 1;
            this.btAddItem.Text = "Add item";
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // tbNewItem
            // 
            this.tbNewItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewItem.Location = new System.Drawing.Point(87, 8);
            this.tbNewItem.MaxLength = 300;
            this.tbNewItem.Name = "tbNewItem";
            this.tbNewItem.Size = new System.Drawing.Size(284, 21);
            this.tbNewItem.TabIndex = 0;
            this.tbNewItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNewItem_KeyDown);
            // 
            // lbNewItem
            // 
            this.lbNewItem.AutoSize = true;
            this.lbNewItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewItem.Location = new System.Drawing.Point(6, 11);
            this.lbNewItem.Name = "lbNewItem";
            this.lbNewItem.Size = new System.Drawing.Size(75, 16);
            this.lbNewItem.TabIndex = 6;
            this.lbNewItem.Text = "New item:";
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(241, 45);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(130, 25);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // AddNewItemForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(381, 82);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAddItem);
            this.Controls.Add(this.tbNewItem);
            this.Controls.Add(this.lbNewItem);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewItemForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add new";
            this.Load += new System.EventHandler(this.AddNewItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.TextBox tbNewItem;
        private System.Windows.Forms.Label lbNewItem;
        private System.Windows.Forms.Button btCancel;
    }
}