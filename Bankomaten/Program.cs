using System;

namespace Bankomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) // Keeps the program running for login/logout loop
            {
                Console.WriteLine("Välkommen till Bank AB!");

                // Array för användare där varje rad representerar {användarID, lösenord}
                int[,] users = { { 1, 1111 }, { 2, 2222 }, { 3, 3333 }, { 4, 4444 }, { 5, 5555 } };

                // User ID input
                Console.WriteLine("Vänligen skriv in användar ID:");
                int userID = Convert.ToInt32(Console.ReadLine());

                // Check if the user exists
                int userIndex = GetUserIndex(users, userID);
                if (userIndex != -1)
                {
                    Console.WriteLine("Vänligen skriv in lösenordet (xxxx):");

                    // Attempt to log in with password (max 3 attempts)
                    bool loginSuccessful = AuthenticateUser(users, userIndex);

                    if (loginSuccessful)
                    {
                        Console.WriteLine("Inloggning Lyckades!");

                        // Loop for the main menu after login until the user logs out
                        bool loggedIn = true;
                        while (loggedIn)
                        {
                            // Menu
                            Console.Clear();
                            Console.WriteLine("Vad vill du göra?");
                            Console.WriteLine("1. Se dina konton och saldo");
                            Console.WriteLine("2. Överföring mellan konton");
                            Console.WriteLine("3. Ta ut pengar");
                            Console.WriteLine("4. Logga ut");

                            string choice = Console.ReadLine();

                            // Switch case to handle user choice
                            switch (choice)
                            {
                                case "1":
                                    ShowAccounts();
                                    break;
                                case "2":
                                    TransferBetweenAccounts();
                                    break;
                                case "3":
                                    WithdrawMoney();
                                    break;
                                case "4":
                                    loggedIn = false;
                                    Console.WriteLine("Du har loggats ut.");
                                    break;
                                default:
                                    Console.WriteLine("Ogiltigt val, försök igen.");
                                    break;
                            }

                            if (loggedIn)
                            {
                                Console.WriteLine("Klicka enter för att komma till huvudmenyn.");
                                Console.ReadLine(); // Waits for user to press enter before clearing screen
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du skrev in fel lösenord för många gånger! Starta om programmet.");
                    }
                }
                else
                {
                    Console.WriteLine("Användaren finns ej!");
                }
            }
        }

        // Function to find the user's index based on user ID
        static int GetUserIndex(int[,] users, int userID)
        {
            for (int i = 0; i < users.GetLength(0); i++)
            {
                if (users[i, 0] == userID)
                {
                    return i;
                }
            }
            return -1;
        }

        // Function to authenticate the user with password
        static bool AuthenticateUser(int[,] users, int userIndex)
        {
            for (int i = 0; i < 3; i++) // Max 3 försök
            {
                int userPSWD = Convert.ToInt32(Console.ReadLine());

                if (users[userIndex, 1] == userPSWD)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Fel lösenord! Försök igen.");
                }
            }
            return false;
        }

        // Dummy function to simulate showing accounts and balance
        static void ShowAccounts()
        {
            Console.WriteLine("Dina konton och saldon:");
            Console.WriteLine("1. Sparkonto: 5000 kr");
            Console.WriteLine("2. Lönekonto: 12000 kr");
        }

        // Dummy function to simulate transfer between accounts
        static void TransferBetweenAccounts()
        {
            Console.WriteLine("Överföring mellan konton:");
            Console.WriteLine("Du har överfört 500 kr från Sparkonto till Lönekonto.");
        }

        // Dummy function to simulate withdrawing money
        static void WithdrawMoney()
        {
            Console.WriteLine("Ta ut pengar:");
            Console.WriteLine("Du har tagit ut 1000 kr.");
        }
    }
}
