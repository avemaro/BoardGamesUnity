using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    protected List<Piece> pieces = new List<Piece>();
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;
    public bool IsGameOver { get; protected set; }
    public PieceColor Winner { get; protected set; } 

    public Piece GetPiece(Cell? cell) {
        foreach (var piece in pieces)
            if (piece.Position == cell) return piece;
        return null;
    }

    #region color
    public PieceColor GetColor(Cell cell) {
        var piece = GetPiece(cell);
        if (piece == null) return PieceColor.none;
        return piece.Color;
    }
    public bool IsBlack(Cell cell) {
        return GetColor(cell) == PieceColor.black;
    }
    public bool IsWhite(Cell cell) {
        return GetColor(cell) == PieceColor.white;
    }
    public bool IsNone(Cell cell) {
        return GetColor(cell) == PieceColor.none;
    }

    public bool Check(Cell[] blackCells, Cell[] whiteCells) {
        var noneCells = new List<Cell>(CellExtend.AllCases);
        foreach (Cell cell in blackCells) {
            if (!IsBlack(cell)) return false;
            noneCells.Remove(cell);
        }
        foreach (Cell cell in whiteCells) {
            if (!IsWhite(cell)) return false;
            noneCells.Remove(cell);
        }
        foreach (Cell cell in noneCells)
            if (!IsNone(cell)) return false;
        return true;
    }
    #endregion

    public bool PutPiece(Cell cell) {
        var newPiece = CreatePiece(cell);
        if (!newPiece.IsRegal()) return false;
        pieces.Add(newPiece);
        newPiece.Work();

        ColorInTurn = ColorInTurn.Reverse();
        if (NoRegalHands(ColorInTurn)) ColorInTurn = ColorInTurn.Reverse();
        DecideWinner();

        return true;
    }

    protected virtual void DecideWinner() {
        foreach (var piece in pieces)
            if (piece.IsGameOver) {
                IsGameOver = true;
                Winner = piece.Color;
            }
    }

    protected bool NoRegalHands(PieceColor color) {
        foreach (var cell in CellExtend.AllCases) {
            var newPiece = CreatePiece(color, cell);
            if (newPiece.IsRegal()) return false;
        }
        return true;
    }

    protected virtual Piece CreatePiece(Cell cell) {
        return new Piece(this, ColorInTurn, cell);
    }

    protected virtual Piece CreatePiece(PieceColor color, Cell cell) {
        return new Piece(this, color, cell);
    }

    public void PrintBoard() {
        for (var rank = 0; rank < 8; rank++) {
            string log = "";
            for (var file = 0; file < 8; file++) {
                Cell cell = (Cell)CellExtend.AllCases.GetValue((rank * 8) + file);
                log += GetColor(cell).GetString();
            }
            Debug.Log(log);
        }
    }
}