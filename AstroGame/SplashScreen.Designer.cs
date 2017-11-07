namespace AstroGame
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.StartGameBtn = new System.Windows.Forms.Button();
            this.Records = new System.Windows.Forms.Button();
            this.ExitGame = new System.Windows.Forms.Button();
            this.BtrInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartGameBtn
            // 
            this.StartGameBtn.Location = new System.Drawing.Point(60, 12);
            this.StartGameBtn.Name = "StartGameBtn";
            this.StartGameBtn.Size = new System.Drawing.Size(164, 41);
            this.StartGameBtn.TabIndex = 0;
            this.StartGameBtn.Text = "Старт";
            this.StartGameBtn.UseVisualStyleBackColor = true;
            this.StartGameBtn.Click += new System.EventHandler(this.StartGameBtn_Click);
            // 
            // Records
            // 
            this.Records.Location = new System.Drawing.Point(63, 75);
            this.Records.Name = "Records";
            this.Records.Size = new System.Drawing.Size(161, 37);
            this.Records.TabIndex = 1;
            this.Records.Text = "Рекорды";
            this.Records.UseVisualStyleBackColor = true;
            // 
            // ExitGame
            // 
            this.ExitGame.Location = new System.Drawing.Point(66, 191);
            this.ExitGame.Name = "ExitGame";
            this.ExitGame.Size = new System.Drawing.Size(156, 44);
            this.ExitGame.TabIndex = 2;
            this.ExitGame.Text = "Выход";
            this.ExitGame.UseVisualStyleBackColor = true;
            this.ExitGame.Click += new System.EventHandler(this.ExitGame_Click);
            // 
            // BtrInfo
            // 
            this.BtrInfo.Location = new System.Drawing.Point(66, 132);
            this.BtrInfo.Name = "BtrInfo";
            this.BtrInfo.Size = new System.Drawing.Size(154, 36);
            this.BtrInfo.TabIndex = 3;
            this.BtrInfo.Text = "Информация";
            this.BtrInfo.UseVisualStyleBackColor = true;
            this.BtrInfo.Click += new System.EventHandler(this.BtrInfo_Click);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(284, 258);
            this.Controls.Add(this.BtrInfo);
            this.Controls.Add(this.ExitGame);
            this.Controls.Add(this.Records);
            this.Controls.Add(this.StartGameBtn);
            this.Name = "SplashScreen";
            this.Text = "Asteroid";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartGameBtn;
        private System.Windows.Forms.Button Records;
        private System.Windows.Forms.Button ExitGame;
        private System.Windows.Forms.Button BtrInfo;
    }
}