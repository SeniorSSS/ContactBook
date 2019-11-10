using ContactBook.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;

namespace ContactBook.Core.Services
{
    public static class Utils
    {
        public static bool ValidateContact(Contacts contact)
        {
            if (contact == null || String.IsNullOrEmpty(contact.Name)) { return false; }

            return true;
        }

        public static bool ValidateEmail(Emails emailToValidate)
        {
            if (emailToValidate == null || emailToValidate.Contact == null || string.IsNullOrWhiteSpace(emailToValidate.Email))
                return false;
            var email = emailToValidate.Email;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

        }

        public static bool ValidatePhoneType(PhoneTypes phoneType)
        {
            if (phoneType == null || String.IsNullOrEmpty(phoneType.PhoneType)) { return false; }
            return true;
        }

        public static bool ValidatePhoneNumber(PhoneNumbers phoneNumber)
        {
            if (phoneNumber == null || phoneNumber.Contact == null || String.IsNullOrEmpty(phoneNumber.PhoneNumber)) { return false; }

            //var regex = @"^\+(?:[0-9] ?){6,14}[0-9]$";

            //RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;

            var phoneNumberWithoutSpaces = phoneNumber.PhoneNumber.Replace(" ", string.Empty);

            var regex = @"^\+?[0-9]+$";
            return Regex.IsMatch(phoneNumberWithoutSpaces, regex);

            return true;
        }
        public static bool ValidateAddressInput(Addresses address)
        {
            if (address == null || address.Contact == null || String.IsNullOrEmpty(address.Address)) { return false; }


            return true;
        }

        public static bool ValidateSearchInput(string search)
        {
            search = search.Trim();
            if (search == null || String.IsNullOrEmpty(search)) { return false; }

            return true;
        }

    }
}
