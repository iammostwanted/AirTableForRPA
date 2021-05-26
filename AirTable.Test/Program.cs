using AirTable.Core;
using AirTable.Core.Data;
using AirTable.Core.Data.Parameter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace AirTable.Test
{
    class Program
    {
        static void Main(string[] args)
        {    
            AirTableConnector connector = new AirTableConnector("keyv3uJQfr55iagqJ");
            var baseAirTable = connector.ExtractBase("appzn1hp9vPhFzufD", "Sheet1");
        
            Task.Factory.StartNew(
                async () =>
                {
                    try
                    {
                        //Pure sample based on Agile template.
                        var tableRecords =  await baseAirTable.List(new ListParameter() { });
                        //var record = await baseAirTable.Retreive(tableRecords.Records.First().Id);
                        //var deleted = await baseAirTable.Delete(tableRecords.First().Id);
                        //record.ExtractStringField("First Name").FieldValue = "Modified !!! " + DateTime.Now.ToLongTimeString();
                        //record = await baseAirTable.Update(record);


                        string json = @"{'First Name': 'test',
                                       'Last Name' : 'Testovich',
                                       'Country' : 'KZ',
                                        'phoneNumber' : '111',
                                        'People': '11212121',
                                        'Email': 'person@mail.ru' }";

                        Console.WriteLine("Working with the list of customers\n");

                        List<Customer> customers = new List<Customer>();
                        foreach (Record item in tableRecords.Records)
                        {
                            //Console.WriteLine(item.ToString());
                            
                            //Customer c = JsonConvert.DeserializeObject<Customer>(item.ToString());

                            Customer c = JsonConvert.DeserializeObject<Customer>(json);
                            Console.WriteLine(c.ToString());

                            Console.WriteLine(item.ToString().Replace("|", ""));
                            //JObject o = JObject.Parse(item.ToString());
                            //Console.WriteLine("JObject: " + o.ToString());




                            Customer tempCustomer = new Customer(
                                item.ExtractStringField("First Name").FieldValue,
                                item.ExtractStringField("Last Name").FieldValue, 
                                item.ExtractStringField("Phone").FieldValue,
                                item.ExtractStringField("Email").FieldValue, 
                                item.ExtractStringField("Country").FieldValue);
                            //Console.WriteLine(tempCustomer.ToString());
                            //Console.WriteLine("---------------------------------------------------");
                            customers.Add(tempCustomer);
                        }



                        /* < --------- Adding new Record to the table -------------->
                        var newRecord = new Record();
                        newRecord.ExtractStringField("#").FieldValue = "11";
                        newRecord.ExtractStringField("First Name").FieldValue = "Serik";
                        newRecord.ExtractStringField("Last Name").FieldValue = "Seidigalimov";
                        newRecord.ExtractStringField("Email").FieldValue = "ss@mail.ru";
                        newRecord.ExtractStringField("Phone").FieldValue = "777-777-77-77";
                        newRecord.ExtractStringField("Country").FieldValue = "Canada";
                        record = await baseAirTable.Create(newRecord);
                           < ------ END of Adding new Record to the table -------> */


                        Console.WriteLine("Done");
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.ToString());
                    }
                });
            Console.ReadLine();
        }
    }
}
