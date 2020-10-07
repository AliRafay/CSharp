using System;
using System.Collections.Generic;
using System.IO;

namespace Basic_Login_System
{
    class Program
    {

        class Accounts
        {
            protected string userName, password, name, DOB, cnic;
            protected bool isLoggedIn = false;
            public static List<string> UserNameList = new List<string>();  //to make better signup process, avoiding having two same userNames
            public static List<string[]> UserList = new List<string[]>();

            public static void Initiate()
            {
                Console.WriteLine("*********************************************\n" +
                                  "\t    SIMPLE LOGIN SYSTEM!!\n" +
                                  "*********************************************");
            }
            public Accounts()
            {
                getData();
            }
            public static void getData()
            {
                List<string> Credentials = new List<string>();

                // Read file line by line

                string line;
                StreamReader file = new StreamReader(@"C:\Users\Koderlabs\Desktop\C# Projects\Basic Login System\Login Credentials.txt");
                while ((line = file.ReadLine()) != null)
                {
                    Credentials.Add(line);
                }




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
            public void Login()
            {
                while (true)
                {
                    Console.WriteLine("Enter Username(Case sensitive): ");
                    userName = Console.ReadLine();
                    bool userExist = false;
                    foreach (string[] array in UserList)
                    {
                        if (userExist == false)
                        {
                            if (userName == array[0])
                            {
                                userExist = true;
                                Console.WriteLine("This User Exists!");
                                while (true)
                                {
                                    Console.WriteLine("Enter Password: ");
                                    password = Console.ReadLine();
                                    if (password == array[1])
                                    {
                                        isLoggedIn = true;
                                        Console.WriteLine("You have Successfully Logged in!");

                                        userName = array[0];
                                        password = array[1];
                                        name = array[2];           // Creates an instance of account when login
                                        DOB = array[3];
                                        cnic = array[4];


                                        userDisplay();
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

                        }
                        else
                        {
                            Console.WriteLine("User doesn't not exist\n" +
                                              "Press 1 to try again\n" +
                                              "Press 2 to Signup");
                            string choice = Console.ReadLine();
                            if (choice == "1")
                            {
                                continue;
                            }
                            else if (choice == "2")
                            {
                                signUp();
                                break;
                            }
                        }

                    }
                }
            }
            public void viewDetails()
            {
                Console.WriteLine("UserName: {0}", userName);
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("Date of Birth: {0}", DOB);
                Console.WriteLine("National Identification Number: {0}", cnic);

                userDisplay();
            }
            public void signUp()
            {
                while (true)
                {
                    Console.WriteLine("Enter your Username: ");
                    userName = Console.ReadLine();
                    if (UserNameList.Contains(userName))
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
                name = Console.ReadLine();
                Console.WriteLine("Enter your DOB: ");
                DOB = Console.ReadLine();
                Console.WriteLine("Enter your CNIC: ");
                cnic = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                password = Console.ReadLine();



                string[] pushData = { userName, password, name, DOB, cnic, "------------------------------" };
                File.AppendAllLines(@"C:\Users\Koderlabs\Desktop\C# Projects\Basic Login System\Login Credentials.txt", pushData);

                isLoggedIn = true;
                userDisplay();

            }

            public void logout()
            {
                Console.WriteLine("Are you sure? (Y/N)");
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    isLoggedIn = false;
                }

                userDisplay();
            }

            public void userDisplay()
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
                    Console.WriteLine("1: View Details ");
                    Console.WriteLine("2: Logout ");
                    Console.WriteLine("Press the corresponding number to proceed: ");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "1")
                    {
                        viewDetails(); // No view Details in Admin ????
                    }
                    else if (choice2 == "2")
                    {
                        logout();
                    }
                }



            }
        }

        static void Main(string[] args)
        {
            Accounts.Initiate();
            Accounts Acc = new Accounts();
            Acc.userDisplay();
        }
    }
}

