using System;
using System.Windows.Forms;

namespace DamkaUI
{
    public partial class GameSettings : Form
    {
        private int m_BoardSize;
        private string m_Player1Name;
        private string m_Player2Name;
        private bool m_IsPlayer2Computer;
        private bool m_ClosedByDone = false;

        public GameSettings()
        {
            InitializeComponent();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlayer2.Enabled = checkBoxPlayer2.Checked;
            textBoxPlayer2.Text = !checkBoxPlayer2.Checked ? "[Computer]" : "";
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (radioButtonSize6.Checked)
            {
                m_BoardSize = 6;
            }
            else if (radioButtonSize8.Checked)
            {
                m_BoardSize = 8;
            }
            else if (radioButtonSize10.Checked)
            {
                m_BoardSize = 10;
            }

            m_Player1Name = textBoxPlayer1.Text;
            m_Player2Name = checkBoxPlayer2.Checked ? textBoxPlayer2.Text : "Computer";
            m_IsPlayer2Computer = !checkBoxPlayer2.Checked;
            m_ClosedByDone = true;
            Close();
        }

        public int BoardSize
        {
            get 
            { 
                return m_BoardSize;
            }
        }

        public string Player1Name
        {
            get
            {
                return m_Player1Name;
            }
        }

        public string Player2Name
        {
            get
            {
                return m_Player2Name;
            }
        }

        public bool IsPlayer2Computer
        {
            get
            {
                return m_IsPlayer2Computer; 
            }
        }

        public bool ClosedByDone
        {
            get
            {
                return m_ClosedByDone;
            }
        }
    }
}
