using System.Collections.Generic;

namespace PasswordPuzzle
{
    public class Properties
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Congrats { get; set; }
        public List<Question> Questions { get; set; }

        public void Initialise()
        {
            Title = "Bday gifts giveaway!";
            Subtitle = "You have to decode the clues and get the passwords to move to the next gift :)";
            Congrats = "Congratumalations \nyou got everything you greedy beach";
            var questions = new List<Question>()
            {
                new Question("Your work gear is putting a lot of pressure on me", ""),
                new Question("You don't have chairs in the kitchen, perhaps you should use one there", ""),
                new Question("What sound does the animal VACA do?", ""),
                new Question("Where all the toots get together", ""),
                new Question("lalala", ""),
                new Question("lalala", ""),
                new Question("lalala", ""),
            };

            Questions = questions;
        }
    }
}
