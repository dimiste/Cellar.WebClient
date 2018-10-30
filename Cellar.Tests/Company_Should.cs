using Cellar.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Tests
{
    [TestFixture]
    public class Company_Should
    {
        [Test]
        public void ReturnValuesPropertiesCorrect_WhenSetPropertiesAreCorrect()
        {
            // Arrange
            var company = new Company();
            var name = "Name";
            var number = "123";
            var commercial = "Commercial";

            // Act
            company.Id = 1;
            company.Name = name;
            company.Number = number;
            company.Commercial = commercial;

            var expectedId = 1;
            var expectedName = name;
            var expectedNumber = number;
            var expectedCommercial = commercial;

            // Assert
            Assert.AreEqual(expectedId, company.Id);
            Assert.AreEqual(expectedName, company.Name);
            Assert.AreEqual(expectedNumber, company.Number);
            Assert.AreEqual(expectedCommercial, company.Commercial);
        }
    }
}
