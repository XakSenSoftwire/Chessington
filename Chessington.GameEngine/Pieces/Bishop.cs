﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            // Directions: top-right, bottom-right, bottom-left, top-left
            int[][] directions = new int[][]
            {
                new int[] { 1, 1 },   // Top-right
                new int[] { 1, -1 },  // Bottom-right
                new int[] { -1, -1 }, // Bottom-left
                new int[] { -1, 1 }   // Top-left
            };
            
            IEnumerable<Square> possibleSquares = new List<Square>();
            Square currSquare = board.FindPiece(this);
            
            foreach (var direction in directions)
            {
                int newRow = currSquare.Row;
                int newCol = currSquare.Col;

                while (true)
                {
                    newRow += direction[0];
                    newCol += direction[1];

                    // Check if the new position is within the board limits
                    if ((newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8) || !(
                            board.GetPiece(Square.At(newRow, newCol)) is null))
                    {
                        break;
                    }
                    
                    ((List<Square>)possibleSquares).Add(Square.At(newRow, newCol));
                }
            }

            return possibleSquares;
        }
    }
}