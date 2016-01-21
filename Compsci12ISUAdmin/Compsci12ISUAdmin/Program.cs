/*
Tianli Zhan
January 19, 2016
A small program meant only for system admins to add new admins and new clubs, as well as deleting them
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compsci12ISUAdmin
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string serverPath;
            const string REQUEST_PATH = "\\pseudo_requests\\SystemAdminRequest.txt";
            //check if the config file exits
            if (!File.Exists("config.txt"))
            {
                Console.WriteLine("config file missing");
                return;
            }
            //read the config file to get the server's path
            using (StreamReader sr = new StreamReader("config.txt"))
            {
                serverPath = sr.ReadLine();
            }
            //welcome the user
            Console.WriteLine("Welcome to the system admin only software, enter command below.\r\nType \"help\" for a list of commands");
            input = Console.ReadLine();
            while(input != "exit")
            {
                //shows user a list of commands when they enter help
                if(input == "help")
                {
                    Console.WriteLine("A list of commands:");
                    Console.WriteLine("create admin - starts the creation of a club admin");
                    Console.WriteLine("create club - starts the process of creating a club");
                    Console.WriteLine("assign club - starts the process of assigning a club to be manageable by an admin");
                    Console.WriteLine("exit - ends the program");
                }
                //if the the user chose to create a new admin
                else if(input == "create admin")
                {
                    //stores the username and password the user inputs
                    string username;
                    string password;
                    //prompt the user for username and password, and store the inputs
                    Console.Write("New Username: ");
                    username = Console.ReadLine();
                    Console.Write("New Password: ");
                    password = Console.ReadLine();
                    //sends the request
                    using (StreamWriter sw = new StreamWriter(serverPath + REQUEST_PATH))
                    {
                        sw.WriteLine("NEW CLUBADMIN");
                        sw.WriteLine(username);
                        sw.WriteLine(password);
                    }
                }
                ////if the user choose to delete an admin
                //else if(input == "delete admin")
                //{
                //    //stores the username
                //    string username;
                //    //prompt the user for username and stores it
                //    Console.Write("Username of admin to delete: ");
                //    username = Console.ReadLine();
                //    //sends the request
                //    using (StreamWriter sw = new StreamWriter(serverPath + REQUEST_PATH))
                //    {
                //        sw.WriteLine("DELETE CLUBADMIN");
                //        sw.WriteLine(username);
                //    }
                //}
                //if the user choose to create a club
                else if(input == "create club")
                {
                    //stores the clubname
                    string clubName;
                    //prompt the user for club name and stores it
                    Console.Write("New Club Name: ");
                    clubName = Console.ReadLine();
                    //sends the request
                    using (StreamWriter sw = new StreamWriter(serverPath + REQUEST_PATH))
                    {
                        sw.WriteLine("NEW CLUB");
                        sw.WriteLine(clubName);
                    }
                }
                //if the user choose to assign a club to an admin to have permission to manage
                else if(input == "assign club")
                {
                    //stores the name of the club and username of the admin
                    string club;
                    string admin;
                    //prompt the user to input the club name and username of admin, and store the inputs
                    Console.Write("Name of club: ");
                    club = Console.ReadLine();
                    Console.Write("Username of admin to give permission to: ");
                    admin = Console.ReadLine();
                    //sends the request
                    using (StreamWriter sw = new StreamWriter(serverPath + REQUEST_PATH))
                    {
                        sw.WriteLine("ASSIGN");
                        sw.WriteLine(club);
                        sw.WriteLine(admin);
                    }
                }
                else
                {
                    //otherwise the command is invalid
                    Console.WriteLine("Invalid command");
                }
                input = Console.ReadLine();
            }
        }
    }
}
