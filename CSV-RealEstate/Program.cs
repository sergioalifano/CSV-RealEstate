﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace CSV_RealEstate
{
    // WHERE TO START?
    // 1. Complete the RealEstateType enumeration
    // 2. Complete the RealEstateSale object.  Fill in all properties, then create the constructor.
    // 3. Complete the GetRealEstateSaleList() function.  This is the function that actually reads in the .csv document and extracts a single row from the document and passes it into the RealEstateSale constructor to create a list of RealEstateSale Objects.
    // 4. Start by displaying the the information in the Main() function by creating lambda expressions.  After you have acheived your desired output, then translate your logic into the function for testing.
    class Program
    {
        static void Main(string[] args)
        {
            List<RealEstateSale> realEstateSaleList = GetRealEstateSaleList();
            
            //Display the average square footage of a Condo sold in the city of Sacramento, 
            //Use the GetAverageSquareFootageByRealEstateTypeAndCity() function.
            Console.WriteLine(GetAverageSquareFootageByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Condo, "Sacramento")); 
            

            //Display the total sales of all residential homes in Elk Grove.  Use the GetTotalSalesByRealEstateTypeAndCity() function for testing.

            //Display the total number of residential homes sold in the zip code 95842.  Use the GetNumberOfSalesByRealEstateTypeAndZip() function for testing.

            //Display the average sale price of a lot in Sacramento.  Use the GetAverageSalePriceByRealEstateTypeAndCity() function for testing.

            //Display the average price per square foot for a condo in Sacramento. Round to 2 decimal places. Use the GetAveragePricePerSquareFootByRealEstateTypeAndCity() function for testing.

            //Display the number of all sales that were completed on a Wednesday.  Use the GetNumberOfSalesByDayOfWeek() function for testing.


            //Display the average number of bedrooms for a residential home in Sacramento when the 
            // price is greater than 300000.  Round to 2 decimal places.  Use the GetAverageBedsByRealEstateTypeAndCityHigherThanPrice() function for testing.

            //Extra Credit:
            //Display top 5 cities by the number of homes sold (using the GroupBy extension)
            // Use the GetTop5CitiesByNumberOfHomesSold() function for testing.

            Console.ReadKey();

        }

        public static List<RealEstateSale> GetRealEstateSaleList()
        {

            List<RealEstateSale> realEstateSaleList = new List<RealEstateSale>();
            //read in the realestatedata.csv file.  As you process each row, you'll add a new 
            // RealEstateData object to the list for each row of the document, excluding the first.  bool skipFirstLine = true;
            StreamReader reader = new StreamReader("realestatedata.csv");

            // Get and don't use the first line
            string firstline = reader.ReadLine();

            // Loop through the rest of the lines
            while (!reader.EndOfStream)
            {
                string oneLineOfTextFromTheDocument = reader.ReadLine();
                RealEstateSale estateLine = new RealEstateSale(oneLineOfTextFromTheDocument);
                realEstateSaleList.Add(estateLine);
            }
         
            return realEstateSaleList;
        }

        //Display the average square footage of a Condo sold in the city of Sacramento
        public static double GetAverageSquareFootageByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city) 
        {
            return realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.Type==realEstateType).Average(x => x.Sq_Ft);
             
        }

        public static decimal GetTotalSalesByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return 0.0m;
        }

        public static int GetNumberOfSalesByRealEstateTypeAndZip(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string zipcode)
        {
            return 0;
        }

        
        public static decimal GetAverageSalePriceByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            //Must round to 2 decimal points
            return 0.0m;
        }
        public static decimal GetAveragePricePerSquareFootByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            //Must round to 2 decimal points
            return 0.0m;
        }

        public static int GetNumberOfSalesByDayOfWeek(List<RealEstateSale> realEstateDataList, DayOfWeek dayOfWeek)
        {
            return 0;
        }

        public static double GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city, decimal price)
        {
            //Must round to 2 decimal points
            return 0.0;
        }

        public static List<string> GetTop5CitiesByNumberOfHomesSold(List<RealEstateSale> realEstateDataList)
        {
            return new List<string>();
        }
    }

    public enum RealEstateType
    {
        //fill in with enum types: Residential, MultiFamily, Condo, Lot
        Residential,
        MultiFamily,
        Condo,
        Lot
    }
    class RealEstateSale
    {
        //Create properties, using the correct data types (not all are strings) for all columns of the CSV
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip{get;set;}
        public string State{get;set;}
        public int Beds { get; set; }
        public int Baths { get; set; }
        public double Sq_Ft { get; set; }
        public RealEstateType Type { get; set; }
        public DateTime Sale_Date { get; set; }
        public double Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        //The constructor will take a single string arguement.  This string will be one line of the real estate data.
        // Inside the constructor, you will seperate the values into their corrosponding properties, and do the necessary conversions
        public RealEstateSale(string inputLine)
        {
            string[] myList = inputLine.Split(',');

            this.Street = myList[0];
            this.City = myList[1];
            this.Zip = myList[2];
            this.State = myList[3];
            this.Beds = int.Parse(myList[4]);
            this.Baths = int.Parse(myList[5]);
            this.Sq_Ft = double.Parse(myList[6], CultureInfo.InvariantCulture.NumberFormat);

            //When computing the RealEstateType, if the square footage is 0, then it is of the Lot type, otherwise, use the string
            // value of the "Type" column to determine its corresponding enumeration type.
            if (this.Sq_Ft == 0)
            {
                this.Type = (RealEstateType)Enum.Parse(typeof(RealEstateType), "Lot");
            }
            else if (myList[7] == "Multi-Family")
            {
                this.Type = (RealEstateType)Enum.Parse(typeof(RealEstateType), "MultiFamily");
            }
            else
            { this.Type = (RealEstateType)Enum.Parse(typeof(RealEstateType), myList[7]); }

            string format = "ddd MMM dd yyyy";
            DateTime dateTime = DateTime.ParseExact(myList[8], format, CultureInfo.InvariantCulture);
            this.Sale_Date = dateTime;

            this.Price = double.Parse(myList[9], CultureInfo.InvariantCulture.NumberFormat);
            this.Latitude = double.Parse(myList[10], CultureInfo.InvariantCulture.NumberFormat);
            this.Longitude = double.Parse(myList[11], CultureInfo.InvariantCulture.NumberFormat);
        }

       
    }
}
