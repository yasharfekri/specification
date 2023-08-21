using System;

namespace Specification.Api.Models
{
    public class Customer
    {
        #region ctors

        public Customer(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public Customer(string name, DateTime dateOfBirth, DateTime memberSince) : this(name, dateOfBirth)
        {
            MemberSince = memberSince;
        }

        #endregion


        public DateTime MemberSince { get; }

        public string Name { get; }

        public DateTime DateOfBirth { get; }
    }
}