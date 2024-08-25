using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp5.Commands;

namespace ConsoleApp5
{
    public class ZittiRobot
    {
        private readonly Receiver receiver;
        private readonly IDictionary<string, ICommand> commandMap;
       
        public ZittiRobot(Receiver receiver, IDictionary<string, ICommand> commandMap)
        {
            this.receiver = receiver;
            this.commandMap = commandMap;
        }

        public void Listen(string input)
        {
            ICommand command;
            string[] items = null;
            string item = null;
            //Sender sender = new Sender(receiver);
            if (input.StartsWith("Add ") && input.EndsWith(" to my shopping list"))
            {
                string keyword = "Add ";
                int start = input.IndexOf(keyword) + keyword.Length;
                int end = input.IndexOf(" to my shopping list");
                item = "";

                if (start >= keyword.Length && end > start)
                {
                    item = input.Substring(start, end - start).Trim();
                     items = item.Split(',').Select(sValue => sValue.Trim()).ToArray();
                    //if (!string.IsNullOrEmpty(item))
                    //{
                    //    command = new AddToShoppingListCommand(receiver, item);
                    //    Sender sender = new Sender(receiver);
                    //    sender.SetCommand(command);
                    //    sender.ExecuteCommand();
                    //}
                    // command = new AddToShoppingListCommand(receiver, item);
                }
                
            }
            else if (input.StartsWith("Remove ") && input.EndsWith(" from my shopping list"))
            {
                string keyword = "Remove ";
                int start = input.IndexOf(keyword) + keyword.Length;
                int end = input.IndexOf(" from my shopping list");
                item = "";

                if (start >= keyword.Length && end > start)
                {
                    item = input.Substring(start, end - start).Trim();
                   // items = item.Split(',').Select(sValue => sValue.Trim()).ToArray();
                    //if (!string.IsNullOrEmpty(item))
                    //{
                    //    command = new AddToShoppingListCommand(receiver, item);
                    //    Sender sender = new Sender(receiver);
                    //    sender.SetCommand(command);
                    //    sender.ExecuteCommand();
                    //}
                    // command = new AddToShoppingListCommand(receiver, item);
                }
            }

       
            Sender sender = new Sender(receiver);
            if (items != null && !input.StartsWith("Remove "))
            {
                command = new AddToShoppingListCommand(receiver, items);

                sender.SetCommand(command);
                sender.ExecuteCommand();
            }
            else if (item != null) {

                command = new RemoveFromtheShoppingList(receiver, item);
                sender.SetCommand(command);
                sender.ExecuteCommand();
            }
            else if (commandMap.TryGetValue(input, out command) || item != null)
            {
                sender.SetCommand(command);
                sender.ExecuteCommand();
            }
            else
            {
                ICommand unknownCommand = new UnknownCommand(receiver);
                sender.SetCommand(unknownCommand);
                sender.ExecuteCommand();
            }
        }
    }

}
