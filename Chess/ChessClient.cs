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

        private void ShowSinglePlayerSettings(object sender, EventArgs e)
        {
            mainMenu.Visible = false;
            singlePlayerSettings.Visible = true;
        }

        private void ShowMultiplayerSettings(object sender, EventArgs e)
        {
            mainMenu.Visible = false;
            multiplayerSettings.Visible = true;
        }

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

        private void ChangeTheme(object sender, EventArgs e)
        {
            theme = ((RadioButton)sender).Name;
            if (theme.Contains('2'))
            {
                theme = theme.Substring(0, theme.Length - 1);
            }
        }

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

        private void StartMultiplayerGame(object sender, EventArgs e)
        {
            this.Hide();
            ChessGame game = new(0, 0, theme, flipBoard, !hideMoves, fullScreen);
            game.ShowDialog();
        }

        private void StartSinglePlayerGame(object sender, EventArgs e)
        {
            this.Hide();
            ChessGame game = new(singlePlayerDifficulty, singlePlayerColor, theme, false, !hideMoves, fullScreen);
            game.ShowDialog();
        }

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

        private void DifficultyChanged(object sender, EventArgs e)
        {
            singlePlayerDifficulty = int.Parse(((RadioButton)sender).Name.Substring(5));
        }
    }
}