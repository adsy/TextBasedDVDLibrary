using System;

namespace adamBrittain_cab301_assignment
{
    // MovieCollection class to utilise the Movie class.
    public class MovieCollection
    {
        // Local class to hold a TreeNode
        public class TreeNode
        {
            public Movie movie;
            public TreeNode left;
            public TreeNode right;
        }

        //Local class to create a Movie BST inside of the MovieCollection object.
        public class MovieTree
        {

            // Local variable to keep track of total movies in BST.
            public int movieCount = 0;

            // Local variable used to add movies for top 10 sort.
            public int i = 0;

            // Movie array to hold movies in BST for top 10 sort.
            public Movie[] movies;

            // Setup root variable for BST
            public TreeNode root;




            // Setup constructor for MovieTree class
            public MovieTree()
            {
                root = null;
            }

            // Function that returns the root of the BST.
            // Return the root of the BST.
            public TreeNode ReturnRoot()
            {
                return root;
            }



            // Function that adds the movie object into the BST.
            public void Insert(Movie movie)
            {
                // Setup a new TreeNode to add to BST.
                TreeNode newTreeNode = new TreeNode();

                // Assign the movie object to the movie object in the TreeNode.
                newTreeNode.movie = movie;

                bool exit = false;

                // If there is no root in the BST, set the root to the new tree
                // node.
                // Increment the count of movies in the tree.
                if (root == null)
                {
                    root = newTreeNode;
                    movieCount++;
                }
                else
                {
                    // Setup a new treeNode for the current node and parent node
                    // to start comparisons when travelling in tree.
                    TreeNode current = root;
                    TreeNode parent;

                    while (!exit)
                    {
                        // Assign parent node to the current node being compared.
                        parent = current;

                        // If the comparison returns -1, traverse left side of
                        // current node.
                        if (string.Compare
                            (movie.GetTitle(), current.movie.GetTitle()) == -1)
                        {
                            // Assign the left node of the current node to the
                            // current variable
                            current = current.left;

                            //If its empty add at this location
                            if (current == null)
                            {
                                // Add treeNode to parent of current.
                                parent.left = newTreeNode;

                                // Increase count of movies in BST.
                                movieCount++;
                                exit = true;
                            }
                        }
                        else
                        {
                            //Assign the right node of the current node to the
                            // current variable
                            current = current.right;

                            //If its empty add at this location
                            if (current == null)
                            {
                                // Add treeNode to parent of current.
                                parent.right = newTreeNode;

                                // Increase count of movies in BST.
                                movieCount++;
                                exit = true;
                            }
                        }
                    }
                }
            }



            // Function that initialises the local movie array with the current 
            // count of movies in BST
            // No output.
            public void InitaliseMovieArray()
            {
                i = 0;
                movies = new Movie[movieCount];
            }



            // Function that traverses BST in order and adds the movie to the
            // local movie array for top 10 function.
            // No output.
            public void InOrderAdd(TreeNode root)
            {
                if (root != null)
                {
                    InOrderAdd(root.left);
                    movies[i] = root.movie;
                    i++;
                    InOrderAdd(root.right);
                }
            }



            // Function that uses the InverseSort method to sort through Movies
            // and sort in a decrease order.

            // Returns the array after it has been sorted.
            public Movie[] ReverseInsertionSort(Movie[] arr)
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    Movie v = arr[i];
                    int j = i - 1;

                    while (j >= 0 && arr[j].GetTimesRented() < v.GetTimesRented())
                    {
                        arr[j + 1] = arr[j];
                        j = j - 1;
                    }
                    arr[j + 1] = v;
                }
                return arr;
            }



