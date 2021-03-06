using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        //default constructor - no return type
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();    
        }


        // GradeStats is returning Compute stats
        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            stats.HighestGrade = 0;

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            // be mindfull of 0 count - can cause an error
            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public void WriteGrades(TextWriter destination)
        {
            Console.WriteLine("All Grades:");
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);   
        }

        public string Name
        {
            get { return _name; }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (_name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = _name;

                        NameChanged(this, args);
                    }
                    _name = value;
                }
            }
        }

        public event NameChangedDelegate NameChanged;

        private string _name;
        protected List<float> grades;
    }
}
