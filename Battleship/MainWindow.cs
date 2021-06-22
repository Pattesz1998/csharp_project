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
    public partial class MainWindow : Window
    {

        //-------global vars---------------
        //to store computer ships on the grid
        private int[,] compGrid = new int[10, 10];
        //to store computer ships locations
        private int[][] compBoats = new int[5][];
        //to store user ships locations
        private int[][] userBoats = new int[5][];
        //computer mode when playing, where 0-hunter & 1-killer
        private int mode = 0;
        //level of the computer 
        private int level = 0;
        //to store computer moves
        private IList<int> compMoves = new List<int>();
        //the move that found the boat to sink
        private int moveHit;
        //the move that found the boat to sink, 
        //where 0-right, 1-down, 2-left, 3-up
        private int dirHit;
        //at which step the computer is in killer mode:
        //0-find boat direction, 1-kill boat
        private int killStep = 0;
        //the index of the ship that is hit in the array of user ships
        private int hitShip;
        //indicates whether the jump (change direction to the opposite) is needed to sink the ship
        private bool jump;
        //counts enemy ships
        private int enemyShipCount = 17;
        //counts user ships
        private int userShipCount = 17;

        //player index in file
        private int playerNameIndex;

        //------setup---------------------

        /*
         * Generates computer ships. 
         * 
         */
        private void computerSetup()
        {
            compGrid = new int[10, 10];
            compBoats = new int[5][];
            compMoves = new List<int>();

            compBoats[0] = addCompBoat(5); //aircraft carrier
            compBoats[1] = addCompBoat(4); //battleship
            compBoats[2] = addCompBoat(3); //submarine
            compBoats[3] = addCompBoat(3); //cruise
            compBoats[4] = addCompBoat(2); //destroyer


        }

        /*
         * Creates valid ship locations for a given boat length.
         * Adds the found ship to the grid array. 
         * param boatLength The length of the ship to create.
         * Returns an array containing coordinates of the given boat.
         */
        private int[] addCompBoat(int boatLength)
        {
            Random random = new Random();
            int[] boat = new int[boatLength];
            int coord = 0;
            int direction = 0;
            bool valid;

            //validates the coordinate
            do
            {
                valid = true;
                coord = random.Next(0, 100);
                direction = random.Next(0, 2);
                valid = isShipCoordsValid(compGrid, direction, coord, boatLength)
                        && checkSpaceAroundShip(compGrid, direction, coord, boatLength);
            } while (!valid);

            //add the ship and reserve empty spaces around the ship on the grid
            addShipToGrid(compGrid, boat, direction, coord, boatLength);
            addSpaceAroundShip(compGrid, direction, coord, boatLength);
            return boat;
        }

        /*
         * Given the first coordinate of the ship calculates 
         * the starting and ending point of spaces around the ship.
         * param direction The direction in which the boat in created (horizontal/vertical).
         * param coord The first coordinate of the ship.
         * param boatLength The length of the ship to create.
         * Returns an array containg both points.
         */
        private int[] calcSpaceBoundariesAroundShip(int direction, int coord, int boatLength)
        {
            int[] array = new int[2];
            int end;
            //horizontal
            if (direction == 1)
            {
                //the space right after the last ship coordinate
                end = coord + boatLength * 10;
                //the space preceding the boat
                array[0] = coord > 9 ? (coord - 10) : coord;
                //the space after the boat
                array[1] = end < 100 ? end : (end - 10);
            }
            //vertical
            else
            {
                end = coord + boatLength;
                array[0] = coord % 10 != 0 ? (coord - 1) : coord;
                array[1] = end % 10 != 0 ? end : (end - 1);
            }
            return array;
        }

        /*
         * Verifies whether at a given row and column in the grid there is
         * a free space.
         * param grid The grid where the free space needs to be verified.
         * param row The row change(increment/decrement) of the coordinate on the grid.
         * param col The column change(increment/decrement) of the coordinate on the grid.
         * param i The coordinate of the ship around which the space is verified.
         * Returns true if the coordinate is a free space; false otherwise.
         */
        private bool isFreePlace(int[,] grid, int row, int col, int i)
        {
            int coord = grid[(i + row) / 10, (i + col) % 10];
            if (coord != 0 && coord != 7)
                return false;
            return true;
        }

        /*
         * Verifies whether a ship is not situated next to the other ship.
         * param grid The grid where the space needs to be verified.
         * param direction The direction in which the boat in created (horizontal/vertical).
         * param coord The first coordinate of the ship.
         * param boatLength The length of the ship to create.
         * Returns true if the position is valid; false otherwise.
         */
        private bool checkSpaceAroundShip(int[,] grid, int direction, int coord, int boatLength)
        {
            bool valid1 = true, valid2;
            int[] spaceBoundaries = calcSpaceBoundariesAroundShip(direction, coord, boatLength);
            int firstSpace = spaceBoundaries[0];
            int lastSpace = spaceBoundaries[1];
            int increaseLoop = (direction == 1) ? 10 : 1;

            for (int i = firstSpace; i <= lastSpace; i += increaseLoop)
            {
                //horizontal
                if (direction == 1)
                {
                    //check grid boundaries
                    if (coord % 10 != 0)
                        valid1 = isFreePlace(grid, 0, -1, i);
                    //check grid boundaries
                    if (coord % 10 != 9)
                        valid1 = isFreePlace(grid, 0, 1, i);
                }
                //vertical
                else
                {
                    if (coord > 9)
                        valid1 = isFreePlace(grid, -10, 0, i);
                    if (coord < 90)
                        valid1 = isFreePlace(grid, 10, 0, i);
                }
                if (!valid1)
                    return false;
            }
            valid1 = isFreePlace(grid, 0, 0, firstSpace);
            valid2 = isFreePlace(grid, 0, 0, lastSpace);

            return valid1 && valid2;
        }

        /*
         * Verifies whether ship coordinates are valid 
         * (in the grid boindaries and the space is empty and not next to the other ship).
         * param grid The grid where the coordinates need to be verified.
         * param direction The direction in which the boat in created (horizontal/vertical).
         * param coord The first coordinate of the ship.
         * param boatLength The length of the ship to create.
         * Returns true if each position is valid; false otherwise.
         */
        private bool isShipCoordsValid(int[,] grid, int direction, int coord, int boatLength)
        {
            int ctr = boatLength;
            for (int i = 0; i < ctr; i++)
            {
                if (coord < 0 || coord > 99)
                    return false;
                if (coord % 10 == 9 && direction == 0 && (i != boatLength - 1))
                    return false;
                if (coord > 89 && direction == 1 && (i != boatLength - 1))
                    return false;
                int x = grid[coord / 10, coord % 10];
                if (x != 0)
                    return false;
                coord = changeCoord(direction, coord);
            }
            return true;
        }

        /*
         * Verifies whether the given coordinate is within grid boundaries.
         * param coord The coordinate to verify.
         * param direction The direction in which the next coordinate will be placed.
         * Return true if the coordinate is within grid boundaries; false otherwise.
         */
        private bool isCoordWithinBoundaries(int coord, int direction)
        {
            if (coord < 0 || coord > 99)
                return false;
            if (coord % 10 == 9 && direction == 0)
                return false;
            if (coord > 89 && direction == 1)
                return false;
            if (coord % 10 == 0 && direction == 2)
                return false;
            if (coord < 10 && direction == 3)
                return false;
            return true;
        }

        /*
         * Adds the specified ship to the grid and populates the boat array with ship coordinates.
         * The ship is indicated on the grid by its length (5-2).
         * param grid The grid where the ship will be added.
         * param boat The array to hold ship coordinates.
         * param direction The direction in which the boat in created (horizontal/vertical).
         * param coord The first coordinate of the ship.
         * param boatLength The length of the ship to create.
         */
        private void addShipToGrid(int[,] grid, int[] boat, int direction, int coord, int boatLength)
        {
            for (int i = 0; i < boatLength; i++)
            {
                boat[i] = coord;
                grid[coord / 10, coord % 10] = boatLength;
                coord = changeCoord(direction, coord);
            }
        }

        /*
         * Adds space positions around the given ship 
         * (to ensure that to ships are not placed next to each other).
         * param grid The grid where the ship space is added (indicated as 7).
         * param direction The direction in which the boat in created (horizontal/vertical).
         * param coord The first coordinate of the ship.
         * param boatLength The length of the ship to create.
         */
        private void addSpaceAroundShip(int[,] grid, int direction, int coord, int boatLength)
        {
            int[] spaceBoundaries = calcSpaceBoundariesAroundShip(direction, coord, boatLength);
            int firstSpace = spaceBoundaries[0];
            int lastSpace = spaceBoundaries[1];
            int increaseLoop = (direction == 1) ? 10 : 1;

            for (int i = firstSpace; i <= lastSpace; i += increaseLoop)
            {
                if (direction == 1)
                {
                    if (coord % 10 != 0)
                        grid[i / 10, (i - 1) % 10] = 7;
                    if (coord % 10 != 9)
                        grid[i / 10, (i + 1) % 10] = 7;
                }
                else
                {
                    if (coord > 9)
                        grid[(i - 10) / 10, i % 10] = 7;
                    if (coord < 90)
                        grid[(i + 10) / 10, i % 10] = 7;
                }
            }
            if (grid[firstSpace / 10, firstSpace % 10] == 0)
                grid[firstSpace / 10, firstSpace % 10] = 7;
            if (grid[lastSpace / 10, lastSpace % 10] == 0)
                grid[lastSpace / 10, lastSpace % 10] = 7;
        }

        /*
         * Changes the coordinate to the next one depending on the direction.
         * param direction The direction in which the coordinate is changed
         * (0-left, 1-down, 2-right, 3-up).
         * param coord The coordinate to change.
         * Returns the modified coordinate.
         */
        private int changeCoord(int direction, int coord)
        {
            if (direction == 0)
                return coord + 1;
            else if (direction == 2)
                return coord - 1;
            else if (direction == 3)
                return coord - 10;
            else
                return coord + 10;
        }

        /*
         * Translates from integer notation of the ship to the string one.
         * param boat Integer notation of the ship.
         * Returns string notation of the ship.
         */
        private string intToStr(int boat)
        {
            switch (boat)
            {
                case 0:
                    return "aircraft carrier";
                case 1:
                    return "battleship";
                case 2:
                    return "submarine";
                case 3:
                    return "cruise";
                default:
                    return "destroyer";
            }
        }

        //----------play-----------

        /*
         * Generates computer's move.  
         * Returns the generated move.
         */
        private int generateCompMove()
        {
            player = 1;
            int choice = 0;
            //hunter mode
            if (mode == 0)
            {
                choice = compSimple();
                //check whether the computer hit user's ship
                hitShip = findHitShip(userBoats, choice);
                if (hitShip >= 0)
                {
                    mode = 1;
                    moveHit = choice;
                    dirHit = -1;
                    killStep = 0;
                    //record hit in user boats
                    isShipHit(userBoats[hitShip], choice);
                    userShipCount--;
                    userShipsLeftLabel.Content = userShipCount.ToString();
                }
            }
            //killer mode
            else
            {
                choice = compKill();
            }

            compMoves.Add(choice);
            player = 0;
            return choice;
        }

        /*
         * Generates random and unique for the game computer's move.
         * Returns the generated move.
         */
        private int compSimple()
        {
            int choice = 0;
            Random random = new Random();
            do
            {
                choice = random.Next(0, 100);
            } while (inList(compMoves, choice));

            return choice;
        }

        /*
		* The mode in which the computer tries to "kill" user's ship. 
		* The appropriate move is generated.
		* Returns the appropriate move.
		*/
        private int compKill()
        {
            int choice;
            //the step to find user's ship direction
            if (killStep == 0)
            {
                choice = compKillFind();
                if (choice >= 0)
                    return choice;
            }
            //the step to sink user's ship
            else
                choice = compKillSink();

            //change to hunter mode if ship is sunk	
            if (isShipSunk(userBoats[hitShip], hitShip))
                mode = 0;

            return (choice < 0 ? -(choice + 1) : choice);
        }

        /*
         * Generates computer's move based on the move that hit user's ship
         * in order to find the direction of that ship.
         * Returns (-choice-1) if the found direction is the direction of user's ship;
         * choice otherwise.
         */
        private int compKillFind()
        {
            int choice;
            do
            {
                dirHit++;
                choice = changeCoord(dirHit, moveHit);
            } while (!isCoordWithinBoundaries(moveHit, dirHit));

            //change step to start sinking the boat	
            if (isShipHit(userBoats[hitShip], choice))
            {
                userShipCount--;
                userShipsLeftLabel.Content = userShipCount.ToString();
                killStep = 1;
            }
            else
                return choice;
            return -choice - 1;
        }

        /*
         * Generates the move to sink user's ship.
         * Returns this move.
         */
        private int compKillSink()
        {
            int choice;
            int lastMove = compMoves[compMoves.Count - 1];
            if (isCoordWithinBoundaries(lastMove, dirHit))
            {
                if (jump)
                {
                    choice = changeCoord(dirHit, moveHit);
                    isShipHit(userBoats[hitShip], choice);
                    userShipCount--;
                    userShipsLeftLabel.Content = userShipCount.ToString();
                    jump = false;
                }
                else
                {
                    choice = changeCoord(dirHit, lastMove);
                    //if the next move is miss, but the ship is not sunk
                    //the direction is changed to the opposite one-the jump
                    if (!isShipHit(userBoats[hitShip], choice) &&
                       !isShipSunk(userBoats[hitShip], hitShip))
                    {
                        jump = true;
                        switchDirection();
                    }
                }
            }
            //if next proposed move will be outside grid boundaries
            //the direction is changed to the opposite one
            else
            {
                switchDirection();
                choice = changeCoord(dirHit, moveHit);
                isShipHit(userBoats[hitShip], choice);
                userShipCount--;
                userShipsLeftLabel.Content = userShipCount.ToString();
            }
            return choice;
        }

        /*
         * Changes the hit direction to the opposite one.
         */
        private void switchDirection()
        {
            if (dirHit < 2)
                dirHit += 2;
            else
                dirHit -= 2;
        }

        /*
         * Verifies whether the given boat is sunk.
         * If it is the case prints the appropriate message.
         * param boat An array containing boat coordinates.
         * param hitShip The boat to check (in integer notation).
         * Returns true if the ship is sunk; false otherwise.
         */
        private bool isShipSunk(int[] boat, int hitShip)
        {
            if (isArrayEntriesHaveSameValue(boat))
            {
                if (player == 0)
                {
                    enemyShipCount--;
                    enemyShipsLeftLabel.Content = enemyShipCount.ToString();
                    MessageBox.Show("You sank my " + intToStr(hitShip) + "!");
                }


                return true;
            }
            else
                return false;
        }

        /*
         * Checks if all ships are sunk.
         * param boats An array containg all boats coordinates.
         * Returns true if all ships are sunk; false otherwise.
         */
        private bool allShipsSunk(int[][] boats)
        {
            return isArrayEntriesHaveSameValue(boats[0]) &&
                    isArrayEntriesHaveSameValue(boats[1]) &&
                    isArrayEntriesHaveSameValue(boats[2]) &&
                    isArrayEntriesHaveSameValue(boats[3]) &&
                    isArrayEntriesHaveSameValue(boats[4]);
        }

        /*
         * Finds which ship is hit.
         * param boats An array contaning all boats coordinates.
         * param choice Computer's move that hit the ship.
         * Returns the ship that is hit (its index in boats array).
         */
        private int findHitShip(int[][] boats, int choice)
        {
            for (int i = 0; i < boats.Length; i++)
                for (int j = 0; j < boats[i].Length; j++)
                    if (boats[i][j] == choice)
                        return i;
            color(choice, Brushes.White);
            return -1;
        }

        /*
         * Verifies whether given boat is hit with the given move.
         * If the ship is hit this coordinate is set to -100.
         * param boat An array holding boat coordinates.
         * param choice The move to verify.
         * Returns true if the ship is hit; false otherwise.
         */
        private bool isShipHit(int[] boat, int choice)
        {
            for (int i = 0; i < boat.Length; i++)
                if (boat[i] == choice)
                {
                    boat[i] = -100;
                    color(choice, Brushes.DarkRed);

                    return true;
                }
            color(choice, Brushes.White);
            return false;
        }

        /*
		 * Changes the color of the user or computer grid
		 * according to whether the player hit or missed.
		 * param choice The chosen coordinate.
		 * param color The color to display (red for hit, white for miss).
		 */
        private void color(int choice, SolidColorBrush color)
        {
            if (player == 0)
                compButtons[choice].Background = color;
            else
                playerButtons[choice].Background = color;
        }

        /*
         * Verifies whether the given value is in the given integer list.
         * param list A list to search.
         * param val The value to check for in the list.
         * Returns true if value in the list; false otherwise.
         */
        private bool inList(IList<int> list, int val)
        {
            foreach (int i in list)
                if (val == i)
                    return true;
            return false;
        }

        //-------------ai--------------

        /*
         * Generates computer's move based on pattern AI. 
         * When one pattern is finished, next pattern is started.
         * Returns computer's move.
         */


        /*
         * Verifies whether all entries in a given array have the same value.
         * param array An array to check.
         * Returns true if the above statement is true; false otherwise.
         */
        private bool isArrayEntriesHaveSameValue(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
                if (array[i] != array[i - 1])
                    return false;
            return true;
        }

        /*
         * Checks whether the given coordinate is in the pattern array.
         * If this is the case the value in array in replaced with -100.
         */


        /*
         * Adds space positions near the given coordinate according to the row
         * and column change in coordinate. Adds this space coordinates to
         * userShipSpaces array for the specific ship.
         * param row The row change(increment/decrement) of the coordinate on the grid.
         * param col The column change(increment/decrement) of the coordinate on the grid.
         * param i The coordinate of the ship around which the space is verified.
         * param ship The ship for which the empty space is assigned.
         * param counter The index in userShipSpaces.
         * Returns incremented counter.
         */
        private int assignFreeSpaceAroundShip(int row, int col, int i, int ship, int counter)
        {
            //add reserved empty space to the grid
            userGrid[(i + row) / 10, (i + col) % 10] = 7;
            //add this space coordinate to the array
            if (row == 0)
                userShipSpaces[ship][counter] = i + col;
            else
                userShipSpaces[ship][counter] = i + row;

            return ++counter;
        }

        /*
         * Adds space positions around the given ship.
         * (to ensure that to ships are not placed next to each other).
         * param direction The direction in which the boat in created (horizontal/vertical).
         * param coord The first coordinate of the ship.
         * param boatLength The length of the ship to create.
         * param ship The ship around which the space is added
         * (from 0-aircraft carrier to 5-destroyer).
         */
        private void addSpaceAroundUserShipHard(int direction, int coord, int boatLength, int ship)
        {
            int[] spaceBoundaries = calcSpaceBoundariesAroundShip(direction, coord, boatLength);
            int firstSpace = spaceBoundaries[0];
            int lastSpace = spaceBoundaries[1];
            int increaseLoop = (direction == 1) ? 10 : 1;
            int counter = 0;
            //array to store coordinates of empty places around given ship
            userShipSpaces[ship] = new int[16];

            for (int i = firstSpace; i <= lastSpace; i += increaseLoop)
            {
                //horizontal
                if (direction == 1)
                {
                    //check that the coordinate is within grid boundaries
                    if (coord % 10 != 0)
                        counter = assignFreeSpaceAroundShip(0, -1, i, ship, counter);
                    //check that the coordinate is within grid boundaries
                    if (coord % 10 != 9)
                        counter = assignFreeSpaceAroundShip(0, 1, i, ship, counter);
                }
                //vertical
                else
                {
                    if (coord > 9)
                        counter = assignFreeSpaceAroundShip(-10, 0, i, ship, counter);
                    if (coord < 90)
                        counter = assignFreeSpaceAroundShip(10, 0, i, ship, counter);
                }
            }
            if (userGrid[firstSpace / 10, firstSpace % 10] == 0)
                counter = assignFreeSpaceAroundShip(0, 0, firstSpace, ship, counter);
            if (userGrid[lastSpace / 10, lastSpace % 10] == 0)
                counter = assignFreeSpaceAroundShip(0, 0, lastSpace, ship, counter);

            Array.Resize(ref userShipSpaces[ship], counter);
        }

        //------------file handling------------------
        /*
         * Checks whether current player is in the file.
         * If there is one, it displays his wins and losses.
		 * The player name comparison is case-insensitive.
         */
        private void checkPlayer()
        {
            string name = txtPlayerName.Text;
            bool playerFound = false;
            int counter = 0;

            try
            {
                if (!File.Exists("players.txt"))
                {
                    File.Create("players.txt").Close();
                    playerNameIndex = -1;
                }
                else
                {
                    string[] array = File.ReadAllLines("players.txt");
                    while (counter < array.Length && !playerFound)
                    {
                        if (String.Equals(array[counter], name, StringComparison.OrdinalIgnoreCase))
                        {
                            playerNameIndex = counter;
                            playerFound = true;
                            txtPlayerWinPoints.Text = array[counter + 1];
                            txtPlayerLossPoints.Text = array[counter + 2];
                        }
                        counter += 3;
                    }
                    if (!playerFound)
                        playerNameIndex = -1;
                }
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
        }

        /*
         * Save results of the current game in the file.
         * If the player is present, the results are changes according to the current game.
         * Otherwise, the new player is added to the file with his game results.
         */
        private void saveResults()
        {
            string name = txtPlayerName.Text;
            int winsIndex;
            try
            {
                string[] array = File.ReadAllLines("players.txt");
                if (playerNameIndex >= 0)
                    winsIndex = playerNameIndex + 1;

                else
                {
                    int newLength = array.Length + 3;
                    Array.Resize(ref array, newLength);
                    array[newLength - 3] = name;
                    winsIndex = newLength - 2;
                }

                array[winsIndex] = txtPlayerWinPoints.Text;
                array[winsIndex + 1] = txtPlayerLossPoints.Text;
                File.WriteAllLines("players.txt", array);

            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
        }
    }
}
