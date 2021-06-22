using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.IO;

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //-------global vars---------------
        // to store player ships in the grid
        private int[,] userGrid = new int[10, 10];
        //to save the coordiantes of user ships,to remove the ships present on the user grid during reset
        private int[][] userBoatsCopy = new int[5][];
        //to save the user ship coordinates
        private int[][] userShipSpaces = new int[5][];
        //to save the user moves to check for used hit or miss cell
        private IList<int> userMoves = new List<int>();
        //to count the moves so that winner is not checked until 16th move
        private int move;
        // 0=user, 1=computer
        private int player;
        //the buttons on player's grid
        private Button[] playerButtons = new Button[100];
        //the buttons on computer grid
        private Button[] compButtons = new Button[100];
        // the user is not allowed to click on grid when the one round is over
        private Boolean allowGridClick = false;

        public MainWindow()
        {
            InitializeComponent();
            createButtons(gridPlayer);
            createButtons(gridComputer);
        }

        /**
         * when ok button for AIRCARFT carrier is clicked, it checks for user input,
         * adds the ships on the grid and respective arrays, hides the related labels
         * and textboxes, and make the button disable.
         */
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            int colVal = 0;
            int rowVal = 0;

            int dir = 0;
            if (txtRow.Text == "" || txtCol.Text == "")
            {
                labelOutOfRange.Content = "Please enter a valid value";
                labelOutOfRange.Visibility = Visibility.Visible;
            }

            if (!validateRowValue(txtRow))
                return;
            else
                rowVal = convertLetterToNum(txtRow.Text);

            if (!validateColumnValue(txtCol))
                return;
            else colVal = Int32.Parse(txtCol.Text) - 1;
            if (radioButtonHorizontal.IsChecked == false && radioButtonVertical.IsChecked == false)
            {
                labelOutOfRange.Content = "Please choose an alignment!";
                labelOutOfRange.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                if (radioButtonHorizontal.IsChecked == true)
                {
                    dir = 0;
                }
                else if (radioButtonVertical.IsChecked == true)
                {
                    dir = 1;
                }
            }

            if (!userShipAdded(rowVal, colVal, dir, 5, 0))
            {
                labelOutOfRange.Content = "The coordinates are not valid";
                labelOutOfRange.Visibility = Visibility.Visible;
                txtCol.Text = "";
                txtRow.Text = "";
            }
            else
            {
                if (dir == 0)
                {
                    placePlayerShips(0, colVal, rowVal, 5);
                }
                else if (dir == 1)
                {
                    placePlayerShips(1, colVal, rowVal, 5);
                }

                hideVisibility(lblCol, lblRow, txtCol, txtRow, btnOK,
                            radioButtonVertical, radioButtonHorizontal);

                btnAircarftCarrier.IsEnabled = false;
                if (allShipsPlaced())
                    btnStart.IsEnabled = true;

            }//end else for coords valid
        }

        /**
         * when ok button for BATTLESHIP is clicked, it checks for user input,
         * adds the ships on the grid and respective arrays, hides the related labels
         * and textboxes, and make the button disable.
         */
        private void buttonOKBatlleship_Click(object sender, RoutedEventArgs e)
        {
            int colVal = 0;
            int rowVal = 0;

            int dir = 0;
            if (textBoxRowBattleship.Text == "" || textBoxColBattleship.Text == "")
            {
                labelOutOfRange.Content = "Please enter a valid value";
                labelOutOfRange.Visibility = Visibility.Visible;
            }
            if (!validateRowValue(textBoxRowBattleship))
                return;
            else
                rowVal = convertLetterToNum(textBoxRowBattleship.Text);

            if (!validateColumnValue(textBoxColBattleship))
                return;
            else colVal = Int32.Parse(textBoxColBattleship.Text) - 1;

            if (radioButtonHorizontalBattleship.IsChecked == false && radioButtonVerticalBattleship.IsChecked == false)
            {
                labelOutOfRange.Content = "Please choose an alignment!";
                labelOutOfRange.Visibility = Visibility.Visible;
                return;
            }

            else
            {
                if (radioButtonHorizontalBattleship.IsChecked == true)
                {
                    dir = 0;
                }
                else if (radioButtonVerticalBattleship.IsChecked == true)
                {
                    dir = 1;
                }
            }

            if (!userShipAdded(rowVal, colVal, dir, 4, 1))
            {
                labelOutOfRange.Content = "The coordinates are not valid";
                labelOutOfRange.Visibility = Visibility.Visible;
                textBoxColBattleship.Text = "";
                textBoxRowBattleship.Text = "";
            }
            else
            {
                if (dir == 0)
                {
                    placePlayerShips(0, colVal, rowVal, 4);
                }
                else if (dir == 1)
                {
                    placePlayerShips(1, colVal, rowVal, 4);
                }

                hideVisibility(lblColBattleship, lblRowBattleship, textBoxColBattleship,
                    textBoxRowBattleship, buttonOKBattleship, radioButtonVerticalBattleship, radioButtonHorizontalBattleship);
                btnBattleship.IsEnabled = false;
                if (allShipsPlaced())
                    btnStart.IsEnabled = true;
            }
        }


        /**
        * when ok button for SUBMARINE is clicked, it checks for user input,
        * adds the ships on the grid and respective arrays, hides the related labels
        * and textboxes, and make the button disable.
        */
        private void buttonOKSubmarine_Click(object sender, RoutedEventArgs e)
        {
            int colVal = 0;
            int rowVal = 0;

            int dir = 0;
            if (textBoxRowSubmarine.Text == "" || textBoxColSubmarine.Text == "")
            {
                labelOutOfRange.Content = "Please enter a valid value";
                labelOutOfRange.Visibility = Visibility.Visible;
            }
            if (!validateRowValue(textBoxRowSubmarine))
                return;
            else
                rowVal = convertLetterToNum(textBoxRowSubmarine.Text);

            if (!validateColumnValue(textBoxColSubmarine))
                return;
            else colVal = Int32.Parse(textBoxColSubmarine.Text) - 1;
            if (radioButtonHorizontalSubmarine.IsChecked == false && radioButtonVerticalSubmarine.IsChecked == false)
            {
                labelOutOfRange.Content = "Please choose an alignment!";
                labelOutOfRange.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                if (radioButtonHorizontalSubmarine.IsChecked == true)
                {
                    dir = 0;
                }
                else if (radioButtonVerticalSubmarine.IsChecked == true)
                {
                    dir = 1;
                }
            }

            if (!userShipAdded(rowVal, colVal, dir, 3, 2))
            {
                labelOutOfRange.Content = "The coordinates are not valid";
                labelOutOfRange.Visibility = Visibility.Visible;
                textBoxColSubmarine.Text = "";
                textBoxRowSubmarine.Text = "";
            }
            else
            {
                if (dir == 0)
                {
                    placePlayerShips(0, colVal, rowVal, 3);
                }
                else if (dir == 1)
                {
                    placePlayerShips(1, colVal, rowVal, 3);
                }

                hideVisibility(lblColSubmarine, lblRowSubmarine, textBoxColSubmarine, textBoxRowSubmarine,
                    buttonOKSubmarine, radioButtonVerticalSubmarine, radioButtonHorizontalSubmarine);

                btnSubmarine.IsEnabled = false;
                if (allShipsPlaced())
                    btnStart.IsEnabled = true;
            }
        }

        /**
        * when ok button for CRUISER is clicked, it checks for user input,
        * adds the ships on the grid and respective arrays, hides the related labels
        * and textboxes, and make the button disable.
        */
        private void buttonOKCruiser_Click(object sender, RoutedEventArgs e)
        {
            int colVal = 0;
            int rowVal = 0;

            int dir = 0;
            if (textBoxRowCruiser.Text == "" || textBoxColCruiser.Text == "")
            {
                labelOutOfRange.Content = "Please enter a valid value";
                labelOutOfRange.Visibility = Visibility.Visible;
            }
            if (!validateRowValue(textBoxRowCruiser))
                return;
            else
                rowVal = convertLetterToNum(textBoxRowCruiser.Text);

            if (!validateColumnValue(textBoxColCruiser))
                return;
            else colVal = Int32.Parse(textBoxColCruiser.Text) - 1;

            if (radioButtonHorizontalCruiser.IsChecked == false && radioButtonVerticalCruiser.IsChecked == false)
            {
                labelOutOfRange.Content = "Please choose an alignment!";
                labelOutOfRange.Visibility = Visibility.Visible;
                return;
            }

            else
            {
                if (radioButtonHorizontalCruiser.IsChecked == true)
                {
                    dir = 0;
                }
                else if (radioButtonVerticalCruiser.IsChecked == true)
                {
                    dir = 1;
                }
            }

            if (!userShipAdded(rowVal, colVal, dir, 3, 3))
            {
                labelOutOfRange.Content = "The coordinates are not valid";
                labelOutOfRange.Visibility = Visibility.Visible;
                textBoxColCruiser.Text = "";
                textBoxRowCruiser.Text = "";
            }
            else
            {
                if (dir == 0)
                {
                    placePlayerShips(0, colVal, rowVal, 3);
                }
                else if (dir == 1)
                {
                    placePlayerShips(1, colVal, rowVal, 3);
                }
                hideVisibility(lblColCruiser, lblRowCruiser, textBoxColCruiser, textBoxRowCruiser,
                    buttonOKCruiser, radioButtonVerticalCruiser, radioButtonHorizontalCruiser);

                btnCruiser.IsEnabled = false;
                if (allShipsPlaced())
                    btnStart.IsEnabled = true;
            }
        }



        /**
        * when ok button for DESTROYER is clicked, it checks for user input,
        * adds the ships on the grid and respective arrays, hides the related labels
        * and textboxes, and make the button disable.
        */
        private void buttonOKDestroyer_Click(object sender, RoutedEventArgs e)
        {

            int colVal = 0;
            int rowVal = 0;

            int dir = 0;
            if (textBoxRowDestroyer.Text == "" || textBoxColDestroyer.Text == "")
            {
                labelOutOfRange.Content = "Please enter a valid value";
                labelOutOfRange.Visibility = Visibility.Visible;
            }

            if (!validateRowValue(textBoxRowDestroyer))
                return;
            else
                rowVal = convertLetterToNum(textBoxRowDestroyer.Text);

            if (!validateColumnValue(textBoxColDestroyer))
                return;
            else colVal = Int32.Parse(textBoxColDestroyer.Text) - 1;

            if (radioButtonHorizontalDestroyer.IsChecked == false && radioButtonVerticalDestroyer.IsChecked == false)
            {
                labelOutOfRange.Content = "Please choose an alignment!";
                labelOutOfRange.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                if (radioButtonHorizontalDestroyer.IsChecked == true)
                {
                    dir = 0;
                }
                else if (radioButtonVerticalDestroyer.IsChecked == true)
                {
                    dir = 1;
                }
            }

            if (!userShipAdded(rowVal, colVal, dir, 2, 4))
            {
                labelOutOfRange.Content = "The coordinates are not valid";
                labelOutOfRange.Visibility = Visibility.Visible;
                textBoxColDestroyer.Text = "";
                textBoxRowDestroyer.Text = "";
            }
            else
            {
                if (dir == 0)
                {
                    placePlayerShips(0, colVal, rowVal, 2);
                }
                else if (dir == 1)
                {
                    placePlayerShips(1, colVal, rowVal, 2);
                }
                hideVisibility(lblColDestroyer, lblRowDestroyer, textBoxColDestroyer, textBoxRowDestroyer,
                    buttonOKDestroyer, radioButtonVerticalDestroyer, radioButtonHorizontalDestroyer);

                btnDestroyer.IsEnabled = false;
                if (allShipsPlaced())
                    btnStart.IsEnabled = true;
            }
        }

        /**
        * When button is clicked , it shows the related labels and textboxes
        */
        private void btnAircarftCarrier_Click(object sender, RoutedEventArgs e)
        {
            showVisibility(lblCol, lblRow, txtCol, txtRow, btnOK, radioButtonVertical,
                       radioButtonHorizontal);

        }
        /*
         * When button is clicked , it shows the related labels and textboxes
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            showVisibility(lblColBattleship, lblRowBattleship, textBoxColBattleship, textBoxRowBattleship,
                buttonOKBattleship, radioButtonVerticalBattleship, radioButtonHorizontalBattleship);
        }

        /*
         * When button is clicked , it shows the related labels and textboxes
         */
        private void btnSubmarine_Click(object sender, RoutedEventArgs e)
        {
            showVisibility(lblColSubmarine, lblRowSubmarine, textBoxColSubmarine, textBoxRowSubmarine,
                buttonOKSubmarine, radioButtonVerticalSubmarine, radioButtonHorizontalSubmarine);
        }
        /*
         * When button is clicked , it shows the related labels and textboxes
         */
        private void btnCruiser_Click(object sender, RoutedEventArgs e)
        {
            showVisibility(lblColCruiser, lblRowCruiser, textBoxColCruiser, textBoxRowCruiser,
                buttonOKCruiser, radioButtonVerticalCruiser, radioButtonHorizontalCruiser);
        }
        /*
        * When button is clicked , it shows the related labels and textboxes
        */
        private void btnDestroyer_Click(object sender, RoutedEventArgs e)
        {
            showVisibility(lblColDestroyer, lblRowDestroyer, textBoxColDestroyer, textBoxRowDestroyer,
                buttonOKDestroyer, radioButtonVerticalDestroyer, radioButtonHorizontalDestroyer);

        }
        /*
        * makes the labels and textboxes visible
        */
        private void showVisibility(Label lblCol, Label lblRow, TextBox txtBoxCol, TextBox txtBoxRow,
            Button btnOk, RadioButton vertical, RadioButton horizontal)
        {
            lblCol.Visibility = Visibility.Visible;
            lblRow.Visibility = Visibility.Visible;
            txtBoxCol.Visibility = Visibility.Visible;
            txtBoxRow.Visibility = Visibility.Visible;
            btnOk.Visibility = Visibility.Visible;
            vertical.Visibility = Visibility.Visible;
            horizontal.Visibility = Visibility.Visible;
        }
        /**
        * Converts the given string alphabet to a number for row label
        * Param String letter which is user input for the row
        * Return an int number corresponding to row value
        */
        private int convertLetterToNum(String letter)
        {
            int num = -1;
            switch (letter.ToUpper())
            {
                case "A":
                    return 0;
                case "B":
                    return 1;
                case "C":
                    return 2;
                case "D":
                    return 3;
                case "E":
                    return 4;
                case "F":
                    return 5;
                case "G":
                    return 6;
                case "H":
                    return 7;
                case "I":
                    return 8;
                case "J":
                    return 9;
            }
            return num;
        }
        /**
         * Validates the given textbox value to make sure it is in range
         * Param textcol is the textbox with user input
         * Return true if the input is valid,false if it is invalid
         */
        private Boolean validateColumnValue(TextBox textCol)
        {
            Boolean colValid = Regex.IsMatch(textCol.Text, @"^([1-9]|10)$");
            if (!colValid)
            {
                textCol.Text = "";
                labelOutOfRange.Content = "Enter a valid value for column";
                labelOutOfRange.Visibility = Visibility.Visible;
                return false;
            }
            else
                return true;
        }
        /*
         * Validates the given textbox value to make sure it is in range
         * Param textrow is the textbox with user input
         * Return true if the input is valid,false if it is invalid 
         */
        private Boolean validateRowValue(TextBox textRow)
        {

            Boolean rowValid = Regex.IsMatch(textRow.Text, @"^[a-jA-J]$");
            if (!rowValid)
            {
                textRow.Text = "";
                labelOutOfRange.Content = "Enter a valid value for row";
                labelOutOfRange.Visibility = Visibility.Visible;

                return false;
            }
            else return true;
        }

        /*
         * checks if the user input is valid and add the ship on the player grid array
         * and populate the userboat array. It also checks if the space around the ship
         * is available
         * Return true if the ship can be added,otherwise it returns false
         */
        private Boolean userShipAdded(int rowValue, int colValue, int dir, int shipLength, int shipValue)
        {
            int coord = rowValue * 10 + colValue;
            if (isShipCoordsValid(userGrid, dir, coord, shipLength) &&
                    checkSpaceAroundShip(userGrid, dir, coord, shipLength))
            {
                userBoats[shipValue] = new int[shipLength];
                addShipToGrid(userGrid, userBoats[shipValue], dir, coord, shipLength);
                addSpaceAroundShip(userGrid, dir, coord, shipLength);

                return true;
            }
            else return false;
        }
        /**
         * hides the given labels and textboxes
         */
        private void hideVisibility(Label lblCol, Label lblRow, TextBox txtBoxCol, TextBox txtBoxRow,
            Button btnOk, RadioButton vertical, RadioButton horizontal)
        {
            lblCol.Visibility = Visibility.Hidden;
            lblRow.Visibility = Visibility.Hidden;
            txtBoxCol.Visibility = Visibility.Hidden;
            txtBoxRow.Visibility = Visibility.Hidden;
            btnOk.Visibility = Visibility.Hidden;
            vertical.Visibility = Visibility.Hidden;
            horizontal.Visibility = Visibility.Hidden;
            labelOutOfRange.Visibility = Visibility.Hidden;
        }
        /**
         * verifies that user name is entered, and all the ships are disabled
         * changes the visibility of labels and textboxes, copies userBoats
         */
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (txtPlayerName.Text.Equals(""))
                MessageBox.Show("Please enter your name.");
            else if (!allShipsPlaced())
            {
                labelOutOfRange.Content = "Please place all the ships first!";
                labelOutOfRange.Visibility = Visibility.Visible;
            }
            else
            {
                hideTheControls();
                controlsVisibility();
                userShipsLeftLabel.Content = "17";
                enemyShipsLeftLabel.Content = "17";
                labelPlayerWins.Content = "\'s Wins:";
                labelPlayerWins.Content = txtPlayerName.Text + labelPlayerWins.Content;
                computerSetup();
                allowGridClick = true;
                checkPlayer();
                //copies userBoats to userBoatsCopy to remove pictureboxes 
                for (int i = 0; i < 5; i++)
                {
                    int len = userBoats[i].Length;
                    userBoatsCopy[i] = new int[len];
                    Array.Copy(userBoats[i], userBoatsCopy[i], len);
                }
            }

        }
        private void hideTheControls()
        {
            lblHelp.Visibility = Visibility.Hidden;
            lblPlayerName.Visibility = Visibility.Hidden;
            txtPlayerName.Visibility = Visibility.Hidden;
            lblYourShips.Visibility = Visibility.Hidden;
            groupboxBattleship.Visibility = Visibility.Hidden;
            btnAircarftCarrier.Visibility = Visibility.Hidden;
            btnBattleship.Visibility = Visibility.Hidden;
            btnSubmarine.Visibility = Visibility.Hidden;
            btnCruiser.Visibility = Visibility.Hidden;
            btnDestroyer.Visibility = Visibility.Hidden;
            btnStart.Visibility = Visibility.Hidden;
            labelOutOfRange.Visibility = Visibility.Hidden;

        }
        private void controlsVisibility()
        {
            labelPlayerWins.Visibility = Visibility.Visible;
            txtPlayerWinPoints.Visibility = Visibility.Visible;
            labelPlayerLosses.Visibility = Visibility.Visible;
            txtPlayerLossPoints.Visibility = Visibility.Visible;
            buttonReset.Visibility = Visibility.Visible;
        }
        /**
         * resets the game setup 
         */
        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }
        /**
       * hides the textboxes and labels for ships placements , and shows the textboxes and labels
       * to play
       */
        private void reset()
        {
            emptyTextBoxes();
            changeControlsVisibility();

            btnAircarftCarrier.IsEnabled = true;
            btnBattleship.IsEnabled = true;
            btnCruiser.IsEnabled = true;
            btnSubmarine.IsEnabled = true;
            btnDestroyer.IsEnabled = true;

            txtPlayerWinPoints.Text = "0";
            txtPlayerLossPoints.Text = "0";

            // makes the hit and miss buttons go back to normal color
            for (int i = 0; i < playerButtons.Length; i++)
            {
                playerButtons[i].Background = Brushes.Transparent;
                compButtons[i].Background = Brushes.Transparent;
            }

            // removes the pictureboxes from player's grid
            for (int i = 0; i < userBoatsCopy.Length; i++)
            {
                for (int j = 0; j < userBoatsCopy[i].Length; j++)
                {
                    int coord = userBoatsCopy[i][j];
                    playerButtons[coord].Content = null;
                }
            }
            //reset variables
            userBoats = new int[5][];
            userGrid = new int[10, 10];
            userShipSpaces = new int[5][];
            userMoves = new List<int>();
            move = 0;
            mode = 0;
            level = 0;
            killStep = 0;
            jump = false;
            allowGridClick = false;
            enemyShipCount = 17;
            userShipCount = 17;
        }
        /**
         * Sets the text of textboxes to empty string
         */
        private void emptyTextBoxes()
        {
            txtPlayerName.Text = "";
            txtCol.Text = "";
            txtRow.Text = "";
            textBoxRowBattleship.Text = "";
            textBoxColBattleship.Text = "";
            textBoxColCruiser.Text = "";
            textBoxRowCruiser.Text = "";
            textBoxColSubmarine.Text = "";
            textBoxRowSubmarine.Text = "";
            textBoxColDestroyer.Text = "";
            textBoxRowDestroyer.Text = "";
            textBoxPlayerCol.Text = "";
            textBoxPlayerRow.Text = "";
            enemyShipsLeftLabel.Content = enemyShipCount.ToString();
            userShipsLeftLabel.Content = userShipCount.ToString();

        }
        /**
         * changes visibilty of controls
         */
        private void changeControlsVisibility()
        {
            btnAircarftCarrier.Visibility = Visibility.Visible;
            btnBattleship.Visibility = Visibility.Visible;
            btnCruiser.Visibility = Visibility.Visible;
            btnSubmarine.Visibility = Visibility.Visible;
            btnDestroyer.Visibility = Visibility.Visible;
            lblYourShips.Visibility = Visibility.Visible;
            lblPlayerName.Visibility = Visibility.Visible;
            txtPlayerName.Visibility = Visibility.Visible;
            btnStart.Visibility = Visibility.Visible;
            groupboxBattleship.Visibility = Visibility.Visible;
            labelPlayerLosses.Visibility = Visibility.Hidden;
            txtPlayerLossPoints.Visibility = Visibility.Hidden;
            txtPlayerWinPoints.Visibility = Visibility.Hidden;
            labelPlayerWins.Visibility = Visibility.Hidden;
            buttonOKPlay.Visibility = Visibility.Hidden;
            textBoxPlayerCol.Visibility = Visibility.Hidden;
            textBoxPlayerRow.Visibility = Visibility.Hidden;
            labelPlayerCol.Visibility = Visibility.Hidden;
            labelPlayerRow.Visibility = Visibility.Hidden;
            buttonReset.Visibility = Visibility.Hidden;
            lblHelp.Visibility = Visibility.Visible;
        }


        /**
         * places the ships pictures on the grid
         */
        private void placePlayerShips(int dir, int colVal, int rowVal, int boatLength)
        {


            if (dir == 0)
            {
                for (int i = 1; i <= boatLength; i++)
                {

                    Button b = playerButtons[rowVal * 10 + colVal];
                    b.Background = Brushes.Black;


                    Grid.SetColumn(b, colVal);
                    Grid.SetRow(b, rowVal);

                    colVal = colVal + 1;

                }
            }
            else
            {
                for (int i = 1; i <= boatLength; i++)
                {


                    Button b = playerButtons[rowVal * 10 + colVal];
                    b.Background = Brushes.Black;


                    Grid.SetColumn(b, colVal);
                    Grid.SetRow(b, rowVal);

                    rowVal = rowVal + 1;

                }
            }
        }
        /**
          * Verifies that all 5 ships are placed before starting the game
          * Return true if all ships are placed
          */
        private Boolean allShipsPlaced()
        {
            if (btnAircarftCarrier.IsEnabled)
                return false;
            if (btnBattleship.IsEnabled)
                return false;
            if (btnCruiser.IsEnabled)
                return false;
            if (btnDestroyer.IsEnabled)
                return false;
            if (btnSubmarine.IsEnabled)
                return false;
            return true;
        }
        /**
         * creates the buttons on both grids to display ships 
         */
        private void createButtons(Grid gridName)
        {
            for (int row = 0; row <= 9; row++)
            {
                for (int col = 0; col <= 9; col++)
                {
                    Button b = new Button();
                    b.Background = Brushes.Transparent;
                    b.Name = "btn" + row + col;
                    b.Focusable = false;
                    if (gridName == gridPlayer)
                        playerButtons[row * 10 + col] = b;
                    else
                    {
                        compButtons[row * 10 + col] = b;
                        b.Click += new RoutedEventHandler(this.buttonGrid_Click);
                    }
                    Grid.SetColumn(b, col);
                    Grid.SetRow(b, row);
                    gridName.Children.Add(b);
                }
            }
        }

        /*
		 * Accepts and validates user's choice of coordinates for computer grid
		 * Only valid coordinates will be processed.
		 */
        private void buttonOKPlay_Click(object sender, RoutedEventArgs e)
        {
            int playerCol = 0;
            int playerRow = 0;

            if (textBoxPlayerRow.Text == "" || textBoxPlayerCol.Text == "")
            {
                labelOutOfRange.Content = "Please enter a valid value";
                labelOutOfRange.Visibility = Visibility.Visible;
            }

            if (!validateRowValue(textBoxPlayerRow))
                return;
            else
                playerRow = convertLetterToNum(textBoxPlayerRow.Text);
            if (!validateColumnValue(textBoxPlayerCol))
                return;
            else playerCol = Int32.Parse(textBoxPlayerCol.Text) - 1;

            int coords = playerRow * 10 + playerCol;
            if (inList(userMoves, coords))
            {
                labelOutOfRange.Visibility = Visibility.Visible;
                labelOutOfRange.Content = "You've already made this move";
                textBoxPlayerRow.Text = "";
                textBoxPlayerCol.Text = "";
            }
            else
            {
                labelOutOfRange.Visibility = Visibility.Hidden;
                play(coords);
                textBoxPlayerRow.Text = "";
                textBoxPlayerCol.Text = "";
            }
        }

        /*
         * Accepts user shot when (s)he clicks on the grid.
         */
        private void buttonGrid_Click(object sender, RoutedEventArgs e)
        {
            if (allowGridClick)
            {
                Button b = (Button)sender;
                int coords = Int32.Parse(b.Name.Substring(3, 2));
                if (inList(userMoves, coords))
                {
                    labelOutOfRange.Visibility = Visibility.Visible;
                    labelOutOfRange.Content = "You've already made this move";
                }
                else
                {
                    labelOutOfRange.Visibility = Visibility.Hidden;
                    play(coords);
                }
            }
        }

        /*
		 * Processes user's move. Indicates if user hits or sinks computer's boat(s).
		 * Then generates computer's move.
		 * param coords User-chosen validated coordinates for the next move.
		 */
        private void play(int coords)
        {
            userMoves.Add(coords);
            try
            {
                //find whether user hit computer's ship
                int result = findHitShip(compBoats, coords);
                if (result >= 0)
                {
                    isShipHit(compBoats[result], coords);
                    bool isSunk = isShipSunk(compBoats[result], result);
                    if (!isSunk)
                    {
                        enemyShipCount--;
                        enemyShipsLeftLabel.Content = enemyShipCount.ToString();
                        MessageBox.Show("You hit my " + intToStr(result) + "!");
                    }
                    else
                    {
                        if (allSunk(0))
                            return;
                    }
                }

                int compChoice = generateCompMove();
                if (allSunk(1))
                    return;
                move++;
            }
            //defensive design
            catch (Exception e)
            {
                MessageBox.Show("Sorry! Something went wrong. Restart the game!");
                Console.Write(e.Message);
            }
        }

        /*
		 * Checks whether the computer or user sunk all of the opponents ships.
		 * Displays the appropriate message and saves the results to file.
		 * param turn Indicates a player, where 0 is the user and 1 the computer.
		 * Returns true if all ships are sunk; false otherwise.
		 */
        private bool allSunk(int turn)
        {
            string player;
            int[][] array;
            TextBox text;
            bool sunk;
            if (move >= 16)
            {
                if (turn == 0)
                {
                    player = txtPlayerName.Text;
                    array = compBoats;
                    text = txtPlayerWinPoints;
                }
                else
                {
                    player = "Computer";
                    array = userBoats;
                    text = txtPlayerLossPoints;
                }

                sunk = allShipsSunk(array);
                if (sunk)
                {
                    MessageBox.Show(player + " is the winner!");
                    text.Text = int.Parse(text.Text) + 1 + "";
                    saveResults();
                    allowGridClick = false;
                    buttonOKPlay.Visibility = Visibility.Hidden;
                    textBoxPlayerCol.Visibility = Visibility.Hidden;
                    textBoxPlayerRow.Visibility = Visibility.Hidden;
                    labelPlayerCol.Visibility = Visibility.Hidden;
                    labelPlayerRow.Visibility = Visibility.Hidden;
                    return true;
                }
            }
            return false;
        }

    }
}
