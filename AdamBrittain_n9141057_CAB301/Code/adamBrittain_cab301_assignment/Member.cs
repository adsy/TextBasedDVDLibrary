using System;
using System.Collections;

namespace adamBrittain_cab301_assignment
{
    //Member class to create Member Objects
    public class Member
    {
        private ArrayList borrowedMovies = new ArrayList();
        private string firstName;
        private string lastName;
        private string address;
        private int phNo;
        private string username;
        private int password;


        public Member()
        {

        }

        public Member(string firstName, string lastName, string address,
            int phNo, int password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phNo = phNo;
            this.username = lastName + firstName;
            this.password = password;
        }


        //Public getters for the Member class
        public string GetFirstName()
        {
            return this.firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public string GetAddress()
        {
            return this.address;
        }

        public int GetPhNo()
        {
            return this.phNo;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public int GetPassword()
        {
            return this.password;
        }

        // Getter that converts the ArrayList to an array of Movie objects for
        // the memberCollection class.
        public Movie[] GetBorrowedMovies()
        {
            Movie[] movies = new Movie[this.borrowedMovies.Count];
            int count = 0;

            foreach (Movie mov in borrowedMovies)
            {
                movies[count] = mov;
                count++;
            }
            return movies;
        }


        
        public bool AddBorrowedMovie(Movie movie)
        {
            if (borrowedMovies.Count < 10)
            {
                borrowedMovies.Add(movie);
                return true;
            }
            
            else
            {
                Console.WriteLine("Error - You already have 10 rented movies");
                return false;
            }
                
        }

        public void RemoveBorrowedMovie(Movie movie)
        {
            borrowedMovies.Remove(movie);
        }



    }
}
