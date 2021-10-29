using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation;
            fileLocation = CreateDirectory();


            string[] arrayFromFile = File.ReadAllLines($"{fileLocation}");
            List<string> myList = arrayFromFile.ToList<string>();

            bool loopActive = true;
            while (loopActive)
            {
                Console.WriteLine("Would you like to add an item? Y/N:");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());
                if (userInput == 'y')
                {
                    Console.WriteLine("Enter your item:");
                    string userWish = Console.ReadLine();
                    myList.Add(userWish);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Take care!");
                }
            }
            Console.Clear();
            
            foreach (string wish in myList)
            {
                Console.WriteLine($"Your item: {wish}");
            }
            File.WriteAllLines($"{fileLocation}", myList);
        }
        public static string CreateDirectory()
        {
            string rootDirectory = @"C:\Users\Anton\samples";
            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();
            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();

            string directoryName = rootDirectory+"\\"+newDirectory+"\\"+fileName;
            
            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{directoryName}"))
            {
                Console.WriteLine("Directory and file exist.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{directoryName}");
                Console.WriteLine($"File {fileName} created!");
            }
            
            return directoryName;
            
        
        }
        
    }
}