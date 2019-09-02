using System;
using System.Collections.Generic;
using VidApp.Core.Entity;

namespace ConsoleApp2019
{
    class Program
    {
        static List<Video> VideosLibrary = new List<Video>();
        static void Main(string[] args)
        {
            Console.WriteLine("Select operation:\n");
            List<string> menuItems = new List<string>
            {
                "Search",
                "Show all videos",
                "Add video",
                "Delete video",
                "Edit video",
                "Exit"
            };

            
            

            int selection = CreateMenu(menuItems);
            initData();


            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        var movie = Search();
                        if (movie != null)
                            Console.WriteLine("ID: " + movie.ID + " Title: " + movie.Title);
                        else
                            Console.WriteLine("No such movie.");
                        break;
                    case 2:
                        Console.Clear();
                        ShowAllVideos();
                        break;
                    case 3:
                        Console.Clear();
                        AddVideo();
                      
                        break;
                    case 4:
                        Console.Clear();
                        RemoveVideo();
                        break;
                    case 5:
                        EditVideo();
                        break;
                    default:
                        break;
                }
                
                selection = CreateMenu(menuItems);
            }
            Console.WriteLine("Closing the program...");

        }

        private static void initData()
        {
            Video v1 = new Video { ID = 1, Title = "Cats" };
            Video v2 = new Video { ID = 2, Title = "Dogs" };
            Video v3 = new Video { ID = 3, Title = "Ducks" };
            Video v4 = new Video { ID = 4, Title = "Sky" };
            Video v5 = new Video { ID = 5, Title = "Grass" };
            Video v6 = new Video { ID = 6, Title = "Hell" };
            VideosLibrary.Add(v1);
            VideosLibrary.Add(v2);
            VideosLibrary.Add(v3);
            VideosLibrary.Add(v4);
            VideosLibrary.Add(v5);
            VideosLibrary.Add(v6);
        }

        private static Video Search()
        {
            Console.WriteLine("What movie are you looking for? ");
            string title = Console.ReadLine();
            foreach (Video vid in VideosLibrary)
            {
                if (vid.Title.ToLower().Contains(title.ToLower()))
                {

                    return vid;
                }
            }
                return null;
        }

        private static void EditVideo()
        {
            if (VideosLibrary.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Library empty.");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }
            else
            {
                Console.Write("Provide the ID of the movie you want to change name of: ");
                int ToChange = int.Parse(Console.ReadLine());
                if (IsIdValid(ToChange))
                {
                    Console.Write("New name of the movie: ");
                    string newName = Console.ReadLine();
                    Video VidToChange = new Video();
                    foreach (Video vid in VideosLibrary)
                    {
                        if (ToChange.Equals(vid.ID))
                        {
                            vid.Title = newName;
                            Console.WriteLine("Title changed.\n");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong ID, try again.\n");
                }
            }
                
        }

        private static bool IsIdValid(int toChange)
        {
            bool b=false;
            foreach (var vid in VideosLibrary)
            {
                if (vid.ID == toChange)
                    b = true;
            }
            return b;
        }

        private static void RemoveVideo()
        {
            if (VideosLibrary.Count == 0) {
                Console.WriteLine("Library empty.");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
            }
            else
            {
                Console.Write("Type ID you want to remove from the list: ");
                int idToRemove;
                int.TryParse(Console.ReadLine(),out idToRemove);
                Video VidToRemove = new Video();
                foreach (Video vid in VideosLibrary)
                {
                    if (idToRemove.Equals(vid.ID))
                    {
                        VidToRemove = vid;
                        Console.Clear();
                        Console.WriteLine("Movie succesfully removed.\n");
                    }
                }

                VideosLibrary.Remove(VidToRemove);
                
            }
        }
        private static void ShowAllVideos()
        {
            if (VideosLibrary.Count == 0)
                Console.WriteLine("Library empty.");
            else {
            foreach (var video in VideosLibrary)
            {
                Console.WriteLine($"ID: {video.ID} Title: {video.Title}");
                }
            }
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }
        private static void AddVideo()
        { 
            string name;
            Console.Write("Type movie Title: ");
            name = Console.ReadLine();

            Video video = new Video();
            video.ID = GetAvailableID();
            video.Title = name;
            VideosLibrary.Add(video);
            Console.WriteLine("Movie succesfully added.\n");
           }

        private static int GetAvailableID()
        {

            
            if (VideosLibrary.Count == 0)
            {
                return 1;
            }
            else
            {
                int MaxID = 1;
                foreach (Video vid in VideosLibrary)
                {
                    if (vid.ID >= MaxID)
                        MaxID = vid.ID;
                }
                return MaxID+1;
            }
            
        }

        private static int CreateMenu(List<string> menuItems)
        {
            
           
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{(i + 1)}:{menuItems[i]}");
            }


            
            int selection;

            while(!int.TryParse(Console.ReadLine(),out selection) || selection>6 || selection<1)
            {
                Console.WriteLine("Error, select number 1-6.");
            }
            
            return selection;
        }



    }
}
