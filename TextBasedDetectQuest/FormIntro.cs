using System;
using System.Windows.Forms;

namespace TextBasedDetectQuest
{
    public partial class FormIntro : Form
    {
        public FormIntro()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
