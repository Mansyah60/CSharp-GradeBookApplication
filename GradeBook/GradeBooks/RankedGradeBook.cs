using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");

            // Position per 20% of the students for determining the threshold pe Rank.
            var threshold = Convert.ToInt32(Math.Ceiling((Students.Count * 0.2)));

            // Select parameter AverageGrade from the list of Student in ascending order
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            // The poisition of last 20% of the Students
            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            // The position of the last 40% of the Students
            else if (grades[threshold * 2 - 1] <= averageGrade)
                return 'B';
            // The position of the last 60% of the Students
            else if (grades[threshold * 3 - 1] <= averageGrade)
                return 'C';
            // The position of the last 80% of the Students
            else if (grades[threshold * 4 - 1] <= averageGrade)
                return 'D';
            else 
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students in order to properly calculate a student's overall grade");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students in order to properly calculate a student's overall grade");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
