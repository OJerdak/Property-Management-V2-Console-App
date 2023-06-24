using PropertyManagementV2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementV2.Transactions
{
    public class TransactionEventArgs :EventArgs
    {
        public Buyer Buyer { get; set; }

        public Property Property { get; set; }
    }
}
