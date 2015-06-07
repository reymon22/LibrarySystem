using System;
using System.Threading;


namespace BookStoreGUI
{
    
    public class BackgroundTask
    {

       
        public delegate void BackgroundOperation();
        
        private BackgroundOperation Operation;
 
        private WorkInProgressForm progressForm;

        private Exception operationException;

        private void OperationThread()
        {
            try
            {
                Operation();
            }
            catch (Exception ex)
            {
                operationException = ex;
            }
            finally
            {
                progressForm.CloseProgressForm();
            }
        }


        /// <summary>
        /// BackgroundTask constructor.
        /// </summary>
        /// <param name="operationText">The text to be displayed on the progress form</param>
        /// <param name="Operation">The operation to be performed in the background</param>
        public BackgroundTask(string operationText, BackgroundOperation Operation)
        {
            this.Operation = Operation;
            this.progressForm = new WorkInProgressForm(operationText);

            Thread anOperationThread = new Thread(new ThreadStart(OperationThread));
            anOperationThread.Name = "BackgroundTask";
            anOperationThread.Start();

            progressForm.ShowDialog();
            anOperationThread.Join();
            GC.KeepAlive(progressForm);

            if ((operationException != null))
            {
                throw operationException;
            }
        }

    }

}
