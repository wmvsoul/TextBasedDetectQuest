using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;

namespace TextBasedDetectQuest
{
    public partial class FormCharacterCreation : Form
    {
        private bool isClosedByUser = true;

        public FormCharacterCreation()
        {
            InitializeComponent();

            cbRole.Items.Add("Частный детектив");
            cbRole.Items.Add("Журналист");
            if (cbRole.Items.Count > 0) cbRole.SelectedIndex = 0;
            if (cbCharacterTrait.Items.Count > 0) cbCharacterTrait.SelectedIndex = 0;
            if (cbInventorySlot.Items.Count > 0) cbInventorySlot.SelectedIndex = 0;
            if (cbContact.Items.Count > 0) cbContact.SelectedIndex = 0;

            foreach (ComboBox cb in new[] { cbRole, cbCharacterTrait, cbInventorySlot, cbContact })
            {
                cb.DropDownClosed += (s, e) => cb.SelectionLength = 0;
                cb.SelectedIndexChanged += (s, e) => cb.SelectionLength = 0;
                cb.GotFocus += (s, e) => cb.SelectionLength = 0;
                cb.MouseDown += (s, e) => cb.SelectionLength = 0;
            }

        }

        private void FormCharacterCreation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isClosedByUser)
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите выйти?\n\n" +
                    "Весь прогресс создания персонажа будет потерян.",
                    "Выход из игры", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.No)
                    e.Cancel = true; //отмена закрытия окна
                else Environment.Exit(0); //выход из программы
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRole.SelectionLength = 0; //убрать синее выделение
            try
            {
                string role = cbRole.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(role))
                    return;

                string imagePath = Path.Combine(Application.StartupPath, "Images");

                if (role == "Частный детектив")
                {
                    string detectPath = Path.Combine(imagePath, "detective.png");

                    if (File.Exists(detectPath))
                    {
                        pbIconRole.Image = Image.FromFile(detectPath);
                    }
                    else
                    {
                        pbIconRole.Image = null;
                        pbIconRole.BackColor = Color.Transparent;
                    }
                }
                else if (role == "Журналист")
                {
                    string jourPath = Path.Combine(imagePath, "journalist.png");

                    if (File.Exists(jourPath))
                    {
                        pbIconRole.Image = Image.FromFile(jourPath);
                    }
                    else
                    {
                        pbIconRole.Image = null;
                        pbIconRole.BackColor = Color.Transparent;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки изображения: {ex.Message}");
                pbIconRole.Image = null;
            }
        }

        private void cbCharacterTrait_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCharacterTrait.SelectionLength = 0;
            //выбор черты
            string trait = cbCharacterTrait.SelectedItem?.ToString(); //если объект null, то null, если нет, то обращение к свойству

            if (string.IsNullOrEmpty(trait)) return; //подсказка в зависимости от выбора

            string toolTipText = GetTraitDescription(trait);

            toolTip.SetToolTip(cbCharacterTrait, toolTipText); //меняет подсказку у кб
        }

        private string GetTraitDescription(string trait)
        {
            switch (trait)
            {
                case "Харизматичный":
                    return "ХАРИЗМАТИЧНЫЙ\n\n" +
                        "Люди вам доверяют и готовы рассказать больше, чем обычно.\n" +
                        "Бонус: +1 к убеждению при допросах";

                case "Циничный":
                    return "ЦИНИЧНЫЙ\n\n" +
                           "Вы замечаете ложь и противоречия в показаниях.\n" +
                           "Бонус: +1 к распознаванию лжи.";

                case "Наблюдательный":
                    return "НАБЛЮДАТЕЛЬНЫЙ\n\n" +
                           "Вы видите то, что другие упускают из виду.\n" +
                           "Бонус: +1 к поиску скрытых улик.";

                case "Эмпатичный":
                    return "ЭМПАТИЧНЫЙ\n\n" +
                           "Вы чувствуете эмоции собеседника и его истинные мотивы.\n" +
                           "Бонус: +1 к пониманию мотивов подозреваемых.";

                case "Бесстрашный":
                    return "БЕССТРАШНЫЙ\n\n" +
                           "Вас трудно запугать или остановить.\n" +
                           "Бонус: +1 к стрессоустойчивости в опасных ситуациях.";

                case "Педантичный":
                    return "ПЕДАНТИЧНЫЙ\n\n" +
                           "Вы замечаете мельчайшие детали и несоответствия.\n" +
                           "Бонус: +1 к анализу документов и вещественных доказательств.";

                default:
                    return "Выберите черту характера";
            }
        }

        private void cbInventorySlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbInventorySlot.SelectionLength = 0;

            string item = cbInventorySlot.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(item)) return;

            string toolTipText = GetInventoryDescription(item);
            toolTip.SetToolTip(cbInventorySlot, toolTipText);
        }

        private string GetInventoryDescription(string item)
        {
            switch (item)
            {
                case "Диктофон":
                    return "ДИКТОФОН\n\nЗаписывает разговоры для последующего анализа.\nМожно переслушать показания подозреваемых.";
                case "Старое удостоверение":
                    return "СТАРОЕ УДОСТОВЕРЕНИЕ\n\nДокумент, открывающий многие двери.\nДоступ в закрытые места и полицейские участки.";
                case "Наручные часы":
                    return "НАРУЧНЫЕ ЧАСЫ\n\nТочное время и встроенный секундомер.\nПомогает проверять алиби по времени.";
                case "Лупа":
                    return "ЛУПА\n\nУвеличивает мелкие детали на месте преступления.\nПозволяет находить скрытые улики (отпечатки, волокна, микрочастицы).";
                case "Отмычки":
                    return "ОТМЫЧКИ\n\nПозволяют открывать замки без ключа.\nДоступ в закрытые помещения и сейфы.";
                case "Фото близкого человека":
                    return "ФОТО БЛИЗКОГО ЧЕЛОВЕКА\n\nНапоминание о том, ради чего вы ведёте расследование.\n+1 к решимости в сложных ситуациях.";
                default:
                    return "Выберите предмет";
            }
        }

        private void cbContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbContact.SelectionLength = 0;

            string contact = cbContact.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(contact)) return;

            string toolTipText = GetContactDescription(contact);
            toolTip.SetToolTip(cbContact, toolTipText);
        }

        private string GetContactDescription(string contact)
        {
            switch (contact)
            {
                case "Бывший напарник":
                    return "БЫВШИЙ НАПАРНИК\n\nСтарый друг, который работает в органах.\nДоступ к полицейским базам данных.";
                case "Хакер":
                    return "ХАКЕР\n\nУмеет взламывать телефоны и электронную почту.\nВзлом цифровых улик (1 раз за игру).";
                case "Бармен":
                    return "БАРМЕН\n\nСлышит все городские слухи и сплетни.\nСбор информации в криминальных кругах.";
                case "Адвокат":
                    return "АДВОКАТ\n\nЗнает законы и юридические лазейки.\nПомощь при аресте или задержании.";
                default:
                    return "Выберите контакт";
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            GameData.CurrentPlayer = new Player
            {
                Name = tbNameCharacter.Text.Trim(),
                Role = cbRole.SelectedItem?.ToString(),
                CharacterTrait = cbCharacterTrait.SelectedItem?.ToString(),
                InventorySlot = cbInventorySlot.SelectedItem?.ToString(),
                Contact = cbContact.SelectedItem?.ToString()
            };

            if (string.IsNullOrWhiteSpace(tbNameCharacter.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя вашего персонажа!",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка роли
            if (cbRole.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите роль!",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка черты характера
            if (cbCharacterTrait.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите черту характера!",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка предмета
            if (cbInventorySlot.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите предмет!",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка контакта
            if (cbContact.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите контакт!",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.isClosedByUser = false;
            this.Close();
        }
    }
}
