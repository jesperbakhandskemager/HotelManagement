using System;
using System.IO;  // include the System.IO namespace, necassary to write to files

namespace HotelManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runLoop = true; // Used in multiple loops througout the program
            int roomNumber = 0;
            string sRooms = ""; // Same as below but used for the ReadLine
            int iRooms = 0; // Used as an interger for a selected room
            int i = 0; // It's the Index Variable
            bool boolss = true; // The do while loop around the whole program
            int choice = 0; // Used for the main menu
            char yn; //Char for Yes/No questions
            bool bookSaved; // Boolean for whether the booking was saved
            string phoneNumber = ""; // Used in the Lookup by Phone 
            bool searchEmpty;


            do {
                if (File.Exists("file.csv") != true) // Make sure File.txt exists, if it dosen't it will ask the user if it should be created
                {
                    Console.Write("file.csv does not exist, do you want to create it? (Y/N): ");
                    yn = char.Parse(Console.ReadLine());
                    if (yn == 'y' || yn == 'Y')
                    {
                        do
                        {
                            Console.Write("How many rooms do you want: ");
                            sRooms = Console.ReadLine();
                            try
                            {
                                iRooms = int.Parse(sRooms);
                                runLoop = false;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Input!");
                                runLoop = true;
                            }

                        } while (runLoop == true);

                        string[] emptyArray = new string[iRooms];
                        
                        for (i = 0; i < iRooms; i++)
                        {
                            emptyArray[i] = (i + 1) + ",,,,false";
                        }

                        File.WriteAllLines("file.csv", emptyArray);
                        Console.WriteLine("file.csv created!");
                    }

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

                i = 0;

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

                    room[i].booked = bool.Parse(fields[4]);

                    i += 1;

                }

                Console.Clear();


                // MENU
                // Console.WriteLine("ooooo   ooooo               .             oooo  \n`888'   `888'             .o8             `888  \n 888     888   .ooooo.  .o888oo  .ooooo.   888  \n 888ooooo888  d88' `88b   888   d88' `88b  888  \n 888     888  888   888   888   888ooo888  888  \n 888     888  888   888   888 . 888    .o  888  \no888o   o888o `Y8bod8P'   \"888\" `Y8bod8P' o888o \n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" /$$   /$$             /$$               /$$\n| $$  | $$            | $$              | $$\n| $$  | $$  /$$$$$$  /$$$$$$    /$$$$$$ | $$\n| $$$$$$$$ /$$__  $$|_  $$_/   /$$__  $$| $$\n| $$__  $$| $$  \\ $$  | $$    | $$$$$$$$| $$\n| $$  | $$| $$  | $$  | $$ /$$| $$_____/| $$\n| $$  | $$|  $$$$$$/  |  $$$$/|  $$$$$$$| $$\n|__/  |__/ \\______/    \\___/   \\_______/|__/");
                Console.ResetColor();
                Console.WriteLine("\n1) Overview\t\t2) Book a Room");
                Console.WriteLine("3) Lookup Room\t\t4) Delete a Booking");
                Console.WriteLine("5) Search by Phone\t6) Exit");

                do
                {
                    Console.Write("\nHotel: ");

                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        runLoop = false;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Option");
                        runLoop = true;

                    }
                } while (runLoop == true);

                switch (choice)
                {
                    case 1:
                        // Overview();
                        Console.Clear();
                        Console.WriteLine("Overview");

                        i = 0;

                        while (i < room.Length)

                        {
                            if (room[i].booked == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nRoom: " + room[i].room + " - Occupied");
                                Console.ResetColor();
                            }

                            // If i want all information Console.WriteLine("\nRoom : " + room[i].room + "\nName : " + room[i].name + "\nPhone: " + room[i].phonenumber + "\nEmail: " + room[i].email);
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nRoom: " + room[i].room + " - Available");
                                Console.ResetColor();
                            }


                            i += 1;

                        }

                        Console.ReadLine();
                        break;





                    case 2: //BookRoom
                        roomNumber = 0;
                        runLoop = true;

                        do
                        { 
                        Console.WriteLine("Which Room? (WARNING! This will replace the old values!)");
                            Console.Write("Available Rooms: ");
                            for (i = 0; i < room.Length; i++)
                            {
                                if (room[i].booked == false)
                                    Console.Write(room[i].room + ", ");

                            }
                            Console.Write("or 'c' to show overview and go back!");
                            Console.Write("\nRoom: ");
                        string sInput = Console.ReadLine();

                            if (sInput == "c" || sInput == "C" || sInput == "q")
                                goto case 1;

                                try
                                {
                                    roomNumber = int.Parse(sInput);
                                    runLoop = false;
                                }
                                catch
                                {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Input!");
                                Console.ResetColor();

                                runLoop = true;
                                }
                            
                            }while (runLoop == true) ;

                        Console.Clear();
                        string userName = "";
                        string userPhone = "";
                        string userEmail = "";
                        bool userBooked;

                        runLoop = false;
                        do
                        {
                            Console.WriteLine("Room " + roomNumber);
                            Console.Write("Name: ");
                            userName = Console.ReadLine();
                            Console.Write("Phone: ");
                            userPhone = Console.ReadLine();
                            Console.Write("E-Mail: ");
                            userEmail = Console.ReadLine();

                            if (userName.Contains(',') || userPhone.Contains(',') || userEmail.Contains(','))
                            {
                                runLoop = true;
                                Console.WriteLine("You DISGUSTING CUNT OF A HUMAN BEING DON'T FUCKING USE COMMAS IN A NAME/EMAIL/ROOM NUMBER OR PHONE NUMBER!!!!!!\n");
                            }
                            else
                                runLoop = false;

                        } while (runLoop == true);


                        try
                        {
                            userBooked = true;
                            lines[roomNumber - 1] = roomNumber + "," + userName + "," + userPhone + "," + userEmail + "," + userBooked;
                            File.WriteAllLines("file.csv", lines);
                            bookSaved = true;
                        }
                        catch
                        {
                            Console.WriteLine("Room dosen't exist! Not saved!");
                            userBooked = false;
                            bookSaved = false;
                        }
                        if (bookSaved == true)
                        Console.WriteLine("Room Booked!");

                        Console.ReadLine();

                        
                        break;



                    case 3: // LookupRoom
                        Console.Clear();
                        runLoop = true;
                        roomNumber = 0;
                        do {
                            Console.WriteLine("Lookup Room!");
                            Console.Write("\n\nBooked Rooms: ");
                            for (i = 0; i < room.Length; i++)
                            {
                                if (room[i].booked == true)
                                    Console.Write(room[i].room + ", ");

                            }
                            Console.Write("\nEnter Room Number: ");
                            try
                            {
                                roomNumber = int.Parse(Console.ReadLine());
                                Console.Clear();
                                runLoop = false;
                                if (room[roomNumber -1].booked == true)
                                Console.WriteLine("Room: " + room[roomNumber - 1].room + "\nName: " + room[roomNumber - 1].name + "\nPhone: " + room[roomNumber - 1].phonenumber + "\nEmail: " + room[roomNumber - 1].email + "\nBooked: " + room[roomNumber -1].booked);
                                else
                                {
                                    Console.WriteLine("Room {0} - Available!", roomNumber);
                                }

                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Room! (You can only enter numbers!)\nTry Again!");
                                Console.ResetColor();

                                runLoop = true;
                            }
                            

                        } while (runLoop == true);


                     //   Console.WriteLine(roomNumber);
                        Console.ReadLine();
                        break;






                    case 4: // DeleteBooking

                        roomNumber = 0;
                        runLoop = true;
                        do
                        {
                            Console.WriteLine("Which Room? (WARNING! This will delete the booking!)");
                            Console.Write("Booked Rooms: ");
                            for (i = 0; i < room.Length; i++)
                            {
                                if (room[i].booked == true)
                                    Console.Write(room[i].room + ", ");

                            }
                            Console.Write("or 'c' to show overview and go back!");

                            Console.Write("\nRoom: ");
                            string sInput = Console.ReadLine();

                            if (sInput == "c" || sInput == "C" || sInput == "q")
                                  goto case 1;

                                try
                                {
                                    roomNumber = int.Parse(sInput);
                                    runLoop = false;
                                }
                                catch
                                {
                                Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid Input!");
                                Console.ResetColor();

                                runLoop = true;
                                }
                            
                        } while (runLoop == true);

                        Console.Clear();
                        userName = "";
                        userPhone = "";
                        userEmail = "";
                        userBooked = false;



                        try
                        {
                            lines[roomNumber - 1] = roomNumber + "," + userName + "," + userPhone + "," + userEmail + "," + userBooked;
                            File.WriteAllLines("file.csv", lines);
                            Console.WriteLine("Room: " + roomNumber + " was reset!");
                        }
                        catch
                        {
                            Console.WriteLine("Room dosen't exist! Not saved!");
                            userBooked = false;
                        }
                        Console.ReadLine();

                        break;





                    case 5: // Search By Phone Number
                        Console.Clear();
                        runLoop = true;
                        searchEmpty = true;
                        phoneNumber = "";
                        Console.WriteLine("Lookup By Phone!");

                        Console.Write("\nEnter Phone Number: ");
                        phoneNumber = Console.ReadLine();
                        if (phoneNumber == "")
                            break;
                        for (i = 0; i < room.Length; i++)
                        {
                            if (room[i].phonenumber.Contains(phoneNumber))
                            {
                                searchEmpty = false;
                                Console.WriteLine("\nRoom: " + room[i].room + "\nName: " + room[i].name + "\nPhone: " + room[i].phonenumber + "\nEmail: " + room[i].email + "\nBooked: " + room[i].booked);
                            }

                        }
                            if(searchEmpty == true)
                            Console.WriteLine("No Results!");
                        



                        //   Console.WriteLine(roomNumber);
                        Console.ReadLine();

                        break;







                    case 6:
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
