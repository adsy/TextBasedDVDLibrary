using System;
using System.Collections;
using System.Collections.Generic;


namespace adamBrittain_cab301_assignment
{
    class Program
    {


        static void Main(string[] args)
        {

            // Create a movieTree BST to hold movies and also a new 
            // MemberCollection to hold members.
            MovieCollection.MovieTree BST = new MovieCollection.MovieTree();
            MemberCollection memberCollection = new MemberCollection();
            Member testMember = new Member("test", "test", "1", 1, 2414);
            memberCollection.AddMember(testMember);

            // Flags used to run program
            bool quit = false;
            bool logout = false;

            // Login details for admin user access.
            string adminUser = "admin";
            string adminPass = "adminPass";


            Movie movie1 = new Movie("movie6", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5,3);
            BST.Insert(movie1);


            Movie movie2 = new Movie("movie5", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5,7);
            BST.Insert(movie2);


            Movie movie3 = new Movie("movie10", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5,2);
            BST.Insert(movie3);


            Movie movie4 = new Movie("movie9", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5,4);
            BST.Insert(movie4);


            Movie movie5 = new Movie("movie2", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5,1);
            BST.Insert(movie5);

            Movie movie6 = new Movie("movie4", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5, 3);
            BST.Insert(movie6);


            Movie movie7 = new Movie("movie7", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5, 9);
            BST.Insert(movie7);


            Movie movie8 = new Movie("movie11", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5, 0);
            BST.Insert(movie8);


            Movie movie9 = new Movie("movie8", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5, 4);
            BST.Insert(movie9);


            Movie movie10 = new Movie("movie1", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5, 3);
            BST.Insert(movie10);

            Movie movie11 = new Movie("movie3", "actor1",
                "director1", 90, "Horror", "MA 15+", DateTime.Now, 5, 1);
            BST.Insert(movie11);

            




            // Strings to hold the menus to prompt user input for Main Menu,
            // Staff Menu and Member Menu

            string mainMenu = "Welcome to the Community Library\n" +
                "==============Main Menu===========\n" +
                "1. Staff Login\n" +
                "2. Member Login\n" +
                "0. Exit\n" +
                "===================================";



            string staffMenu = "============Staff Menu============\n" +
                "1. Add a new movie DVD\n" +
                "2. Remove a movie DVD\n" +
                "3. Register a new Member\n" +
                "4. Find a registered member's phone number\n" +
                "0. Return to main menu\n" +
                "===================================";




            string memberMenu = "==============Member Menu==============\n" +
                 "1. Display all movies\n" +
                 "2. Borrow a movie DVD\n" +
                 "3. Return a movie DVD\n" +
                 "4. List current borrowed movie DVDs\n" +
                 "5. Display top 10 most popular movies\n" +
                 "0. Return to main menu\n" +
                 "===================================";


            
            
            // While quit is not set to true, run program.
            while (!quit)
            {
                Console.WriteLine(mainMenu);
                string input = Console.ReadLine();


                // Exit Program if user input is 0.
                if (input == "0")
                {
                    quit = true;
                }



                // Show staff login screen if user input is 1.
                else if (input == "1")
                {

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Please enter the admin username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Please enter the admin password:");
                    string password = Console.ReadLine();


                    // Show next screen is user Enter's correct login details
                    // for Admin.
                    if (username == "admin" && password == "adminPass")
                    {

                        logout = false;
                        while (!logout)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine(staffMenu);

                            input = Console.ReadLine();



                            //Admin enters 0 and goes back to main menu
                            if (input == "0")
                            {
                                logout = true;
                                Console.WriteLine();
                                Console.WriteLine();
                            }

                            //Admin enters 1 to add a new movie.
                            if (input == "1")
                            {
                                HelperFunctions.Insert(BST);

                            }

                            //Admin enters 2 to remove a movie.
                            if (input == "2")
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Please enter movie name " +
                                    "which you wish to remove: ");
                                string title = Console.ReadLine();

                                // Call return movie function to get Movie info.
                                Movie movie = BST.ReturnMovie(BST.ReturnRoot(), title);

                                if (movie == null)
                                {
                                    Console.WriteLine("There is no movie with that name.");
                                }
                                else
                                {
                                    bool check = BST.Delete(movie,memberCollection);
                                    if (check)
                                    {
                                        BST.movieCount--;
                                        Console.WriteLine(title + " has been deleted from the database.");
                                    }


                                }
                            }

                            //Admin enters 3 to register a new user.
                            if (input == "3")
                            {

                                // Call the helper function that contains the calls for user input.
                                // Function has input parsing to check for incorrect user input.
                                // Adds user to MemberCollection if it passes.
                                HelperFunctions.AddUser(memberCollection);



                            }

                            //Admin enters 4 to search for users phone number by entering username
                            if (input == "4")
                            {
                                Console.WriteLine("Please enter the persons " +
                                    "username to find their phone " +
                                    "number: ");
                                string user = Console.ReadLine();

                                int phNo = memberCollection.ReturnPhNo(user);

                                if (phNo != -1)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("The users phone number " +
                                        "is " + phNo);
                                }
                                else
                                {
                                    Console.WriteLine("There are no users" +
                                        " registered with that username.");
                                }
                            }

                        }
                        

                    }

                    //Incorrect login details entered - return to main menu.
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Incorrect login details - " +
                            "returning to main menu");
                        Console.WriteLine();
                        Console.WriteLine();
                    }


                    
                }


                //Member Login
                else if (input == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine();

                    logout = false;
                    string username = "empty";
                    int password = 0;
                    int num = 0;

                    Console.WriteLine("Please enter username:");
                    username = Console.ReadLine();
                    Console.WriteLine("Please enter password:");
                    bool check = int.TryParse(Console.ReadLine(), out num);

                    while (!logout)
                    {
                        password = num;


                        Member currentUser =
                            memberCollection.CheckLogin(username, password);

                        if (currentUser != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine(memberMenu);


                            input = Console.ReadLine();

                            string movieTitle;
                            Movie movie;
                            switch (input)
                            {

                                //Display all movie info
                                case "1":
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("----ALL MOVIE INFO----");
                                    BST.InOrderDisplayInfo(BST.ReturnRoot());
                                    break;


                                    //Borrow a movie
                                case "2":
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Please enter the " +
                                        "name of the movie you " +
                                    "wish to rent: ");
                                    movieTitle = Console.ReadLine();
                                    movie = BST.ReturnMovie
                                        (BST.ReturnRoot(), movieTitle);
                                    memberCollection.Insert2Member
                                        (currentUser, movie);
                                    break;


                                    //Return a movie
                                case "3":
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Please enter the " +
                                        "name of the movie you " +
                                    "wish to return: ");
                                    movieTitle = Console.ReadLine();
                                    movie = BST.ReturnMovie
                                        (BST.ReturnRoot(), movieTitle);
                                    memberCollection.RemoveMovieFromMember
                                        (currentUser, movie);
                                    break;


                                    //Show borrowed movies
                                case "4":
                                    memberCollection.ShowBorrowedMovies
                                        (currentUser);
                                    break;


                                    //Display top 10 rented movies.
                                case "5":
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("----T0P 10 RENTED MOVIES----");
                                    BST.DisplayTop10();
                                    break;


                                    //Return to main menu.
                                case "0":
                                    logout = true;
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        else
                        {
                            logout = true;
                        }
                    }
                }



                //Incorrect input
                else
                {
                    Console.WriteLine("Incorrect number entered - you must " +
                        "enter a number between 0 - 2.");
                }

            }
        }
    }
}
    


