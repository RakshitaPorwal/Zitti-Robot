using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConsoleApp5
{
   public class Commands
    {
        public class GreetCommand : ICommand
        {
            private readonly Receiver _receiver;

            public GreetCommand(Receiver receiver)
            {
                _receiver = receiver;
            }

            public void Execute()
            {
                _receiver.Greet();
            }

            public void Undo()
            {
                _receiver.SayGoodbye();
            }
        }

        public class CleanRoomCommand : ICommand
        {
            private readonly Receiver _receiver;

            public CleanRoomCommand(Receiver receiver)
            {
                _receiver = receiver;
            }

            public void Execute()
            {
                _receiver.CleanRoom();
            }

            public void Undo()
            {
                _receiver.UndoCleanRoom();
            }
        }

        public class FetchNewspaperCommand : ICommand
        {
            private readonly Receiver _receiver;

            public FetchNewspaperCommand(Receiver receiver)
            {
                _receiver = receiver;
            }

            public void Execute()
            {
                _receiver.FetchNewspaper();
            }

            public void Undo()
            {
                _receiver.UndoFetchNewspaper();
            }
        }

        public class AddToShoppingListCommand : ICommand
        {
            private readonly Receiver _receiver;
            private readonly string[] _items;

            public AddToShoppingListCommand(Receiver receiver, string[] _items)
            {
                //Console.WriteLine("Please list down your number of items");
                //string x = Console.ReadLine();
                //Console.WriteLine("List down the items");
                //int y = Convert.ToInt32(x);
                //while (y > 0)
                //{
                //  string item =  Console.ReadLine();
                //  _items.Append(item);
                //    y--;
                //}


                this._receiver = receiver;
               this._items = _items;
            }

            public void Execute()
            {
                _receiver.AddToShoppingList(_items);
            }

            public void Undo()
            {
                _receiver.UndoAddToShoppingList();
            }
        }
        //public class AddToShoppingListCommand : ICommand
        //{
        //    private readonly Receiver _receiver;
        //    private readonly string _item;

        //    public AddToShoppingListCommand(Receiver receiver, string item)
        //    {
        //        _receiver = receiver;
        //        _item = item;
        //    }

        //    public void Execute()
        //    {
        //        if (_receiver._shoppingList.Contains(_item))
        //        {
        //            _receiver.Output = $"You already have {_item} in your shopping list.";
        //        }
        //        else
        //        {
        //            _receiver._shoppingList.Add(_item);
        //            _receiver.Output = $"{_item} has been added to your shopping list.";
        //        }
        //    }

        //    public void Undo()
        //    {
        //        if (_receiver._shoppingList.Contains(_item))
        //        {
        //            _receiver._shoppingList.Remove(_item);
        //            _receiver.Output = $"{_item} has been removed from your shopping list.";
        //        }
        //        else
        //        {
        //            _receiver.Output = $"{_item} was not in your shopping list.";
        //        }
        //    }
        //}
        public class RemoveFromtheShoppingList : ICommand
        {
            private readonly Receiver _receiver;
            private readonly string _item;

            public RemoveFromtheShoppingList(Receiver receiver,string _item)
            {
                this._receiver= receiver;
                this._item = _item;
            }
            public void Execute()
            {
                _receiver.RemoveItem(_item);
                //if (_receiver._shoppingList.Contains(_item))
                //{
                //    _receiver._shoppingList.Remove(_item);
                //    _receiver.Output = $"{_item} has been removed from your shopping list.";
                //    Console.WriteLine($"{{_item}} has been removed from your shopping list.");
                //}
                //else
                //{
                //    _receiver.Output = $"{_item} was not in your shopping list.";
                //    Console.WriteLine($"{_item} was not in your shopping list.");
                //}
            }

            public void Undo()
            {
                //this command does nothing
            }
        }

        public class ReadShoppingListCommand : ICommand
        {
            private readonly Receiver _receiver;

            public ReadShoppingListCommand(Receiver receiver)
            {
                _receiver = receiver;
            }

            public void Execute()
            {
                _receiver.ReadShoppingList();
            }

            public void Undo()
            {
               _receiver.UndoReadShoppingList();
             
            }
        }
        public class ReadWeatherCommand : ICommand
        {
            private readonly Receiver _receiver;

            public ReadWeatherCommand(Receiver receiver)
            {
                _receiver = receiver;
            }

            public void Execute()
            {
                _receiver.ReadWeather();
            }

            public void Undo()
            {
                _receiver.UndoWeather();
            }

        }

        public class UnknownCommand : ICommand
        {
            private readonly Receiver _receiver;

            public UnknownCommand(Receiver receiver)
            {
                _receiver = receiver;
            }
            public void Execute()
            {
                _receiver.UnknownCommandResponse(); //Console.WriteLine("Hmm.. I don't know that");
            }

            public void Undo()
            {
                // This command is not undoable
            }
        }

    }
}
