using System;
using System.IO;  // include the System.IO namespace, necassary to write to files

namespace HotelManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
        void Overview() // Show overview over avaible rooms
            {
                Console.WriteLine("Overview");
                i = 0;

                while (i < room.Length)

                {

                    Console.WriteLine(room[i].name);

                    i += 1;

                }

                Console.ReadLine();
            }
            */

            void BookRoom() // Book a Room
            {
                Console.WriteLine("Book a Room");
            }

            /*
            void LookupRoom()
            {
                Console.Write("Enter Room Number: ");
                // TODO Make bug proof Try Catch
                int roomNumber = int.Parse(Console.ReadLine());

                Console.WriteLine(roomNumber);
                Console.ReadLine();
            }
            */

            void DeleteBooking() // Delete a Booking
            {
                Console.WriteLine("Delete a Booking!");
            }


            bool boolss = true;
            bool run = true;
            int choice = 0;
            char yn; //Char for Yes/No questions

            do {
                if (File.Exists("file.csv") != true) // Make sure File.txt exists, if it dosen't it will ask the user if it should be created
                {
                    Console.Write("file.csv does not exist, do you want to create it? (Y/N): ");
                    yn = char.Parse(Console.ReadLine());
                    if (yn == 'y' || yn == 'Y')
                        File.Create("file.csv");
                    else
                        Console.WriteLine("Could not find 'file.csv'!\nClosing Program!");
                        Environment.Exit(1); // Close Application
                }

                // Import Data from file.csv

                // Reads data from file.csv and saves it as a string array

                string[] lines = File.ReadAllLines("file.csv");

                // Creating an array to save the rooms and their data

                Room[] room = new Room[lines.Length];

                //gennemgår alle linjerne i filen

                int i = 0;

                while (i < lines.Length)

                {

                    //Splitter den pågældende linje op, efter ","

                    string line = lines[i];

                    string[] fields = line.Split(",");

                    //Opretter et objekt og fylder det med data fra den opsplittede linje

                    room[i] = new Room();

                    room[i].room = int.Parse(fields[0]);

                    room[i].name = fields[1];

                    room[i].phonenumber = fields[2];

                    room[i].email = fields[3];

                    i += 1;

                }

                //Følgende loop er til at teste om dataen er gemt korrekt.






                Console.Clear();


                // MENU
                // Console.WriteLine("ooooo   ooooo               .             oooo  \n`888'   `888'             .o8             `888  \n 888     888   .ooooo.  .o888oo  .ooooo.   888  \n 888ooooo888  d88' `88b   888   d88' `88b  888  \n 888     888  888   888   888   888ooo888  888  \n 888     888  888   888   888 . 888    .o  888  \no888o   o888o `Y8bod8P'   \"888\" `Y8bod8P' o888o \n");
                Console.WriteLine(" /$$   /$$             /$$               /$$\n| $$  | $$            | $$              | $$\n| $$  | $$  /$$$$$$  /$$$$$$    /$$$$$$ | $$\n| $$$$$$$$ /$$__  $$|_  $$_/   /$$__  $$| $$\n| $$__  $$| $$  \\ $$  | $$    | $$$$$$$$| $$\n| $$  | $$| $$  | $$  | $$ /$$| $$_____/| $$\n| $$  | $$|  $$$$$$/  |  $$$$/|  $$$$$$$| $$\n|__/  |__/ \\______/    \\___/   \\_______/|__/");
                Console.WriteLine("\n1) Overview\t\t2) Book a Room");
                Console.WriteLine("3) Lookup Room\t\t4) Something Else");
                Console.WriteLine("5) Delete a Booking\t6) Exit");
                Console.Write("\nHotel: ");

                do
                {
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        run = false;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Option");
                        run = true;
                    }
                } while (run == true);

                switch (choice)
                {
                    case 1:
                        // Overview();
                        Console.Clear();
                        Console.WriteLine("Overview");

                        i = 0;

                        while (i < room.Length)

                        {
                            Console.WriteLine("\nRoom : " + room[i].room + "\nName : " + room[i].name + "\nPhone: " + room[i].phonenumber + "\nEmail: " + room[i].email);

                            i += 1;

                        }

                        Console.ReadLine();
                        break;
                    case 2:
                        BookRoom();
                        break;
                    case 3:
                        // LookupRoom();
                        bool runLoop = true;
                        int roomNumber = 0;
                        do {

                            Console.Write("Enter Room Number: ");
                            try
                            {
                                roomNumber = int.Parse(Console.ReadLine());
                                runLoop = false;
                                Console.WriteLine("Room: " + room[roomNumber - 1].room + "\nName: " + room[roomNumber - 1].name + "\nPhone: " + room[roomNumber - 1].phonenumber + "\nEmail: " + room[roomNumber - 1].email);

                            }
                            catch
                            {
                                Console.WriteLine("Invalid Room! (You can only enter numbers!)\nTry Again!");
                                runLoop = true;
                            }
                            

                        } while (runLoop == true);


                     //   Console.WriteLine(roomNumber);
                        Console.ReadLine();
                        break;
                    case 4:
                        break;
                    case 5:
                        DeleteBooking();
                        break;
                    case 6:
                        Console.WriteLine("Exit");
                        boolss = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Option");
                        Console.ResetColor();
                        break;
                }

            } while (boolss == true);

        }

        class Room
        {
            // In CSV file data is saved as
            // room, name, phonenumber, email
            public int room;
            public string name;
            public string email;
            public string phonenumber;
            public bool booked;

        }
    }
}
