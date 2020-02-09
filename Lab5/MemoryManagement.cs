using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public class MemoryManagement
    {
        [STAThread]
        static void Main(string[] args)
        {
            args = new string[2];
            args[0] = "commands";
            args[1] = "memory.conf";

            ControlPanel controlPanel;
            Kernel kernel;

            if (args.Length < 1 || args.Length > 2)
            {
                MessageBox.Show("Usage: 'java MemoryManagement <COMMAND FILE> <PROPERTIES FILE>'");
                return;
            }

            if (!(File.Exists(args[0])))
            {
                MessageBox.Show("MemoryM: error, file '" + args[0] + "' does not exist.");
                return;
            }

            if (args.Length == 2)
            {
                if (!(File.Exists(args[1])))
                {
                    MessageBox.Show("MemoryM: error, file '" + args[1] + "' does not exist.");
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            kernel = new Kernel();
            controlPanel = new ControlPanel();

            if (args.Length == 1)
            {
                controlPanel.init(kernel, args[0], null);
            }
            else
            {
                controlPanel.init(kernel, args[0], args[1]);
            }
            
            Application.Run(controlPanel);
        }
    }
}
