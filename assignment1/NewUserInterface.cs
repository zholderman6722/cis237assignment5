//Author: Zachery Holderman
//CIS 237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class NewUserInterface
    {
        public void UserInteface()
        {

            //Make new instance of the wine Collection
            //Probably going to be BeverageFInitialLName for you.
            BeverageZHoldermanEntities BeverageZholdermanEntities = new BeverageZHoldermanEntities();

            //*************************************************
            //List out all of the beverages in the table
            //*************************************************

            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();

            Console.WriteLine("1. Print The Entire List Of Items");
            Console.WriteLine("2. Search For An Item by item ID");
            Console.WriteLine("3. Add New Item To The List");
            Console.WriteLine("4. Update an existing Wine Item.");
            Console.WriteLine("5. Delete an existing Item from the List.");
            Console.WriteLine("6. Exit Program");
            int getUserInput = int.Parse(Console.ReadLine());
            switch (getUserInput)
            {
                case 1:
                    Console.WriteLine("Printing list of items...");
                    foreach (Beverage beverage in BeverageZholdermanEntities.Beverages)
                    {
                        Console.WriteLine(beverage.id);
                        Console.WriteLine(beverage.name);
                        Console.WriteLine(beverage.pack);
                        Console.WriteLine(beverage.price);
                        Console.WriteLine("***************************************************************************");
                    }
                    break;
                //***********************************************************************************************************************************************************
                case 2:
                    //************************************
                    //Find a specific one by any property
                    //************************************

                    //Call the Where method on the table Beverages and pass in a lambda expression
                    //for the criteria we are looking for. There is nothing special about the
                    //word beverages in the part that reads: beverages => beverages.id == "V0...". It could be
                    //any characters we want it to be.
                    //It is just a variable name for the current beverage we are considering
                    //in the expression. This will automagically loop through all the beverages,
                    //and run the expression against each of them. When the result is finally
                    //true, it will return that car.
                    Console.WriteLine("searching for an item by item ID...");
                    Console.WriteLine("List an item id of a beverage that you would like to find.");
                    string input = Console.ReadLine();
                    Beverage beverageToFind = BeverageZholdermanEntities.Beverages.Where(beverage => beverage.id == input).First();

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Find specific beverage with where method.");
                    Console.WriteLine(beverageToFind.id + " " + beverageToFind.name + " " + beverageToFind.pack + " " + beverageToFind.price);
                    break;
                //***********************************************************************************************************************************************************
                case 3:
                    Console.WriteLine("Adding a new wine item to the list...");
                    //***************************************
                    //Add a new beverage to the database
                    //***************************************
                    Beverage newBeverageToAdd = new Beverage();
                    //assign properties to the parts of the beverage.
                    Console.WriteLine("What is the ID?");
                    string choice = Console.ReadLine();
                    newBeverageToAdd.id = choice;
                    Console.WriteLine("What is the name?");
                    newBeverageToAdd.name = Console.ReadLine();
                    Console.WriteLine("What is the pack?");
                    newBeverageToAdd.pack = Console.ReadLine();
                    Console.WriteLine("What is the price?");
                    string newprice = Console.ReadLine();
                    decimal newPrice;
                    Decimal.TryParse(newprice, out newPrice);
                    newBeverageToAdd.price = newPrice;

                    try
                    {
                        //Add the new beverage to the beverage collection
                        BeverageZholdermanEntities.Beverages.Add(newBeverageToAdd);
                        BeverageZholdermanEntities.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        //Remove the new beverage from the beverages collection since we can't save it.
                        BeverageZholdermanEntities.Beverages.Remove(newBeverageToAdd);

                        Console.WriteLine("Can't add the record. Already have one with that primary key.");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Just added a new beverage. Going to fetch it and print it to verify.");

                    beverageToFind = BeverageZholdermanEntities.Beverages.Find(choice);
                    Console.WriteLine(beverageToFind.id + " " + beverageToFind.name + " " + beverageToFind.pack + " " + beverageToFind.price);
                    break;
                //***********************************************************************************************************************************************************
                case 4:
                    Console.WriteLine("Updating an existing Wine Item...");
                    //*********************************
                    //How to do an update
                    //*********************************

                    //Get a beverage out of the database that we would like to update
                    Console.WriteLine("What is the id of the beverage that you would like to update?");
                    string updateThisBeverage = Console.ReadLine();
                    Beverage beverageToFindForUpdate = BeverageZholdermanEntities.Beverages.Find(updateThisBeverage);

                    //Output the beverage to find
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("About to do an update on a beverage");
                    Console.WriteLine(beverageToFindForUpdate.id + " " + beverageToFindForUpdate.name +
                                        " " + beverageToFindForUpdate.pack + " " + beverageToFindForUpdate.price);
                    Console.WriteLine("Doing the update now");

                    //Update some of the properties of the beverage we found. Don't need to update
                    //all of them if we don't want to.
                    
                    Console.WriteLine("What would you like to change the name to?");
                    string newName = Console.ReadLine();
                    beverageToFindForUpdate.name = newName;
                    Console.WriteLine("What would you like to change the pack to?");
                    string newPack = Console.ReadLine();
                    beverageToFindForUpdate.pack = newPack;
                    Console.WriteLine("What would you like to change the price to?");
                    newprice = Console.ReadLine();
                    newPrice = 0;
                    Decimal.TryParse(newprice, out newPrice);
                    beverageToFindForUpdate.price = newPrice;

                    //Save the changes to the database. Since when we pulled out the one to
                    //update, all we were really doing was getting a reference to the one in
                    //the collection we wanted to update, there is no need to 'put' the beverage
                    //back into the Beverages colllection. It is still there. 
                    //All we have to do is save the changes.
                    BeverageZholdermanEntities.SaveChanges();

                    //Get a beverage out of the database that we would like to update
                    beverageToFindForUpdate = BeverageZholdermanEntities.Beverages.Find(updateThisBeverage);

                    //Output the car to find
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Outputing the updated beverage that was retrieved from the db");
                    Console.WriteLine(beverageToFindForUpdate.id + " " + beverageToFindForUpdate.name +
                    " " + beverageToFindForUpdate.pack + " " + beverageToFindForUpdate.price);
                    break;
                //***********************************************************************************************************************************************************
                case 5:
                    //*********************************
                    //How to do a delete
                    //*********************************
                    Console.WriteLine("What beverage ID would you like to delete?");
                    string deleteBeverage = Console.ReadLine();
                    //Get a beverage out of the database that we want to delete
                    Beverage beverageToFindForDelete = BeverageZholdermanEntities.Beverages.Find(deleteBeverage);

                    //Remove the Beverage from the Beverage Collection
                    BeverageZholdermanEntities.Beverages.Remove(beverageToFindForDelete);

                    //Save the changes to the database
                    BeverageZholdermanEntities.SaveChanges();

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Deleted the added beverage. Looking to see if it is still in the db");

                    //Try to get the car out of the database, and print it out
                    beverageToFindForDelete = BeverageZholdermanEntities.Beverages.Find(deleteBeverage);
                    if (beverageToFindForDelete == null)
                    {
                        Console.WriteLine("The beverage you are looking for does not exist.");
                    }
                    break;
                case 6:
                    Console.WriteLine("Exit Program");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Selection, sorry.");
                    break;
            }
        }
    }
}
