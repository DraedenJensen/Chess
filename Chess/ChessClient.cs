using ChessClientGUI;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace Chess
{
    public partial class ChessClient : Form
    {
        private string theme;
        private bool flipBoard;
        private bool hideMoves;
        private bool fullScreen;
        private int singlePlayerDifficulty;
        private int singlePlayerColor;
        
        /// <summary>
        /// Initializes a new window for the program's main menu.
        /// </summary>
        public ChessClient()
        {
            InitializeComponent();

            theme = "gray";
            singlePlayerColor = 1;
            singlePlayerDifficulty = 1;
            flipBoard = false;
            hideMoves = false;
            fullScreen = false;
        }

        /// <summary>
        /// Event handler method for when the user selects a single-player game against a computer.
        /// </summary>
        private void ShowSinglePlayerSettings(object sender, EventArgs e)
        {
            mainMenu.Visible = false;
            singlePlayerSettings.Visible = true;
        }

        /// <summary>
        /// Event handler method for when the user selects a local multiplayer game.
        /// </summary>
        private void ShowMultiplayerSettings(object sender, EventArgs e)
        {
            mainMenu.Visible = false;
            multiplayerSettings.Visible = true;
        }

        /// <summary>
        /// Event handler method for when the user selects the credits menu.
        /// </summary>
        private void showCredits(object sender, EventArgs e)
        {
            mainMenu.Visible = false;
            credits.Visible = true;
        }

        /// <summary>
        /// Event handler method for when the user presses the back button from an inner menu.
        /// </summary>
        private void returnToMenu(object sender, EventArgs e)
        {
            gray.Checked = true;
            flipBoardBox.Checked = false;
            showMovesBox.Checked = false;
            fullScreenBox.Checked = false;

            gray2.Checked = true;
            skill1.Checked = true;
            white.Checked = true;

            singlePlayerSettings.Visible = false;
            multiplayerSettings.Visible = false;
            mainMenu.Visible = true;
            fullScreen2.Checked = false;
            showMoves2.Checked = false;
        }

        /// <summary>
        /// Event handler method for when the user changes the selected theme from an inner menu.
        /// </summary>
        private void ChangeTheme(object sender, EventArgs e)
        {
            theme = ((RadioButton)sender).Name;
            if (theme.Contains('2'))
            {
                theme = theme.Substring(0, theme.Length - 1);
            }
        }

        /// <summary>
        /// Event handler method for when the user changes the board flip setting from the multiplayer menu.
        /// </summary>
        private void ToggleBoardFlip(object sender, EventArgs e)
        {
            flipBoard = !flipBoard;
            if (flipBoard)
            {
                ((CheckBox)sender).BackgroundImage = ChessClientGUI.Properties.Resources.translucentDot;
            }
            else
            {
                ((CheckBox)sender).BackgroundImage = null;
            }
        }

        /// <summary>
        /// Event handler method for when the user changes the hide moves setting from an inner menu.
        /// </summary>
        private void ToggleShowMoves(object sender, EventArgs e)
        {
            hideMoves = !hideMoves;
            if (hideMoves)
            {
                ((CheckBox)sender).BackgroundImage = ChessClientGUI.Properties.Resources.translucentDot;
            }
            else
            {
                ((CheckBox)sender).BackgroundImage = null;
            }
        }

        /// <summary>
        /// Event handler method for when the user changes the intial full screen setting from an inner menu.
        /// </summary
        private void ToggleFullScreen(object sender, EventArgs e)
        {
            fullScreen = !fullScreen;
            if (fullScreen)
            {
                ((CheckBox)sender).BackgroundImage = ChessClientGUI.Properties.Resources.translucentDot;
            }
            else
            {
                ((CheckBox)sender).BackgroundImage = null;
            }
        }

        /// <summary>
        /// Event handler method for when the user starts a multiplayer game.
        /// </summary>
        private void StartMultiplayerGame(object sender, EventArgs e)
        {
            this.Hide();
            ChessGame game = new(0, 0, theme, flipBoard, !hideMoves, fullScreen);
            game.ShowDialog();
        }

        /// <summary>
        /// Event handler method for when the user starts a single-player game.
        /// </summary>
        private void StartSinglePlayerGame(object sender, EventArgs e)
        {
            this.Hide();
            ChessGame game = new(singlePlayerDifficulty, singlePlayerColor, theme, false, !hideMoves, fullScreen);
            game.ShowDialog();
        }

        /// <summary>
        /// Event handler method for when the user changes the color setting from the single-player menu.
        /// </summary>
        private void ColorChanged(object sender, EventArgs e)
        {
            if (white.Checked)
            {
                singlePlayerColor = 1;
            }
            if (black.Checked)
            {
                singlePlayerColor = -1;
            }
        }

        /// <summary>
        /// Event handler method for when the user changes the difficultly setting from the single-player menu.
        /// </summary>
        private void DifficultyChanged(object sender, EventArgs e)
        {
            singlePlayerDifficulty = int.Parse(((RadioButton)sender).Name.Substring(5));
        }
    }
}