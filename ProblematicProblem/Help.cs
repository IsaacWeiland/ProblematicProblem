using System;
namespace ProblematicProblem;

public class Help
{
    public static int NumberParse()
    {
        var inputSuccess = int.TryParse(Console.ReadLine(), out int parseSucceed);
        while (!inputSuccess)
        {
            Console.WriteLine("Please enter a number.");
            inputSuccess = int.TryParse(Console.ReadLine(), out parseSucceed);
        }
        return parseSucceed;
    }
    public static bool BoolParse()
    {
       string parse = Console.ReadLine();
       while (true)
       {
           if (parse.ToLower() == "yes")
           {
               return true;
           }
           else if (parse.ToLower() == "no")
           {
               return false;
           }
           else
           {
               Console.WriteLine("Please enter a yes or a no.");
               parse = Console.ReadLine();
           }
       }
    }

    public static bool KeepRedo()
    {
        string parse = Console.ReadLine();
        while (true)
        {
            if (parse.ToLower() == "redo")
            {
                return true;
            }
            else if (parse.ToLower() == "keep")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter keep or redo.");
                parse = Console.ReadLine();
            }
        }
    }
}