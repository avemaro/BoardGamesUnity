using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    List<Piece> pieces;
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;

    public Board() {
        pieces = new List<Piece> {
            new Piece(PieceColor.black, Cell.d5),
            new Piece(PieceColor.black, Cell.e4),
            new Piece(PieceColor.white, Cell.d4),
            new Piece(PieceColor.white, Cell.e5)
        };
    }

    public Board(params (PieceColor, Cell)[] pieces ) {
        this.pieces = new List<Piece>();
        foreach (var piece in pieces) {
            this.pieces.Add(new Piece(piece.Item1, piece.Item2));
        }
    }

    #region color
    public PieceColor GetColor(Cell cell) {
        foreach (var piece in pieces)
            if (cell == piece.Position) return piece.Color;
        return PieceColor.none;
    }
    public bool IsNone(Cell cell) {
        return GetColor(cell) == PieceColor.none;
    }
    public bool IsBlack(Cell cell) {
        return GetColor(cell) == PieceColor.black;
    }
    public bool IsWhite(Cell cell) {
        return GetColor(cell) == PieceColor.white;
    }
    #endregion

    public bool PutPiece(Cell cell) {
        if (!IsNone(cell)) return false;

        foreach (var piece in pieces) {
            if (cell == Cell.d3 && piece.Position == Cell.d4)
                piece.Reverse();
            if (cell == Cell.c5 && piece.Position == Cell.d5)
                piece.Reverse();
            if (cell == Cell.b6 && piece.Position == Cell.c5)
                piece.Reverse();
        }

        pieces.Add(new Piece(ColorInTurn, cell));
        ColorInTurn = ColorInTurn.Reversed();
        return true;
    }
}
