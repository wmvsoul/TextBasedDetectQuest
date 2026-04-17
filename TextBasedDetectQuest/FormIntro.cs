using System;
using System.Windows.Forms;

namespace TextBasedDetectQuest
{
    public partial class FormIntro : Form
    {
        /// <summary>
        /// был ли нажат крестик и закрыто окно без продолжения
        /// </summary>
        //true - закрыли без кнопки
        //false - нажата кнопка "Продолжить", переход к следующему окну
        private bool isClosedByUser = true;

        public FormIntro()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.isClosedByUser = false;
            this.Close();
        }

        private void FormInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //если окно закрывается через крестик или альт ф4
            if (this.isClosedByUser)
            {
                Environment.Exit(0); //немедленно завершается программа полностью, 0 - успешное завершение
            }
        }
    }
}
