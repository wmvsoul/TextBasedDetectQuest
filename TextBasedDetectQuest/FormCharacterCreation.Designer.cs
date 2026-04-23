namespace TextBasedDetectQuest
{
    partial class FormCharacterCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCharacterCreation));
            toolTip = new ToolTip(components);
            cbRole = new ComboBox();
            lblNameCharacter = new Label();
            tbNameCharacter = new TextBox();
            lblRole = new Label();
            lblCharacterTrait = new Label();
            cbCharacterTrait = new ComboBox();
            lblInventorySlot = new Label();
            cbInventorySlot = new ComboBox();
            lblContact = new Label();
            cbContact = new ComboBox();
            pbIconRole = new PictureBox();
            lblCreation = new Label();
            btnCreate = new Button();
            ((System.ComponentModel.ISupportInitialize)pbIconRole).BeginInit();
            SuspendLayout();
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 10000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 100;
            // 
            // cbRole
            // 
            cbRole.BackColor = Color.FromArgb(180, 140, 80);
            cbRole.FlatStyle = FlatStyle.Flat;
            cbRole.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            cbRole.ForeColor = Color.FromArgb(30, 25, 20);
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(89, 251);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(264, 35);
            cbRole.TabIndex = 3;
            toolTip.SetToolTip(cbRole, resources.GetString("cbRole.ToolTip"));
            cbRole.SelectedIndexChanged += cbRole_SelectedIndexChanged;
            // 
            // lblNameCharacter
            // 
            lblNameCharacter.AutoSize = true;
            lblNameCharacter.BackColor = Color.Transparent;
            lblNameCharacter.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            lblNameCharacter.ForeColor = Color.FromArgb(180, 140, 80);
            lblNameCharacter.Location = new Point(12, 112);
            lblNameCharacter.Name = "lblNameCharacter";
            lblNameCharacter.Size = new Size(197, 27);
            lblNameCharacter.TabIndex = 0;
            lblNameCharacter.Text = "Имя персонажа:";
            // 
            // tbNameCharacter
            // 
            tbNameCharacter.BackColor = Color.FromArgb(180, 140, 80);
            tbNameCharacter.BorderStyle = BorderStyle.None;
            tbNameCharacter.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            tbNameCharacter.ForeColor = Color.FromArgb(30, 25, 20);
            tbNameCharacter.Location = new Point(215, 112);
            tbNameCharacter.MaxLength = 10;
            tbNameCharacter.Name = "tbNameCharacter";
            tbNameCharacter.Size = new Size(257, 27);
            tbNameCharacter.TabIndex = 1;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.BackColor = Color.Transparent;
            lblRole.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            lblRole.ForeColor = Color.FromArgb(180, 140, 80);
            lblRole.Location = new Point(12, 254);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(71, 27);
            lblRole.TabIndex = 2;
            lblRole.Text = "Роль:";
            // 
            // lblCharacterTrait
            // 
            lblCharacterTrait.AutoSize = true;
            lblCharacterTrait.BackColor = Color.Transparent;
            lblCharacterTrait.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            lblCharacterTrait.ForeColor = Color.FromArgb(180, 140, 80);
            lblCharacterTrait.Location = new Point(12, 364);
            lblCharacterTrait.Name = "lblCharacterTrait";
            lblCharacterTrait.Size = new Size(221, 27);
            lblCharacterTrait.TabIndex = 4;
            lblCharacterTrait.Text = "Черта характера:";
            // 
            // cbCharacterTrait
            // 
            cbCharacterTrait.BackColor = Color.FromArgb(180, 140, 80);
            cbCharacterTrait.FlatStyle = FlatStyle.Flat;
            cbCharacterTrait.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            cbCharacterTrait.ForeColor = Color.FromArgb(30, 25, 20);
            cbCharacterTrait.FormattingEnabled = true;
            cbCharacterTrait.Items.AddRange(new object[] { "Харизматичный", "Циничный", "Наблюдательный", "Эмпатичный", "Бесстрашный", "Педантичный" });
            cbCharacterTrait.Location = new Point(239, 361);
            cbCharacterTrait.Name = "cbCharacterTrait";
            cbCharacterTrait.Size = new Size(233, 35);
            cbCharacterTrait.TabIndex = 5;
            cbCharacterTrait.SelectedIndexChanged += cbCharacterTrait_SelectedIndexChanged;
            // 
            // lblInventorySlot
            // 
            lblInventorySlot.AutoSize = true;
            lblInventorySlot.BackColor = Color.Transparent;
            lblInventorySlot.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            lblInventorySlot.ForeColor = Color.FromArgb(180, 140, 80);
            lblInventorySlot.Location = new Point(12, 474);
            lblInventorySlot.Name = "lblInventorySlot";
            lblInventorySlot.Size = new Size(242, 27);
            lblInventorySlot.TabIndex = 6;
            lblInventorySlot.Text = "Инвентарный слот:";
            // 
            // cbInventorySlot
            // 
            cbInventorySlot.BackColor = Color.FromArgb(180, 140, 80);
            cbInventorySlot.FlatStyle = FlatStyle.Flat;
            cbInventorySlot.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            cbInventorySlot.ForeColor = Color.FromArgb(30, 25, 20);
            cbInventorySlot.FormattingEnabled = true;
            cbInventorySlot.Items.AddRange(new object[] { "Диктофон", "Старое удостоверение", "Наручные часы", "Лупа", "Отмычки", "Фото близкого человека" });
            cbInventorySlot.Location = new Point(260, 471);
            cbInventorySlot.Name = "cbInventorySlot";
            cbInventorySlot.Size = new Size(270, 35);
            cbInventorySlot.TabIndex = 7;
            cbInventorySlot.SelectedIndexChanged += cbInventorySlot_SelectedIndexChanged;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.BackColor = Color.Transparent;
            lblContact.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            lblContact.ForeColor = Color.FromArgb(180, 140, 80);
            lblContact.Location = new Point(12, 578);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(128, 27);
            lblContact.TabIndex = 8;
            lblContact.Text = "Контакт:";
            // 
            // cbContact
            // 
            cbContact.BackColor = Color.FromArgb(180, 140, 80);
            cbContact.FlatStyle = FlatStyle.Flat;
            cbContact.Font = new Font("Georgia", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            cbContact.ForeColor = Color.FromArgb(30, 25, 20);
            cbContact.FormattingEnabled = true;
            cbContact.Items.AddRange(new object[] { "Бывший напарник", "Хакер", "Бармен", "Адвокат" });
            cbContact.Location = new Point(146, 575);
            cbContact.Name = "cbContact";
            cbContact.Size = new Size(233, 35);
            cbContact.TabIndex = 9;
            cbContact.SelectedIndexChanged += cbContact_SelectedIndexChanged;
            // 
            // pbIconRole
            // 
            pbIconRole.BackColor = Color.Transparent;
            pbIconRole.Location = new Point(536, 85);
            pbIconRole.Name = "pbIconRole";
            pbIconRole.Size = new Size(467, 612);
            pbIconRole.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIconRole.TabIndex = 10;
            pbIconRole.TabStop = false;
            // 
            // lblCreation
            // 
            lblCreation.BackColor = Color.Transparent;
            lblCreation.Dock = DockStyle.Top;
            lblCreation.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold);
            lblCreation.ForeColor = Color.FromArgb(180, 140, 80);
            lblCreation.Location = new Point(0, 0);
            lblCreation.Name = "lblCreation";
            lblCreation.Size = new Size(1039, 46);
            lblCreation.TabIndex = 11;
            lblCreation.Text = "Создание персонажа";
            lblCreation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(180, 140, 80);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCreate.ForeColor = Color.FromArgb(30, 25, 20);
            btnCreate.Location = new Point(110, 672);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(300, 50);
            btnCreate.TabIndex = 12;
            btnCreate.Text = "СОЗДАТЬ ПЕРСОНАЖА";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // FormCharacterCreation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1039, 762);
            Controls.Add(btnCreate);
            Controls.Add(pbIconRole);
            Controls.Add(lblCreation);
            Controls.Add(cbContact);
            Controls.Add(lblContact);
            Controls.Add(cbInventorySlot);
            Controls.Add(lblInventorySlot);
            Controls.Add(cbCharacterTrait);
            Controls.Add(lblCharacterTrait);
            Controls.Add(cbRole);
            Controls.Add(lblRole);
            Controls.Add(tbNameCharacter);
            Controls.Add(lblNameCharacter);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCharacterCreation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Создание персонажа";
            FormClosing += FormCharacterCreation_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbIconRole).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNameCharacter;
        private TextBox tbNameCharacter;
        private Label lblRole;
        private ComboBox cbRole;
        private Label lblCharacterTrait;
        private ComboBox cbCharacterTrait;
        private Label lblInventorySlot;
        private ComboBox cbInventorySlot;
        private Label lblContact;
        private ComboBox cbContact;
        private PictureBox pbIconRole;
        private Label lblCreation;
        private ToolTip toolTip;
        private Button btnCreate;
    }
}