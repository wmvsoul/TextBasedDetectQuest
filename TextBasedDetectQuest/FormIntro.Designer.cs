namespace TextBasedDetectQuest
{
    partial class FormIntro
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIntro));
            lblTextQuest = new Label();
            btnContinue = new Button();
            lblInfo = new Label();
            SuspendLayout();
            // 
            // lblTextQuest
            // 
            lblTextQuest.BackColor = Color.Transparent;
            lblTextQuest.Dock = DockStyle.Top;
            lblTextQuest.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTextQuest.ForeColor = Color.FromArgb(180, 140, 80);
            lblTextQuest.Location = new Point(0, 0);
            lblTextQuest.Name = "lblTextQuest";
            lblTextQuest.Size = new Size(1039, 44);
            lblTextQuest.TabIndex = 0;
            lblTextQuest.Text = "ТЕКСТОВЫЕ ДЕТЕКТИВНЫЕ КВЕСТЫ";
            lblTextQuest.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnContinue
            // 
            btnContinue.BackColor = Color.FromArgb(180, 140, 80);
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnContinue.ForeColor = Color.FromArgb(30, 25, 20);
            btnContinue.Location = new Point(370, 670);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(300, 50);
            btnContinue.TabIndex = 2;
            btnContinue.Text = "ПРОДОЛЖИТЬ →";
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // lblInfo
            // 
            lblInfo.BackColor = Color.Transparent;
            lblInfo.Font = new Font("Georgia", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblInfo.ForeColor = Color.FromArgb(200, 180, 140);
            lblInfo.Location = new Point(30, 130);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(979, 520);
            lblInfo.TabIndex = 1;
            lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // FormIntro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1039, 762);
            Controls.Add(lblInfo);
            Controls.Add(btnContinue);
            Controls.Add(lblTextQuest);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormIntro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Детективный текстовый квест";
            FormClosing += FormInfo_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Label lblTextQuest;
        private Label lblClone1;
        private Button btnContinue;
        private Label lblInfo;
    }
}
