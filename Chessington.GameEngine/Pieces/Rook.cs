﻿using System;
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
            // Directions: top-right, bottom-right, bottom-left, top-left
            int[][] directions = new int[][]
            {
                new int[] { 1, 0 }, // right
                new int[] { -1, 0 }, // left
                new int[] { 0, 1 }, // up
                new int[] { 0, -1 } // down
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

                    if (newRow < 0 || newRow >= 8 || newCol < 0 || newCol >= 8)
                    {
                        break;
                    }
                    if (board.GetPiece(Square.At(newRow, newCol)) is null)
                    {
                        ((List<Square>)possibleSquares).Add(Square.At(newRow, newCol));
                    }
                    else if (board.GetPiece(Square.At(newRow, newCol)).Player != board.CurrentPlayer)
                    {
                        ((List<Square>)possibleSquares).Add(Square.At(newRow, newCol));
                        break;
                    }
                    else if (board.GetPiece(Square.At(newRow, newCol)).Player == board.CurrentPlayer)
                    {
                        break;
                    }
                }
            }
            return possibleSquares;
        }
    }
}