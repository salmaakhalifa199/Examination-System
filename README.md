Examination System
📌 Tech Stack: C#, OOP Principles

Developed a console-based Examination System that simulates both Final and Practical exams with multiple question types and exam behaviors.

🔹 Key Features:
Implemented an object-oriented exam structure with inheritance and polymorphism.

Created a base Question class with shared properties (header, body, mark), and extended it into:

True/False and MCQ for Final Exams

MCQ only for Practical Exams

Linked each question with a list of Answer objects (ID, text) and a correct answer.

Developed a base Exam class for shared exam attributes (time, question count) with overridden ShowExam() for Final vs. Practical behavior.

Associated each exam with a Subject class (Subject ID, name, and its exam).

Final Exam displays the full exam with grading; Practical Exam reveals correct answers after submission.

Used constructor chaining, implemented ICloneable and IComparable, and overridden ToString() for better output formatting.
