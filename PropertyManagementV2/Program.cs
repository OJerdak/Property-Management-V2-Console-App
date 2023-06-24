
using PropertyManagementV2.Properties;
using PropertyManagementV2.Enumerables;
using PropertyManagementV2.Transactions;
using PropertyManagementV2;
using System;
using System.Collections.Generic;
using System.Transactions;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using System.Collections;


var properties = new List<Property>()
{
    new Apartment("ap1","hazmieh1",1),
    new Apartment("ap2","hazmieh2",2),
    new Apartment("ap3","hazmieh3",3),
    new Apartment("ap4","hazmieh4",4),
    new Apartment("ap5","hazmieh5",5),

    new Land("land1","beirut1",80 , true),
    new Land("land2","beirut2",40 , false),

    new Shop("shop1","Antelias1", 50, BusinessType.Food),
    new Shop("shop2","Antelias2", 60, BusinessType.Retail),
    new Shop("shop3","Antelias3", 70, BusinessType.Repair)
};



var buyers = new List<Buyer>()
{
    new Buyer("Ali", "Mokdad", 60000),
    new Buyer("Jamal", "Salman", 10000),
    new Buyer("Omar", "Jerdak", 400000)
};


Console.WriteLine("\n****************** 03 - Displaying All Properties*****************\n");

foreach (var property in properties)
{
    Console.WriteLine(property.ToString());
}




Console.WriteLine("\n****************** 04 - Displaying All Lands********************\n");

foreach (var property in properties)
{
    if(property is Land)
        Console.WriteLine(property.ToString());
}


Console.WriteLine("\n******************  05 - Displaying all properties whose price is between 45,000 and 100,000 ********************\n");

var midRangeProperties = properties.Where(x=> x.Price >= 45000 && x.Price <= 100000).ToList();

foreach (var property in midRangeProperties)
{
        Console.WriteLine(property.ToString());
}



Console.WriteLine("\n******************  06 -  Simulating purchases... ********************\n");

//Injecting the list of buyers and the list of properties into the transaction manager 
var services = new ServiceCollection();

services.AddSingleton(buyers);
services.AddSingleton(properties);

services.AddScoped<TransactionsManager>();

var serviceProvider = services.BuildServiceProvider();

var myInstance = serviceProvider.GetService<TransactionsManager>();

var purchaseSimulator = new TransactionsManager(buyers , properties);
var emitter = new Emitter();

purchaseSimulator.PropertyPurchased += emitter.OnPropertyPurchased;

purchaseSimulator.TryBuy();


if (serviceProvider is IDisposable disposable)
{
    disposable.Dispose();
}

#region Omitted
/****************** Before DI *****************/

//try
//{
//    foreach (var buyer in buyers)
//    {
//        foreach (var property in properties)
//        {
//            purchaseSimulator.TryBuy(buyer, property);
//            //Console.WriteLine("Buyer ID {0} property id{1}", buyer.Id , property.Id);
//        }

//    }
//}
//catch(Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion


Console.WriteLine("\n******************   07 -   Displaying All Buyers... ********************\n");


foreach (Buyer buyer in buyers)
{
    Console.WriteLine(buyer.ToString());
}


Console.WriteLine("\n******************   08 -   Property Having Id = 2 ********************\n");



var prop2 = properties.Where(x => x.Id == 2).FirstOrDefault();

prop2.Title = "Property with ID = 2";

Console.WriteLine(prop2.ToString());





Console.WriteLine("\n******************   09 -  Displaying all properties minus 2 unpurchased ones ********************\n");

var unpurchasedProperties = new List<Property>();

foreach(Property property in properties)
{
    if(!buyers.Any(x => x.OwnedProperties.Contains(property))) { 
        unpurchasedProperties.Add(property);
    }
}

properties.Remove(unpurchasedProperties[0]);
properties.Remove(unpurchasedProperties[1]);

foreach (Property property in properties)
{
    Console.WriteLine(property.ToString());
}
Console.ReadLine();