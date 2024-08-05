using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
     public enum QuestionType
     {
        TrueFalse = 1,
        MultipleChoice = 2
     }
    public abstract class QuestionBase : ICloneable, IComparable<QuestionBase>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answers[] AnswerList { get; set; }= Array.Empty<Answers>();
        public Answers RightAnswer { get; set; }

        protected QuestionBase(string body, int marks)
        {
            Header = "Question Header"; 
            Body = body;
            Mark = marks;
        }

        public abstract void Display();
        public object Clone()
        {
            var clonedQuestion = (QuestionBase)this.MemberwiseClone();
            clonedQuestion.AnswerList = (Answers[])this.AnswerList.Clone();
            clonedQuestion.RightAnswer = (Answers)this.RightAnswer.Clone();
            return clonedQuestion;

        }
        public override string ToString()
        {
            return $"Question:{Body} (Mark:{Mark})";
        }
        public int CompareTo(QuestionBase? other)
        {
            if (other == null) return 1;
            return this.Mark.CompareTo(other.Mark);
        }


        public static QuestionType GetQuestionType(ExamType examType, int questionNumber)
        {
            if (examType == ExamType.Practical)
            {
                return QuestionType.MultipleChoice;
            }
            else
            {
                while (true)
                {
                    Console.WriteLine($"Please choose the type of question number {questionNumber} (1 for True or False, 2 for MCQ):");
                    if (Enum.TryParse(Console.ReadLine(), out QuestionType questionType) && Enum.IsDefined(typeof(QuestionType), questionType))
                    {
                        return questionType;
                    }
                    Console.WriteLine("Invalid input. Please enter 1 for True or False or 2 for MCQ.");
                }
            }
        }

        public static string GetQuestionBody(int questionNumber)
        {
            Console.WriteLine($"Please enter the body of question number {questionNumber}:");
            return Console.ReadLine();
        }

        public static int GetQuestionMarks(int questionNumber)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Please enter the marks for question number {questionNumber}:");
                    if (int.TryParse(Console.ReadLine(), out int marks) && marks > 0)
                    {
                        return marks;
                    }
                    throw new ArgumentException("Invalid input. Please enter a valid mark.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static List<Answers> GetQuestionAnswers(QuestionType questionType, int questionNumber)
        {
            List<Answers> answers = new List<Answers>();
            if (questionType == QuestionType.TrueFalse)
            {
                answers.Add(new Answers(1, "True"));
                answers.Add(new Answers(2, "False")); 
            }
            else
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.WriteLine($"Please enter choice number {j} for question number {questionNumber}:");
                    answers.Add(new Answers(j, Console.ReadLine()));
                }
            }
            return answers;
        }

        public static Answers GetCorrectAnswer(QuestionType questionType, List<Answers> answers)
        {
            while (true)
            {
                if (questionType == QuestionType.TrueFalse)
                {
                    Console.WriteLine("Please specify the right choice of the question (1 for True, 2 for False):");
                }
                else
                {
                    Console.WriteLine("Please specify the right choice of the question (enter the choice number):");
                }
                if (int.TryParse(Console.ReadLine(), out int rightAnswerId) && answers.Exists(a => a.AnswerId == rightAnswerId))
                {
                    return answers.First(a => a.AnswerId == rightAnswerId);
                }
                Console.WriteLine("Invalid right answer choice.");
            }
        }

        public static QuestionBase CreateQuestion(QuestionType questionType, string body, int marks, List<Answers> answers, Answers rightAnswer)
        {
            return questionType switch
            {
                QuestionType.TrueFalse => new TFQuestion(body, marks) { AnswerList = answers.ToArray(), RightAnswer = rightAnswer },
                QuestionType.MultipleChoice => new MCQ(body, marks) { AnswerList = answers.ToArray(), RightAnswer = rightAnswer },
                _ => throw new ArgumentException("Invalid question type.")
            };
        }
       
    }
}
