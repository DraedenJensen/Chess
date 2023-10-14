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
            mainMenu.Visible = false;
            multiplayerSettings.Visible = true;
            this.Hide();
            ChessGame game = new ChessGame();
            game.ShowDialog();
        }

        private void startComputerGame(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}