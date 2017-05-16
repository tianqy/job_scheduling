using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win
{
    public partial class TextForm : Form
    {
        string msg = "";
        public TextForm(string msg)
        {
            InitializeComponent();
            this.msg = msg;
        }

        private void TextForm_Load(object sender, EventArgs e)
        {
            txt_Result.Text = msg;
        }
    }
}
