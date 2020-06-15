using System;
namespace adamBrittain_cab301_assignment
{
    // Class used by program to control user input for adding members and movies.
    public class HelperFunctions
    {

        // Function th
        public static bool CheckInput(string s, int i)
        {
            // Check to see if anything has been entered.
            if (s.Length >= 1)
            {
                // Check if it was just white space.
                if (s.Trim() == "")
                {

                    Console.WriteLine("Incorrect input - " +
                            "must be letters or numbers only.");
                    Console.WriteLine();
                    return false;
                }
                else
                {
                    //if i is 0, allow numbers and letters.
                    if (i == 0)
                    {
                        foreach (char c in s)
                        {

                            if (!char.IsLetter(c) &&
                                !char.IsWhiteSpace(c) && !char.IsNumber(c))
                            {
                                Console.WriteLine("Incorrect input - " +
                                "must be letters or numbers only.");
                                Console.WriteLine();
                                return false;
                            }
                        }
                        return true;
                    }
                    // if i is 1, allow only letters.
                    else if (i == 1)
                    {
                        foreach (char c in s)
                        {

                            if (!char.IsLetter(c) &&
                                !char.IsWhiteSpace(c))
                            {
                                Console.WriteLine("Incorrect input - " +
                                "must be letters only.");
                                Console.WriteLine();
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                    
                }
            }
            else
            {
                Console.WriteLine("Incorrect input - " +
                            "must be letters or numbers only.");
                Console.WriteLine();
                return false;
            }
        }



        // Function that controls user input when prompting user to enter new
        // movie details.
        public static void Insert(MovieCollection.MovieTree BST)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----ENTER MOVIE DETAILS----");
            Console.WriteLine();


            // Create flag used to check user input.
            bool correct = false;

            // Prompt user to enter movie title
            Console.Write("Enter movie title: ");
            string movieTitle = Console.ReadLine(); ;

            // Enter movie title.
            while (!correct)
            {
                correct = CheckInput(movieTitle, 0);
                if (!correct)
                {
                    Console.Write("Enter movie title: ");
                    movieTitle = Console.ReadLine();
                }
            }


            // Check to see if the movie exists
            // in the BST before creating a new copy.
            Movie movieExists = BST.ReturnMovie(BST.ReturnRoot(), movieTitle);


            // If the movie exists, prompt user to enter an amount to add to database.
            if (movieExists != null)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Movie already" +
                    " exists in database: How many" +
                    " copies do you want to add?");
                correct = false;
                int n = 0;
                correct = int.TryParse(Console.ReadLine(), out int movieAmount);
                // Check user input
                while (!correct || movieAmount <= 0 || movieAmount >= 1000)
                {
                    if (!correct || movieAmount <= 0 || movieAmount >= 1000)
                    {
                        Console.Write("Please enter a number for copies " +
                            "between 1 and 1000: ");
                    }
                    correct = int.TryParse(Console.ReadLine(), out movieAmount);
                }

                n = movieAmount;
                Console.WriteLine();
                Console.WriteLine();

                // Increase copies available by number
                movieExists.IncreaseCopiesAvail(n);
                Console.WriteLine(movieExists.GetTitle() +
                    " copies increased by " +
                    n);

            }

            // If movie doesnt exist prompt user for input about movie.
            else
            {
                // Check user input for actors
                Console.WriteLine();

                correct = false;
                Console.Write("Enter starring actors: ");
                string starring = Console.ReadLine();
                while (!correct)
                {
                    correct = CheckInput(starring, 1);
                    if (!correct)
                    {
                        Console.Write("Enter starring actors: ");
                        starring = Console.ReadLine();
                    }
                }


                // Check user input for directors
                Console.WriteLine();

                correct = false;
                Console.Write("Enter movie director: ");
                string director = Console.ReadLine();
                while (!correct)
                {

                    correct = CheckInput(director, 1);
                    if (!correct)
                    {
                        Console.Write("Enter movie director: ");
                        director = Console.ReadLine();
                    }
                }


                // Check user input for genre
                Console.WriteLine();

                correct = false;
                string genre = "empty";
                Console.WriteLine("Choose Genre: \n" +
                                "1. Drama\n" +
                                "2. Family\n" +
                                "3. Action\n" +
                                "4. SciFi\n" +
                                "5. Comedy\n" +
                                "6. Animated\n" +
                                "7. Thriller\n" +
                                "8. Other\n" +
                                "Enter Number between 1-8: ");

                correct = int.TryParse(Console.ReadLine(), out int num);
                while (!correct || num <= 0 || num >= 9)
                {
                    Console.WriteLine("Please enter a number between 1 and 8.");
                    correct = int.TryParse(Console.ReadLine(), out num);
                }


                // Set genre based off switch case
                switch (num)
                {
                    case 1:
                        genre = "Drama";
                        break;

                    case 2:
                        genre = "Family";
                        break;

                    case 3:
                        genre = "Action";
                        break;

                    case 4:
                        genre = "SciFi";
                        break;

                    case 5:
                        genre = "Comedy";
                        break;

                    case 6:
                        genre = "Animated";
                        break;

                    case 7:
                        genre = "Thriller";
                        break;

                    case 8:
                        genre = "Other";
                        break;

                    default:

                        break;
                }


                // Check user input for classification
                Console.WriteLine();

                correct = false;
                string classification = "empty";
                Console.Write("Enter classification: \n" +
                            "1. G\n" +
                            "2. PG\n" +
                            "3. M 15+\n" +
                            "4. MA 15+\n" +
                            "5. R 18+\n" +
                            "Enter Number between 1-5: ");

                correct = int.TryParse(Console.ReadLine(), out num);
                while (!correct || num <= 0 || num >= 6)
                {
                    Console.WriteLine("Please enter a number between 1 and 5.");
                    correct = int.TryParse(Console.ReadLine(), out num);
                }

                // Set classification based off switch case
                switch (num)
                {
                    case 1:
                        classification = "G";
                        break;

                    case 2:
                        classification = "PG";
                        break;

                    case 3:
                        classification = "M 15+";
                        break;

                    case 4:
                        classification = "MA 15+";
                        break;

                    case 5:
                        classification = "R 18+";
                        break;

                    default:

                        break;
                }


                // Check user input for duration
                Console.WriteLine();

                correct = false;
                int duration = 0;
                Console.Write("Enter duration: ");

                correct = int.TryParse(Console.ReadLine(), out num);
                while (!correct || num <= 0 || num >= 600)
                {
                    Console.WriteLine("Please enter a number for duration " +
                        "- 1.30 hr = 90 min for example.");
                    Console.WriteLine();
                    Console.Write("Enter duration: ");

                    correct = int.TryParse(Console.ReadLine(), out num);
                }

                duration = num;


                // Check user input for date
                Console.WriteLine();

                DateTime releaseDate = DateTime.Now;
                correct = false;
                while (!correct)
                {
                    try
                    {
                        Console.Write("Enter release date (dd/mm/yyyy): ");
                        releaseDate =
                        DateTime.Parse(Console.ReadLine());
                        correct = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong date and time format - please enter dd/mm/yyyy");
                        Console.WriteLine();
                    }
                }


                // Check user input for amount of copies
                Console.WriteLine();
                correct = false;
                int copiesAvail = 1;
                Console.Write("Enter amount of copies: ");

                correct = int.TryParse(Console.ReadLine(), out num);
                while (!correct || num <= 0 || num >= 1000)
                {
                    Console.WriteLine("Please enter a number for copies " +
                            "between 1 and 1000.");
                    Console.WriteLine();
                    Console.Write("Enter amount of copies: ");
                    correct = int.TryParse(Console.ReadLine(), out num);
                }

                copiesAvail = num;


                //Create new movie and it to BST tree.
                Console.WriteLine();
                Movie movie = new Movie(movieTitle, starring
                    , director, duration, genre, classification, releaseDate, copiesAvail, 0);
                Console.WriteLine("New movie " + movie.GetTitle() + " added to database.");
                BST.Insert(movie);
            }
        }



