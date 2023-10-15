using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessClientGUI
{
    public partial class PromotionPopup : Form
    {
        public string SelectedType { get; set; }

        /// <summary>
        /// Creates a new popup whenever promotion is needed.
        /// </summary>
        /// <param name="color">The color that's promoting</param>
        public PromotionPopup(int color)
        {
            InitializeComponent();
            SelectedType = "";

            if (color == 1)
            {
                queen.Image = ChessClientGUI.Properties.Resources.white_queen;
                rook.Image = ChessClientGUI.Properties.Resources.white_rook;
                bishop.Image = ChessClientGUI.Properties.Resources.white_bishop;
                knight.Image = ChessClientGUI.Properties.Resources.white_knight;
            }
            else
            {
                queen.Image = ChessClientGUI.Properties.Resources.black_queen;
                rook.Image = ChessClientGUI.Properties.Resources.black_rook;
                bishop.Image = ChessClientGUI.Properties.Resources.black_bishop;
                knight.Image = ChessClientGUI.Properties.Resources.black_knight;
            }
        }

        /// <summary>
        /// Event handler method called when the user clicks one of the four buttons deciding piece type.
        /// </summary>
        public void PieceSelected(object sender, EventArgs e)
        {
            SelectedType = ((Button)sender).Name;
            this.Hide();
        }
    }
}
