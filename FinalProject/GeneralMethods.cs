using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    class GeneralMethods
    {
        public static void showErrorMessageBox(string text)
        {
            MessageBox.Show(text,"Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);

        }
    }
}
