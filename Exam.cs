using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public abstract class Exam
    {
        public TimeSpan TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<QuestionBase> Questions { get; set; } 
        protected Stopwatch Timer { get; set; } = new Stopwatch();
        protected Dictionary<QuestionBase, Answers> UserAnswers { get; set; } = new Dictionary<QuestionBase, Answers>();
        protected Exam(TimeSpan timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<QuestionBase>();
        }
        public abstract void StartExam();
        protected abstract void ShowExam();
        public override string ToString()
        {
            return $"Time of Exam: {TimeOfExam}\nNumber of Questions: {NumberOfQuestions}";
        }
    }
}
