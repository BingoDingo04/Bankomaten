using System;

namespace Bankomaten
{
    internal class Program
    {
        static void Main(string[] args)
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
    }
}
