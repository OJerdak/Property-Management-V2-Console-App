using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PropertyManagementV2.Properties
{
    internal class Apartment : Property
    {
        public int NbOfRooms { get; set; }

        public override int Price => this.NbOfRooms * 15000;

        public Apartment()
        :base(){
                
        }

        public Apartment(string title)
        :base(title){
                
        }

        public Apartment(string title, string address)
        : base(title, address)
        {

        }

        public Apartment(string title, string address, int nbofrooms)
        :base(title , address){
            NbOfRooms = nbofrooms;
        }

    }
}
