using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<int> rowDisplacement = new List<int> {};
            // no need for colDisplacement as pawns cannot en-passant or takes
            
            if (this.Player == Player.Black)
            {
                // normal pawn movement logic
                rowDisplacement.Add(1);
                
                // special two-step logic
                if (this.HasMoved == false)
                {
                    rowDisplacement.Add(2);
                }

            }
            else
            {
                rowDisplacement.Add(-1);

                if (this.HasMoved == false)
                {
                    rowDisplacement.Add(-2);
                }
            }

            Square currSquare = board.FindPiece(this);
            IEnumerable<Square> possibleSquares = new List<Square>();
    
            // for loop to generate possible moves based on row Displacements
            for (int idx = 0; idx < rowDisplacement.Count; idx++)
            {
                ((List<Square>)possibleSquares).Add(Square.At(currSquare.Row + rowDisplacement[idx], currSquare.Col));
            }
            
            return possibleSquares;
        }
    }
}