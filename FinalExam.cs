using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam : Exam
    {
        public FinalExam(TimeSpan timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }

        public override void StartExam()
        {
            Console.WriteLine(this);
            Console.WriteLine("Final Exam:");
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
            Console.WriteLine("Final Exam Results:");
            int totalMarks = Questions.Sum(q => q.Mark);
            int obtainedMarks = Questions.Sum(q => UserAnswers.ContainsKey(q) && UserAnswers[q].AnswerId == q.RightAnswer.AnswerId ? q.Mark : 0);

            foreach (var question in Questions)
            {
                Console.WriteLine($"Question:{question.Body} => You selected: {UserAnswers[question]?.AnswerText}  -The Right Answer : {question.RightAnswer.AnswerText}");
            }

            Console.WriteLine($"Your exam grade is {obtainedMarks} out of {totalMarks}");
            Console.WriteLine($"Elapsed Time: {Timer.Elapsed}");
        }

    }
}

