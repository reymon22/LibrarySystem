using System;
using System.Threading;
using System.Windows.Forms;


namespace BookStoreGUI
{

    static class Program
    {

        private const string ApplicationName = "BookStore";

        
        private const int WaitingTimeInMilliseconds = 50;


        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Mutex applicationMutex = new Mutex(false, ApplicationName);

            if (applicationMutex.WaitOne(WaitingTimeInMilliseconds, false) == false)
                Application.Run(new MultipleInstancesErrorForm());
            else
            {
                Application.Run(new MainForm());
                applicationMutex.ReleaseMutex();
            }
        }

    }

}
