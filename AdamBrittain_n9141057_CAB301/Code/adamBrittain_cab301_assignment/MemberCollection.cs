using System;

namespace adamBrittain_cab301_assignment
{
    // MemberCollection class to utilise the Member objects.
    public class MemberCollection
    {



        // Set 10 user limit and keep track of the number of Members.
        Member[] memberList = new Member[10];
        int numMembers = 0;



        // Function to add member to to memberList.
        // No output.
        public void AddMember(Member member)
        {
            // If there are no registered users yet add member and increase
            // member count.
            if (numMembers == 0)
            {
                memberList[numMembers] = member;
                numMembers++;
            }
            else
            {
                // Check to see if there are too many users, if there isn't add
                // user.
                if (numMembers == 10)
                {
                    Console.WriteLine("Error - cannot add another " +
                        "member as member list is full");
                }
                else
                {
                    memberList[numMembers] = member;
                    numMembers++;
                }
            }
        }



        // Function to return user's phone number.
        // Returns members phone number if they exist, -1 if they do not exist.
        public int ReturnPhNo(string username)
        {
            for (int i = 0; i < numMembers; i++)
            {
                if (memberList[i].GetUsername() == username)
                {
                    return memberList[i].GetPhNo();
                }
            }
            return -1;
        }



        // Helper function used by Helper Function class to check if users already exists.
        // Returns 1 if user exists, -1 if they do not exist.
        public int CheckUsers(string username)
        {
            {
                for (int i = 0; i < numMembers; i++)
                {
                    if (memberList[i].GetUsername() == username)
                    {
                        return 1;
                    }
                }
                return -1;
            }
        }



        // Function that checks if the username and password entered by user
        // matches a member stored in the array.
        // Return that member if they exist.
        public Member CheckLogin(string username, int password)
        {
            {
                for (int i = 0; i < numMembers; i++)
                {
                    if (memberList[i].GetUsername()
                            == username && memberList[i].GetPassword()
                            == password)
                    {
                        return memberList[i];
                    }
                    else
                    {
                    }

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Incorrect username or password");
                Console.WriteLine();
                Console.WriteLine();
                return null;
            }
        }



        // Helper function to check if movie is currently rented out by a
        // member.
        public bool CheckMovie(Member member, Movie movie)
        {
            bool check = false;
            // Grab the current movies borrwed by the member entered
            // into parameters.
            Movie[] movies = member.GetBorrowedMovies();

            // If user has this movie in their current borrowed movies,
            // mark check as true if they do.
            foreach (Movie mov in movies)
            {
                if (mov.GetTitle() == movie.GetTitle())
                {
                    check = true;
                    return check;
                }
            }
            return check;

        }



        // Function  that takes a member and movie object and adds the movie to
        // members movie collection if the movie exists.
        // No output.
        public void Insert2Member(Member member, Movie movie)
        {
            // Flag used to check if movie is currently already rented out.
            bool check = false;

            // Check to see if movie is an object or null based off parameter input.
            if (movie != null)
            {

                // Use CheckMovie function to check if the member current has
                // the movie rented out
                check = CheckMovie(member, movie);

                // If they do not currently have this movie rented out, add to
                // their collection.
                if (!check)
                {


                    // Check to see if there are enough copies available.

                    // there is, use the member function to add the borrowed
                    // movie to its own movie collection.

                    // Decrease amount of copies available and increase times rented.
                    if (movie.GetCopiesAvail() >= 1)
                    {
                        check = member.AddBorrowedMovie(movie);

                        if (check)
                        {
                            movie.DecreaseCopiesAvail();
                            movie.IncreaseTimesRented();
                            Console.WriteLine(movie.GetTitle() + " rented to user " +
                                member.GetUsername());
                        }
                    }
                    else
                        Console.WriteLine("There are no copies of that " +
                            "movie available");
                }
                else
                    Console.WriteLine("You already currently have that movie rented.");
            }
            else
                Console.WriteLine("The movie you entered does not exist.");
        }



        // Function  that takes a member and movie object and removes the movie
        // from the members movie collection if the movie exists.
        // No output.
        public void RemoveMovieFromMember(Member member, Movie movie)
        {
            // Flag used to check if movie is currently already rented out.
            bool check = false;

            // Check to see if movie is an object or null based off parameter input.
            if (movie != null)
            {

                // Use CheckMovie function to check if the member current has
                // the movie rented out
                check = CheckMovie(member, movie);

                // If they do have the movie rented out, remove from their
                // collection.
                if (check)
                {

                    member.RemoveBorrowedMovie(movie);
                    movie.IncreaseCopiesAvail(1);
                    Console.WriteLine(movie.GetTitle() + " returned to database by " +
                        member.GetUsername() +".");

                }
                else
                    Console.WriteLine("You do not have that movie currently rented out.");
            }
            else
                Console.WriteLine("The movie you entered does not exist.");
        }



        // Function that shows the current borrowed movies of a particular member.
        // No output.
        public void ShowBorrowedMovies(Member member)
        {
            // Grab borrowed movies array from the member object.
            Movie[] movies = member.GetBorrowedMovies();


            // Display current borrowed movies in nice format by iterating
            // each movie object and use getters to grab the movie info.
            Console.WriteLine();
            Console.WriteLine();
            if (movies.Length == 0)
            {
                Console.WriteLine("You currently have no borrowed movies.");
            }
            else
            {
                Console.WriteLine("----CURRENT BORROWED MOVIES----");

                foreach (Movie movie in movies)
                {
                    if (movie != null)
                    {
                        Console.WriteLine("Movie Title: " + movie.GetTitle());
                        Console.WriteLine("Starring: " + movie.GetStarring());
                        Console.WriteLine("Director: " + movie.GetDirector());
                        Console.WriteLine("Classification: " + movie.GetClassification());
                        Console.WriteLine("Duration: " + movie.GetDuration());
                        Console.WriteLine("Genre: " + movie.GetGenre());
                        Console.WriteLine("Release Date: " + movie.GetReleaseDate());
                        Console.WriteLine();
                        Console.WriteLine();
                    }

                }
            }
            
        }



        // Function that returns the current borrowed movies of all users. This
        // function is used by the delete function of the BST to check if the
        // movie is currently being rented.
        // Returns an array of movie objects.
        public Movie[] ReturnCurrentBorrowedMovies()
        {
            // Start a count to keep track for size of array
            int count = 0;
            for (int i = 0; i < numMembers; i++)
            {
                foreach (Movie movie in memberList[i].GetBorrowedMovies())
                {
                    count++;
                }
            }

            // Initialise array of Movie objects with the amount of movies
            Movie[] movies = new Movie[count];
            int k = 0;

            // Add movies into new array.
            for (int i = 0; i < numMembers; i++)
            {
                foreach (Movie movie in memberList[i].GetBorrowedMovies())
                {
                    movies[k] = movie;
                    k++;
                }
            }

            return movies;
        }

    }
}
