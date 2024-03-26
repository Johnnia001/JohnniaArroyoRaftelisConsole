using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter the path to the .txt file
        Console.WriteLine("/Users/miti/Raftelis/JohnniaArroyoRaftelisConsole/JohnniaArroyoRaftelisConsole/Parcels.txt");
        string filePath = Console.ReadLine();

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read all lines from the file and print them out
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine("Contents of the file:");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }

        Console.ReadLine(); // Keep the console window open until Enter is pressed
    }
}
