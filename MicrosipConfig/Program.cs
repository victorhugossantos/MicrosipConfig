using System;
using System.Windows.Forms;

namespace MicrosipConfig
{
    static class Program
    {
        [STAThread]
        static void Main() {
            // habilitar estilos visuais do windows para os controles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
        }
    }
}