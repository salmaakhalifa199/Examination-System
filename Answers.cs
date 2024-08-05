using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Answers : ICloneable
    {
       
        public int AnswerId { get; set; }
        public string AnswerText { get; set; } 
        public Answers(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public object Clone()
        {
            return new Answers(AnswerId, AnswerText);
        }

        public override string ToString()
        {
            return AnswerText;
        }
    }
}
