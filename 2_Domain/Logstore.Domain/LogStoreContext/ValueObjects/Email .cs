using System;
using Logstore.Domain.ValueObjects;

namespace Logstore.Domain.LogStoreContext.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }
        public String Address { get; private set; }
    }
}