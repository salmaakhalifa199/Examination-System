using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MCQ : QuestionBase
    {
        public MCQ(string body, int mark) : base(body, mark)
        {
        }

        public override void Display()
        {
            Console.WriteLine(this);
            if (AnswerList != null && AnswerList.Length > 0)
            {
                for (int i = 0; i < AnswerList.Length; i++)
                {
                    Console.WriteLine($"{i + 1}- {AnswerList[i].AnswerText}");
                }
            }
            else
            {
                Console.WriteLine("No choices available for this question.");
            }
        }
    }
}
