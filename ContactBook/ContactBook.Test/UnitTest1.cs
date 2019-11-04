using System;
using System.Net;
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
            var emailEmpty = new Emails
            {
                Contact = new Contacts()
                {
                    Id = 1,
                    Name = "test",
                },
                Email = ""
            };
            Emails emailNull = null;

            var emailNoContact = new Emails
            {
                Email = "legit@email.com"
            };

            var emailValid = new Emails
            {
                Contact = new Contacts()
                {
                    Id = 1,
                    Name = "test",
                },
                Email = "kinda.legit@email.com"
            };

            var emailNotValid1 = new Emails
            {
                Contact = new Contacts()
                {
                    Id = 1,
                    Name = "test",
                },
                Email = "notlegitemail.com"
            };

            var emailNotValid2 = new Emails
            {
                Contact = new Contacts()
                {
                    Id = 1,
                    Name = "test",
                },
                Email = "notlegitemail@com"
            };

            var emailNotValid3 = new Emails
            {
                Contact = new Contacts()
                {
                    Id = 1,
                    Name = "test",
                },
                Email = "notlegitemailcom"
            };

            Assert.IsFalse(Utils.ValidateEmail(emailEmpty));
            Assert.IsFalse(Utils.ValidateEmail(emailNull));
            Assert.IsFalse(Utils.ValidateEmail(emailNoContact));
            Assert.IsFalse(Utils.ValidateEmail(emailNotValid1));
            Assert.IsFalse(Utils.ValidateEmail(emailNotValid2));
            Assert.IsFalse(Utils.ValidateEmail(emailNotValid3));
            Assert.IsTrue(Utils.ValidateEmail(emailValid));

        }

        [TestMethod]
        public void TestValidatePhoneNumber()
        {

            var phoneValid1 = new PhoneNumbers()
            {
                Contact = new Contacts()
                {
                    Id = 1
                },
                PhoneNumber = "29374039"
            };

            var phoneValid2 = new PhoneNumbers()
            {
                Contact = new Contacts()
                {
                    Id = 1
                },
                PhoneNumber = "+371 29374039"
            };

            var phoneEmpty = new PhoneNumbers()
            {
                Contact = new Contacts()
                {
                    Id = 1
                },
                PhoneNumber = ""
            };

            PhoneNumbers phoneNull = null;

            var phoneNotValid1 = new PhoneNumbers()
            {
                Contact = new Contacts()
                {
                    Id = 1
                },
                PhoneNumber = "mob 29374039"
            };

            var phoneNotValid2 = new PhoneNumbers()
            {
                Contact = new Contacts()
                {
                    Id = 1
                },
                PhoneNumber = "2937+4039"
            };


            Assert.IsTrue(Utils.ValidatePhoneNumber(phoneValid1));
            Assert.IsTrue(Utils.ValidatePhoneNumber(phoneValid2));
            Assert.IsFalse(Utils.ValidatePhoneNumber(phoneEmpty));
            Assert.IsFalse(Utils.ValidatePhoneNumber(phoneNull));
            Assert.IsFalse(Utils.ValidatePhoneNumber(phoneNotValid1));
            Assert.IsFalse(Utils.ValidatePhoneNumber(phoneNotValid2));

        }


        //AIzaSyDu83QjX9wpMP4b7OglQwxDN1HMnPt56BE - gugle


        //df9ab3fa81249c https://my.locationiq.com/dashboard/?firstLogin=1
        [TestMethod]
        public void TestValidateAddress()
        {
            var adressCorrect = "Kristapa";
        }
    }
}
