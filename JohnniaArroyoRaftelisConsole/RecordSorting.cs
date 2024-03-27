using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Spectre.Console;

class Record
{
    public string Pin { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
    public decimal MarketValue { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SalePrice { get; set; }
    public string Link { get; set; } = string.Empty;
    public string GoogleMapsLink { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Pin}|{Address}|{Owner}|{MarketValue}|{SaleDate}|{SalePrice}|{Link}|{GoogleMapsLink}";
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

                                       string googleMapsLink = $"https://www.google.com/maps?q={Uri.EscapeDataString(parts[1] + ", Mazama, WA")}";

                                       return new Record
                                       {
                                           Pin = parts[0],
                                           Address = parts[1],
                                           Owner = parts[2],
                                           MarketValue = decimal.Parse(parts[3]),
                                           SaleDate = saleDate,
                                           SalePrice = decimal.Parse(parts[5]),
                                           Link = parts[6],
                                           GoogleMapsLink = googleMapsLink
                                       };
                                   })
                                   .ToList();

        // Sort by street name and then by street number
        var sortedByStreet = records.OrderBy(r => r.Address.Split(' ')[1])
                                    .ThenBy(r => int.Parse(r.Address.Split(' ')[0]));

        Console.WriteLine("Sorted by Street:");
        Console.WriteLine("=================");
        RenderTable(sortedByStreet);

        // Sort by first name
        var sortedByFirstName = records.OrderBy(r =>
        {
            string[] nameParts = r.Owner.Split(',');
            return nameParts?.Length > 1 ? nameParts[1].Trim().Split(' ')[0] : string.Empty;
        });

        Console.WriteLine("\nSorted by First Name:");
        Console.WriteLine("=================");
        RenderTable(sortedByFirstName);
    }

    static void RenderTable(IEnumerable<Record> records)
    {
        var table = new Table();
        table.AddColumn(new TableColumn("PIN").Centered().Header(new Markup("[bold red]PIN[/]")));
        table.AddColumn(new TableColumn("Address").Centered().Header(new Markup("[bold red]Address[/]")));
        table.AddColumn(new TableColumn("Owner").Centered().Header(new Markup("[bold red]Owner[/]")));
        table.AddColumn(new TableColumn("Market Value").Centered().Header(new Markup("[bold red]Market Value[/]")));
        table.AddColumn(new TableColumn("Sale Date").Centered().Header(new Markup("[bold red]Sale Date[/]")));
        table.AddColumn(new TableColumn("Sale Price").Centered().Header(new Markup("[bold red]Sale Price[/]")));
        table.AddColumn(new TableColumn("Link").Centered().Header(new Markup("[bold red]Link[/]")));
        table.AddColumn(new TableColumn("Google Maps").Centered().Header(new Markup("[bold red]Google Maps[/]")));

        foreach (var record in records)
        {
            table.AddRow(
                record.Pin,
                record.Address,
                record.Owner,
                record.MarketValue.ToString("C"),
                record.SaleDate.ToShortDateString(),
                record.SalePrice.ToString("C"),
                record.Link,
                record.GoogleMapsLink);
        }

        AnsiConsole.Write(table);
    }
}
