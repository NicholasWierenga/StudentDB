    public class Program
    {
        public static void Main()
        {
            string strInput;
            int numInput;
            bool validResponse;

            List<string> name = new List<string> { "Casey", "Hannah", "Jake", "Jared", "Jimmy", "John", "Nick", "Scott", "Zach" };
            List<string> homeTown = new List<string> { "Grand Rapids", "Grandville", "Detroit", "New York", "Detroit", "Atlanta", "New Orleans", "Detroit", "Detroit" };
            List<string> favFood = new List<string> { "spaghetti", "pizza", "ramen noodles", "cake", "Hershey's chocolate", "ice cream", "pancakes", "steak", "hotdog" };
            List<int> favPrime = new List<int> { 4973, 5737, 4051, 3407, 5807, 4363, 8053, 9157, 9769 };

            Console.Write("Welcome! ");

            do
            {
                while (true) // Checks if user wants to add a student's info or query the lists.
                {
                    strInput = GetUserInput("Would you like to add a student and their info or select a student? Enter \"add\" or \"select.\"").ToLower();

                    if (strInput == "add" || strInput == "select")
                    {
                        break;
                    }
                    else
                        Console.WriteLine("There was something wrong with that input. Let's try again.");
                }

                if (strInput == "add")
                {
                    int arrayNum = 0;
                    int index = -1;

                    while (arrayNum <= 4) // Iterates through our arrays, hopefully putting data in the correct spot.
                    {
                        arrayNum++;
                        switch (arrayNum)
                        {
                            case 1:
                                strInput = GetUserInput("Please enter the new student's first name.").ToLower();
                                name.Add(char.ToUpper(strInput[0]) + strInput.Substring(1)); // Makes the name capitalized.
                                name.Sort();
                                index = name.IndexOf(char.ToUpper(strInput[0]) + strInput.Substring(1));
                                continue;
                            case 2:
                                strInput = GetUserInput("Please enter their hometown.");
                                homeTown.Insert(index, strInput);
                                continue;
                            case 3:
                                strInput = GetUserInput("Please enter their favorite food.");
                                favFood.Insert(index, strInput);
                                continue;
                            case 4:
                                List<int> primes = getPrimes();
                                while (true)
                                {
                                    strInput = GetUserInput("Please enter their favorite prime between 3000 to 10000.");

                                    if (int.TryParse(strInput, out numInput))
                                    {
                                        if (numInput > 10000 || numInput < 3000)
                                        {
                                            Console.WriteLine("That is not a prime between 3 and 10 thousand.");
                                        }
                                        else if (primes.Contains(numInput))
                                        {
                                            break;
                                        }
                                    }

                                }
                                favPrime.Insert(index, numInput);
                                continue;
                        }
                    }

                }
                else if (strInput == "select")
                {

                    while (true) // Validates user input by checking if the name they put exists in the list or if the integer they put in is correct.
                    {
                        strInput = GetUserInput("Please enter a number from 1-" + name.Count + " or a student's name to select a student. \n" +
                            "If you would like to see data for all students enter 0.").ToLower();


                        if (int.TryParse(strInput, out numInput) && numInput <= name.Count && numInput >= 0)
                        { // Looks to see if they entered a number that is valid.
                            numInput = int.Parse(strInput);
                            break;
                        }
                        else if (name.Contains(strInput.Substring(0, 1).ToUpper() + strInput.Substring(1)))
                        {
                            numInput = name.IndexOf(strInput.Substring(0, 1).ToUpper() + strInput.Substring(1)) + 1;
                            break;
                        }
                        else if (numInput < 0 || numInput > name.Count)
                        {
                            Console.WriteLine("This is an invalid integer. Valid integers are 0 to " + name.Count + ". Let's try again");
                            continue;
                        }
                        else

                            Console.WriteLine("That input is invalid. Let's try again.");

                    }

                    if (numInput == 0) // Prints out all student data.
                    {
                        Console.WriteLine("Here is a list of all student info.");
                        for (int i = 0; i < name.Count; i++)
                            Console.WriteLine(name[i] + " has the number " + (i + 1) + ". Their hometown is " + homeTown[i] + ". Their Favorite food is "
                                + favFood[i] + ". Their favorite prime number is " + favPrime[i] + ".");
                    }
                    else // For if someone selected a particular student.
                    {
                        Console.WriteLine("Enter \"hometown\", \"favorite food\", or \"favorite prime\" for " + name[numInput - 1] +
                            "'s hometown, favorite food, or favorite prime number, respectively.");

                        do // Gets input and checks if it contains a phrase corresponding to favorite food or hometown.
                        {
                            strInput = Console.ReadLine().ToLower();


                            if (strInput.Contains("food"))
                            {                     // Below was to make sure the first letter of the word is capitalized.
                                Console.WriteLine(char.ToUpper(favFood[numInput - 1][0]) + favFood[numInput - 1].Substring(1) + " is " + name[numInput - 1] + "'s favorite food.");
                                break;
                            }
                            else if (strInput.Contains("home") || strInput.Contains("town"))
                            {
                                Console.WriteLine(homeTown[numInput - 1] + " is " + name[numInput - 1] + "'s hometown.");
                                break;
                            }
                            else if (strInput.Contains("prime") || strInput.Contains("num"))
                            {
                                Console.WriteLine(favPrime[numInput - 1] + " is " + name[numInput - 1] + "'s favorite prime number.");
                                break;
                            }

                            Console.WriteLine("Please enter the correct keyword, which is either \"hometown,\" \"favorite food,\" or \"favorite prime. \"");

                        } while (true);
                    }
                }

            } while (RunAgain());
        }

        public static string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            string output = Console.ReadLine().Trim();

            if (output.Length == 0)
            {
                Console.WriteLine("Input must be not be blank or only spaces. Let's try again.");
                return GetUserInput(prompt);
            }

            return output;
        }

        public static bool RunAgain()
        {
            string input = GetUserInput("Would you like to try selecting a student again? y/n");

            if (input.ToLower() == "y")
            {
                return true;
            }
            else if (input.ToLower() == "n")
            {
                Console.WriteLine("Goodbye.");
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that lets try again");
                return RunAgain();
            }
        }

        public static List<int> getPrimes()
        {
            List<int> primes = new List<int>();

            for (int i = 2; i <= 10000; i++)
            {
                primes.Add(i);
            }

            for (int i = 2; i <= Math.Pow(10000, 1.0 / 2.0); i++)
            {
                for (int j = i + 1; j <= primes.Count; j++)
                {
                    if (primes[j - 1] % i == 0)
                    {
                        primes.RemoveAt(j - 1);
                    }
                }
            }

            return primes;
        }
    }