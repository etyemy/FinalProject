using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    class ArticleTabPage : TabPage
    {
        private Form frm;
        public ArticleTabPage(ArticleFormPage container)
        {
            this.frm = container;
            this.Controls.Add(container.pnl);
            this.Text = container.Text;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                frm.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    public class ArticleFormPage : Form
    {
        public Panel pnl;
    }
}



