using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISPRO_TRANSPORTES
{
    public partial class frmNoVale : Form
    {
        public frmNoVale()
        {
            InitializeComponent();
        }

        private void frmNoVale_Load(object sender, EventArgs e)
        {
            int ancholbl = label1.Width;
            label1.Left = (this.Width / 2) - (ancholbl / 2);
            int ancholbl2 = label2.Width;
            label2.Left = (this.Width / 2) - (ancholbl2 / 2);
            int ancholbl3 = label3.Width;
            label3.Left = (this.Width / 2) - (ancholbl3 / 2);
        }

        
    }
}
