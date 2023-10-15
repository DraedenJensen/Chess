using ChessClientGUI;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace Chess
{
    public partial class ChessClient : Form
    {
        private string theme;
        private bool flipBoard;
        private bool showMoves;
        private bool fullScreen;

        public ChessClient()
        {
            InitializeComponent();

            theme = "gray";
            flipBoard = false;
            showMoves = false;
            fullScreen = false;
        }

        private void ShowSinglePlayerSettings(object sender, EventArgs e)
        {
            //TODO
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
            multiplayerSettings.Visible = false;
            mainMenu.Visible = true;
        }

        private void ChangeTheme(object sender, EventArgs e)
        {
            theme = ((RadioButton)sender).Name;
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
            showMoves = !showMoves;
            if (showMoves)
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
            ChessGame game = new(theme, flipBoard, showMoves, fullScreen);
            game.ShowDialog();
        }
    }
}