using System;
using System.IO;
using System.Collections.Generic;
namespace WillHuck
{
    class Program
    {
        static List<Ticket> tickets = new List<Ticket>();
        static void Main(string[] args)
        {
            //Main Menu / Screen
            string menuInput = "";
            string file = "Tickets.csv";
            Console.WriteLine("Welcome to TicketFest!");
            //check if tickets.csv exists, parse file and create ticket objects and dump into List<Ticket> tickets
            if(System.IO.File.Exists(file)) {
                StreamReader sr = new StreamReader(file);
                Console.WriteLine($"reading {file}");
                //grab file data line by line and display it
                while(!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    string[] props = line.Split(",");
                    tickets.Add(new Ticket(props[0],props[1],props[2],props[3],props[4],props[5],props[6]) );
                    Console.WriteLine($"Created Ticket{props[0]}");
                }
                sr.Close();
            } else { //create file
                Console.WriteLine("Ticket file not found, creating /Tickets.csv");
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine("0,Summary,Status,Priority,Submitter,Assigned,Watching1|Watching2");
                tickets.Add(new Ticket("0","Summary","Status","Priority","Submitter","Assigned","Watching1|Watching2"));
                sw.Close();
            }

            //loop menu options until quit is selected
            while (menuInput != "0") {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1]Display Tickets");
                Console.WriteLine("[2]Create Ticket");
                Console.WriteLine("[0]Quit");
                //grab input
                menuInput = Console.ReadLine();

                //Display tickets... ie read List tickets and display data
                if(menuInput == "1") {
                    //display column headers
                    Console.WriteLine($"{"Ticket ID", 12}{"Summary",30}{"Status",12}{"Priority",12}{"Submitter",12}{"Assigned",12}{"Watching",45}");
                    //loop through List<Ticket> ticketlist and display Ticket Object properties
                    foreach (Ticket t in tickets) {
                        
                        Console.WriteLine(t.ToString());
                    }                    
                }
                //create ticket line in file
                else if(menuInput =="2"){
                    //ask for each ticket field then smush em together and write to file
                    if(System.IO.File.Exists(file)) {
                        StreamWriter sw = new StreamWriter(file, append: true);
                        string[] input = new string[7];
                        Console.WriteLine("Ticket ID:");
                        input[0] = Console.ReadLine();
                        Console.WriteLine("Summary:");
                        input[1] = Console.ReadLine();
                        Console.WriteLine("Status:");
                        input[2] = Console.ReadLine();
                        Console.WriteLine("Priority:");
                        input[3] = Console.ReadLine();
                        Console.WriteLine("Submitter:");
                        input[4] = Console.ReadLine();
                        Console.WriteLine("Assigned:");
                        input[5] = Console.ReadLine();
                        Console.WriteLine("Watching:");
                        input[6] = Console.ReadLine();
                        Ticket t = new Ticket(input[0],input[1],input[2],input[3],input[4],input[5],input[6]);
                        Console.WriteLine(t.ToFileString());
                        sw.WriteLine(t.ToFileString());
                        sw.Close();
                        tickets.Add(t);
                    }
                }                
            }
        }
    }
}
