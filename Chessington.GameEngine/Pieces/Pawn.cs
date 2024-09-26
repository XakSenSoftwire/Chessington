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
            int playerRowDirection = (Player == Player.Black) ? 1 : -1; 
            // no need for playerColDirection
            Square currSquare = board.FindPiece(this);
            IEnumerable<Square> possibleSquares = new List<Square>
            {
               // pawns only have one move (assuming no en-passant or two-step or takes) 
                Square.At(currSquare.Row + playerRowDirection, currSquare.Col),
            };
            return possibleSquares;
        }
    }
}