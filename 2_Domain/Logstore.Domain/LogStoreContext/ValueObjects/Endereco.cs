using System;
using Logstore.Domain.ValueObjects;


namespace Logstore.Domain.LogStoreContext.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(String street, String number, String neighborhood, String city, String state, String country, String zipCode)
        {
            this.Street = street;
            this.Number = number;
            this.Neighborhood = neighborhood;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.ZipCode = zipCode;

        }
        public String Street { get; private set; }
        public String Number { get; private set; }
        public String Neighborhood { get; private set; }
        public String City { get; private set; }
        public String State { get; private set; }
        public String Country { get; private set; }
        public String ZipCode { get; private set; }

    }
}