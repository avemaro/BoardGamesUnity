using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    List<Piece> pieces = new List<Piece>();
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;
    public bool IsGameOver { get; private set; }
    public PieceColor Winner { get; private set; } 

    public Piece GetPiece(Cell cell) {
        foreach (var piece in pieces)
            if (piece.Position == cell) return piece;
        return null;
    }

    public PieceColor GetColor(Cell cell) {
        var piece = GetPiece(cell);
        if (piece == null) return PieceColor.none;
        return piece.Color;
    }

    public bool PutPiece(Cell cell) {
        if (GetPiece(cell) != null) return false;
        var newPiece = new Piece(ColorInTurn, cell);
        pieces.Add(newPiece);

        DecideWinner(newPiece);
        ColorInTurn = ColorInTurn.Reverse();

        return true;
    }

    void DecideWinner(Piece piece) {
        foreach (var direction in DirectionExtend.AllCases) {
            var countInRow = 1;
            countInRow += CountSameColorInDirection(piece, direction);
            countInRow += CountSameColorInDirection(piece, direction.Reverse());
            if (countInRow >= 5) {
                IsGameOver = true;
                Winner = ColorInTurn;
                return;
            }
        }
    }

    int CountSameColorInDirection(Piece piece, Direction direction) {
        var nextCell = piece.Position;
        var count = 0;
        while (true) {
            if (nextCell.Next(direction) == null) break;
            nextCell = (Cell)nextCell.Next(direction);
            if (GetColor(nextCell) != GetColor(piece.Position)) break;
            count++;
        }
        return count;
    }
}