using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DamkaUI
{
    partial class DamkaForm
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
            this.labelsPlayers.Add(new System.Windows.Forms.Label());
            this.labelsPlayers.Add(new System.Windows.Forms.Label());
            this.labelsPlayersTotalScore.Add(new System.Windows.Forms.Label());
            this.labelsPlayersTotalScore.Add(new System.Windows.Forms.Label());
            this.SuspendLayout();
            // 
            // m_LabelPlayer1
            // 
            this.labelsPlayers[0].AutoSize = true;
            this.labelsPlayers[0].Location = new System.Drawing.Point(r_BoardSize * k_CellSize / 4, 20);
            this.labelsPlayers[0].Name = "labelPlayer1";
            this.labelsPlayers[0].Size = new System.Drawing.Size(65, 20);
            this.labelsPlayers[0].TabIndex = 0;
            this.labelsPlayers[0].Text = m_Game.Players[0].Name + ":";
            int player1TextWidth = TextRenderer.MeasureText(labelsPlayers[0].Text, labelsPlayers[0].Font).Width;
            // 
            // m_LabelPlayer2
            // 
            this.labelsPlayers[1].AutoSize = true;
            this.labelsPlayers[1].Location = new System.Drawing.Point(r_BoardSize * k_CellSize / 2 + labelsPlayers[0].Location.X, 20);
            this.labelsPlayers[1].Name = "labelPlayer2";
            this.labelsPlayers[1].Size = new System.Drawing.Size(65, 20);
            this.labelsPlayers[1].TabIndex = 1;
            this.labelsPlayers[1].Text = m_Game.Players[1].Name + ":";
            this.labelsPlayers[1].Click += new System.EventHandler(this.labelPlayer2_Click);
            int player2TextWidth = TextRenderer.MeasureText(labelsPlayers[1].Text, labelsPlayers[1].Font).Width;
            // 
            // m_LabelPlayer1Score
            // 
            this.labelsPlayersTotalScore[0].AutoSize = true;
            this.labelsPlayersTotalScore[0].Location = new System.Drawing.Point(labelsPlayers[0].Location.X + player1TextWidth, 20);
            this.labelsPlayersTotalScore[0].Name = "labelPlayer1TotalScore";
            this.labelsPlayersTotalScore[0].Size = new System.Drawing.Size(18, 20);
            this.labelsPlayersTotalScore[0].TabIndex = 2;
            this.labelsPlayersTotalScore[0].Text = m_Game.Players[0].TotalScore.ToString();
            // 
            // m_LabelPlayer2Score
            // 
            this.labelsPlayersTotalScore[1].AutoSize = true;
            this.labelsPlayersTotalScore[1].Location = new System.Drawing.Point(labelsPlayers[1].Location.X + player2TextWidth, 20);
            this.labelsPlayersTotalScore[1].Name = "labelPlayer2TotalScore";
            this.labelsPlayersTotalScore[1].Size = new System.Drawing.Size(18, 20);
            this.labelsPlayersTotalScore[1].TabIndex = 3;
            this.labelsPlayersTotalScore[1].Text = m_Game.Players[1].TotalScore.ToString();
            // 
            // Damka
            // 
            this.ClientSize = new System.Drawing.Size(r_BoardSize * 60, r_BoardSize * 65);
            this.Controls.Add(this.labelsPlayersTotalScore[0]);
            this.Controls.Add(this.labelsPlayersTotalScore[1]);
            this.Controls.Add(this.labelsPlayers[0]);
            this.Controls.Add(this.labelsPlayers[1]);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Damka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Icon = SystemIcons.WinLogo;
            this.ShowIcon = true;
            this.Text = "Damka";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private List<Label> labelsPlayers = new List<Label>();
        private List<Label> labelsPlayersTotalScore = new List<Label>();
        private Button[,] m_BoardButtons;
        private const int k_CellSize = 50;
    }
}