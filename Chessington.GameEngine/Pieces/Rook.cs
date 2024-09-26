using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<int> rowDisplacement = new List<int> {};
            List<int> colDisplacement = new List<int> {};
            
        
            Square currSquare = board.FindPiece(this);

            for (int rosPosition = 0; rosPosition < 8; rosPosition++)
            {
                if (rosPosition !=currSquare.Row)
                {
                    rowDisplacement.Add(rosPosition-currSquare.Row);
                }
            }

            for (int colPosition = 0; colPosition < 8; colPosition++)
            {
                if (colPosition != currSquare.Col)
                {
                    colDisplacement.Add(colPosition-currSquare.Col);
                }
            }
            
            IEnumerable<Square> possibleSquares = new List<Square>();
            
            // for loop to generate possible moves based on row Displacements
            for (int idx = 0; idx < rowDisplacement.Count; idx++)
            {
                ((List<Square>)possibleSquares).Add(Square.At(currSquare.Row + rowDisplacement[idx],
                    currSquare.Col));
            }
            
            // for loop to generate possible moves based on row Displacements
            for (int idx = 0; idx < colDisplacement.Count; idx++)
            {
                ((List<Square>)possibleSquares).Add(Square.At(currSquare.Row,
                    currSquare.Col + colDisplacement[idx]));
            }

            return possibleSquares;
        }
    }
}