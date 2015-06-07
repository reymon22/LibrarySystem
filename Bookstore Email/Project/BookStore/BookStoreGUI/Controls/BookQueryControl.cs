using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BookEntities;


namespace BookStoreGUI
{
    
    
    partial class BookQueryControl : UserControl
    {

        /// <summary>
        /// Business logic command pattern instance.
        /// </summary>
        private BooksManager booksManager;

        /// <summary>
        /// The type of book meta data.
        /// </summary>
        private Type bookMetaDataType;


        /// <summary>
        /// Intra-category query category.
        /// </summary>
        private IQueryDataCategory queryDataCategory;

        private List<IBookMetaData> checkedItems;


        /// <summary>
        /// The type of the query.
        /// </summary>
        private QueryType queryType;


        /// <summary>
        /// BookQueryControl constructor.
        /// </summary>
        /// <param name="booksManager">Business logic command pattern instance</param>
        /// <param name="bookMetaDataType">The type of book meta data</param>
        /// <param name="queryType">The type of the query</param>
        public BookQueryControl(BooksManager booksManager, Type bookMetaDataType, QueryType queryType)
        {
            this.booksManager = booksManager;
            this.bookMetaDataType = bookMetaDataType;

            this.queryType = queryType;

            this.checkedItems = new List<IBookMetaData>();

            InitializeComponent();
            this.cbQueryType.SelectedIndex = 0;
        }


        private void BookQueryControl_Load(object sender, EventArgs e)
        {
            switch (bookMetaDataType.Name)
            {
                case "Author":
                    lbQueryCategory.Text += " authors?";
                    break;
                case "Tag":
                    lbQueryCategory.Text += " tags?";
                    break;
                case "PublishingHouse":
                    lbQueryCategory.Text += " publishing houses?";
                    break;
                case "YearOfPublishing":
                    lbQueryCategory.Text += " years of publishing?";
                    break;
            }

            RefreshData();
        }


        /// <summary>
        /// Refreshes the data presented by the user control.
        /// </summary>
        public void RefreshData()
        {
            GetCheckedItems();

            clbItems.Items.Clear();

            if (bookMetaDataType == typeof(Author))
                foreach (Author currentAuthor in booksManager.BooksRepository.Authors)
                {
                    if (checkedItems.Contains(currentAuthor))
                        clbItems.Items.Add(currentAuthor, true);
                    else
                        clbItems.Items.Add(currentAuthor, false);
                }

            else if (bookMetaDataType == typeof(Tag))
                foreach (Tag currentTag in booksManager.BooksRepository.Tags)
                {
                    if (checkedItems.Contains(currentTag))
                        clbItems.Items.Add(currentTag, true);
                    else
                        clbItems.Items.Add(currentTag, false);
                }

            else if (bookMetaDataType == typeof(PublishingHouse))
                foreach (PublishingHouse currentPublishingHouse in booksManager.BooksRepository.PublishingHouses)
                {
                    if (checkedItems.Contains(currentPublishingHouse))
                        clbItems.Items.Add(currentPublishingHouse, true);
                    else
                        clbItems.Items.Add(currentPublishingHouse, false);
                }

            else if (bookMetaDataType == typeof(YearOfPublishing))
                foreach (YearOfPublishing currentYearOfPublishing in booksManager.BooksRepository.YearsOfPublishing)
                {
                    if (checkedItems.Contains(currentYearOfPublishing))
                        clbItems.Items.Add(currentYearOfPublishing, true);
                    else
                        clbItems.Items.Add(currentYearOfPublishing, false);
                }
        }


        private void GetCheckedItems()
        {
            checkedItems.Clear();
            
            if (clbItems.Items.Count > 0)
            {
                foreach (object aBookMetaData in clbItems.CheckedItems)
                    checkedItems.Add((IBookMetaData)aBookMetaData);
            }
        }


        private void chbSelectControl_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSelectControl.Checked == true)
            {
                if (queryType == QueryType.ANDORQuery)
                {
                    lbQueryType.Visible = true;
                    cbQueryType.Visible = true;
                }

                clbItems.Visible = true;
            }

            else
            {
                lbQueryType.Visible = false;
                cbQueryType.Visible = false;
                clbItems.Visible = false;
            }
        }


        /// <summary>
        /// Gets the control checked status.
        /// </summary>
        public bool IsChecked
        {
            get { return chbSelectControl.Checked; }
        }


        /// <summary>
        /// Returns the list of checked items of the control.
        /// </summary>
        /// <returns>The list of checked items of the control</returns>
        private List<T> GetCheckedItemsList<T>()
        {
            List<T> selectedItems = new List<T>();

            foreach (object currentObject in clbItems.CheckedItems)
                selectedItems.Add((T)currentObject);

            return selectedItems;
        }


        /// <summary>
        /// Gets the list of the books that satisfy the query.
        /// </summary>
        public List<Book> CorrespondingBooks
        {
            get
            {
                if (bookMetaDataType == typeof(Author))
                    queryDataCategory = new AuthorsQueryDataCategory(booksManager,
                                                                  GetCheckedItemsList<Author>());

                else if (bookMetaDataType == typeof(Tag))
                    queryDataCategory = new TagsQueryDataCategory(booksManager,
                                                                  GetCheckedItemsList<Tag>());

                else if (bookMetaDataType == typeof(PublishingHouse))
                    queryDataCategory = new PublishingHousesQueryDataCategory(booksManager,
                                                                  GetCheckedItemsList<PublishingHouse>());

                else if (bookMetaDataType == typeof(YearOfPublishing))
                    queryDataCategory = new YearsOfPublishingQueryDataCategory(booksManager,
                                                                  GetCheckedItemsList<YearOfPublishing>());

                if (queryType == QueryType.ORQuery)
                    return queryDataCategory.ORInternalQuery();

                else
                {
                    if (cbQueryType.SelectedItem.ToString() == "OR")
                        return queryDataCategory.ORInternalQuery();
                    else
                        return queryDataCategory.ANDInternalQuery();
                }
            }
        }

    }

}
