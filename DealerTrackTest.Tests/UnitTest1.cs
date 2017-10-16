using System;
using InterviewTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteviewTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReceiveBasicString()
        {
            //Assign
            //CreateString
            var passedString = "Automotive";
            var expectedString = "A6e";

            //Act
            var sut = ReturnString.PassMeAStringAnyString(passedString);

            //Assert
            Assert.AreEqual(expectedString, sut);
        }

        [TestMethod]
        public void ShouldReturnWordIfNoDuplicateLetters()
        {
            //Assign
            var passedString = "is";
            var expectedString = "is";

            //Act
            var sut = ReturnString.PassMeAStringAnyString(passedString);

            //Assert
            Assert.AreEqual(expectedString, sut);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenNoWordIsPassed()
        {
            //Assign
            var passedString = "";

            //Act
            var sut = ReturnString.PassMeAStringAnyString(passedString);

        }

        [TestMethod]
        public void ShouldReturnSpecialCharsInSamePlace()
        {
            //Assign
            var passedString = "Automotive's";
            var expectedString = "A7's";

            //Act
            var sut = ReturnString.PassMeAStringAnyString(passedString);

            //Assert
            Assert.AreEqual(expectedString, sut);
        }

        [TestMethod]
        public void PassIn1LetterShouldReturnThatLetter()
        {
            //Assign
            var passedString = "I am";
            var expectedString = "I am";

            //Act
            var sut = ReturnString.PassMeAStringAnyString(passedString);

            //Assert
            Assert.AreEqual(expectedString, sut);
        }

        [TestMethod]
        public void PassMultiWordsWithSpecialCharactersShouldReturn()
        {
            //Assign
            var passedString = "How, are things going buddy?";
            var expectedString = "H1w, a1e t4s g3g b2y?";

            //Act
            var sut = ReturnString.PassMeAStringAnyString(passedString);

            //Assert
            Assert.AreEqual(expectedString, sut);
        }

        [TestMethod]
        public void PassMultiWordsBeginningAndEndingWithSpecialShouldReturn()
        {
            //Assign
            var passedString = "_Hello, World_";
            var expectedString = "_H2o, W3d_";

            //Act
            var sut = ReturnString.PassMeAStringAnyString(passedString);

            //Assert
            Assert.AreEqual(expectedString, sut);
        }
    }
}
