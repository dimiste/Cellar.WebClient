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
            var id = 1;
            var name = "Name";
            var number = "123";
            var commercial = "Commercial";
            var idUser = "idUser";

            // Act
            company.Id = id;
            company.Name = name;
            company.Number = number;
            company.Commercial = commercial;
            company.IdUser = idUser;

            var expectedId = id;
            var expectedName = name;
            var expectedNumber = number;
            var expectedCommercial = commercial;
            var expectedIdUser = idUser;

            // Assert
            Assert.AreEqual(expectedId, company.Id);
            Assert.AreEqual(expectedName, company.Name);
            Assert.AreEqual(expectedNumber, company.Number);
            Assert.AreEqual(expectedCommercial, company.Commercial);
            Assert.AreEqual(expectedIdUser, company.IdUser);
        }
    }
}
