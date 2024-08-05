using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examination_System
{
    #region 
    //    public enum ExamType
    //    {
    //        Practical=1,
    //        Final = 2
    //    }

    //    public enum QuestionType
    //    {
    //        TrueFalse = 1,
    //        MultipleChoice = 2
    //    }

    //    public class Subject
    //    {
    //        public int SubjectId { get; set; }
    //        public string SubjectName { get; set; }
    //        public Exam Exam { get; set; } 
    //        public Subject(int subjectId, string subjectName)
    //        {
    //            SubjectId = subjectId;
    //            SubjectName = subjectName;
    //        }

    //        public void CreateExam()
    //        {


    //            int examType;
    //            while (true)
    //            {
    //                try
    //                {
    //                    Console.WriteLine("Please enter the type of exam you want to create (1 for Practical and 2 for Final):");
    //                    if (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2))
    //                    {
    //                        throw new ValidationException("Invalid input. Please enter 1 for Practical or 2 for Final.");
    //                    }
    //                    break;

    //                }
    //                catch (ValidationException ex)
    //                {
    //                    Console.WriteLine(ex.Message);
    //                }

    //            }   


    //            TimeSpan timeOfExam;
    //            while (true)
    //            {
    //                try
    //                {
    //                    Console.WriteLine("Please enter the Time of the exam in minutes:");
    //                    if (!int.TryParse(Console.ReadLine(), out int timeInMinutes) || timeInMinutes <= 0)
    //                    {
    //                        throw new ArgumentException("An error occurred: Please enter a valid time.");
    //                    }
    //                    timeOfExam = TimeSpan.FromMinutes(timeInMinutes);
    //                    break;
    //                }
    //                catch (ArgumentException ex)
    //                {
    //                    Console.WriteLine(ex.Message);
    //                }
    //            }
    //            Console.WriteLine($"Time of Exam: {timeOfExam}");


    //            int numberOfQuestions;
    //            while (true)
    //            {
    //                try
    //                {
    //                    Console.WriteLine("Please enter the number of questions you wanted to create:");
    //                    if (!int.TryParse(Console.ReadLine(), out  numberOfQuestions) || numberOfQuestions <= 0)
    //                    {
    //                        throw new ArgumentException("Invalid input. Please enter a valid number.");
    //                    }
    //                    break;
    //                }
    //                catch (ArgumentException ex)
    //                {
    //                    Console.WriteLine(ex.Message);
    //                }
    //            }
    //            Console.WriteLine($"Number of Questions: {numberOfQuestions}");


    //            Exam? exam;
    //            if (examType == 1)
    //            {
    //                exam = new PracticalExam(timeOfExam, numberOfQuestions);
    //            }
    //            else if (examType == 2)
    //            {
    //                exam = new FinalExam(timeOfExam, numberOfQuestions);
    //            }
    //            else
    //            {
    //                throw new ArgumentException("Invalid exam type.");
    //            }


    //            for (int i = 1; i <= numberOfQuestions; i++)
    //            {
    //                int questionType;

    //                if (examType == 1)
    //                {
    //                    questionType = 2; 
    //                }
    //                else
    //                {
    //                    while (true)
    //                    {
    //                        Console.WriteLine($"Please choose the type of question number {i} (1 for True or False, 2 for MCQ):");
    //                        if (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2))
    //                        {
    //                            Console.WriteLine("Invalid input. Please enter 1 for True or False or 2 for MCQ.");
    //                        }
    //                        else
    //                        {
    //                            break;
    //                        }
    //                    }
    //                }

    //                Console.WriteLine($"Please enter the body of question number {i }:");
    //                string body = Console.ReadLine();

    //                int marks;
    //                while (true)
    //                {
    //                    try
    //                    {
    //                        Console.WriteLine($"Please enter the marks for question number {i}:");
    //                        if (!int.TryParse(Console.ReadLine(), out marks) || marks <= 0)
    //                        {
    //                            throw new ArgumentException("Invalid input. Please enter a valid number.");
    //                        }
    //                        break;
    //                    }
    //                    catch (ArgumentException ex)
    //                    {
    //                        Console.WriteLine(ex.Message);
    //                    }
    //                }

    //                QuestionBase question = null;
    //                int rightAnswerId;
    //                List<Answers> answers = new List<Answers>();

    //                if (questionType == 1) 
    //                {
    //                    question = new TFQuestion(body, marks);
    //                    answers.Add(new Answers(1, "True"));
    //                    answers.Add(new Answers(2, "False"));

    //                    Console.WriteLine("Please specify the right choice of question (1 for true and 2 for false):");
    //                    if (!int.TryParse(Console.ReadLine(), out  rightAnswerId) || rightAnswerId < 1 || rightAnswerId > 2)
    //                    {
    //                        Console.WriteLine("Invalid right answer choice.");
    //                        return;
    //                    }
    //                    question.AnswerList = answers.ToArray();
    //                    question.RightAnswer = answers.Find(a => a.AnswerId == rightAnswerId);
    //                    if (question.RightAnswer == null)
    //                    {
    //                        Console.WriteLine("The specified right answer choice does not exist.");
    //                        return;
    //                    }
    //                }
    //                else if (questionType == 2)
    //                {
    //                    question = new MCQ(body, marks);
    //                    Console.WriteLine($"Please enter the choices for question number {i}:");
    //                    for (int j = 0; j < 3; j++)
    //                    {
    //                        Console.WriteLine($"Please enter choice number {j + 1}:");
    //                        string choice = Console.ReadLine();
    //                        answers.Add(new Answers(j + 1, choice));
    //                    }
    //                    question.AnswerList = answers.ToArray();

    //                    Console.WriteLine("Please specify the right choice of question (enter the choice number):");
    //                    if (!int.TryParse(Console.ReadLine(), out rightAnswerId) || rightAnswerId < 1 || rightAnswerId > answers.Count)
    //                    {
    //                        Console.WriteLine("Invalid right answer choice.");
    //                        return;
    //                    }
    //                    question.RightAnswer = answers.First(a => a.AnswerId == rightAnswerId);
    //                }

    //                exam.Questions.Add(question);
    //            }

    //            Exam = exam;
    //        }
    #endregion

    public enum ExamType
    {
        Practical = 1,
        Final = 2
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            ExamType examType = GetExamType();
            TimeSpan timeOfExam = GetExamDuration();
            int numberOfQuestions = GetNumberOfQuestions();

            Exam exam = PrepareExam(examType, timeOfExam, numberOfQuestions);
            AddQuestionsToExam(exam, examType, numberOfQuestions);

            Exam = exam;
        }

        private static ExamType GetExamType()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the type of exam you want to create (1 for Practical and 2 for Final):");
                    if (Enum.TryParse(Console.ReadLine(), out ExamType examType) && Enum.IsDefined(typeof(ExamType), examType))
                    {
                        return examType;
                    }
                    throw new ValidationException("Invalid input. Please enter 1 for Practical or 2 for Final.");
                }
                catch (ValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static TimeSpan GetExamDuration()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the Time of the exam in minutes:");
                    if (int.TryParse(Console.ReadLine(), out int timeInMinutes) && timeInMinutes > 0)
                    {
                       return TimeSpan.FromMinutes(timeInMinutes);
                    }
                    throw new ArgumentException("Invalid input. Please enter a valid time.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static int GetNumberOfQuestions()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the number of questions you wanted to create:");
                    if (int.TryParse(Console.ReadLine(), out int numberOfQuestions) && numberOfQuestions > 0)
                    {
                        return numberOfQuestions;
                    }
                    throw new ArgumentException("Invalid input. Please enter a valid number.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static Exam PrepareExam(ExamType examType, TimeSpan timeOfExam, int numberOfQuestions)
        {
            return examType switch
            {
                ExamType.Practical => new PracticalExam(timeOfExam, numberOfQuestions),
                ExamType.Final => new FinalExam(timeOfExam, numberOfQuestions),
                _ => throw new ArgumentException("Invalid exam type.")
            };
        }

        public static void AddQuestionsToExam(Exam exam, ExamType examType, int numberOfQuestions)
        {
            for (int i = 1; i <= numberOfQuestions; i++)
            {
                QuestionType questionType = QuestionBase.GetQuestionType(examType, i);
                string questionBody = QuestionBase.GetQuestionBody(i);
                int questionMarks = QuestionBase.GetQuestionMarks(i);
                List<Answers> answers = QuestionBase.GetQuestionAnswers(questionType, i);
                Answers correctAnswer = QuestionBase.GetCorrectAnswer(questionType,answers);

                QuestionBase question = QuestionBase.CreateQuestion(questionType, questionBody, questionMarks, answers, correctAnswer);
                exam.Questions.Add(question);
            }
        }

     

    }
}
