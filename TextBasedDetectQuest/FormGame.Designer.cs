namespace TextBasedDetectQuest
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            pnlTop = new Panel();
            lblCluesValue = new Label();
            lblCharismaValue = new Label();
            lblLogicValue = new Label();
            lblAttentionValue = new Label();
            lblResolveValue = new Label();
            gbStatus = new GroupBox();
            lblCharacterTrait = new Label();
            lblRole = new Label();
            lblPlayerName = new Label();
            pbCharisma = new ProgressBar();
            pbLogic = new ProgressBar();
            lblCharisma = new Label();
            lblLogic = new Label();
            pbAttention = new ProgressBar();
            pbResolve = new ProgressBar();
            lblAttention = new Label();
            lblResolve = new Label();
            pbClues = new ProgressBar();
            lblClues = new Label();
            pbTime = new ProgressBar();
            lblTime = new Label();
            pnlLocation = new Panel();
            listLocation = new ListBox();
            lblLocation = new Label();
            pnlDescription = new Panel();
            flpChoises = new FlowLayoutPanel();
            rtbDescription = new RichTextBox();
            pnlBottom = new Panel();
            btnItemAndContact = new Button();
            btnJournal = new Button();
            pbLocation = new PictureBox();
            btnNextLocation = new Button();
            pnlTop.SuspendLayout();
            gbStatus.SuspendLayout();
            pnlLocation.SuspendLayout();
            pnlDescription.SuspendLayout();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLocation).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(35, 35, 45);
            pnlTop.Controls.Add(lblCluesValue);
            pnlTop.Controls.Add(lblCharismaValue);
            pnlTop.Controls.Add(lblLogicValue);
            pnlTop.Controls.Add(lblAttentionValue);
            pnlTop.Controls.Add(lblResolveValue);
            pnlTop.Controls.Add(gbStatus);
            pnlTop.Controls.Add(pbCharisma);
            pnlTop.Controls.Add(pbLogic);
            pnlTop.Controls.Add(lblCharisma);
            pnlTop.Controls.Add(lblLogic);
            pnlTop.Controls.Add(pbAttention);
            pnlTop.Controls.Add(pbResolve);
            pnlTop.Controls.Add(lblAttention);
            pnlTop.Controls.Add(lblResolve);
            pnlTop.Controls.Add(pbClues);
            pnlTop.Controls.Add(lblClues);
            pnlTop.Controls.Add(pbTime);
            pnlTop.Controls.Add(lblTime);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1039, 135);
            pnlTop.TabIndex = 0;
            // 
            // lblCluesValue
            // 
            lblCluesValue.AutoSize = true;
            lblCluesValue.Font = new Font("Georgia", 9F);
            lblCluesValue.ForeColor = Color.FromArgb(210, 195, 160);
            lblCluesValue.Location = new Point(714, 19);
            lblCluesValue.Name = "lblCluesValue";
            lblCluesValue.Size = new Size(38, 18);
            lblCluesValue.TabIndex = 16;
            lblCluesValue.Text = "0/11";
            // 
            // lblCharismaValue
            // 
            lblCharismaValue.AutoSize = true;
            lblCharismaValue.Font = new Font("Georgia", 9F);
            lblCharismaValue.ForeColor = Color.FromArgb(210, 195, 160);
            lblCharismaValue.Location = new Point(720, 104);
            lblCharismaValue.Name = "lblCharismaValue";
            lblCharismaValue.Size = new Size(32, 18);
            lblCharismaValue.TabIndex = 15;
            lblCharismaValue.Text = "0/5";
            // 
            // lblLogicValue
            // 
            lblLogicValue.AutoSize = true;
            lblLogicValue.Font = new Font("Georgia", 9F);
            lblLogicValue.ForeColor = Color.FromArgb(210, 195, 160);
            lblLogicValue.Location = new Point(714, 75);
            lblLogicValue.Name = "lblLogicValue";
            lblLogicValue.Size = new Size(32, 18);
            lblLogicValue.TabIndex = 14;
            lblLogicValue.Text = "0/5";
            // 
            // lblAttentionValue
            // 
            lblAttentionValue.AutoSize = true;
            lblAttentionValue.Font = new Font("Georgia", 9F);
            lblAttentionValue.ForeColor = Color.FromArgb(210, 195, 160);
            lblAttentionValue.Location = new Point(393, 105);
            lblAttentionValue.Name = "lblAttentionValue";
            lblAttentionValue.Size = new Size(32, 18);
            lblAttentionValue.TabIndex = 13;
            lblAttentionValue.Text = "0/5";
            // 
            // lblResolveValue
            // 
            lblResolveValue.AutoSize = true;
            lblResolveValue.Font = new Font("Georgia", 9F);
            lblResolveValue.ForeColor = Color.FromArgb(210, 195, 160);
            lblResolveValue.Location = new Point(355, 73);
            lblResolveValue.Name = "lblResolveValue";
            lblResolveValue.Size = new Size(32, 18);
            lblResolveValue.TabIndex = 12;
            lblResolveValue.Text = "0/5";
            // 
            // gbStatus
            // 
            gbStatus.BackColor = Color.FromArgb(180, 140, 80);
            gbStatus.Controls.Add(lblCharacterTrait);
            gbStatus.Controls.Add(lblRole);
            gbStatus.Controls.Add(lblPlayerName);
            gbStatus.ForeColor = Color.FromArgb(35, 35, 45);
            gbStatus.Location = new Point(752, 6);
            gbStatus.Name = "gbStatus";
            gbStatus.Size = new Size(275, 118);
            gbStatus.TabIndex = 0;
            gbStatus.TabStop = false;
            gbStatus.Text = "📋 СТАТУС ПЕРСОНАЖА";
            // 
            // lblCharacterTrait
            // 
            lblCharacterTrait.AutoSize = true;
            lblCharacterTrait.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblCharacterTrait.ForeColor = Color.FromArgb(35, 35, 45);
            lblCharacterTrait.Location = new Point(6, 92);
            lblCharacterTrait.Name = "lblCharacterTrait";
            lblCharacterTrait.Size = new Size(123, 20);
            lblCharacterTrait.TabIndex = 14;
            lblCharacterTrait.Text = "Черта игрока:";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblRole.ForeColor = Color.FromArgb(35, 35, 45);
            lblRole.Location = new Point(6, 63);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(111, 20);
            lblRole.TabIndex = 13;
            lblRole.Text = "Роль игрока:";
            // 
            // lblPlayerName
            // 
            lblPlayerName.AutoSize = true;
            lblPlayerName.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPlayerName.ForeColor = Color.FromArgb(35, 35, 45);
            lblPlayerName.Location = new Point(6, 33);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new Size(109, 20);
            lblPlayerName.TabIndex = 12;
            lblPlayerName.Text = "Имя игрока:";
            // 
            // pbCharisma
            // 
            pbCharisma.Location = new Point(533, 104);
            pbCharisma.Maximum = 5;
            pbCharisma.Name = "pbCharisma";
            pbCharisma.Size = new Size(188, 20);
            pbCharisma.TabIndex = 11;
            // 
            // pbLogic
            // 
            pbLogic.Location = new Point(522, 73);
            pbLogic.Maximum = 5;
            pbLogic.Name = "pbLogic";
            pbLogic.Size = new Size(192, 20);
            pbLogic.TabIndex = 10;
            // 
            // lblCharisma
            // 
            lblCharisma.AutoSize = true;
            lblCharisma.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblCharisma.ForeColor = Color.FromArgb(210, 195, 160);
            lblCharisma.Location = new Point(423, 104);
            lblCharisma.Name = "lblCharisma";
            lblCharisma.Size = new Size(104, 20);
            lblCharisma.TabIndex = 9;
            lblCharisma.Text = "🗣️ Харизма:";
            // 
            // lblLogic
            // 
            lblLogic.AutoSize = true;
            lblLogic.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLogic.ForeColor = Color.FromArgb(210, 195, 160);
            lblLogic.Location = new Point(423, 73);
            lblLogic.Name = "lblLogic";
            lblLogic.Size = new Size(93, 20);
            lblLogic.TabIndex = 8;
            lblLogic.Text = "\U0001f9e0 Логика:";
            // 
            // pbAttention
            // 
            pbAttention.Location = new Point(191, 104);
            pbAttention.Maximum = 5;
            pbAttention.Name = "pbAttention";
            pbAttention.Size = new Size(196, 20);
            pbAttention.TabIndex = 7;
            // 
            // pbResolve
            // 
            pbResolve.Location = new Point(149, 73);
            pbResolve.Maximum = 5;
            pbResolve.Name = "pbResolve";
            pbResolve.Size = new Size(200, 20);
            pbResolve.TabIndex = 6;
            // 
            // lblAttention
            // 
            lblAttention.AutoSize = true;
            lblAttention.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblAttention.ForeColor = Color.FromArgb(210, 195, 160);
            lblAttention.Location = new Point(20, 104);
            lblAttention.Name = "lblAttention";
            lblAttention.Size = new Size(165, 20);
            lblAttention.TabIndex = 5;
            lblAttention.Text = "👁️ Внимательность:";
            // 
            // lblResolve
            // 
            lblResolve.AutoSize = true;
            lblResolve.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblResolve.ForeColor = Color.FromArgb(210, 195, 160);
            lblResolve.Location = new Point(20, 73);
            lblResolve.Name = "lblResolve";
            lblResolve.Size = new Size(123, 20);
            lblResolve.TabIndex = 4;
            lblResolve.Text = "💪 Решимость:";
            // 
            // pbClues
            // 
            pbClues.Location = new Point(514, 19);
            pbClues.Maximum = 17;
            pbClues.Name = "pbClues";
            pbClues.Size = new Size(200, 20);
            pbClues.TabIndex = 3;
            // 
            // lblClues
            // 
            lblClues.AutoSize = true;
            lblClues.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblClues.ForeColor = Color.FromArgb(210, 195, 160);
            lblClues.Location = new Point(423, 19);
            lblClues.Name = "lblClues";
            lblClues.Size = new Size(85, 20);
            lblClues.TabIndex = 2;
            lblClues.Text = "🔍 Улики:";
            // 
            // pbTime
            // 
            pbTime.Location = new Point(110, 19);
            pbTime.Name = "pbTime";
            pbTime.Size = new Size(200, 20);
            pbTime.TabIndex = 1;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTime.ForeColor = Color.FromArgb(210, 195, 160);
            lblTime.Location = new Point(20, 19);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(84, 20);
            lblTime.TabIndex = 0;
            lblTime.Text = "⏰ Время:";
            // 
            // pnlLocation
            // 
            pnlLocation.BackColor = Color.FromArgb(25, 25, 35);
            pnlLocation.Controls.Add(listLocation);
            pnlLocation.Controls.Add(lblLocation);
            pnlLocation.Location = new Point(0, 141);
            pnlLocation.Name = "pnlLocation";
            pnlLocation.Size = new Size(349, 254);
            pnlLocation.TabIndex = 1;
            // 
            // listLocation
            // 
            listLocation.BackColor = Color.FromArgb(40, 40, 50);
            listLocation.BorderStyle = BorderStyle.None;
            listLocation.Dock = DockStyle.Fill;
            listLocation.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            listLocation.ForeColor = Color.FromArgb(210, 195, 160);
            listLocation.FormattingEnabled = true;
            listLocation.Location = new Point(0, 29);
            listLocation.Name = "listLocation";
            listLocation.Size = new Size(349, 225);
            listLocation.TabIndex = 2;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Dock = DockStyle.Top;
            lblLocation.Font = new Font("Georgia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLocation.ForeColor = Color.FromArgb(210, 195, 160);
            lblLocation.Location = new Point(0, 0);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(173, 29);
            lblLocation.TabIndex = 6;
            lblLocation.Text = "📍 ЛОКАЦИИ";
            lblLocation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDescription
            // 
            pnlDescription.BackColor = Color.FromArgb(35, 35, 45);
            pnlDescription.Controls.Add(flpChoises);
            pnlDescription.Controls.Add(rtbDescription);
            pnlDescription.Location = new Point(355, 141);
            pnlDescription.Name = "pnlDescription";
            pnlDescription.Size = new Size(672, 555);
            pnlDescription.TabIndex = 2;
            // 
            // flpChoises
            // 
            flpChoises.AutoScroll = true;
            flpChoises.Dock = DockStyle.Fill;
            flpChoises.FlowDirection = FlowDirection.TopDown;
            flpChoises.Location = new Point(0, 434);
            flpChoises.Name = "flpChoises";
            flpChoises.Size = new Size(672, 121);
            flpChoises.TabIndex = 1;
            // 
            // rtbDescription
            // 
            rtbDescription.BackColor = Color.FromArgb(25, 25, 35);
            rtbDescription.BorderStyle = BorderStyle.None;
            rtbDescription.Dock = DockStyle.Top;
            rtbDescription.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rtbDescription.ForeColor = Color.FromArgb(210, 195, 160);
            rtbDescription.Location = new Point(0, 0);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.ReadOnly = true;
            rtbDescription.Size = new Size(672, 434);
            rtbDescription.TabIndex = 0;
            rtbDescription.Text = "";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(35, 35, 45);
            pnlBottom.Controls.Add(btnItemAndContact);
            pnlBottom.Controls.Add(btnJournal);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 702);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1039, 60);
            pnlBottom.TabIndex = 3;
            // 
            // btnItemAndContact
            // 
            btnItemAndContact.BackColor = Color.FromArgb(180, 140, 80);
            btnItemAndContact.FlatStyle = FlatStyle.Flat;
            btnItemAndContact.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnItemAndContact.Location = new Point(533, 16);
            btnItemAndContact.Name = "btnItemAndContact";
            btnItemAndContact.Size = new Size(273, 32);
            btnItemAndContact.TabIndex = 6;
            btnItemAndContact.Text = "ПРЕДМЕТ И КОНТАКТ";
            btnItemAndContact.UseVisualStyleBackColor = false;
            btnItemAndContact.Click += btnUseItem_Click;
            // 
            // btnJournal
            // 
            btnJournal.BackColor = Color.FromArgb(180, 140, 80);
            btnJournal.FlatStyle = FlatStyle.Flat;
            btnJournal.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnJournal.Location = new Point(265, 16);
            btnJournal.Name = "btnJournal";
            btnJournal.Size = new Size(171, 32);
            btnJournal.TabIndex = 5;
            btnJournal.Text = "📓 ЖУРНАЛ УЛИК";
            btnJournal.UseVisualStyleBackColor = false;
            btnJournal.Click += btnJournal_Click;
            // 
            // pbLocation
            // 
            pbLocation.BackColor = Color.Transparent;
            pbLocation.BackgroundImageLayout = ImageLayout.Center;
            pbLocation.BorderStyle = BorderStyle.FixedSingle;
            pbLocation.Location = new Point(0, 439);
            pbLocation.Name = "pbLocation";
            pbLocation.Size = new Size(349, 257);
            pbLocation.SizeMode = PictureBoxSizeMode.Zoom;
            pbLocation.TabIndex = 4;
            pbLocation.TabStop = false;
            // 
            // btnNextLocation
            // 
            btnNextLocation.BackColor = Color.FromArgb(180, 140, 80);
            btnNextLocation.FlatStyle = FlatStyle.Flat;
            btnNextLocation.Font = new Font("Georgia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnNextLocation.Location = new Point(40, 401);
            btnNextLocation.Name = "btnNextLocation";
            btnNextLocation.Size = new Size(287, 32);
            btnNextLocation.TabIndex = 5;
            btnNextLocation.Text = "СЛЕДУЮЩАЯ ЛОКАЦИЯ";
            btnNextLocation.UseVisualStyleBackColor = false;
            btnNextLocation.Click += btnNextLocation_Click_1;
            // 
            // FormGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1039, 762);
            Controls.Add(btnNextLocation);
            Controls.Add(pbLocation);
            Controls.Add(pnlBottom);
            Controls.Add(pnlDescription);
            Controls.Add(pnlLocation);
            Controls.Add(pnlTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Смертельный антракт";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            gbStatus.ResumeLayout(false);
            gbStatus.PerformLayout();
            pnlLocation.ResumeLayout(false);
            pnlLocation.PerformLayout();
            pnlDescription.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLocation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTime;
        private ProgressBar pbTime;
        private ProgressBar pbClues;
        private Label lblClues;
        private Label lblLogic;
        private ProgressBar pbAttention;
        private ProgressBar pbResolve;
        private Label lblAttention;
        private Label lblResolve;
        private ProgressBar pbCharisma;
        private ProgressBar pbLogic;
        private Label lblCharisma;
        private GroupBox gbStatus;
        private Label lblPlayerName;
        private Label lblCharacterTrait;
        private Label lblRole;
        private Panel pnlLocation;
        private ListBox listLocation;
        private Label lblLocation;
        private Panel pnlDescription;
        private RichTextBox rtbDescription;
        private FlowLayoutPanel flpChoises;
        private Panel pnlBottom;
        private Button btnInventory;
        private Button btnContact;
        private Button btnItemAndContact;
        private Button btnJournal;
        private PictureBox pbLocation;
        private Button btnNextLocation;
        private Label lblResolveValue;
        private Label lblCharismaValue;
        private Label lblLogicValue;
        private Label lblAttentionValue;
        private Label lblCluesValue;
    }
}