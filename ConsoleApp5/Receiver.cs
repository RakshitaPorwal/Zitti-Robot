using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Receiver
    {
        public DateTime _lastRoomCleaningTime = DateTime.MinValue;
        public DateTime _lastNewspaperFetchTime = DateTime.MinValue;
        public List<string> _shoppingList = new List<string>();
        public string lastWeather = " ";
        public string Output { get; set; }

        public void Greet()
        {
            Console.WriteLine("Hello, I am doing great.");
            Output = "Hello, I am doing great.";
        }

        public void SayGoodbye()
        {
            Console.WriteLine("Goodbye!");
            Output = "Goodbye!";
        }

        public void CleanRoom()
        {
            TimeSpan timeSinceLastCleaning = DateTime.Now - _lastRoomCleaningTime;
            if (timeSinceLastCleaning.TotalMinutes < 10)
            {
                Console.WriteLine($"The room was just cleaned {timeSinceLastCleaning.TotalMinutes} minute(s) ago. I hope it's not dirty");
                Output = $"The room was just cleaned {timeSinceLastCleaning.TotalMinutes} minute(s) ago. I hope it's not dirty";
                return;
            }

            Console.WriteLine($"Room is cleaned. It looks tidy now. Job completed at {DateTime.Now.ToString("hh:mm tt")}");
            Output = $"Room is cleaned. It looks tidy now. Job completed at {DateTime.Now.ToString("hh:mm tt")}";
            _lastRoomCleaningTime = DateTime.Now;
        }

        public void UndoCleanRoom()
        {
            _lastRoomCleaningTime = DateTime.MinValue;
            Console.WriteLine("Cleaning undone");
            Output = "Cleaning undone";
        }

        public void FetchNewspaper()
        {
            if (_lastNewspaperFetchTime.Date == DateTime.Now.Date)
            {
                Console.WriteLine("I think you don't get another newspaper the same day");
                Output = "I think you don't get another newspaper the same day";
                return;
            }

            Console.WriteLine("Here is your newspaper.");
            Output = "Here is your newspaper.";
            _lastNewspaperFetchTime = DateTime.Now;
        }
        public void UndoFetchNewspaper()
        {
            _lastNewspaperFetchTime = DateTime.MinValue;
            Console.WriteLine("Newspaper fetch undone");
            Output = "Newspaper fetch undone";
        }
       

        // Other methods

        public void AddToShoppingList(string[] items)
        {
            //if (_shoppingList.Contains(item))
            //{
            //    Console.WriteLine($"You already have {item} in your shopping list.");
            //    return false;
            //}

            //_shoppingList.Add(item);
            //Console.WriteLine($"{item} added to shopping list.");
            //return true;
            foreach (string item in items) {
                if (_shoppingList.Contains(item))
                {
                    Output = $"You already have {item} in your shopping list.";
                    Console.WriteLine($"You already have {item} in your shopping list.");
                }
                else
                {
                    _shoppingList.Add(item);
                    if (_shoppingList.Count >= 1)
                    {   
                        Output = $"{item} has been added to your shopping list.";
                        Console.WriteLine($"{item} has been added to your shopping list.");
                    }
                }
            }

        }

        public void UndoAddToShoppingList()
        {
            //{
            //    if (_shoppingList.Contains(item))
            //    {
            //        _receiver._shoppingList.Remove(_item);
            //        _receiver.Output = $"{_item} has been removed from your shopping list.";
            //    }
            //    else
            //    {
            //        _receiver.Output = $"{_item} was not in your shopping list.";
            //    }
            //THIS COMMAND IS NOT UNDOABLE
            Console.WriteLine("This Command is not undoable");
        }
        public string ReadShoppingList()
        {
            if (_shoppingList.Count == 0)
            {
                Console.WriteLine("Shopping list is empty.");
                return "Shopping list is empty.";
            }
            string item_list = string.Join(", ", _shoppingList);
            Console.WriteLine($"Here is your shopping list, {item_list}");
            return string.Join(", ", _shoppingList);
        }

        public void ClearShoppingList()
        {
            _shoppingList.Clear();
            Console.WriteLine("You have no items in your shopping list");
        }

        
        public void UndoReadShoppingList()
        {
            Console.WriteLine("Undoing read shopping list...");
            Output = "Undoing read shopping list...";
        }

        public void ReadWeather()
        {
            Output = "It's pleasant outside. You should take a walk.";
            Console.WriteLine("It's pleasant outside. You should take a walk.");
            lastWeather = "pleasant";
        }

        public void UndoWeather()
        {
            Console.WriteLine($"Undoing last weather command. Setting weather back to {lastWeather}.");
        }
      
        public void UnknownCommandResponse()
        {
            Output = "Hmm.. I don't know that";
            Console.WriteLine("Hmm.. I don't know that");
        }
        public void RemoveItem(string item)
        {
            if (_shoppingList.Contains(item))
            {
                _shoppingList.Remove(item);
                Output = $"{item} has been removed from your shopping list.";
                Console.WriteLine($"{item} has been removed from your shopping list.");
            }
            else
            {
                Output = $"{item} was not in your shopping list.";
                Console.WriteLine($"{item} was not in your shopping list.");
            }

        }

    }

}
