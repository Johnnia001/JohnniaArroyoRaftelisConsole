# Johnnia Arroyo Console Sorting App
This console application is designed to read in a delimited text file containing parcel records and sort them based on different criteria.

## Setup
Clone the Repository: Clone this repository to your local machine using the following command:

`git clone https://github.com/your-username/JohnniaArroyoRaftelisConsole.git`

Navigate to Directory: Change your current directory to the cloned repository:

`cd JohnniaArroyoRaftelisConsole`

Build the Project: Build the C# project using the .NET CLI:

`dotnet build`

## Usage
Prepare Input Data:

Ensure you have a text file named Parcels.txt containing the parcel records. Each record should be in the format:

PIN|ADDRESS|OWNER|MARKET_VALUE|SALE_DATE|SALE_PRICE|LINK

Example:

6000090000|51 LOST RIVER AIRPORT RUNWAY|CHUNG, SAMUEL & HEIDI|339100.00|8/1/2003|152000.00|http://okanoganwa.taxsifter.com/Search/results.aspx?q=6000090000
## Run the Application:

Execute the compiled application using the .NET CLI:
arduino

`dotnet run`
## View Sorted Records:

The application will display sorted records based on different criteria:
Sorted by Street: Records sorted by street name and then by street number.
Sorted by First Name: Records sorted by the first name of the owner.
## Dependencies
- [.NET Core SDK (version 8.0)](https://dotnet.microsoft.com/download)
- [Spectre.Console](https://spectreconsole.net/)