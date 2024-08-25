using ConsoleApp5;
using static ConsoleApp5.Commands;

namespace Commands.nunitTests
{
    public class Tests
    {
        private Receiver _receiver;
        private Sender _sender;

        [SetUp]
        public void Setup()
        {
            _receiver = new Receiver();
            _sender = new Sender(_receiver);

        }

        [Test]
        public void GreetCommand_Execute_ReturnsExpectedResult()
        {
            ICommand command = new GreetCommand(_receiver);

            _sender.SetCommand(command);
            _sender.ExecuteCommand();

            Assert.AreEqual("Hello, I am doing great.", _receiver.Output);
        }


        [Test]
        public void FetchNewspaperCommand_Execute_ReturnsExpectedResult()
        {
            ICommand command = new FetchNewspaperCommand(_receiver);

            _sender.SetCommand(command);
            _sender.ExecuteCommand();
            if (_receiver._lastNewspaperFetchTime.Date == DateTime.Now.Date)
                Assert.AreEqual("Here is your newspaper.", _receiver.Output);
            else {
                Assert.AreEqual("I think you don't get another newspaper the same day", _receiver.Output);
               _receiver._lastNewspaperFetchTime = DateTime.Now;
            }
        }

        [Test]
        public void AddToShoppingListCommand_Execute_ReturnsExpectedResult()
        {
            ICommand command = new AddToShoppingListCommand(_receiver, "Milk");

            _sender.SetCommand(command);
            _sender.ExecuteCommand();

            Assert.AreEqual("Milk has been added to your shopping list.", _receiver.Output);
        }

        [Test]
        public void ReadShoppingListCommand_Execute_ReturnsExpectedResult()
        {
            ICommand addToShoppingListCommand = new AddToShoppingListCommand(_receiver, "Milk");
            ICommand command = new ReadShoppingListCommand(_receiver);

            _sender.SetCommand(addToShoppingListCommand);
            _sender.ExecuteCommand();

            _sender.SetCommand(command);
            _sender.ExecuteCommand();

            Assert.AreEqual("Milk has been added to your shopping list.", _receiver.Output);
        }

        [Test]
        public void UnknownCommand_Execute_ReturnsExpectedResult()
        {
            ICommand command = new UnknownCommand(_receiver);

            _sender.SetCommand(command);
            _sender.ExecuteCommand();

            Assert.AreEqual("Hmm.. I don't know that", _receiver.Output);
        }

        [Test]
        public void ReadWeatherCommand_Execute_ReturnsExpectedResult()
        {
            ICommand command = new ReadWeatherCommand(_receiver);

            _sender.SetCommand(command);
            _sender.ExecuteCommand();

            Assert.AreEqual("It's pleasant outside. You should take a walk.", _receiver.Output);
        }


        [Test]
        public void ReadWeatherCommand_Execute_ShouldSetReceiverLastWeather()
        {
            // Arrange
           
            ICommand readWeatherCommand = new ReadWeatherCommand(_receiver);

            // Act
            readWeatherCommand.Execute();

            // Assert
            Assert.AreEqual("It's pleasant outside. You should take a walk.", _receiver.Output);
        }
        [Test]
        public void CleanRoom_WhenCalledAfter10Minutes_ReturnsSuccessMessage()
        {
            // Arrange
            
            ICommand cleanRoomCommand = new CleanRoomCommand(_receiver);
            _receiver._lastRoomCleaningTime = DateTime.Now.AddMinutes(-11);

            // Act
            cleanRoomCommand.Execute();

            // Assert
            Assert.AreEqual($"Room is cleaned. It looks tidy now. Job completed at {DateTime.Now.ToString("hh:mm tt")}", _receiver.Output);
            Assert.AreEqual(DateTime.Now.ToString("hh:mm tt"), _receiver._lastRoomCleaningTime.ToString("hh:mm tt"));
        }
    }
}