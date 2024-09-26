using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            // Directions: permutations of Ls
            int[][] directions = new int[][]
            {
                new int[] { 1, 2 }, // NNE
                new int[] { 2, 1 }, // NEE
                new int[] { 2, -1 }, // EES
                new int[] { 1, -2 }, // ESS
                new int[] { -1, -2 }, // SSW
                new int[] { -2, -1 }, // SWW
                new int[] { -2, 1 }, // WNW
                new int[] { -1, 2 }   // WNN
            };

            IEnumerable<Square> possibleSquares = new List<Square>();
            Square currSquare = board.FindPiece(this);

            foreach (var direction in directions)
            {
                int newRow = currSquare.Row + direction[0];
                int newCol = currSquare.Col + direction[1];

                // Check if the new position is within the board limits
                if (newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8)
                {
                    break;
                }

                ((List<Square>)possibleSquares).Add(Square.At(newRow, newCol));
            }
            return possibleSquares;
        }
    }
}