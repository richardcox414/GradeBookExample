using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests.Types
{

    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UpperCaseString()
        {
            string name = "rick";
            name = name.ToUpper();

            Assert.AreEqual("RICK", name);
        }

        [TestMethod]
        public void AddDayToDateTime()
        {
            DateTime date = new DateTime(2017, 1, 1);
            date = date.AddDays(1);
            
            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypePassByValue()
        {
            int x = 46;
            IncremenatNumber(x);

            Assert.AreEqual(46, x);
        }

        private void IncremenatNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A Gradebook", book1.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Rick";
            string name2 = "rick";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            Assert.AreEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        { 
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Rick's Grade Book";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
