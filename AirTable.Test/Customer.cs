using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirTable.Test
{
    public class Customer
    {
        [JsonProperty(PropertyName = "First Name")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string country { get; set; }


        public Customer() { }

        public Customer(string _firstName, string _lastName, string _phoneNumber, string _email, string _country)
        {
            firstName = _firstName;
            lastName = _lastName;
            phoneNumber = _phoneNumber;
            email = _email;
            country = _country;
        }

        public override string ToString()
        {
            return firstName + ", " + lastName + ", " + email + ", " + phoneNumber + ", " + country;
        }

       

    }
}
