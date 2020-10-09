using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Basic_Login_System
{
    class Program
    {
        class Display
        {
            public static bool isLoggedIn = false;
            public static bool isAdmin = false;
            public static List<string> UserNameList = new List<string>();  //to make better signup process, avoiding having two same userNames
            public static List<string[]> UserList = new List<string[]>();
            public static void Initiate()
            {
                Console.WriteLine("*********************************************\n" +
                                  "\t    SIMPLE LOGIN SYSTEM!!\n" +
                                  "*********************************************");
            }
            public static void Login()
            {
                Display.FetchData();
                isAdmin = false;
                string userName, password = "", name = "", DOB = "", cnic = "";
                Console.WriteLine("Enter Username(Case sensitive): ");
                userName = Console.ReadLine();
                if (UserNameList.Contains(userName))
                {
                    int userIndex = UserNameList.IndexOf(userName);

                    if (userName == "Admin")
                    {
                        isAdmin = true;
                    }

                    Console.WriteLine("This User Exists!");
                    while (true)
                    {
                        Console.WriteLine("Enter Password: ");
                        password = AsteriskPassword();
                        if (password == UserList[userIndex][1])
                        {
                            isLoggedIn = true;
                            Console.WriteLine("You have Successfully Logged in!");

                            userName = UserList[userIndex][0];
                            password = UserList[userIndex][1];
                            name = UserList[userIndex][2];           // Creates an instance of account when login
                            DOB = UserList[userIndex][3];
                            cnic = UserList[userIndex][4];

                            //userDisplay();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("You have Entered the wrong Password!\n" +
                                              "Press 1 to try again\n" +
                                              "Press 2 to exit");
                            string choice = Console.ReadLine();
                            if (choice == "1")
                            {
                                continue;
                            }
                            else if (choice == "2")
                            {
                                break;
                            }
                        }
                    }
                }

                else
                {
                    Console.WriteLine("User doesn't not exist\n" +
                                      "Press 1 to try again\n" +
                                      "Press 2 to Signup");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Login();
                    }
                    else if (choice == "2")
                    {
                        signUp();

                    }
                }
                if (isLoggedIn && isAdmin)
                {
                    Admin Admin = new Admin();
                }
                else if (isLoggedIn && (!isAdmin))
                {
                    User User = new User(userName, password, name, DOB, cnic);

                }
            }
            public static void signUp()
            {
                string userNameTemp, passwordTemp, nameTemp, DOBTemp, cnicTemp;
                while (true)
                {
                    Console.WriteLine("Enter your Username: ");
                    userNameTemp = Console.ReadLine();
                    if (UserNameList.Contains(userNameTemp))
                    {
                        Console.WriteLine("Username already taken!\n" +
                                          "Try again...");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("Enter your Name: ");
                nameTemp = Console.ReadLine();
                Console.WriteLine("Enter your DOB: ");
                DOBTemp = Console.ReadLine();
                Console.WriteLine("Enter your CNIC: ");
                cnicTemp = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Enter password: ");
                    string pass1 = AsteriskPassword();
                    Console.WriteLine("Confirm password: ");
                    string pass2 = AsteriskPassword();
                    if (pass1 == pass2)
                    {
                        passwordTemp = pass1;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The Passwords Doesnt Match!\n" +
                            "Please try Again!");

                    }
                }


                string[] pushData = { userNameTemp, passwordTemp, nameTemp, DOBTemp, cnicTemp, "------------------------------" };
                File.AppendAllLines(@"C:\Users\Koderlabs\Desktop\C# Projects\Basic Login System\Login Credentials.txt", pushData);

                Display.Login();

            }
            public static void FetchData()
            {
                UserNameList.Clear();
                UserList.Clear();
                List<string> Credentials = new List<string>();

                // Read file line by line

                string line;
                StreamReader file = new StreamReader(@"C:\Users\Koderlabs\Desktop\C# Projects\Basic Login System\Login Credentials.txt");
                while ((line = file.ReadLine()) != null)
                {
                    Credentials.Add(line);
                }
                file.Close();



                for (int i = 0; i < Credentials.Count; i += 6) // 6 because we have a line breaker 
                {
                    string[] Arr =
                    {
                        Credentials[i],
                        Credentials[i+1],
                        Credentials[i+2],
                        Credentials[i+3],
                        Credentials[i+4],

                    };

                    UserNameList.Add(Credentials[i]);   //to create a list of all usernames

                    UserList.Add(Arr);
                    Arr = null;

                }

            }
            public static void userDisplay1()
            {
                while (true)
                {
                    if (!isLoggedIn)
                    {
                        Console.WriteLine("1: Login ");
                        Console.WriteLine("2: SignUp ");
                        Console.WriteLine("3: Exit ");
                        Console.WriteLine("Press the corresponding number to proceed: ");
                        string choice1 = Console.ReadLine();
                        if (choice1 == "1")
                        {
                            Login();
                        }
                        else if (choice1 == "2")
                        {
                            signUp();
                        }
                        else if (choice1 == "3")
                        {
                            Environment.Exit(0);  // exits program successfully
                        }
                    }
                    else
                    {
                        break;
                    }
                    
                }


            }


        }
        public static string AsteriskPassword()
        {
            string EnteredVal = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work  
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    EnteredVal += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && EnteredVal.Length > 0)
                    {
                        EnteredVal = EnteredVal.Substring(0, (EnteredVal.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (string.IsNullOrWhiteSpace(EnteredVal))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Empty value not allowed.");
                            AsteriskPassword();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("");
                            break;
                        }
                    }
                }
            } while (true);
            return EnteredVal;
        }
        class Accounts
        {
            protected string userName, password, name, DOB, cnic;
            public static List<string[]> UserList = Display.UserList;
            public static List<string> UserNameList = Display.UserNameList;
            public void viewDetails()
            {
                Console.WriteLine("UserName: {0}", userName);
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("Date of Birth: {0}", DOB);
                Console.WriteLine("National Identification Number: {0}", cnic);

                //userDisplay();
            }
            public void logout()
            {
                Console.WriteLine("Are you sure? (Y/N)");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    Display.isLoggedIn = false;
                    Display.userDisplay1(); 
                        
                }
            }
            virtual public void userDisplay2()
            {

            }
        }

        class User : Accounts
        {
            public User(string uName, string pswd, string nm, string DB, string nic)
            {
                userName = uName;
                password = pswd;
                name = nm;
                DOB = DB;
                cnic = nic;

                userDisplay2();
            }
            public override void userDisplay2()
            {
                while (true)
                {
                    Console.WriteLine("1: View Details ");
                    Console.WriteLine("2: Logout ");
                    Console.WriteLine("Press the corresponding number to proceed: ");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "1")
                    {
                        viewDetails();
                    }
                    else if (choice2 == "2")
                    {
                        logout();
                    }

                }


            }
        }

        class Admin : Accounts
        {
            public Admin()
            {
                userDisplay2();
            }
            public void ViewAllUsers()
            {
                Display.FetchData();
                foreach (string[] array in Display.UserList)
                {
                    Console.WriteLine("User Name: {0}", array[0]);
                    Console.WriteLine("Full Name: {0}", array[2]);  //1 holds the password which we dont want to show
                    Console.WriteLine("Date Of Birth: {0}", array[3]);
                    Console.WriteLine("CNIC Number: {0}", array[4]);
                    Console.WriteLine("------------------------------");

                }

            }
            public void DeleteUser()
            {
                Console.WriteLine("Please Select Which Users do u want to delete");
                for (int i = 0; i < UserNameList.Count; i++)
                {
                    Console.Write(i + 1 + ") "); Console.WriteLine(UserNameList[i]);
                }
                int choice = int.Parse(Console.ReadLine());
                File.Delete(@"C:\Users\Koderlabs\Desktop\C# Projects\Basic Login System\Login Credentials.txt");
                Console.WriteLine("user deleted\n");
                for (int j = 0; j < UserList.Count; j++)
                {
                    if (j != choice - 1)
                    {
                        string[] pushData = { UserList[j][0], UserList[j][1], UserList[j][2], UserList[j][3], UserList[j][4], "------------------------------" };
                        File.AppendAllLines(@"C:\Users\Koderlabs\Desktop\C# Projects\Basic Login System\Login Credentials.txt", pushData);
                    }
                }
            }
            public override void userDisplay2()
            {
                while (true)
                {
                    Console.WriteLine("1: View All Users ");
                    Console.WriteLine("2: Delete A User ");
                    Console.WriteLine("3: Logout ");
                    Console.WriteLine("Press the corresponding number to proceed: ");
                    string choice2 = Console.ReadLine();

                    if (choice2 == "1")
                    {
                        ViewAllUsers();
                        
                    }
                    else if (choice2 == "2")
                    {
                        DeleteUser();
                        

                    }
                    else if (choice2 == "3")
                    {
                        logout();
                    }
                }

            }
        }
        static void Main(string[] args)
        {
            Display.FetchData();
            Display.Initiate();
            Display.userDisplay1();
        }
    }
}

