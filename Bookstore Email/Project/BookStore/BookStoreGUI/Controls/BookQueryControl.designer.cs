namespace BookStoreGUI
{
    partial class BookQueryControl
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
            this.lbQueryCategory = new System.Windows.Forms.Label();
            this.chbSelectControl = new System.Windows.Forms.CheckBox();
            this.lbQueryType = new System.Windows.Forms.Label();
            this.cbQueryType = new System.Windows.Forms.ComboBox();
            this.clbItems = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lbQueryCategory
            // 
            this.lbQueryCategory.AutoSize = true;
            this.lbQueryCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQueryCategory.Location = new System.Drawing.Point(9, 11);
            this.lbQueryCategory.Name = "lbQueryCategory";
            this.lbQueryCategory.Size = new System.Drawing.Size(64, 14);
            this.lbQueryCategory.TabIndex = 0;
            this.lbQueryCategory.Text = "Query by";
            // 
            // chbSelectControl
            // 
            this.chbSelectControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSelectControl.Location = new System.Drawing.Point(335, 11);
            this.chbSelectControl.Name = "chbSelectControl";
            this.chbSelectControl.Size = new System.Drawing.Size(15, 14);
            this.chbSelectControl.TabIndex = 0;
            this.chbSelectControl.UseVisualStyleBackColor = true;
            this.chbSelectControl.CheckedChanged += new System.EventHandler(this.chbSelectControl_CheckedChanged);
            // 
            // lbQueryType
            // 
            this.lbQueryType.AutoSize = true;
            this.lbQueryType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQueryType.Location = new System.Drawing.Point(9, 39);
            this.lbQueryType.Name = "lbQueryType";
            this.lbQueryType.Size = new System.Drawing.Size(86, 14);
            this.lbQueryType.TabIndex = 2;
            this.lbQueryType.Text = "Query type: ";
            this.lbQueryType.Visible = false;
            // 
            // cbQueryType
            // 
            this.cbQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQueryType.FormattingEnabled = true;
            this.cbQueryType.Items.AddRange(new object[] {
            "OR",
            "AND"});
            this.cbQueryType.Location = new System.Drawing.Point(288, 35);
            this.cbQueryType.MaxDropDownItems = 2;
            this.cbQueryType.Name = "cbQueryType";
            this.cbQueryType.Size = new System.Drawing.Size(62, 23);
            this.cbQueryType.TabIndex = 1;
            this.cbQueryType.Visible = false;
            // 
            // clbItems
            // 
            this.clbItems.CheckOnClick = true;
            this.clbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbItems.FormattingEnabled = true;
            this.clbItems.HorizontalScrollbar = true;
            this.clbItems.Location = new System.Drawing.Point(12, 66);
            this.clbItems.Margin = new System.Windows.Forms.Padding(5);
            this.clbItems.Name = "clbItems";
            this.clbItems.Size = new System.Drawing.Size(338, 132);
            this.clbItems.TabIndex = 2;
            this.clbItems.ThreeDCheckBoxes = true;
            this.clbItems.Visible = false;
            // 
            // BookQueryControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.clbItems);
            this.Controls.Add(this.cbQueryType);
            this.Controls.Add(this.lbQueryType);
            this.Controls.Add(this.chbSelectControl);
            this.Controls.Add(this.lbQueryCategory);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(10);
            this.MaximumSize = new System.Drawing.Size(363, 212);
            this.MinimumSize = new System.Drawing.Size(363, 212);
            this.Name = "BookQueryControl";
            this.Size = new System.Drawing.Size(361, 210);
            this.Load += new System.EventHandler(this.BookQueryControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbQueryCategory;
        private System.Windows.Forms.CheckBox chbSelectControl;
        private System.Windows.Forms.Label lbQueryType;
        private System.Windows.Forms.ComboBox cbQueryType;
        private System.Windows.Forms.CheckedListBox clbItems;
    }
}
