using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    List<Piece> pieces;
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;

    public Board() {
        pieces = new List<Piece> {
            new Piece(this, PieceColor.black, Cell.d5),
            new Piece(this, PieceColor.black, Cell.e4),
            new Piece(this, PieceColor.white, Cell.d4),
            new Piece(this, PieceColor.white, Cell.e5)
        };
    }

    public Board(params (PieceColor, Cell)[] pieces ) {
        this.pieces = new List<Piece>();
        foreach (var piece in pieces) {
            this.pieces.Add(new Piece(this, piece.Item1, piece.Item2));
        }
    }

    #region color
    public PieceColor GetColor(Cell cell) {
        var piece = GetPiece(cell);
        if (piece == null) return PieceColor.none;
        return piece.Color;
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

        var newPiece = new Piece(this, ColorInTurn, cell);
        pieces.Add(newPiece);
        newPiece.Work();

        ColorInTurn = ColorInTurn.Reversed();
        return true;
    }

    public Piece GetPiece(Cell? cell) {
        foreach (var piece in pieces)
            if (piece.Position == cell) return piece;
        return null;
    }
}
