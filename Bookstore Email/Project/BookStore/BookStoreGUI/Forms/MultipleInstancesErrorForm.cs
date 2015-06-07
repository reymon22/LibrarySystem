using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace BookStoreGUI
{
    
    /// <summary>
    /// Error-form corresponding to the situation when an application
    /// instance in already in memory.
    /// </summary>
    public partial class MultipleInstancesErrorForm : Form
    {
        
        public MultipleInstancesErrorForm()
        {
            InitializeComponent();
        }


        private void MultipleProcessErrorForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            this.FormClosing += new FormClosingEventHandler(MultipleProcessErrorForm_FormClosing);
        }


        private void MultipleProcessErrorForm_FormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }


        private void btOK_Click(object sender, EventArgs e)
        {
            this.FormClosing -= MultipleProcessErrorForm_FormClosing;
            
            this.Close();
        }

    }

}
