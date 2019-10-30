using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfNim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string computerName;
        public string playerName;
        public string player2Name;
        public string difficulty;
        public string gameMode;
        public int matchesRemaining;
        public int row1MatchesLeft;
        public int row2MatchesLeft;
        public int row3MatchesLeft;
        public int row4MatchesLeft;
        public bool isPVP;
        public bool isPlayer1Turn;
        public bool matchTaken = false;
        List<Label> row1labels = new List<Label>();
        List<Label> row2labels = new List<Label>();
        List<Label> row3labels = new List<Label>();
        List<Label> row4labels = new List<Label>();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets up the game variables(gamemode, player names, difficulty)
        /// changes grid visability
        /// calls the Setup()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (gameMode == "PVC" || gameMode == "PVP")
            {
                row_one_btn.Visibility = Visibility.Visible;
                row_two_btn.Visibility = Visibility.Visible;
                row_three_btn.Visibility = Visibility.Visible;
                row_four_btn.Visibility = Visibility.Visible;

                if (p_one_name.Text != "")
                {
                    playerName = p_one_name.Text;
                }
                else
                {
                    playerName = "Player One";
                }
                if (p_two_name.Visibility != Visibility.Hidden)
                {
                    if (p_two_name.Text != "")
                    {
                        player2Name = p_two_name.Text;
                    }
                    else
                    {
                        player2Name = "Player Two";

                    }
                }
                difficulty = diffSelect.Text;
                if (difficulty == "Easy")
                {
                    row_three_btn.Visibility = Visibility.Hidden;
                    row_four_btn.Visibility = Visibility.Hidden;
                }
                else if (difficulty == "Medium")
                {
                    row_four_btn.Visibility = Visibility.Hidden;
                }

                SetUp();
                SetUpGrid.Visibility = Visibility.Hidden;
                Game.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// changes other buttons visibility
        /// removes from the items from the two list
        /// removes one from matchesRemaining and matches left in that row
        /// matchtaken is changed to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Row_one_btn_Click(object sender, RoutedEventArgs e)
        {
            row_two_btn.Visibility = Visibility.Hidden;
            row_three_btn.Visibility = Visibility.Hidden;
            row_four_btn.Visibility = Visibility.Hidden;
            if(row1labels.Count != 0)
            {
                Row_one.Children.Remove(row1labels.Last());
                row1labels.Remove(row1labels.Last());
            }
            row1MatchesLeft --;
            matchesRemaining --;
            matchTaken = true;
            if(row1MatchesLeft == 0)
            {
                row_one_btn.Visibility = Visibility.Hidden;
            }

        }

        /// <summary>
        /// changes other buttons visibility
        /// removes from the items from the two list
        /// removes one from matchesRemaining and matches left in that row
        /// matchtaken is changed to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Row_two_btn_Click(object sender, RoutedEventArgs e)
        {
            row_one_btn.Visibility = Visibility.Hidden;
            row_three_btn.Visibility = Visibility.Hidden;
            row_four_btn.Visibility = Visibility.Hidden;
            if (row2labels.Count != 0)
            {
                Row_two.Children.Remove(row2labels.Last());
                row2labels.Remove(row2labels.Last());
            }
            row2MatchesLeft -= 1;
            matchesRemaining -= 1;
            matchTaken = true;
            if (row2MatchesLeft == 0)
            {
                row_two_btn.Visibility = Visibility.Hidden;
            }

        }

        /// <summary>
        /// changes other buttons visibility
        /// removes from the items from the two list
        /// removes one from matchesRemaining and matches left in that row
        /// matchtaken is changed to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Row_three_btn_Click(object sender, RoutedEventArgs e)
        {
            row_one_btn.Visibility = Visibility.Hidden;
            row_two_btn.Visibility = Visibility.Hidden;
            row_four_btn.Visibility = Visibility.Hidden;
            if (row3labels.Count != 0)
            {
                Row_three.Children.Remove(row3labels.Last());
                row3labels.Remove(row3labels.Last());
            }
            row3MatchesLeft -= 1;
            matchesRemaining -= 1;
            matchTaken = true;
            if (row3MatchesLeft == 0)
            {
                row_three_btn.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// changes other buttons visibility
        /// removes from the items from the two list
        /// removes one from matchesRemaining and matches left in that row
        /// matchtaken is changed to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Row_four_btn_Click(object sender, RoutedEventArgs e)
        {
            row_one_btn.Visibility = Visibility.Hidden;
            row_two_btn.Visibility = Visibility.Hidden;
            row_three_btn.Visibility = Visibility.Hidden;
            if (row4labels.Count != 0)
            {
                Row_four.Children.Remove(row4labels.Last());
                row4labels.Remove(row4labels.Last());
            }
            row4MatchesLeft -= 1;
            matchesRemaining -= 1;
            matchTaken = true;
            if (row4MatchesLeft == 0)
            {
                row_four_btn.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Checks to see if matchTaken is True (meaning the current player took a match)
        /// If Yes
        ///     Checks If Matches Remaining is below 1
        ///         If yes calls EndGame() and changes winning label  
        ///         If No Checks isPVP()
        ///             If Yes calls PlayerRotation()
        ///             If No calls ComputerTurn()
        /// If No
        /// Does Nothing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndTurn_btn_Click(object sender, RoutedEventArgs e)
        {
            if (matchTaken == true)
            {
                if (matchesRemaining == 1)
                {
                    if (isPVP == true)
                    {
                        if (isPlayer1Turn == true)
                        {
                            Win_Announce.Content = playerName + " Wins!";
                        }
                        else
                        {
                            Win_Announce.Content = player2Name + " Wins!";
                        }
                    }
                    else
                    {
                        if (isPlayer1Turn == true)
                        {
                            Win_Announce.Content = playerName + " Wins!";
                        }
                        else
                        {
                            Win_Announce.Content = computerName + " Wins!";
                        }
                    }

                    EndGame();
                }
                if (matchesRemaining <= 0)
                {
                    //Change win label to the opposite of current player
                    Game.Visibility = Visibility.Hidden;
                    EndScreen.Visibility = Visibility.Visible;
                    if (isPVP == true)
                    {
                        if (isPlayer1Turn == true)
                        {
                            
                            Win_Announce.Content = player2Name + " Wins!";
                        }
                        else
                        {
                            Win_Announce.Content = playerName + " Wins!";
                        }
                    }
                    else
                    {
                        if (isPlayer1Turn == true)
                        {
                            Win_Announce.Content = computerName + " Wins!";
                        }
                        else
                        {
                            Win_Announce.Content = playerName + " Wins!";
                        }
                    }
                    
                }
                else
                {
                    if (gameMode == "PVP")
                    {
                        matchTaken = false;
                        PlayerRotation();
                    }
                    else if (gameMode == "PVC")
                    {
                        matchTaken = false;
                        ComputerTurn();
                    }
                    else
                    {
                        Console.WriteLine("Game Mode Was Not Changed Correctly");
                    }
                }
            }
            
        }
        /// <summary>
        /// Takes the user back to the start screen for a new game, resets all game variables, hides the necessary grids  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            SetUpGrid.Visibility = Visibility.Visible;
            Game.Visibility = Visibility.Hidden;
            EndScreen.Visibility = Visibility.Hidden;
            //playerName = p_one_name.Text;
            Turn_Label.Visibility = Visibility.Visible;
            row1labels.Clear();
            row2labels.Clear();
            row3labels.Clear();
            row4labels.Clear();
            p_one_name.Text = "Player 1 Name";
            p_two_name.Text = "Player 2 Name";
            computerName = "";
            playerName = "";
            playerName = "";
            player2Name = "";
            difficulty = "";
            gameMode = "";
            matchesRemaining = 0;
            row1MatchesLeft = 0;
            row2MatchesLeft = 0;
            row3MatchesLeft = 0;
            row4MatchesLeft = 0;
            isPVP = false;
            isPlayer1Turn = true;
            matchTaken = false;

        }
        /// <summary>
        /// Closes the application window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        /// <summary>
        /// Essentially it takes the computers turn when the End Turn Button is pressed
        /// Checks on the amount of matches left and branches
        ///     1 Match left means it declares the current player as the winner and moves to the end screen
        ///     Less than one match left means it declares the computer as the winner
        ///     More than one match the computer checks row1-4Matches remaining and takes a match from the first available row
        ///     Taking a match includes removing the match label from that row and removing the label from the list of labels, and subtract 1 from row1-4MatchesLeft
        ///     Subtracts 1 from matches remainig
        /// </summary>
        public void ComputerTurn()
        {
            if(matchesRemaining == 1)
            {
                EndGame();
            }
            else if (matchesRemaining > 1)
            {
                if (row1MatchesLeft > 0)
                {
                    //row1labels[0].Visibility = Visibility.Hidden;
                    //Label l = row1labels[0];
                    Row_one.Children.Remove(row1labels[0]);
                    row1labels.Remove(row1labels[0]);
                    row1MatchesLeft--;
                    
                }
                else if (row2MatchesLeft > 0)
                {
                    Row_two.Children.Remove(row2labels[0]);
                    row2labels.Remove(row2labels[0]);
                    row2MatchesLeft--;
                    //Hide Match 2 Label
                }
                else if (row3MatchesLeft > 0)
                {
                    Row_three.Children.Remove(row3labels[0]);
                    row3labels.Remove(row3labels[0]);
                    row3MatchesLeft--;
                    //Hide Match 3 Label
                }
                else if (row4MatchesLeft > 0)
                {
                    Row_four.Children.Remove(row4labels[0]);
                    row4labels.Remove(row4labels[0]);
                    row4MatchesLeft--;
                    //Hide Match 4 Label
                }
                else
                {
                    Console.WriteLine("There are no matches left in any rows");
                }
                if(row1MatchesLeft > 0)
                {
                    row_one_btn.Visibility = Visibility.Visible;
                }
                if(row2MatchesLeft > 0)
                {
                    row_two_btn.Visibility = Visibility.Visible;
                }
                
                if(difficulty == "Hard" || difficulty == "Medium")
                {
                    if(row3MatchesLeft > 0)
                    {
                        row_three_btn.Visibility = Visibility.Visible;
                    }
                    
                    if(difficulty == "Hard")
                    {
                        if(row4MatchesLeft > 0)
                        {
                            row_four_btn.Visibility = Visibility.Visible;
                        }
                        
                    }                   
                }               
                matchesRemaining--;
            }
            else
            {
                if (isPVP == true)
                {
                    if (isPlayer1Turn == true)
                    {
                        Win_Announce.Content = player2Name + "Wins!";
                    }
                    else
                    {
                        Win_Announce.Content = playerName + "Wins!";
                    }
                }
                else
                {
                    if (isPlayer1Turn == true)
                    {
                        Win_Announce.Content = computerName + "Wins!";
                    }
                    else
                    {
                        Win_Announce.Content = playerName + "Wins!";
                    }
                }
                EndGame();
            }
        }
        /// <summary>
        /// Places the appropriate number of match labels into corresponding stack panels,
        /// number of match labels and rows based on difficulty  
        /// </summary>
        public void PlaceMatches()
        {
            var counter1 = 1;
            var counter2 = 1;
            var counter3 = 1;
            var counter4 = 1;
            for (int i = 0; i < row1MatchesLeft; i++)
            {
                Label label = new Label();
                label.Content = "Match";
                label.Name = "row1match" + counter1;

                //label.Name = "row1match" + i;

                row1labels.Add(label);
                Row_one.Children.Add(label);
                 counter1++;

            }
            for (int i = 0; i < row2MatchesLeft; i++)
            {
                Label label = new Label();
                label.Content = "Match";

                label.Name = "row2match" + counter2;
                row2labels.Add(label);

                Row_two.Children.Add(label);
                counter2++;

            }
            for (int i = 0; i < row3MatchesLeft; i++)
            {
                Label label = new Label();
                label.Content = "Match";

                label.Name = "row3match" + counter3;
                row3labels.Add(label);

                Row_three.Children.Add(label);
                counter3++;

            }
            for (int i = 0; i < row4MatchesLeft; i++)
            {
                Label label = new Label();
                label.Content = "Match";

                label.Name = "row4match" + counter4;
                row4labels.Add(label);

                Row_four.Children.Add(label);
                counter4++;

            }



        }
        /// <summary>
        /// Sets up the base game variables, set up default turn label name for PVP,
        /// hides turn label if not PVP,
        /// assign row matches and matches remaining based on difficulty, calls the PlaceMatches() method 
        /// </summary>
        public void SetUp()
        {
      
            Turn_Label.Content = playerName;
            isPlayer1Turn = true;
            int selectedIndex = diffSelect.SelectedIndex;
           
            Object selectedItem = diffSelect.SelectedItem;
            if (difficulty == "Easy")
            {
                row1MatchesLeft = 3;
                row2MatchesLeft = 3;
                matchesRemaining = 6;
            }
            else if (difficulty == "Medium")
            {
                row1MatchesLeft = 2;
                row2MatchesLeft = 5;
                row3MatchesLeft = 7;
                matchesRemaining = 14;

            }
            else
            {
                row1MatchesLeft = 2;
                row2MatchesLeft = 3;
                row3MatchesLeft = 8;
                row4MatchesLeft = 9;
                matchesRemaining = 22;


            }

            if (isPVP != true)
            {

                Turn_Label.Visibility = Visibility.Hidden;
            }
            PlaceMatches();
        }
        /// <summary>
        /// Changes player turn,
        /// changes isPlayer1Turn boolean,
        /// changes row buttons to visible,
        /// changes turn label based on current players turn
        /// </summary>
        public void PlayerRotation()
        {
          

            if (matchesRemaining == 1)
            {
                EndGame();
            }


            if (isPlayer1Turn == true)
            {

                isPlayer1Turn = false;
            }
            else
            {
                isPlayer1Turn = true;
            }


            if (row1MatchesLeft > 0)
            {
                row_one_btn.Visibility = Visibility.Visible;
            }
            if (row2MatchesLeft > 0)
            {
                row_two_btn.Visibility = Visibility.Visible;

            }
            if (row3MatchesLeft > 0)
            {
                row_three_btn.Visibility = Visibility.Visible;

            }
            if (row4MatchesLeft > 0)
            {
                row_four_btn.Visibility = Visibility.Visible;

            }

                if (isPlayer1Turn == false)
                {
                    Turn_Label.Content = player2Name;

                }
                else
                {
                    Turn_Label.Content = playerName;

                }
         
        }
        /// <summary>
        /// Sets game mode,
        /// changes label visibility based on game mode selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PVPSelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = modeSelect.SelectedIndex;
            if (selectedIndex == 1)
            {
                p_two_name.Visibility = Visibility.Hidden;
                Player_Two_Label.Visibility = Visibility.Hidden;
                gameMode = "PVC";
                computerName = "CPU";
            }
            else
            {
                p_two_name.Visibility = Visibility.Visible;
                Player_Two_Label.Visibility = Visibility.Visible;
                gameMode = "PVP";
                isPVP = true;

            }
        }
        /// <summary>
        /// changes the visibility of thw two grids
        /// </summary>
        public void EndGame()
        {
            Game.Visibility = Visibility.Hidden;
            EndScreen.Visibility = Visibility.Visible;
        }


    }

}
