using ChessClientGUI;

namespace Chess
{
    public partial class ChessClient : Form
    {
        public ChessClient()
        {
            InitializeComponent();
        }

        private void StartMultiplayerGame(object sender, EventArgs e)
        {
            this.Hide();
            ChessGame game = new ChessGame();
            game.ShowDialog();
        }

        private void startComputerGame(object sender, EventArgs e)
        {

        }
    }
}