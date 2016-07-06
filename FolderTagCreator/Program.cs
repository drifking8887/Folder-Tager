using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderTagCreator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
           
                try
                {
                    ArrayList myAL = new ArrayList();

                    foreach (string arg in args)
                    {
                        myAL.Add(arg);
                    }
                    if (myAL.Count > 0)
                    {
                        //MessageBox.Show(myAL[0].ToString());
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm(myAL[0].ToString()));
                    }
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm());
                    }

                }
                catch (Exception ex)
                {
                    Helper.showError(new Exception(ex.Message));
                }
                
            //}
            //else
            //{
            //    String[] arguments = Environment.GetCommandLineArgs();
            //    MessageBox.Show(arguments.Length.ToString());
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new MainForm());
            //}
        }
    }
}
