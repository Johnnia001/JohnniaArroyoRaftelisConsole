using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Record
{
    public string Pin { get; set; }
    public string Address { get; set; }
    public string Owner { get; set; }
    public decimal MarketValue { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SalePrice { get; set; }
    public string Link { get; set; }

    //print all columns
    public override string ToString()
    {
        return $"{Pin}|{Address}|{Owner}|{MarketValue}|{SaleDate}|{SalePrice}|{Link}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Record> records = File.ReadAllLines("/Users/miti/Raftelis/JohnniaArroyoRaftelisConsole/JohnniaArroyoRaftelisConsole/Parcels.txt")
                                   .Skip(1)
                                   .Select(line =>
                                   {
                                       string[] parts = line.Split('|');
                                       DateTime.TryParse(parts[4], out DateTime saleDate);
                                       return new Record
                                       {
                                           Pin = parts[0],
                                           Address = parts[1],
                                           Owner = parts[2],
                                           MarketValue = decimal.Parse(parts[3]),
                                           SaleDate = saleDate,
                                           SalePrice = decimal.Parse(parts[5]),
                                           Link = parts[6]
                                       };
                                   })
                                   .ToList();

        // Sort Street Name
        var sortedRecords = records.OrderBy(r => r.Address.Split(' ')[1])
        // Sort Street Number
                                   .ThenBy(r => int.Parse(r.Address.Split(' ')[0]));

        // Print all columns
        Console.WriteLine("Sorted Records:");
        foreach (var record in sortedRecords)
        {
            Console.WriteLine(record);
        }
    }
}
