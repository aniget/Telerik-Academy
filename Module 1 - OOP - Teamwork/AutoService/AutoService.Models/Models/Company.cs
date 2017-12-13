using System;
using AutoService.Models.Contracts;

namespace AutoService.Models.Models
{
    public class Company : ICompany
    {
        private string name;
        private string address;
        private string taxNumber;
        private string uniqueNumber;
        private decimal creditLimit;

        public Company(string name, string address, string uniqueNumber, decimal creditLimit)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Company name cannot be null or empty!");
            }
            this.name = name;
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Company address cannot be null or empty!");
            }

            this.address = address;

            if (string.IsNullOrWhiteSpace(uniqueNumber))
            {
                throw new ArgumentException("Unique identification number cannot be null or empty!");
            }
            this.uniqueNumber = uniqueNumber;

            if (creditLimit <= 0)
            {
                throw new ArgumentException("Credit limit must be positive!");
            }

            this.creditLimit = creditLimit;
        }

        public Company(string name, string address, string uniqueNumber, decimal creditLimit, string taxNumber)
            : this(name, address, uniqueNumber, creditLimit)
        {
            this.taxNumber = taxNumber;
        }


        public string Name { get { return this.name; } }
        public string Address { get { return this.address; } }
        public string TaxNumber { get { return this.taxNumber; } }
        public string UniqueNumber { get { return this.uniqueNumber; } }
        public decimal CreditLimit { get { return this.creditLimit; } }

        public void UpdateCreditLimit(decimal creditLimit)
        {
            if (creditLimit < 0)
            {
                throw new ArgumentException("Credit limit cannot be negative!");
            }
            this.creditLimit = creditLimit;
        }

        public void ChangeAddress(string address)
        {
            this.address = address;
        }
    }
}
