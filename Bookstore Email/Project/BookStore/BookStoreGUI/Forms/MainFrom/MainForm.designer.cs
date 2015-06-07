namespace BookStoreGUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabViewBooks = new System.Windows.Forms.TabPage();
            this.flpViewBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.pnViewBooksList = new System.Windows.Forms.Panel();
            this.lbViewBooks = new System.Windows.Forms.Label();
            this.lbBooks = new System.Windows.Forms.ListBox();
            this.cbViewBooks = new System.Windows.Forms.ComboBox();
            this.tabSearchForBooks = new System.Windows.Forms.TabPage();
            this.flpQueryControls = new System.Windows.Forms.FlowLayoutPanel();
            this.btPerformQuery = new System.Windows.Forms.Button();
            this.cbQueryType = new System.Windows.Forms.ComboBox();
            this.lbQueryType = new System.Windows.Forms.Label();
            this.tabAddBooks = new System.Windows.Forms.TabPage();
            this.btBulkAddFileBasedBooks = new System.Windows.Forms.Button();
            this.btAddFolderBasedBook = new System.Windows.Forms.Button();
            this.btAddFileBasedBook = new System.Windows.Forms.Button();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.miDefragmentDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.miResetConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain.SuspendLayout();
            this.tabViewBooks.SuspendLayout();
            this.flpViewBooks.SuspendLayout();
            this.pnViewBooksList.SuspendLayout();
            this.tabSearchForBooks.SuspendLayout();
            this.tabAddBooks.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabViewBooks);
            this.tcMain.Controls.Add(this.tabSearchForBooks);
            this.tcMain.Controls.Add(this.tabAddBooks);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Location = new System.Drawing.Point(0, 24);
            this.tcMain.MinimumSize = new System.Drawing.Size(792, 540);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(792, 544);
            this.tcMain.TabIndex = 0;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tabViewBooks
            // 
            this.tabViewBooks.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabViewBooks.Controls.Add(this.flpViewBooks);
            this.tabViewBooks.Location = new System.Drawing.Point(4, 24);
            this.tabViewBooks.Name = "tabViewBooks";
            this.tabViewBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabViewBooks.Size = new System.Drawing.Size(784, 516);
            this.tabViewBooks.TabIndex = 0;
            this.tabViewBooks.Text = "View Books";
            // 
            // flpViewBooks
            // 
            this.flpViewBooks.Controls.Add(this.pnViewBooksList);
            this.flpViewBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpViewBooks.Location = new System.Drawing.Point(3, 3);
            this.flpViewBooks.Margin = new System.Windows.Forms.Padding(5);
            this.flpViewBooks.Name = "flpViewBooks";
            this.flpViewBooks.Size = new System.Drawing.Size(778, 510);
            this.flpViewBooks.TabIndex = 0;
            // 
            // pnViewBooksList
            // 
            this.pnViewBooksList.Controls.Add(this.lbViewBooks);
            this.pnViewBooksList.Controls.Add(this.lbBooks);
            this.pnViewBooksList.Controls.Add(this.cbViewBooks);
            this.pnViewBooksList.Location = new System.Drawing.Point(5, 5);
            this.pnViewBooksList.Margin = new System.Windows.Forms.Padding(5);
            this.pnViewBooksList.Name = "pnViewBooksList";
            this.pnViewBooksList.Size = new System.Drawing.Size(410, 508);
            this.pnViewBooksList.TabIndex = 0;
            // 
            // lbViewBooks
            // 
            this.lbViewBooks.AutoSize = true;
            this.lbViewBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbViewBooks.Location = new System.Drawing.Point(3, 13);
            this.lbViewBooks.Name = "lbViewBooks";
            this.lbViewBooks.Size = new System.Drawing.Size(40, 16);
            this.lbViewBooks.TabIndex = 0;
            this.lbViewBooks.Text = "View:";
            // 
            // lbBooks
            // 
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.HorizontalScrollbar = true;
            this.lbBooks.ItemHeight = 15;
            this.lbBooks.Location = new System.Drawing.Point(6, 49);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(400, 439);
            this.lbBooks.Sorted = true;
            this.lbBooks.TabIndex = 1;
            this.lbBooks.SelectedIndexChanged += new System.EventHandler(this.lbBooks_SelectedIndexChanged);
            // 
            // cbViewBooks
            // 
            this.cbViewBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViewBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbViewBooks.FormattingEnabled = true;
            this.cbViewBooks.Items.AddRange(new object[] {
            "All books",
            "Categorized books",
            "Uncategorized books",
            "Sought books"});
            this.cbViewBooks.Location = new System.Drawing.Point(54, 10);
            this.cbViewBooks.Name = "cbViewBooks";
            this.cbViewBooks.Size = new System.Drawing.Size(160, 24);
            this.cbViewBooks.TabIndex = 0;
            this.cbViewBooks.SelectedIndexChanged += new System.EventHandler(this.cbViewBooks_SelectedIndexChanged);
            // 
            // tabSearchForBooks
            // 
            this.tabSearchForBooks.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabSearchForBooks.Controls.Add(this.flpQueryControls);
            this.tabSearchForBooks.Controls.Add(this.btPerformQuery);
            this.tabSearchForBooks.Controls.Add(this.cbQueryType);
            this.tabSearchForBooks.Controls.Add(this.lbQueryType);
            this.tabSearchForBooks.Location = new System.Drawing.Point(4, 24);
            this.tabSearchForBooks.Name = "tabSearchForBooks";
            this.tabSearchForBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearchForBooks.Size = new System.Drawing.Size(784, 516);
            this.tabSearchForBooks.TabIndex = 1;
            this.tabSearchForBooks.Text = "Search for Books";
            // 
            // flpQueryControls
            // 
            this.flpQueryControls.Location = new System.Drawing.Point(8, 43);
            this.flpQueryControls.Margin = new System.Windows.Forms.Padding(5);
            this.flpQueryControls.Name = "flpQueryControls";
            this.flpQueryControls.Size = new System.Drawing.Size(768, 456);
            this.flpQueryControls.TabIndex = 2;
            // 
            // btPerformQuery
            // 
            this.btPerformQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPerformQuery.Location = new System.Drawing.Point(452, 5);
            this.btPerformQuery.Name = "btPerformQuery";
            this.btPerformQuery.Size = new System.Drawing.Size(135, 30);
            this.btPerformQuery.TabIndex = 1;
            this.btPerformQuery.Text = "Perform query";
            this.btPerformQuery.UseVisualStyleBackColor = true;
            this.btPerformQuery.Click += new System.EventHandler(this.btPerformQuery_Click);
            // 
            // cbQueryType
            // 
            this.cbQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQueryType.FormattingEnabled = true;
            this.cbQueryType.Items.AddRange(new object[] {
            "OR",
            "AND"});
            this.cbQueryType.Location = new System.Drawing.Point(374, 9);
            this.cbQueryType.MaxDropDownItems = 2;
            this.cbQueryType.Name = "cbQueryType";
            this.cbQueryType.Size = new System.Drawing.Size(62, 24);
            this.cbQueryType.TabIndex = 0;
            // 
            // lbQueryType
            // 
            this.lbQueryType.AutoSize = true;
            this.lbQueryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQueryType.Location = new System.Drawing.Point(155, 11);
            this.lbQueryType.Name = "lbQueryType";
            this.lbQueryType.Size = new System.Drawing.Size(177, 18);
            this.lbQueryType.TabIndex = 6;
            this.lbQueryType.Text = "Inter-category query type: ";
            // 
            // tabAddBooks
            // 
            this.tabAddBooks.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabAddBooks.Controls.Add(this.btBulkAddFileBasedBooks);
            this.tabAddBooks.Controls.Add(this.btAddFolderBasedBook);
            this.tabAddBooks.Controls.Add(this.btAddFileBasedBook);
            this.tabAddBooks.Location = new System.Drawing.Point(4, 24);
            this.tabAddBooks.Name = "tabAddBooks";
            this.tabAddBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddBooks.Size = new System.Drawing.Size(784, 516);
            this.tabAddBooks.TabIndex = 2;
            this.tabAddBooks.Text = "Add Books";
            // 
            // btBulkAddFileBasedBooks
            // 
            this.btBulkAddFileBasedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBulkAddFileBasedBooks.Location = new System.Drawing.Point(285, 385);
            this.btBulkAddFileBasedBooks.Name = "btBulkAddFileBasedBooks";
            this.btBulkAddFileBasedBooks.Size = new System.Drawing.Size(210, 30);
            this.btBulkAddFileBasedBooks.TabIndex = 2;
            this.btBulkAddFileBasedBooks.Text = "Bulk add file-based books";
            this.btBulkAddFileBasedBooks.UseVisualStyleBackColor = true;
            this.btBulkAddFileBasedBooks.Click += new System.EventHandler(this.btBulkAddFileBasedBooks_Click);
            // 
            // btAddFolderBasedBook
            // 
            this.btAddFolderBasedBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddFolderBasedBook.Location = new System.Drawing.Point(285, 235);
            this.btAddFolderBasedBook.Name = "btAddFolderBasedBook";
            this.btAddFolderBasedBook.Size = new System.Drawing.Size(210, 30);
            this.btAddFolderBasedBook.TabIndex = 1;
            this.btAddFolderBasedBook.Text = "Add folder-based book";
            this.btAddFolderBasedBook.UseVisualStyleBackColor = true;
            this.btAddFolderBasedBook.Click += new System.EventHandler(this.btAddFolderBasedBook_Click);
            // 
            // btAddFileBasedBook
            // 
            this.btAddFileBasedBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddFileBasedBook.Location = new System.Drawing.Point(285, 85);
            this.btAddFileBasedBook.Name = "btAddFileBasedBook";
            this.btAddFileBasedBook.Size = new System.Drawing.Size(210, 30);
            this.btAddFileBasedBook.TabIndex = 0;
            this.btAddFileBasedBook.Text = "Add file-based book";
            this.btAddFileBasedBook.UseVisualStyleBackColor = true;
            this.btAddFileBasedBook.Click += new System.EventHandler(this.btAddFileBasedBook_Click);
            // 
            // menuMain
            // 
            this.menuMain.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miOptions,
            this.miAbout});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(790, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(39, 20);
            this.miFile.Text = "&File";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(94, 22);
            this.miExit.Text = "E&xit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miOptions
            // 
            this.miOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDefragmentDatabase,
            this.miResetConfiguration});
            this.miOptions.Name = "miOptions";
            this.miOptions.Size = new System.Drawing.Size(61, 20);
            this.miOptions.Text = "&Options";
            // 
            // miDefragmentDatabase
            // 
            this.miDefragmentDatabase.Name = "miDefragmentDatabase";
            this.miDefragmentDatabase.Size = new System.Drawing.Size(193, 22);
            this.miDefragmentDatabase.Text = "&Defragment database";
            this.miDefragmentDatabase.Click += new System.EventHandler(this.miDefragmentDatabase_Click);
            // 
            // miResetConfiguration
            // 
            this.miResetConfiguration.Name = "miResetConfiguration";
            this.miResetConfiguration.Size = new System.Drawing.Size(193, 22);
            this.miResetConfiguration.Text = "&Reset configuration";
            this.miResetConfiguration.Click += new System.EventHandler(this.miResetConfiguration_Click);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(50, 20);
            this.miAbout.Text = "&About";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.menuMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Store";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tcMain.ResumeLayout(false);
            this.tabViewBooks.ResumeLayout(false);
            this.flpViewBooks.ResumeLayout(false);
            this.pnViewBooksList.ResumeLayout(false);
            this.pnViewBooksList.PerformLayout();
            this.tabSearchForBooks.ResumeLayout(false);
            this.tabSearchForBooks.PerformLayout();
            this.tabAddBooks.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabViewBooks;
        private System.Windows.Forms.TabPage tabSearchForBooks;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miOptions;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.TabPage tabAddBooks;
        private System.Windows.Forms.ComboBox cbQueryType;
        private System.Windows.Forms.Label lbQueryType;
        private System.Windows.Forms.Button btPerformQuery;
        private System.Windows.Forms.Label lbViewBooks;
        private System.Windows.Forms.ComboBox cbViewBooks;
        private System.Windows.Forms.ListBox lbBooks;
        private System.Windows.Forms.Button btAddFileBasedBook;
        private System.Windows.Forms.Button btAddFolderBasedBook;
        private System.Windows.Forms.Button btBulkAddFileBasedBooks;
        private System.Windows.Forms.ToolStripMenuItem miResetConfiguration;
        private System.Windows.Forms.ToolStripMenuItem miDefragmentDatabase;
        private System.Windows.Forms.FlowLayoutPanel flpQueryControls;
        private System.Windows.Forms.FlowLayoutPanel flpViewBooks;
        private System.Windows.Forms.Panel pnViewBooksList;
    }
}

