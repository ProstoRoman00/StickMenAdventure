namespace AdventureOfStickMan
{
    partial class Game
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
            this.mainGamePanel = new System.Windows.Forms.Panel();
            this.mapArea = new System.Windows.Forms.Panel();
            this.textLogArea = new System.Windows.Forms.Panel();
            this.loggerTextBox = new System.Windows.Forms.TextBox();
            this.playArea = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.skillArea = new System.Windows.Forms.Panel();
            this.skillButton4 = new System.Windows.Forms.Button();
            this.skillButton1 = new System.Windows.Forms.Button();
            this.skillButton2 = new System.Windows.Forms.Button();
            this.skillButton3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainGamePanel.SuspendLayout();
            this.textLogArea.SuspendLayout();
            this.playArea.SuspendLayout();
            this.skillArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainGamePanel
            // 
            this.mainGamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGamePanel.BackColor = System.Drawing.Color.Red;
            this.mainGamePanel.Controls.Add(this.mapArea);
            this.mainGamePanel.Controls.Add(this.textLogArea);
            this.mainGamePanel.Controls.Add(this.playArea);
            this.mainGamePanel.Location = new System.Drawing.Point(0, 0);
            this.mainGamePanel.Name = "mainGamePanel";
            this.mainGamePanel.Size = new System.Drawing.Size(800, 450);
            this.mainGamePanel.TabIndex = 0;
            // 
            // mapArea
            // 
            this.mapArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mapArea.AutoScroll = true;
            this.mapArea.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.mapArea.Location = new System.Drawing.Point(468, 328);
            this.mapArea.Name = "mapArea";
            this.mapArea.Size = new System.Drawing.Size(332, 122);
            this.mapArea.TabIndex = 6;
            // 
            // textLogArea
            // 
            this.textLogArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textLogArea.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textLogArea.Controls.Add(this.loggerTextBox);
            this.textLogArea.Location = new System.Drawing.Point(0, 328);
            this.textLogArea.Name = "textLogArea";
            this.textLogArea.Size = new System.Drawing.Size(468, 122);
            this.textLogArea.TabIndex = 5;
            // 
            // loggerTextBox
            // 
            this.loggerTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.loggerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerTextBox.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loggerTextBox.Location = new System.Drawing.Point(0, 0);
            this.loggerTextBox.Multiline = true;
            this.loggerTextBox.Name = "loggerTextBox";
            this.loggerTextBox.ReadOnly = true;
            this.loggerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.loggerTextBox.Size = new System.Drawing.Size(468, 122);
            this.loggerTextBox.TabIndex = 0;
            // 
            // playArea
            // 
            this.playArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playArea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.playArea.Controls.Add(this.button2);
            this.playArea.Controls.Add(this.skillArea);
            this.playArea.Controls.Add(this.pictureBox1);
            this.playArea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.playArea.Location = new System.Drawing.Point(0, 0);
            this.playArea.Name = "playArea";
            this.playArea.Size = new System.Drawing.Size(800, 328);
            this.playArea.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(690, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // skillArea
            // 
            this.skillArea.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.skillArea.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.skillArea.Controls.Add(this.skillButton4);
            this.skillArea.Controls.Add(this.skillButton1);
            this.skillArea.Controls.Add(this.skillButton2);
            this.skillArea.Controls.Add(this.skillButton3);
            this.skillArea.Location = new System.Drawing.Point(241, 248);
            this.skillArea.Name = "skillArea";
            this.skillArea.Size = new System.Drawing.Size(316, 80);
            this.skillArea.TabIndex = 1;
            // 
            // skillButton4
            // 
            this.skillButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skillButton4.Location = new System.Drawing.Point(231, 4);
            this.skillButton4.Name = "skillButton4";
            this.skillButton4.Size = new System.Drawing.Size(70, 70);
            this.skillButton4.TabIndex = 3;
            this.skillButton4.UseVisualStyleBackColor = true;
            this.skillButton4.Click += new System.EventHandler(this.skillButton4_Click);
            // 
            // skillButton1
            // 
            this.skillButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skillButton1.Location = new System.Drawing.Point(3, 4);
            this.skillButton1.Name = "skillButton1";
            this.skillButton1.Size = new System.Drawing.Size(70, 70);
            this.skillButton1.TabIndex = 0;
            this.skillButton1.UseVisualStyleBackColor = true;
            this.skillButton1.Click += new System.EventHandler(this.skillButton1_Click);
            // 
            // skillButton2
            // 
            this.skillButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skillButton2.Location = new System.Drawing.Point(79, 4);
            this.skillButton2.Name = "skillButton2";
            this.skillButton2.Size = new System.Drawing.Size(70, 70);
            this.skillButton2.TabIndex = 1;
            this.skillButton2.UseVisualStyleBackColor = true;
            this.skillButton2.Click += new System.EventHandler(this.skillButton2_Click);
            // 
            // skillButton3
            // 
            this.skillButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skillButton3.Location = new System.Drawing.Point(155, 4);
            this.skillButton3.Name = "skillButton3";
            this.skillButton3.Size = new System.Drawing.Size(70, 70);
            this.skillButton3.TabIndex = 2;
            this.skillButton3.UseVisualStyleBackColor = true;
            this.skillButton3.Click += new System.EventHandler(this.skillButton3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AdventureOfStickMan.Properties.Resources.Stick_Figure_Knight;
            this.pictureBox1.Location = new System.Drawing.Point(52, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 194);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainGamePanel);
            this.Name = "Game";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.mainGamePanel.ResumeLayout(false);
            this.textLogArea.ResumeLayout(false);
            this.textLogArea.PerformLayout();
            this.playArea.ResumeLayout(false);
            this.skillArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainGamePanel;
        private System.Windows.Forms.Panel mapArea;
        private System.Windows.Forms.Panel textLogArea;
        private System.Windows.Forms.TextBox loggerTextBox;
        private System.Windows.Forms.Panel playArea;
        private System.Windows.Forms.Panel skillArea;
        private System.Windows.Forms.Button skillButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button skillButton4;
        private System.Windows.Forms.Button skillButton2;
        private System.Windows.Forms.Button skillButton3;
    }
}

