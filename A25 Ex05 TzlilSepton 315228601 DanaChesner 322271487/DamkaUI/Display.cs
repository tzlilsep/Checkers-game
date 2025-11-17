using System.Windows.Forms;

namespace DamkaUI
{
    public static class Display
    {
        public static void ShowErrorMessageDialog(string i_Message)
        {
            MessageBox.Show(
                $"{i_Message} Please try again.",
                "Damka",
                MessageBoxButtons.OK,               
                MessageBoxIcon.Error
            );
        }

        public static DialogResult ShowUserQuitDialog()
        {
            DialogResult result = MessageBox.Show(
                $"This round has finished. Do you wish to quit it and start a new round?",
                "Damka",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            return result;
        }

        public static DialogResult ShowRoundOverDialog(string i_Message)
        {
            DialogResult result = MessageBox.Show(
                $"{i_Message}\nAnother Round?",
                "Damka",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            return result;
        }
    }
}