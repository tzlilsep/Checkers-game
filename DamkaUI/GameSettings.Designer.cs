namespace DamkaUI
{
    partial class GameSettings
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
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.radioButtonSize6 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize8 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize10 = new System.Windows.Forms.RadioButton();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(20, 18);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(76, 16);
            this.labelBoardSize.TabIndex = 0;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // radioButtonSize6
            // 
            this.radioButtonSize6.AutoSize = true;
            this.radioButtonSize6.Location = new System.Drawing.Point(42, 44);
            this.radioButtonSize6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSize6.Name = "radioButtonSize6";
            this.radioButtonSize6.Size = new System.Drawing.Size(54, 20);
            this.radioButtonSize6.TabIndex = 1;
            this.radioButtonSize6.TabStop = true;
            this.radioButtonSize6.Text = "6 x 6";
            this.radioButtonSize6.UseVisualStyleBackColor = true;
            // 
            // radioButtonSize8
            // 
            this.radioButtonSize8.AutoSize = true;
            this.radioButtonSize8.Location = new System.Drawing.Point(136, 44);
            this.radioButtonSize8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSize8.Name = "radioButtonSize8";
            this.radioButtonSize8.Size = new System.Drawing.Size(54, 20);
            this.radioButtonSize8.TabIndex = 7;
            this.radioButtonSize8.TabStop = true;
            this.radioButtonSize8.Text = "8 x 8";
            this.radioButtonSize8.UseVisualStyleBackColor = true;
            // 
            // radioButtonSize10
            // 
            this.radioButtonSize10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSize10.AutoSize = true;
            this.radioButtonSize10.Location = new System.Drawing.Point(243, 44);
            this.radioButtonSize10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSize10.Name = "radioButtonSize10";
            this.radioButtonSize10.Size = new System.Drawing.Size(68, 20);
            this.radioButtonSize10.TabIndex = 8;
            this.radioButtonSize10.TabStop = true;
            this.radioButtonSize10.Text = "10 x 10";
            this.radioButtonSize10.UseVisualStyleBackColor = true;
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayer1.Location = new System.Drawing.Point(154, 118);
            this.textBoxPlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(157, 22);
            this.textBoxPlayer1.TabIndex = 3;
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(154, 153);
            this.textBoxPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(157, 22);
            this.textBoxPlayer2.TabIndex = 4;
            this.textBoxPlayer2.Text = "[Computer]";
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(20, 82);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(56, 16);
            this.labelPlayers.TabIndex = 5;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(38, 118);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(59, 16);
            this.labelPlayer1.TabIndex = 6;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(42, 153);
            this.checkBoxPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(81, 20);
            this.checkBoxPlayer2.TabIndex = 2;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDone.Location = new System.Drawing.Point(244, 194);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(67, 26);
            this.buttonDone.TabIndex = 9;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 234);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.radioButtonSize10);
            this.Controls.Add(this.radioButtonSize8);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.radioButtonSize6);
            this.Controls.Add(this.labelBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.RadioButton radioButtonSize6;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.RadioButton radioButtonSize8;
        private System.Windows.Forms.RadioButton radioButtonSize10;
        private System.Windows.Forms.Button buttonDone;
    }
}