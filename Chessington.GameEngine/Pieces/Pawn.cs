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
            // no need for colDisplacement as pawns cannot en-passant or takes
            int[][] directions = new int[][]
            {
                new int[] { 0, 0},
                new int[] { 0, 0}
            };
            
            if (this.Player == Player.Black)
            {
                directions[0] = new int[] { 1, 0 };
                
                // special two-step logic
                if (this.HasMoved == false)
                {
                    directions[1] = new int[] { 2, 0 };
                }

            }
            else
            {
                directions[0] = new int[] { -1, 0 };
                
                // special two-step logic
                if (this.HasMoved == false)
                {
                    directions[1] = new int[] { -2, 0 };
                }

            }
            
            Square currSquare = board.FindPiece(this);
            IEnumerable<Square> possibleSquares = new List<Square>();
    
            // for loop to generate possible moves based on row Displacements
            foreach (var direction in directions)
            {
                int newRow = currSquare.Row + direction[0];
                int newCol = currSquare.Col + direction[1];

                // Check if the new position is within the board limits
                if ((newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8) || !(
                        board.GetPiece(Square.At(newRow, newCol)) is null))
                {
                    break;
                }

                ((List<Square>)possibleSquares).Add(Square.At(newRow, newCol));
            }
            return possibleSquares;
        }
    }
}