using System;
using ContactBook.Core.Models;
using ContactBook.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactBook.Test
{
    [TestClass]
    public class TestValidation
    {
        [TestMethod]
        public void TestValidateContact()
        {
            var contactEmptyName = new Contacts() { Name = ""};
            var contactNullName = new Contacts() { Name = null };
            Contacts contactNull = null;
            var contactsCorrect = new Contacts() { Name = "John" };

            Assert.IsFalse(Utils.ValidateContact(contactEmptyName));
            Assert.IsFalse(Utils.ValidateContact(contactNullName));
            Assert.IsFalse(Utils.ValidateContact(contactNull));
            Assert.IsTrue(Utils.ValidateContact(contactsCorrect));

        }

        [TestMethod]
        public void TestValidateEmail()
        {
            var emailCorrect = "test@test.lv";
            var emailBad1 = "test@lv";
            var emailBad2 = "tests";
            string emailNull = null;
            var emailEmpty = "";

            Assert.IsTrue(Utils.ValidateEmail(emailCorrect));
            Assert.IsFalse(Utils.ValidateEmail(emailEmpty));
            Assert.IsFalse(Utils.ValidateEmail(emailNull));
            Assert.IsFalse(Utils.ValidateEmail(emailBad1));
            Assert.IsFalse(Utils.ValidateEmail(emailBad2));

        }
    }
}
