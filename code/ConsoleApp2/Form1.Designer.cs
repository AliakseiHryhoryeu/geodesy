namespace ConsoleApp2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BoxNumZachetki = new System.Windows.Forms.TextBox();
            this.BoxNumJurnal = new System.Windows.Forms.TextBox();
            this.BoxGroup = new System.Windows.Forms.TextBox();
            this.BoxFUO = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BoxYear = new System.Windows.Forms.TextBox();
            this.тутТипоДолжнаБылаБытьМенюшкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тутТипоДолжнаБылаБытьМенюшкаToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер зачетки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(38, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Номер в журнале";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(38, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Группа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(37, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Фамилия И.О.";
            // 
            // BoxNumZachetki
            // 
            this.BoxNumZachetki.Location = new System.Drawing.Point(210, 44);
            this.BoxNumZachetki.MaxLength = 15;
            this.BoxNumZachetki.Multiline = true;
            this.BoxNumZachetki.Name = "BoxNumZachetki";
            this.BoxNumZachetki.Size = new System.Drawing.Size(136, 20);
            this.BoxNumZachetki.TabIndex = 5;
            this.BoxNumZachetki.TextChanged += new System.EventHandler(this.BoxNumZachetki_TextChanged);
            // 
            // BoxNumJurnal
            // 
            this.BoxNumJurnal.Location = new System.Drawing.Point(210, 79);
            this.BoxNumJurnal.MaxLength = 15;
            this.BoxNumJurnal.Multiline = true;
            this.BoxNumJurnal.Name = "BoxNumJurnal";
            this.BoxNumJurnal.Size = new System.Drawing.Size(136, 20);
            this.BoxNumJurnal.TabIndex = 6;
            this.BoxNumJurnal.TextChanged += new System.EventHandler(this.BoxNumJurnal_TextChanged);
            // 
            // BoxGroup
            // 
            this.BoxGroup.Location = new System.Drawing.Point(210, 114);
            this.BoxGroup.MaxLength = 15;
            this.BoxGroup.Multiline = true;
            this.BoxGroup.Name = "BoxGroup";
            this.BoxGroup.Size = new System.Drawing.Size(136, 20);
            this.BoxGroup.TabIndex = 7;
            this.BoxGroup.TextChanged += new System.EventHandler(this.BoxGroop_TextChanged);
            // 
            // BoxFUO
            // 
            this.BoxFUO.Location = new System.Drawing.Point(210, 150);
            this.BoxFUO.MaxLength = 15;
            this.BoxFUO.Multiline = true;
            this.BoxFUO.Name = "BoxFUO";
            this.BoxFUO.Size = new System.Drawing.Size(136, 20);
            this.BoxFUO.TabIndex = 8;
            this.BoxFUO.TextChanged += new System.EventHandler(this.BoxFUO_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 88);
            this.button1.TabIndex = 9;
            this.button1.Text = "Как все вписал(а) Тыкать клешней вот сюда";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(38, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Какой сейчас год";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "4 цифры";
            // 
            // BoxYear
            // 
            this.BoxYear.Location = new System.Drawing.Point(210, 186);
            this.BoxYear.MaxLength = 15;
            this.BoxYear.Multiline = true;
            this.BoxYear.Name = "BoxYear";
            this.BoxYear.Size = new System.Drawing.Size(136, 20);
            this.BoxYear.TabIndex = 13;
            this.BoxYear.TextChanged += new System.EventHandler(this.BoxYear_TextChanged);
            // 
            // тутТипоДолжнаБылаБытьМенюшкаToolStripMenuItem
            // 
            this.тутТипоДолжнаБылаБытьМенюшкаToolStripMenuItem.Name = "тутТипоДолжнаБылаБытьМенюшкаToolStripMenuItem";
            this.тутТипоДолжнаБылаБытьМенюшкаToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.тутТипоДолжнаБылаБытьМенюшкаToolStripMenuItem.Text = " тут типо должна была быть менюшка";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(515, 233);
            this.Controls.Add(this.BoxYear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BoxFUO);
            this.Controls.Add(this.BoxGroup);
            this.Controls.Add(this.BoxNumJurnal);
            this.Controls.Add(this.BoxNumZachetki);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1 расчетка геодезия";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox BoxNumZachetki;
        public System.Windows.Forms.TextBox BoxNumJurnal;
        public System.Windows.Forms.TextBox BoxGroup;
        public System.Windows.Forms.TextBox BoxFUO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox BoxYear;
        private System.Windows.Forms.ToolStripMenuItem тутТипоДолжнаБылаБытьМенюшкаToolStripMenuItem;
    }
}