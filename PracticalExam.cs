using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(TimeSpan timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }
        public override void StartExam()
        {
            Console.WriteLine(this);
            Console.WriteLine("Practical Exam:");
            Timer.Start();
            Console.WriteLine("Exam started. Answer the following questions:\n");

            foreach (var question in Questions)
            {
                question.Display();
                Console.WriteLine("Choose the number corresponding to your answer:");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > question.AnswerList.Length)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }

                Console.WriteLine($"You Selected : {UserAnswers[question] = question.AnswerList.First(a => a.AnswerId == choice)}\n");
            }

            Timer.Stop();
            ShowExam();
        }
        protected override void ShowExam()
        {
            Console.WriteLine("The Right Answers Of The Exam :");
            foreach (var question in Questions)
            {
                Console.WriteLine($"-The Right Answer of Question({NumberOfQuestions}) : {question.RightAnswer.AnswerText}");
            }
        }
    }
}
