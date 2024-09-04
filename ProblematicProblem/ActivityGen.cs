namespace ProblematicProblem;
using System;
using System.Collections.Generic;
using System.Threading;
public class ActivityGen
{
    static Random _rng = new Random();
    static bool _cont = true;
    private static List<string> _activities = new List<string>()
        { "Movies", "Paintball", "Bowling", "Laser Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
    public static void Start()
    {
        Console.Write(
                "Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            _cont = Help.BoolParse();
            Console.WriteLine();
            if (_cont)
            {
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                int userAge = Help.NumberParse();
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? yes/no: ");
                bool seeList = Help.BoolParse();
                if (seeList)
                {
                    ActivityList();
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    bool addToList = Help.BoolParse();
                    Console.WriteLine();
                    if (addToList)
                    {
                       seeList = ActivityAdd(addToList);
                    }
                    else
                    {
                        seeList = false;
                    }
                }

                while (_cont)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();
                    int randomNumber = _rng.Next(0,_activities.Count);
                    string randomActivity = _activities[randomNumber];
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        _activities.Remove(randomActivity);
                        randomNumber = _rng.Next(0,_activities.Count);
                        randomActivity = _activities[randomNumber];
                    }

                    Console.Write(
                        $"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    _cont = Help.KeepRedo();
                }

                Console.WriteLine("Have fun with your activity!");
            }
            else
            {
                Console.WriteLine("Have a good day!");
            }
    }

    private static void ActivityList()
    {
        foreach (string activity in _activities)
        {
            Console.Write($"{activity} ");
            Thread.Sleep(250);
        }

    }

    private static bool ActivityAdd(bool addToList)
    {
        while (addToList)
        {
            Console.Write("What would you like to add? ");
            string userAddition = Console.ReadLine();
            _activities.Add(userAddition);
            ActivityList();

            Console.WriteLine();
            Console.WriteLine("Would you like to add more? yes/no: ");
            addToList = Help.BoolParse();
        }

        return addToList;
    }
}