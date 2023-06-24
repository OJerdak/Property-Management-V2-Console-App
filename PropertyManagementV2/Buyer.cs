using PropertyManagementV2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PropertyManagementV2
{
    public class Buyer
    {
        private static int _id;

        public int Id { get; private set; }

        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public double Credit { get; set; }

        public List<Property> OwnedProperties { get; set; } = new List<Property>();

        public Buyer()
        {
            _id++;
            Id = _id;
        }

        public Buyer(string firstName):this()
        {
            FirstName = firstName;
        }

         public Buyer(string firstName , string lastName):this(firstName)
        {
            LastName = lastName;
        }

         public Buyer(string firstName , string lastName, int credit):this(firstName,lastName)
        {
            Credit = credit;
        }

        public override string ToString()
        {
            return "\r\nBuyer: FullName" + FullName +
                    "\r\nNb of Owned Properties:" + OwnedProperties.Count +
                    "\r\nRemaining Credit: \r\n" + Credit;
        }
    }
}
