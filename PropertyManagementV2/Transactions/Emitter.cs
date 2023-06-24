using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementV2.Transactions
{
    public class Emitter
    {
        public void OnPropertyPurchased(object source, TransactionEventArgs args)
        {
            Console.WriteLine("{0} with ID {1} was purchased by {2} for {3}.",
                args.Property.GetType().Name , args.Property.Id , args.Buyer.FullName , args.Property.Price);
        }
    }
}
