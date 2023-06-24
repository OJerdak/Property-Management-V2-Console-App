using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PropertyManagementV2.Properties
{
    public abstract class Property
    {
        private static int _id;

        public int Id { get; private set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public virtual int Price { get; set; }
        
        //public virtual int Area { get; set; }

        //public virtual bool CanBeFramed { get; set; }

        public Property()
        {
            _id++;
            Id = _id;
        }

        public Property(string title):this()
        {
            Title = title;
        }

        public Property(string title , string address) :this(title)
        {
            Address = address;
        }


        public override string ToString()
        {
            
            return JsonSerializer.Serialize(this).ToString();

        }

    }
}
