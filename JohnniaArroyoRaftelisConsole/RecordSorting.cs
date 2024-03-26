using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Record
{
    public string Pin { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
    public decimal MarketValue { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SalePrice { get; set; }
    public string Link { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Pin}|{Address}|{Owner}|{MarketValue}|{SaleDate}|{SalePrice}|{Link}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Record> records = File.ReadAllLines("Parcels.txt")
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

        // Sort by street name and then by street number
        var sortedByStreet = records.OrderBy(r => r.Address.Split(' ')[1])
                                    .ThenBy(r => int.Parse(r.Address.Split(' ')[0]));

        Console.WriteLine("Sorted by Street:");
        Console.WriteLine("=================");
        foreach (var record in sortedByStreet)
        {
            Console.WriteLine(record);
        }

        // Sort by first name
        var sortedByFirstName = records.OrderBy(r =>
        {
            string[] nameParts = r.Owner.Split(',');
            return nameParts?.Length > 1 ? nameParts[1].Trim().Split(' ')[0] : string.Empty;
        });

        Console.WriteLine("\nSorted by First Name:");
        Console.WriteLine("=================");
        foreach (var record in sortedByFirstName)
        {
            Console.WriteLine(record);
        }
    }
}
