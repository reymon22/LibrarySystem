namespace BookStoreGUI
{
    partial class BookDetails
    {
        
        private System.ComponentModel.IContainer components = null;

       
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
            this.tbAuthors = new System.Windows.Forms.TextBox();
            this.lbAuthors = new System.Windows.Forms.Label();
            this.btSelectAuthors = new System.Windows.Forms.Button();
            this.btSelectTags = new System.Windows.Forms.Button();
            this.tbTags = new System.Windows.Forms.TextBox();
            this.lbTags = new System.Windows.Forms.Label();
            this.btSetTitle = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btSelectYearOfPublishing = new System.Windows.Forms.Button();
            this.tbYearOfPublishing = new System.Windows.Forms.TextBox();
            this.lbYearOfPublishing = new System.Windows.Forms.Label();
            this.btSelectPublishingHouse = new System.Windows.Forms.Button();
            this.tbPublishingHouse = new System.Windows.Forms.TextBox();
            this.lbPublishingHouse = new System.Windows.Forms.Label();
            this.lbBookInfo = new System.Windows.Forms.Label();
            this.btDeleteBook = new System.Windows.Forms.Button();
            this.btViewBook = new System.Windows.Forms.Button();
            this.pnBookDetails = new System.Windows.Forms.Panel();
            this.pnBookDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbAuthors
            // 
            this.tbAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAuthors.Location = new System.Drawing.Point(0, 124);
            this.tbAuthors.MaxLength = 1200;
            this.tbAuthors.Name = "tbAuthors";
            this.tbAuthors.ReadOnly = true;
            this.tbAuthors.Size = new System.Drawing.Size(335, 22);
            this.tbAuthors.TabIndex = 8;
            // 
            // lbAuthors
            // 
            this.lbAuthors.AutoSize = true;
            this.lbAuthors.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAuthors.Location = new System.Drawing.Point(-3, 97);
            this.lbAuthors.Name = "lbAuthors";
            this.lbAuthors.Size = new System.Drawing.Size(77, 16);
            this.lbAuthors.TabIndex = 2;
            this.lbAuthors.Text = "Author(s):";
            // 
            // btSelectAuthors
            // 
            this.btSelectAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectAuthors.Location = new System.Drawing.Point(255, 93);
            this.btSelectAuthors.Name = "btSelectAuthors";
            this.btSelectAuthors.Size = new System.Drawing.Size(80, 25);
            this.btSelectAuthors.TabIndex = 4;
            this.btSelectAuthors.Text = "Select";
            this.btSelectAuthors.UseVisualStyleBackColor = true;
            this.btSelectAuthors.Click += new System.EventHandler(this.btSelectAuthors_Click);
            // 
            // btSelectTags
            // 
            this.btSelectTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectTags.Location = new System.Drawing.Point(255, 173);
            this.btSelectTags.Name = "btSelectTags";
            this.btSelectTags.Size = new System.Drawing.Size(80, 25);
            this.btSelectTags.TabIndex = 5;
            this.btSelectTags.Text = "Select";
            this.btSelectTags.UseVisualStyleBackColor = true;
            this.btSelectTags.Click += new System.EventHandler(this.btSelectTags_Click);
            // 
            // tbTags
            // 
            this.tbTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTags.Location = new System.Drawing.Point(0, 204);
            this.tbTags.MaxLength = 1200;
            this.tbTags.Name = "tbTags";
            this.tbTags.ReadOnly = true;
            this.tbTags.Size = new System.Drawing.Size(335, 22);
            this.tbTags.TabIndex = 9;
            // 
            // lbTags
            // 
            this.lbTags.AutoSize = true;
            this.lbTags.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTags.Location = new System.Drawing.Point(-3, 177);
            this.lbTags.Name = "lbTags";
            this.lbTags.Size = new System.Drawing.Size(46, 16);
            this.lbTags.TabIndex = 5;
            this.lbTags.Text = "Tags:";
            // 
            // btSetTitle
            // 
            this.btSetTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetTitle.Location = new System.Drawing.Point(255, 14);
            this.btSetTitle.Name = "btSetTitle";
            this.btSetTitle.Size = new System.Drawing.Size(80, 25);
            this.btSetTitle.TabIndex = 2;
            this.btSetTitle.Text = "Set";
            this.btSetTitle.UseVisualStyleBackColor = true;
            this.btSetTitle.Click += new System.EventHandler(this.btSetBookTitle_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(0, 44);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(5);
            this.tbTitle.MaxLength = 300;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(335, 22);
            this.tbTitle.TabIndex = 3;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(-3, 18);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(43, 16);
            this.lbTitle.TabIndex = 8;
            this.lbTitle.Text = "Title:";
            // 
            // btSelectYearOfPublishing
            // 
            this.btSelectYearOfPublishing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectYearOfPublishing.Location = new System.Drawing.Point(255, 332);
            this.btSelectYearOfPublishing.Name = "btSelectYearOfPublishing";
            this.btSelectYearOfPublishing.Size = new System.Drawing.Size(80, 25);
            this.btSelectYearOfPublishing.TabIndex = 7;
            this.btSelectYearOfPublishing.Text = "Select";
            this.btSelectYearOfPublishing.UseVisualStyleBackColor = true;
            this.btSelectYearOfPublishing.Click += new System.EventHandler(this.btSelectYearOfPublishing_Click);
            // 
            // tbYearOfPublishing
            // 
            this.tbYearOfPublishing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbYearOfPublishing.Location = new System.Drawing.Point(0, 364);
            this.tbYearOfPublishing.MaxLength = 4;
            this.tbYearOfPublishing.Name = "tbYearOfPublishing";
            this.tbYearOfPublishing.ReadOnly = true;
            this.tbYearOfPublishing.Size = new System.Drawing.Size(335, 22);
            this.tbYearOfPublishing.TabIndex = 11;
            // 
            // lbYearOfPublishing
            // 
            this.lbYearOfPublishing.AutoSize = true;
            this.lbYearOfPublishing.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYearOfPublishing.Location = new System.Drawing.Point(-3, 336);
            this.lbYearOfPublishing.Name = "lbYearOfPublishing";
            this.lbYearOfPublishing.Size = new System.Drawing.Size(131, 16);
            this.lbYearOfPublishing.TabIndex = 14;
            this.lbYearOfPublishing.Text = "Year of publishing:";
            // 
            // btSelectPublishingHouse
            // 
            this.btSelectPublishingHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectPublishingHouse.Location = new System.Drawing.Point(255, 251);
            this.btSelectPublishingHouse.Name = "btSelectPublishingHouse";
            this.btSelectPublishingHouse.Size = new System.Drawing.Size(80, 25);
            this.btSelectPublishingHouse.TabIndex = 6;
            this.btSelectPublishingHouse.Text = "Select";
            this.btSelectPublishingHouse.UseVisualStyleBackColor = true;
            this.btSelectPublishingHouse.Click += new System.EventHandler(this.btSelectPublishingHouse_Click);
            // 
            // tbPublishingHouse
            // 
            this.tbPublishingHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPublishingHouse.Location = new System.Drawing.Point(0, 284);
            this.tbPublishingHouse.MaxLength = 300;
            this.tbPublishingHouse.Name = "tbPublishingHouse";
            this.tbPublishingHouse.ReadOnly = true;
            this.tbPublishingHouse.Size = new System.Drawing.Size(335, 22);
            this.tbPublishingHouse.TabIndex = 10;
            // 
            // lbPublishingHouse
            // 
            this.lbPublishingHouse.AutoSize = true;
            this.lbPublishingHouse.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPublishingHouse.Location = new System.Drawing.Point(-3, 255);
            this.lbPublishingHouse.Name = "lbPublishingHouse";
            this.lbPublishingHouse.Size = new System.Drawing.Size(122, 16);
            this.lbPublishingHouse.TabIndex = 11;
            this.lbPublishingHouse.Text = "Publishing house:";
            // 
            // lbBookInfo
            // 
            this.lbBookInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBookInfo.AutoSize = true;
            this.lbBookInfo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookInfo.Location = new System.Drawing.Point(92, 65);
            this.lbBookInfo.Name = "lbBookInfo";
            this.lbBookInfo.Size = new System.Drawing.Size(148, 18);
            this.lbBookInfo.TabIndex = 17;
            this.lbBookInfo.Text = "Book information";
            // 
            // btDeleteBook
            // 
            this.btDeleteBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeleteBook.Location = new System.Drawing.Point(0, 12);
            this.btDeleteBook.Name = "btDeleteBook";
            this.btDeleteBook.Size = new System.Drawing.Size(110, 30);
            this.btDeleteBook.TabIndex = 0;
            this.btDeleteBook.Text = "Delete book";
            this.btDeleteBook.UseVisualStyleBackColor = true;
            this.btDeleteBook.Click += new System.EventHandler(this.btDeleteBook_Click);
            // 
            // btViewBook
            // 
            this.btViewBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btViewBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btViewBook.Location = new System.Drawing.Point(225, 12);
            this.btViewBook.Name = "btViewBook";
            this.btViewBook.Size = new System.Drawing.Size(110, 30);
            this.btViewBook.TabIndex = 1;
            this.btViewBook.Text = "View book";
            this.btViewBook.UseVisualStyleBackColor = true;
            this.btViewBook.Click += new System.EventHandler(this.btViewBook_Click);
            // 
            // pnBookDetails
            // 
            this.pnBookDetails.Controls.Add(this.btSetTitle);
            this.pnBookDetails.Controls.Add(this.tbTitle);
            this.pnBookDetails.Controls.Add(this.lbTitle);
            this.pnBookDetails.Controls.Add(this.btSelectAuthors);
            this.pnBookDetails.Controls.Add(this.btSelectYearOfPublishing);
            this.pnBookDetails.Controls.Add(this.tbYearOfPublishing);
            this.pnBookDetails.Controls.Add(this.lbAuthors);
            this.pnBookDetails.Controls.Add(this.lbYearOfPublishing);
            this.pnBookDetails.Controls.Add(this.tbAuthors);
            this.pnBookDetails.Controls.Add(this.btSelectTags);
            this.pnBookDetails.Controls.Add(this.btSelectPublishingHouse);
            this.pnBookDetails.Controls.Add(this.tbPublishingHouse);
            this.pnBookDetails.Controls.Add(this.lbTags);
            this.pnBookDetails.Controls.Add(this.lbPublishingHouse);
            this.pnBookDetails.Controls.Add(this.tbTags);
            this.pnBookDetails.Location = new System.Drawing.Point(0, 96);
            this.pnBookDetails.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnBookDetails.Name = "pnBookDetails";
            this.pnBookDetails.Size = new System.Drawing.Size(335, 403);
            this.pnBookDetails.TabIndex = 18;
            // 
            // BookDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnBookDetails);
            this.Controls.Add(this.btDeleteBook);
            this.Controls.Add(this.btViewBook);
            this.Controls.Add(this.lbBookInfo);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(10, 5, 7, 5);
            this.Name = "BookDetails";
            this.Size = new System.Drawing.Size(335, 510);
            this.pnBookDetails.ResumeLayout(false);
            this.pnBookDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAuthors;
        private System.Windows.Forms.Label lbAuthors;
        private System.Windows.Forms.Button btSelectAuthors;
        private System.Windows.Forms.Button btSelectTags;
        private System.Windows.Forms.TextBox tbTags;
        private System.Windows.Forms.Label lbTags;
        private System.Windows.Forms.Button btSetTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btSelectYearOfPublishing;
        private System.Windows.Forms.TextBox tbYearOfPublishing;
        private System.Windows.Forms.Label lbYearOfPublishing;
        private System.Windows.Forms.Button btSelectPublishingHouse;
        private System.Windows.Forms.TextBox tbPublishingHouse;
        private System.Windows.Forms.Label lbPublishingHouse;
        private System.Windows.Forms.Label lbBookInfo;
        private System.Windows.Forms.Button btDeleteBook;
        private System.Windows.Forms.Button btViewBook;
        private System.Windows.Forms.Panel pnBookDetails;
    }
}
