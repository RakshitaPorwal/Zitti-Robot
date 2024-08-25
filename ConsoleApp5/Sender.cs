using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    using System;

    public class Sender
    {
        private Receiver _receiver;
        private ICommand _command;

        public Sender(Receiver receiver)
        {
            _receiver = receiver;
        }
        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void ExecuteCommand()
        {
            // Declare and assign a command object here
           

            // Call the Execute method on the command object
           _command.Execute();
        }


        public void SendCommand(string command)
        {
            switch (command)
            {
                case "greet":
                    _receiver.Greet();
                    break;

                case "goodbye":
                    _receiver.SayGoodbye();
                    break;

                case "clean":
                    _receiver.CleanRoom();
                    break;

                case "undo":
                    _receiver.UndoCleanRoom();
                    break;

                case "newspaper":
                    _receiver.FetchNewspaper();
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }

}
