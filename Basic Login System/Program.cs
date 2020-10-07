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
            public static List<string[]> UserList = new List<string[]>();

            //public static List<string> userNameList = new List<string>();
            //public static List<string> passwordList = new List<string>();

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


                //int i = 0;
                //while (i < Credentials.Count)
                //{
                //    if (i % 2 == 0 || i == 0)
                //    {
                //        userNameList.Add(Credentials[i]);
                //    }
                //    else
                //    {
                //        passwordList.Add(Credentials[i]);
                //    }
                //    i++;
                //}

                for (int i = 0; i < Credentials.Count; i += 5)
                {
                    string[] Arr =
                    {
                        Credentials[i],
                        Credentials[i+1],
                        Credentials[i+2],
                        Credentials[i+3],
                        Credentials[i+4],

                    };
                    UserList.Add(Arr);
                    Arr = null;

                }

            }
            public void Login()
            {
                getData();
                while (true)
                {
                    Console.WriteLine("Enter Username(Case sensitive): ");
                    userName = Console.ReadLine();
                    foreach (string[] array in UserList)
                    {
                        if (userName == array[0])
                        {
                            Console.WriteLine("This User Exists!");
                            while (true)
                            {
                                Console.WriteLine("Enter Password: ");
                                password = Console.ReadLine();
                                if (password == array[1])
                                {
                                    isLoggedIn = true;
                                    Console.WriteLine("You have Successfully Logged in!");
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
                            //if (userNameList.Contains(userName))
                            //{
                            //    int userIndex = userNameList.IndexOf(userName);
                            //    Console.WriteLine("This User Exists!");
                            //    while (true)
                            //    {
                            //        Console.WriteLine("Enter Password: ");
                            //        password = Console.ReadLine();
                            //        if (password == passwordList[userIndex])
                            //        {
                            //            isLoggedIn = true;
                            //            Console.WriteLine("You have Successfully Logged in!");
                            //            userDisplay();
                            //            break;
                            //        }
                            //        else
                            //        {
                            //            Console.WriteLine("You have Entered the wrong Password!\n" +
                            //                              "Press 1 to try again\n" +
                            //                              "Press 2 to exit");
                            //            string choice = Console.ReadLine();
                            //            if (choice == "1")
                            //            {
                            //                continue;
                            //            }
                            //            else if (choice == "2")
                            //            {
                            //                break;
                            //            }


                            //        }
                            //    }
                            //    break;
                            //}

                            //else
                            //{
                            //    Console.WriteLine("User doesn't not exist\n" +
                            //                      "Press 1 to try again\n" +
                            //                      "Press 2 to Signup");
                            //    string choice = Console.ReadLine();
                            //    if (choice == "1")
                            //    {
                            //        continue;
                            //    }
                            //    else if (choice == "2")
                            //    {
                            //        signUp();
                            //        break;
                            //    }
                            //}
                        }
                    }
                    break;    //continue from here
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
                //while (true)
                //{
                    Console.WriteLine("Enter your Username: ");
                    userName = Console.ReadLine();
                //    if (userNameList.Contains(userName))
                //    {
                //        Console.WriteLine("Username already taken!\n" +
                //                          "Try again...");
                //        continue;
                //    }
                //    else
                //    {
                //        break;
                //    }
                //}
                Console.WriteLine("Enter your Name: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter your DOB: ");
                DOB = Console.ReadLine();
                Console.WriteLine("Enter your CNIC: ");
                cnic = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                password = Console.ReadLine();



                string[] pushData = { userName, password, name, DOB, cnic };
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
                    Console.WriteLine("Press the corresponding number to proceed: ");
                    string choice1 = Console.ReadLine();
                    if (choice1 == "1")
                    {
                        Login();
                    }
                    if (choice1 == "2")
                    {
                        signUp();
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
                    if (choice2 == "2")
                    {
                        logout();
                    }
                }



            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*********************************************\n" +
                              "\t    SIMPLE LOGIN SYSTEM!!\n" +
                              "*********************************************");
            Accounts Acc = new Accounts();
            Acc.userDisplay();
        }
    }
}

