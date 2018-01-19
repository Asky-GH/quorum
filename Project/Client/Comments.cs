using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class formComments : Form
    {
        // Список комментариев
        public List<string> YesNoComments { get; set; }

        public formComments()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formComments_Shown(object sender, EventArgs e)
        {
            foreach (string comment in YesNoComments)
            {
                richTextBoxComments.Text += comment + "\n\r";
            }
        }
    }
}
