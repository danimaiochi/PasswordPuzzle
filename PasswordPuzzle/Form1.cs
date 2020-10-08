using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PasswordPuzzle
{
    public partial class Form1 : Form
    {
        private int rowId = 0;
        private Random rnd = new Random();


        private int NumberOfQuestions => _questions.Count;
        private List<Question> _questions;
        public Form1()
        {
            InitializeComponent();
            var props = File.ReadAllText("properties.json");
            var properties = JsonConvert.DeserializeObject<Properties>(props);
            lblTitle.Text = properties.Title;
            lblSubtitle.Text = properties.Subtitle;
            lblCongrats.Text = properties.Congrats;
            _questions = properties.Questions;

            if (_questions.Count > 0)
            {
                InitialiseQuestions();
            }
        }

        private void InitialiseQuestions()
        {
            AddNewRow(_questions[0]);
        }

        private void AddNewRow(Question question)
        {

            var confirmQuestionEventArgs = new ConfirmQuestionEventArgs();
            confirmQuestionEventArgs.Id = rowId;
            confirmQuestionEventArgs.Question = question;

            var yLocation = (rowId+1) * 60;

            var label = new Label();
            label.Name = $"lbl_{rowId}";
            label.Text = question.Clue;
            label.Width = 500;
            label.Height = 60;
            label.Location = new Point(10, yLocation);
            label.Font = new Font("Ink Free", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.ForeColor = GetRandomColour();
            groupBox.Controls.Add(label);

            var textBox = new TextBox();
            textBox.Name = $"txt_{rowId}";
            textBox.Text = "";
            textBox.Location = new Point(label.Location.X + label.Width + 10, yLocation);
            textBox.Size = new Size(100, 50);
            textBox.Font = new Font("Ink Free", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox.ForeColor = GetRandomColour();
            textBox.Focus();

            groupBox.Controls.Add(textBox);
            confirmQuestionEventArgs.txtAnswer = textBox;

            var btn = new Button();
            btn.Name = $"btn_{rowId}";
            btn.Text = "Confirm";
            btn.Location = new Point(textBox.Location.X + textBox.Width + 30, yLocation);
            btn.Size = new Size(100, 50);
            btn.BackColor = GetRandomColour();
            btn.ForeColor = GetRandomColour();
            btn.Click += (sender, EventArgs) => { CheckAnswer(sender, confirmQuestionEventArgs); };
            groupBox.Controls.Add(btn);
        }

        private void CheckAnswer(object? sender, ConfirmQuestionEventArgs confirmQuestionEventArgs)
        {
            if (confirmQuestionEventArgs.Question.Password == confirmQuestionEventArgs.txtAnswer.Text)
            {
                if (NumberOfQuestions > confirmQuestionEventArgs.Id+1)
                {
                    rowId++;
                    AddNewRow(_questions[confirmQuestionEventArgs.Id + 1]);
                }
                else
                {
                    lblCongrats.Visible = true;
                }

                DeactivateRow(confirmQuestionEventArgs.Id);
            }
        }

        private void DeactivateRow(int id)
        {
            groupBox.Controls[$"btn_{id}"].Enabled = false;
            groupBox.Controls[$"txt_{id}"].Enabled = false;
        }

        private Color GetRandomColour()
        {
            return Color.FromArgb(rnd.Next(200), rnd.Next(200), rnd.Next(200));
        }
    }
}
