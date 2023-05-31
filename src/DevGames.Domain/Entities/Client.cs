using DevGames.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Domain.Entities
{
    public class Client : Entity
    {
        protected Client() { }
        public Client(string name,
            Email email,
            PhoneNumber phoneNumber,
            DateTime birthDate,
            Cpf cpf,
            bool active)
        {
            Name = name;
            Email = email.Address;
            Cpf = cpf.Number;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber.Number;
            Active = active;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }

        public void SetAddress(Address address)
        {
            Address = address;
            AddressId = address.Id;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }
    }
}
