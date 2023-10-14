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

        public void PieceSelected(object sender, EventArgs e)
        {
            SelectedType = ((Button)sender).Name;
            this.Hide();
        }
    }
}
