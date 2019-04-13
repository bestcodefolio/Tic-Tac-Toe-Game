using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Member
        /// <summary>
        /// Holds results of cells in the game
        /// </summary>
        private MarkType[] cellResults;

        /// <summary>
        /// True if 1 player turn (X) or player 2 turn (O)
        /// </summary>
        private bool Player1TurnCell;
        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool TheGameEnded;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion

        #region Newgame
        /// <summary>
        /// Starts a new Game
        /// </summary>
        private void NewGame()
        {
            // new array of free cells
            cellResults = new MarkType[9];

            for (int i = 0; i < cellResults.Length; i++)
            {
                cellResults[i] = MarkType.Free;
            }

            // 1 player starts the game
            Player1TurnCell = true;


            //Container.Children.Cast<Button>().ToList().ForEach(button =>
            //{
            //    //Change Background and Clean grid                
            //    button.Content = string.Empty;
            //    button.Background = Brushes.White;
            //    button.Foreground = Brushes.Aqua;
            //});

            // Default Buttons on the grid
            Button0_0.Background = Button1_0.Background = Button2_0.Background = Button0_1.Background = Button1_1.Background =
               Button2_1.Background = Button1_2.Background = Button0_2.Background = Button2_2.Background = Brushes.White;

            Button0_0.Content = Button1_0.Content = Button2_0.Content = Button0_1.Content = Button1_1.Content =
               Button2_1.Content = Button1_2.Content = Button0_2.Content = Button2_2.Content = string.Empty;

            Button0_0.Foreground = Button1_0.Foreground = Button2_0.Foreground = Button0_1.Foreground = Button1_1.Foreground =
               Button2_1.Foreground = Button1_2.Foreground = Button0_2.Foreground = Button2_2.Foreground =
              new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffeb3b")); ;

            TheGameEnded = false;
        }
        #endregion

        #region Button_Click
        /// <summary>
        /// Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckTheEnd();
            // Start a new Geme after finishing
            if (TheGameEnded)
            {
                NewGame();
                return;
            }

            // Cast a sender to a button
            var button = (Button)sender;

            // Find button position
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            // Find cell index
            var index = column + (row * 3) - 3;

            // Continue if cell has a value
            if (cellResults[index] != MarkType.Free)
            {
                return;
            }

            //Set the cell value
            cellResults[index] = Player1TurnCell ? MarkType.Cross : MarkType.Nought;

            button.Content = Player1TurnCell ? "X" : "O";

            //Set O color
            if (!Player1TurnCell)
            {
                button.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4fc3f7")); ; ;
            }

            Player1TurnCell ^= true;

            CheckTheEnd();
        }
        #endregion

        #region CheckTheEnd

        private void CheckTheEnd()
        {
            #region Horizontal Wins

            // Check for horizontal wins
            //
            //  - Row 0
            //
            if (cellResults[0] != MarkType.Free && (cellResults[0] & cellResults[1] & cellResults[2]) == cellResults[0])
            {
                // Game ends
                TheGameEnded = true;

                // Highlight winning cells in green
                Button0_0.Background = Button1_0.Background = Button2_0.Background = 
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));;
            }
            //
            //  - Row 1
            //
            if (cellResults[3] != MarkType.Free && (cellResults[3] & cellResults[4] & cellResults[5]) == cellResults[3])
            {
                // Game ends
                TheGameEnded = true;

                // Highlight winning cells in green
                Button0_1.Background = Button1_1.Background = Button2_1.Background =
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")); ;
            }
            //
            //  - Row 2
            //
            if (cellResults[6] != MarkType.Free && (cellResults[6] & cellResults[7] & cellResults[8]) == cellResults[6])
            {
                // Game ends
                TheGameEnded = true;

                // Highlight winning cells in green
                Button0_2.Background = Button1_2.Background = Button2_2.Background =
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")); ;
            }

            #endregion

            #region Vertical Wins

            // Check for vertical wins
            //
            //  - Column 0
            //
            if (cellResults[0] != MarkType.Free && (cellResults[0] & cellResults[3] & cellResults[6]) == cellResults[0])
            {
                // Game ends
                TheGameEnded = true;

                // Highlight winning cells in green
                Button0_0.Background = Button0_1.Background = Button0_2.Background =
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")); ;
            }
            //
            //  - Column 1
            //
            if (cellResults[1] != MarkType.Free && (cellResults[1] & cellResults[4] & cellResults[7]) == cellResults[1])
            {
                // Game ends
                TheGameEnded = true;

                // Highlight winning cells in green
                Button1_0.Background = Button1_1.Background = Button1_2.Background =
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")); ;
            }
            //
            //  - Column 2
            //
            if (cellResults[2] != MarkType.Free && (cellResults[2] & cellResults[5] & cellResults[8]) == cellResults[2])
            {
                // Game ends
                TheGameEnded = true;

                // Highlight winning cells in green
                Button2_0.Background = Button2_1.Background = Button2_2.Background =
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")); ;
            }

            #endregion

            #region Diagonal Wins

            // Check for diagonal wins
            //
            //  - Top Left Bottom Right
            //
            if (cellResults[0] != MarkType.Free && (cellResults[0] & cellResults[4] & cellResults[8]) == cellResults[0])
            {
                // Game ends
                TheGameEnded = true;

                // Highlight winning cells in green
                Button0_0.Background = Button1_1.Background = Button2_2.Background =
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")); ;
            }
            //
            //  - Top Right Bottom Left
            //
            if (cellResults[2] != MarkType.Free && (cellResults[2] & cellResults[4] & cellResults[6]) == cellResults[2])
            {
                // Game ends
                TheGameEnded = true;

                // Highlight winning cells in green
                Button2_0.Background = Button1_1.Background = Button0_2.Background =
                    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")); ;
            }

            #endregion

            #region No Winners
            //Container.Children.Cast<Button>().ToList().ForEach(button =>
            //{
            //    button.Background = Brushes.Black;
            //});

            
            // Check for no winner and full board
            if (!cellResults.Any(f => f == MarkType.Free) && TheGameEnded == false)
            {
                // Game ended
                TheGameEnded = true;

                // Turn all cells black
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Button0_1.Background = Button1_1.Background =
                Button2_1.Background = Button1_2.Background = Button0_2.Background = Button2_2.Background =
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#424242")); ;
            }
            #endregion
        }

        #endregion

        #region Menu Buttons
        /// <summary>
        /// Click Menu - NewGame button
        /// </summary>
        private void ClickMenu_NewGame(object sender, RoutedEventArgs e)
        {
            NewGame();
        }


        /// <summary>
        /// Click Menu - Exit button
        /// </summary>
        private void ClickMenu_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClickMenu_About(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.Show();
        }
        #endregion
    }
}
