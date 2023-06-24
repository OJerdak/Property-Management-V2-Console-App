using PropertyManagementV2.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementV2.Properties
{
    public class Shop : Property
    {
        public int Area { get; set; }

        public BusinessType Business { get; set; }

        public override int Price { get
            {
                if (Area > 50)
                 return 120000; 
                
                return 80000;
            }
        }

        public Shop()
            :base()
        {
                
        }

        public Shop(string title)
       : base(title)
        {

        }

        public Shop(string title, string address)
        : base(title, address)
        {

        }

        public Shop(string title, string address, int area)
        : this(title, address)
        {
            Area = area;
        }

         public Shop(string title, string address, int area, BusinessType business)
        : this(title, address, area)
        {
            Business = business;
        }


    }
}
