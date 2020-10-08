using System;
using System.Windows.Forms;

namespace PasswordPuzzle
{
    public class ConfirmQuestionEventArgs : EventArgs
    {
        public int Id { get; set; }
        public Question Question { get; set; }

        public TextBox txtAnswer { get; set; }
    }
}
