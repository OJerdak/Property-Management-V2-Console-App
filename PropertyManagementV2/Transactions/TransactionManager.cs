using PropertyManagementV2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementV2.Transactions
{
    public class TransactionsManager
    {
        private readonly List<Buyer> Buyers ;

        private readonly List<Property> Properties ;


        public event EventHandler<TransactionEventArgs> PropertyPurchased;

        public void TryBuy()
        {
            if (Buyers == null)
            {
                throw new NullReferenceException("No buyer have been assigned");
            }

            if (Properties == null)
            {
                throw new NullReferenceException("No property have been assigned");
            }

            foreach (Buyer buyer in Buyers) {
                foreach (Property property in Properties)
                {
                    if (buyer.Credit >= property.Price
                        && !Buyers.Any(x => x.OwnedProperties.Contains(property)))
                    {
                        buyer.Credit -= property.Price;
                        buyer.OwnedProperties.Add(property);

                        OnPropertyPurchase(buyer, property);
                    }
                }
            }

        }

        protected virtual void OnPropertyPurchase(Buyer buyer, Property property)
        {
            if (PropertyPurchased != null)
            {
                PropertyPurchased(this, new TransactionEventArgs()
                {
                    Buyer = buyer,
                    Property = property
                });
            }
        }

        public TransactionsManager(List<Buyer> buyers, List<Property> properties) {
            Buyers = buyers;
            Properties = properties;
        }
    }
}
