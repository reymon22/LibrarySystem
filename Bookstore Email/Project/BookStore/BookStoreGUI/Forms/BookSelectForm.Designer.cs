namespace BookStoreGUI
{
    partial class BookSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookSelectForm));
            this.btAddNew = new System.Windows.Forms.Button();
            this.btRemoveSelected = new System.Windows.Forms.Button();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.btConfirmSelection = new System.Windows.Forms.Button();
            this.btRenameSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAddNew
            // 
            this.btAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddNew.Location = new System.Drawing.Point(12, 21);
            this.btAddNew.Name = "btAddNew";
            this.btAddNew.Size = new System.Drawing.Size(130, 25);
            this.btAddNew.TabIndex = 1;
            this.btAddNew.Text = "Add new";
            this.btAddNew.UseVisualStyleBackColor = true;
            this.btAddNew.Click += new System.EventHandler(this.btAddNew_Click);
            // 
            // btRemoveSelected
            // 
            this.btRemoveSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemoveSelected.Location = new System.Drawing.Point(12, 195);
            this.btRemoveSelected.Name = "btRemoveSelected";
            this.btRemoveSelected.Size = new System.Drawing.Size(130, 25);
            this.btRemoveSelected.TabIndex = 2;
            this.btRemoveSelected.Text = "Remove selected";
            this.btRemoveSelected.UseVisualStyleBackColor = true;
            this.btRemoveSelected.Click += new System.EventHandler(this.btRemoveSelected_Click);
            // 
            // lbItems
            // 
            this.lbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItems.FormattingEnabled = true;
            this.lbItems.HorizontalScrollbar = true;
            this.lbItems.ItemHeight = 15;
            this.lbItems.Location = new System.Drawing.Point(158, 21);
            this.lbItems.Name = "lbItems";
            this.lbItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbItems.Size = new System.Drawing.Size(308, 199);
            this.lbItems.TabIndex = 0;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // btConfirmSelection
            // 
            this.btConfirmSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmSelection.Location = new System.Drawing.Point(158, 236);
            this.btConfirmSelection.Name = "btConfirmSelection";
            this.btConfirmSelection.Size = new System.Drawing.Size(308, 25);
            this.btConfirmSelection.TabIndex = 4;
            this.btConfirmSelection.Text = "Confirm selection";
            this.btConfirmSelection.UseVisualStyleBackColor = true;
            this.btConfirmSelection.Click += new System.EventHandler(this.btConfirmSelection_Click);
            // 
            // btRenameSelected
            // 
            this.btRenameSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRenameSelected.Location = new System.Drawing.Point(12, 109);
            this.btRenameSelected.Name = "btRenameSelected";
            this.btRenameSelected.Size = new System.Drawing.Size(130, 25);
            this.btRenameSelected.TabIndex = 3;
            this.btRenameSelected.Text = "Rename selected";
            this.btRenameSelected.UseVisualStyleBackColor = true;
            this.btRenameSelected.Click += new System.EventHandler(this.btRenameSelected_Click);
            // 
            // BookSelectForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(480, 283);
            this.Controls.Add(this.btRenameSelected);
            this.Controls.Add(this.btConfirmSelection);
            this.Controls.Add(this.btAddNew);
            this.Controls.Add(this.btRemoveSelected);
            this.Controls.Add(this.lbItems);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 315);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 315);
            this.Name = "BookSelectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.BookSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAddNew;
        private System.Windows.Forms.Button btRemoveSelected;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button btConfirmSelection;
        private System.Windows.Forms.Button btRenameSelected;
    }
}