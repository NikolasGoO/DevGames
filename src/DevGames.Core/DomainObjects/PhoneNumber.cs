using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevGames.Core.DomainObjects
{
    public class PhoneNumber
    {
        public const int PhoneNumberMaxLength = 11;
        public string Number { get; private set; }

        private static readonly Regex phoneRegex = new Regex(@"^\+\d{1,3}\s?\(\d{1,4}\)\s?\d{1,}-\d{1,}$");
        protected PhoneNumber() { }

        public PhoneNumber(string number)
        {
            if (!ValidatePhoneNumber(number)) throw new DomainException("Número inválido");
            Number = number;
        }

        public static bool ValidatePhoneNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }

            return phoneRegex.IsMatch(number);
        }
    }
}
