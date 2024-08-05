using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(10, "C#");
            subject.CreateExam();
            Console.Clear();
         
            Console.WriteLine("Do You Want To Start The Exam (y | n):");
            string startExam = Console.ReadLine();
            if (startExam.Trim().ToLower() == "y")
            {
                subject.Exam.StartExam();
            }
            else
            {
                Console.WriteLine("Exam not started.");
            }

        
        }

    }
    
}