        // Function that controls user input when prompting user to enter new
        // user details.
        public static void AddUser(MemberCollection memberCollection)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----ENTER USER DETAILS----");
            Console.WriteLine();


            // Prompt for first name and checks input
            bool correct = false;
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine(); ;

            while (!correct)
            {
                correct = HelperFunctions.CheckInput(firstName, 1);
                if (!correct)
                {
                    Console.Write("Enter First Name: ");
                    firstName = Console.ReadLine();
                }
            }

            // Prompt for last name and checks input
            Console.WriteLine();
            correct = false;
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine(); ;

            while (!correct)
            {
                correct = CheckInput(lastName, 1);
                if (!correct)
                {
                    Console.Write("Enter Last Name: ");
                    lastName = Console.ReadLine();
                }
            }


            // Prompt for address and checks input
            Console.WriteLine();
            correct = false;
            Console.Write("Enter Address: ");
            string address = Console.ReadLine(); ;

            while (!correct)
            {
                correct = CheckInput(address, 0);
                if (!correct)
                {
                    Console.Write("Enter Address: ");
                    address = Console.ReadLine();
                }
            }

            // Prompt for phone number and checks input
            Console.WriteLine();
            correct = false;
            Console.Write("Enter Phone Number: ");
            string phNo = Console.ReadLine();
            correct = int.TryParse(phNo, out int num);
            int phoneNumber = num;

            while (!correct)
            {
                correct = int.TryParse(phNo, out num);
                if (!correct)
                {
                    Console.WriteLine("Incorrect Phone Number" +
                           " type - Phone Number must be only digits");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Enter Phone Number: ");
                    phNo = Console.ReadLine();
                }
                else
                {
                    phoneNumber = num;
                }
            }

            // Prompt for password and checks input
            Console.WriteLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            correct = int.TryParse(pass, out num);
            int passW = num;

            while (!correct || num <= 999 || num >= 10000)
            {
                correct = int.TryParse(pass, out num);
                if (!correct || num <= 999 || num >= 10000)
                {
                    Console.WriteLine("Incorrect password" +
                        " type - password must be 4 digits");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Enter Password: ");
                    pass = Console.ReadLine();
                }
                else
                {
                    passW = num;
                }
            }


            Console.WriteLine();
            Console.WriteLine();


            // Check if user has already been created, prompt user if it has
            // already.
            if (memberCollection.CheckUsers(lastName + firstName) == -1)
            {

                Member member = new Member(firstName,
                    lastName, address, phoneNumber, passW);
                memberCollection.AddMember(member);
                Console.WriteLine("User " +
                    member.GetUsername() +
                    " has been added to the database.");
            }
            else
            {
                Console.WriteLine("User already exists in database.");
            }
        }
    }
}
