//using ConsoleApp5;
//using System;

//using static ConsoleApp5.Commands;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Receiver receiver = new ConsoleApp5.Receiver();
//        Sender sender = new Sender(receiver);
//        var zittiRobot = new ZittiRobot();
//        while (true)
//        {
//            Console.Write("Instruction: ");
//            string input = Console.ReadLine();
//            zittiRobot.ExecuteCommand(input);

//            // Creating commands
//            //ICommand command;
//            //if (input == "Hey. How are you?")
//            //{
//            //    command = new GreetCommand(receiver);
//            //}
//            //else if (input == "Clean my room")
//            //{
//            //    command = new CleanRoomCommand(receiver);
//            //}
//            //else if (input == "Fetch the newspaper")
//            //{
//            //    command = new FetchNewspaperCommand(receiver);
//            //}
//            //else if (input.StartsWith("Add ") && input.Contains("to my shopping list"))
//            //{

//            //    // string item = input.Substring(4, input.Length - 26);

//            //    string keyword = "Add ";
//            //    int start = input.IndexOf(keyword) + keyword.Length;
//            //    int end = input.IndexOf(" to my shopping list");
//            //    string item =" ";
//            //    if (start >= keyword.Length && end > start)
//            //    {
//            //        item = input.Substring(start, end - start);

//            //    }
//            //    command = new AddToShoppingListCommand(receiver, item);
//            //}
//            //else if (input == "Read my shopping list")
//            //{
//            //    command = new ReadShoppingListCommand(receiver);
//            //}
//            //else if (input == "How's the weather outside?")
//            //{
//            //    command = new ReadWeatherCommand(receiver);
//            //}
//            //else
//            //{
//            //    command = new UnknownCommand();
//            //}

//            // Invoking the command
//            sender.SetCommand(command);
//            sender.ExecuteCommand();

//            Console.WriteLine();
//        }
//    }
//}
using System;
using ConsoleApp5;
using static ConsoleApp5.Commands;

    class Program
    {
        static void Main(string[] args)
        {


            string[] item = null;

            Receiver receiver = new Receiver();
            IDictionary<string, ICommand> commandMap = new Dictionary<string, ICommand>()
        {
            {"Hey. How are you?", new GreetCommand(receiver)},
            {"Clean my room", new CleanRoomCommand(receiver)},
            {"Fetch the newspaper", new FetchNewspaperCommand(receiver)},
           // {"Read my shopping list", new ReadShoppingListCommand(receiver)},
            {"How's the weather outside?", new ReadWeatherCommand(receiver)},
          //  {"Add to my shopping list",new AddToShoppingListCommand(receiver,item)}
        };




            // commandMap.Add($"Add {{item}} to my shopping list", new Func<string, ICommand>((item) => new AddToShoppingListCommand(receiver, item)));


            ZittiRobot robot = new ZittiRobot(receiver, commandMap);

            // Listen for user input
            while (true)
            {
                Console.Write("User: ");
                string input = Console.ReadLine();
                robot.Listen(input);
            }
        }
    }

