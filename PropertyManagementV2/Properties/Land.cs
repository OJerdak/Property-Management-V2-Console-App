using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementV2.Properties
{
    internal class Land : Property
    {
        public int Area { get; set; }

        public bool CanBeFramed { get; set; }

        public override int Price => Area * 3000;

        public Land()
        :base()
        {
        }

        public Land(string title)
        : base(title)
        {

        }

        public Land(string title, string address)
        : base(title, address)
        {

        }

        public Land(string title, string address, int area)
        : this(title, address)
        {
            Area = area;
        }

        public Land(string title, string address, int area , bool canBeFramed)
            :this(title, address, area)
        {
            CanBeFramed = canBeFramed;
        }
    }
}
