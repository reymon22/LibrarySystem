using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace BookStoreGUI
{

    /// <summary>
    /// Form rendering a modal progress window, that is shown as long as the required
    /// background (separate thread) operation is running.
    /// </summary>
    partial class WorkInProgressForm : Form
    {

        /// <summary>
        /// Delegate for a cross-thread operation, that uses invocation to
        /// ensure control integrity.
        /// </summary>
        private delegate void FormOperation();
        
        
        /// <summary>
        /// The message displayed by the progress form. 
        /// </summary>
        private string explanationText;

        private int isFull;


        /// <summary>
        /// WorkInProgressForm constructor.
        /// </summary>
        /// <param name="explanationText">The message displayed by the progress form</param>
        public WorkInProgressForm(string explanationText)
        {
            InitializeComponent();
            this.explanationText = explanationText;
            this.isFull = 0;
        }


        private void WorkInProgressForm_FormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }


        private void CloseProgressFormHelper()
        {
            this.FormClosing -= WorkInProgressForm_FormClosing;
            this.Close();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        public void CloseProgressForm()
        {
            if (this.InvokeRequired == true)
                this.Invoke(new FormOperation(CloseProgressFormHelper));
            else
                CloseProgressFormHelper();
        }


        private void WorkInProgressForm_Load(object sender, EventArgs e)
        {
            lbExplanation.Text = explanationText;
            this.FormClosing += new FormClosingEventHandler(WorkInProgressForm_FormClosing);
        }


        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (isFull == 4)
            {
                pbOperationProgress.Value = 0;
                isFull = 0;
            }
            else if (pbOperationProgress.Value < pbOperationProgress.Maximum)
            {
                pbOperationProgress.PerformStep();
            }
            else if (pbOperationProgress.Value == pbOperationProgress.Maximum)
            {
                pbOperationProgress.PerformStep();
                isFull += 1;
            }
        }

    }

}
