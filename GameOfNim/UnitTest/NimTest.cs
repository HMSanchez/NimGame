using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfNim;
namespace UnitTest
{
    [TestClass]
    public class NimTest
    {
        MainWindow mw = new MainWindow();
        
        [TestMethod]
        public void PlayerRotationIsPlayer1TurnFalseExpected()
        {
            bool expectedResult = false;
            mw.isPlayer1Turn = true;
            mw.PlayerRotation();
            Assert.AreEqual(expectedResult, mw.isPlayer1Turn);
            
        }
        [TestMethod]
        public void PlayerRotationIsPlayer1TurnTrueExpected()
        {
            bool expectedResult = true;
            mw.isPlayer1Turn = false;
            mw.PlayerRotation();
            Assert.AreEqual(expectedResult, mw.isPlayer1Turn);

        }
        [TestMethod]
        public void ComputerTurnMatchRemainingMinus1()
        {
            mw.matchesRemaining = 5;
            mw.ComputerTurn();
            Assert.IsTrue(mw.matchesRemaining == 4);
        }
        [TestMethod]
        public void EasyPVPComputerTurnRow1MatchRemainingMinus1()
        {          
            mw.isPVP = false;
            mw.difficulty = "Easy";
            mw.SetUp();
            mw.ComputerTurn();
            Assert.IsTrue(mw.row1MatchesLeft == 2);
        }
        [TestMethod]
        public void MediumPVCComputerTurnRow1MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Medium";
            mw.SetUp();
            mw.ComputerTurn();
            Assert.IsTrue(mw.row1MatchesLeft == 1);
        }
        [TestMethod]
        public void HardPVCComputerTurnRow1MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.ComputerTurn();
            Assert.IsTrue(mw.row1MatchesLeft == 1);
        }
        [TestMethod]
        public void HardPVCComputerTurnRow2MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.row1MatchesLeft = 0;
            mw.ComputerTurn();
            Assert.IsTrue(mw.row2MatchesLeft == 2);
        }
        [TestMethod]
        public void HardPVCComputerTurnRow3MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.row1MatchesLeft = 0;
            mw.row2MatchesLeft = 0;
            mw.ComputerTurn();
            Assert.IsTrue(mw.row3MatchesLeft == 7);
        }
        [TestMethod]
        public void HardPVCComputerTurnRow4MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.row1MatchesLeft = 0;
            mw.row2MatchesLeft = 0;
            mw.row3MatchesLeft = 0;
            mw.ComputerTurn();
            Assert.IsTrue(mw.row4MatchesLeft == 8);
        }
        [TestMethod]
        public void ComputerTurn1MatchRemaining()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            int row1LblCount = mw.row1labels.Count;
            mw.ComputerTurn();
            Assert.IsTrue(mw.row1labels.Count == row1LblCount-1);
        }
        [TestMethod]
        public void Row1BtnClickedMatchesRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.Row_one_btn_Click(null, null);
            Assert.IsTrue(mw.matchesRemaining == 21);
        }
        //row2match count needs to go down by 1 each time clicked
        [TestMethod]
        public void Row2MatchChange()
        {
            mw.isPVP = false;
            mw.difficulty = "Easy";
            mw.SetUp();
            mw.Row_two_btn_Click(null, null);
            Assert.IsTrue(mw.row2MatchesLeft == 2);

        }

        //row3match count needs to go down by 1 each time clicked
        [TestMethod]
        public void Row3MatchChange()
        {
            mw.isPVP = false;
            mw.difficulty = "Medium";
            mw.SetUp();
            mw.Row_three_btn_Click(null, null);
            Assert.IsTrue(mw.row3MatchesLeft == 6);
        }

        //row4match count needs to go down by 1 each time clicked
        [TestMethod]
        public void Row4MatchChange()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.Row_four_btn_Click(null, null);
            Assert.IsTrue(mw.row4MatchesLeft == 8);
        }

        //matchesRemaining goes down by 1 each time the button is clicked
        [TestMethod]
        public void Row2MatchesRemainingGoesDown1()
        {
            mw.isPVP = false;
            mw.difficulty = "Easy";
            mw.SetUp();
            mw.Row_two_btn_Click(null, null);
            Assert.IsTrue(mw.matchesRemaining == 5);
        }

        //matchesRemaining goes down by 1 each time the button is clicked
        [TestMethod]
        public void Row3MatchesRemainingGoesDown1()
        {
            mw.isPVP = false;
            mw.difficulty = "Medium";
            mw.SetUp();
            mw.Row_three_btn_Click(null, null);
            Assert.IsTrue(mw.matchesRemaining == 13);
        }

        //matchesRemaining goes down by 1 each time the button is clicked
        [TestMethod]
        public void Row4MatchesRemainingGoesDown1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.Row_four_btn_Click(null, null);
            Assert.IsTrue(mw.matchesRemaining == 21);
        }

        // matchTaken bool is changed to true
        [TestMethod]
        public void Row1MatchesTakenBoolChanges()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.Row_one_btn_Click(null, null);
            Assert.IsTrue(mw.matchTaken == true);
        }

        // matchTaken bool is changed to true
        [TestMethod]
        public void Row2MatchesTakenBoolChanges()
        {
            mw.isPVP = false;
            mw.difficulty = "Easy";
            mw.SetUp();
            mw.Row_two_btn_Click(null, null);
            Assert.IsTrue(mw.matchTaken == true);
        }

        // matchTaken bool is changed to true
        [TestMethod]
        public void Row3MatchesTakenBoolChanges()
        {
            mw.isPVP = false;
            mw.difficulty = "Medium";
            mw.SetUp();
            mw.Row_three_btn_Click(null, null);
            Assert.IsTrue(mw.matchTaken == true);
        }

        // matchTaken bool is changed to true
        [TestMethod]
        public void Row4MatchesTakenBoolChanges()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.Row_four_btn_Click(null, null);
            Assert.IsTrue(mw.matchTaken == true);

        }

        [TestMethod]
        public void ReplayYesButtonResetMatchesRemainingReset()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            int expected = 0;
            mw.SetUp();
            mw.Yes_Click(null, null);
            Assert.IsTrue(mw.matchesRemaining == expected);
        }
        [TestMethod]
        public void ReplayYesButtonResetGameModeReset()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            string expected = "";
            mw.SetUp();
            mw.Yes_Click(null, null);
            Assert.IsTrue(mw.gameMode == expected);
        }
        [TestMethod]
        public void ReplayYesButtonResetDifficultyReset()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            string expected = "";
            mw.SetUp();
            mw.Yes_Click(null, null);
            Assert.IsTrue(mw.difficulty == expected);
        }
        [TestMethod]
        public void ReplayYesButtonResetPlayerNameReset()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            string expected = "";
            mw.SetUp();
            mw.Yes_Click(null, null);
            Assert.IsTrue(mw.playerName == expected);
        }
        [TestMethod]
        public void ReplayYesButtonResetPlayer2NameReset()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            string expected = "";
            mw.SetUp();
            mw.Yes_Click(null, null);
            Assert.IsTrue(mw.player2Name == expected);
        }
        [TestMethod]
        public void ReplayYesButtonResetCPUNameReset()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            string expected = "";
            mw.SetUp();
            mw.Yes_Click(null, null);
            Assert.IsTrue(mw.computerName == expected);
        }
 
    }
}
