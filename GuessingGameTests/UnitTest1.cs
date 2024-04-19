using DiceGame;
using DiceGame.UserCommunication;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Moq;
using NUnit.Framework;

namespace GuessingGameTests
{
     
    public class Tests
    {
        private Mock<IDice> _diceMock;
        private Mock<IUserCommunication> _userCommunicationMock;
        private Game _cut;

        [SetUp]
        public void SetUp()
        {
            _diceMock = new Mock<IDice>();
            _userCommunicationMock = new Mock<IUserCommunication>();
            _cut = new Game(_diceMock.Object, _userCommunicationMock.Object);
        }
     


        [Test]
        public void PlayShallReturnVictory_IfUserGuessesTheNumberOnTheFirstTry()
        {
            var number = 3;
            _diceMock.Setup(mock => mock.Roll()).Returns(number);

            _userCommunicationMock.Setup(mock => mock.ReadInteger(It.IsAny<string>()))
                .Returns(number);
            _userCommunicationMock.Setup(mock => mock.ShowMessage("3"));

            var gameResult = _cut.Play();

            Assert.AreEqual(GameResult.Victory, gameResult);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]

        public void PlayShallReturnLoss_IfUserGuessesNeverGuessesTheNumber(int guess)
        {
            var number = 3;
            var wrongguess = guess;
            _diceMock.Setup(mock => mock.Roll()).Returns(number);

            _userCommunicationMock.Setup(mock => mock.ReadInteger(It.IsAny<string>()))
                .Returns(wrongguess);
            //_userCommunicationMock.Setup(mock => mock.ShowMessage("3"));

            var gameResult = _cut.Play();

            Assert.AreEqual(GameResult.Loss, gameResult);

        }

        [Test]
        public void PlayShallReturnVictory_IfUserGuessesTheNumberOnTheThirdTry()
        {
            SetupUserGuessingTheNumberOnTheThirdTry();
            
            var gameResult = _cut.Play();

            Assert.AreEqual(GameResult.Victory, gameResult);

        }

        [TestCase(GameResult.Victory, "You win")]
        [TestCase(GameResult.Loss, "You loose")]
        public void PrintResult_ShallShowProperMessageForGameResult(
            GameResult gameResult, string expectedMessage)
        {
            _cut.PrintResult(gameResult); // this should run the _userCommunicationMock.ShowMessage with the expectedMessage argument passed use Verify! to test it was done.
            _userCommunicationMock.Verify(
                mock => mock.ShowMessage(expectedMessage));
        }

        [TestCase("Dice rolled. Guess what number it shows in 3 tries.")]
        public void PrintResult_ShallShowProperMessageFor(string expectedMessage)
         
        {
            int _tries = 3;
            int number = 1;
            
            //_diceMock.Setup(mock => mock.Roll()).Returns(number);
            //_userCommunicationMock.Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            //    .Returns(number);
          
            _cut.Play(); // this should run the _userCommunicationMock.ShowMessage with the expectedMessage argument passed use Verify! to test it was done.
            _userCommunicationMock.Verify(
                mock => mock.ShowMessage(expectedMessage),
                Times.Once);
                ;
        }
        [Test]
        public void PlayShallAskForNumberThreeTimes_IfUserGuessesTheNumberOnTheThirdTry()
        {
            SetupUserGuessingTheNumberOnTheThirdTry();

            var gameResult = _cut.Play();

            _userCommunicationMock.Verify(
                mock => mock.ReadInteger(Resource.EnterNumberMessage),// mock => mock.ReadInteger("Enter a number"),
                Times.Exactly(3));

            Assert.AreEqual(GameResult.Victory, gameResult);

        }

        [Test]
        public void GuessingWrongNumberShould_WrongNumberMessage()
        {
            //_diceMock.Setup(mock => mock.Roll())
            //    .Returns(1);
            //_userCommunicationMock.Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            //    .Returns(2);
            SetupUserGuessingTheNumberOnTheThirdTry();

            var gameResult = _cut.Play();
            _userCommunicationMock.Verify(mock => mock.ShowMessage("Wrong number")
             ,Times.Exactly(2));
            
        }
        
        
        private void SetupUserGuessingTheNumberOnTheThirdTry()
        {
            var number = 3;
            _diceMock.Setup(mock => mock.Roll()).Returns(number);

            _userCommunicationMock.SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
                .Returns(1)
                .Returns(4)
                .Returns(number);
        }
    }
}