            // Function that displays the information about the top 10 rated
            // movies.
            public void PrintTop10(Movie[] movies)
            {
                int count = 0;

                // Set limit to 10 movies if the amount of movies are over 10.
                if (movies.Length >= 11)
                {
                    count = 10;
                }
                else
                {
                    count = movies.Length;
                }

                // Loop through the movies array and display the top 10
                // rented movies.
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("Movie Title: " + movies[i].GetTitle());
                    Console.WriteLine("Starring: " + movies[i].GetStarring());
                    Console.WriteLine("Director: " + movies[i].GetDirector());
                    Console.WriteLine("Classification: " + movies[i].GetClassification());
                    Console.WriteLine("Duration: " + movies[i].GetDuration());
                    Console.WriteLine("Genre: " + movies[i].GetGenre());
                    Console.WriteLine("Release Date: " + movies[i].GetReleaseDate());
                    Console.WriteLine("Times Rented: " + movies[i].GetTimesRented());
                    Console.WriteLine("Copies Available: " + movies[i].GetCopiesAvail());
                    Console.WriteLine();
                    Console.WriteLine();

                }
            }

            // Function to display top 10 movies inside of MovieCollection
            public void DisplayTop10()
            {
                // Initialise an array with the amount of
                // current movies.
                InitaliseMovieArray();

                // Use In Order Traversal to add all
                // movies to movieCollection movie array.
                InOrderAdd(ReturnRoot());

                // QuickSort the movie array inside the BST
                // object and return to a temp array.
                Movie[] temp = ReverseInsertionSort
                    (movies);

                // Pass temp movie array to DisplayTop10
                // function to display the top 10 movies.
                PrintTop10(temp);
            }



            // Function to do In-Order travel of BST to print details about 
            // movies in an alphabetical order.
            public void InOrderDisplayInfo(TreeNode Root)
            {

                if (Root != null)
                {
                    InOrderDisplayInfo(Root.left);
                    Console.WriteLine("Movie Title: " + Root.movie.GetTitle());
                    Console.WriteLine("Starring: " + Root.movie.GetStarring());
                    Console.WriteLine("Director: " + Root.movie.GetDirector());
                    Console.WriteLine("Classification: " + Root.movie.GetClassification());
                    Console.WriteLine("Duration: " + Root.movie.GetDuration());
                    Console.WriteLine("Genre: " + Root.movie.GetGenre());
                    Console.WriteLine("Release Date: " + Root.movie.GetReleaseDate());
                    Console.WriteLine("Times Rented: " + Root.movie.GetTimesRented());
                    Console.WriteLine("Copies Available: " + Root.movie.GetCopiesAvail());
                    Console.WriteLine();
                    Console.WriteLine();
                    InOrderDisplayInfo(Root.right);
                }
            }


            // Function that recursively searches through BST based off the
            // comparison of the movieTitle in the parameters.

            // Returns movie if found and returns null if it reaches the end
            // of the search.
            public Movie ReturnMovie(TreeNode root, string movieTitle)
            {
                // Assign current node being compared to the node in the
                // Parameters.
                TreeNode current = root;

                // If node is null, movie is not in tree and movie has not been
                // found.
                if (current == null)
                    return null;

                // If the movieTitle variable matches the current nodes title,
                // return the current nodes movie object.
                if (string.Compare(current.movie.GetTitle(), movieTitle) == 0)
                    return current.movie;

                // If the movie title is further in the alphabet, traverse the
                // left side of the BST.
                if (string.Compare(movieTitle, current.movie.GetTitle()) == -1)
                    return ReturnMovie(current.left, movieTitle);

                // If the movie title is earlier in the alphabet, traverse the
                // right side of the BST.
                else
                    return ReturnMovie(current.right, movieTitle);
            }



            // Function that deletes the movie from the BST - accounts for 0
            // children, 1 child on L or R  and 2 children deletion.

            // No output.
            public bool Delete(Movie movie, MemberCollection memberCollection)
            {

                // Check to see if the movie is already rented to a user.
                Movie[] rentedMovies =
                    memberCollection.ReturnCurrentBorrowedMovies();
                bool check = false;

                // Mark check as true if the entered movie is currently rented.
                foreach (Movie m in rentedMovies)
                {
                    if (m.GetTitle() == movie.GetTitle())
                        check = true;
                }


                //If it is not currently rented out to user, delete the movie
                // from BST.
                if (!check)
                {

                    TreeNode current = root;
                    TreeNode parent = root;
                    bool leftNode = true;

                    
                    // Check to see if the current movie is the user entered
                    // movie then traverse the BST based off name comparison.
                    while (current.movie.GetTitle() != movie.GetTitle())
                    {

                        parent = current;

                        // If searched name is less than current node, travel
                        // left tree.
                        if (string.Compare(movie.GetTitle(),
                            current.movie.GetTitle()) == -1)
                        {
                            leftNode = true;
                            current = current.left;
                        }
                        // If searched name is greater than current node, travel
                        // right tree.
                        else
                        {
                            leftNode = false;
                            current = current.right;
                        }
                        if (current == null)
                            return false;
                    }
                    if ((current.left == null) && (current.right == null))
                        // Delete the node as it has no children.
                        if (current == root)
                        {
                            root = null;
                            return true;
                        }

                        // Delete the left child 
                        else if (leftNode)
                        {
                            parent.left = null;
                            return true;
                        }
                        // Delete the right child 
                        else
                        {
                            parent.right = null;
                            return true;
                        }

                    // If current node's right node is empty, replace with left
                    // node
                    else if (current.right == null)
                        if (current == root)
                        {
                            root = current.left;
                            return true;
                        }
                        // Replace current node with its left child in BST.
                        else if (leftNode)
                        {
                            parent.left = current.left;
                            return true;
                        }
                        // Replace current node with its right child in BST.
                        else
                        {
                            parent.right = current.left;
                            return true;
                        }

                    // If current node's left node is empty, replace with right
                    // node
                    else if (current.left == null)
                    {
                        if (current == root)
                        {
                            root = current.right;
                            return true;
                        }
                        // Replace current node with its left child in BST.
                        else if (leftNode)
                        {
                            parent.left = current.right;
                            return true;
                        }
                        // Replace current node with its right child in BST.
                        else
                        {
                            parent.right = current.right;
                            return true;
                        }

                    }

                    // Node has 2 children
                    else
                    {
                        // If far right most node of current node is empty,
                        // current node becomes left node.
                        if (current.left.right == null)
                        {
                            current.movie = current.left.movie;
                            current.left = current.left.left;
                            return true;
                        }
                        // Replace current node with the far right most node.
                        else
                        {
                            TreeNode node = current.left;
                            TreeNode parentNode = current;

                            while (node.right != null)
                            {
                                parentNode = node;
                                node = node.right;
                            }
                            
                            current.movie= node.movie;
                            parentNode.right = node.left ;
                            return true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You cannot delete a " +
                        "movie that is currently rented out.");
                    return false;
                }

            }
        }
    }
}
