namespace PasswordPuzzle
{
    public class Question
    {
        public Question(string clue, string pw)
        {
            Clue = clue;
            Password = pw;
        }
        public string Clue { get; set; }
        public string Password { get; set; }
    }
}
