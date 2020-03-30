using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Board {
    public List<Piece> Pieces { get; protected set; } = new List<Piece>();
    public PieceColor ColorInTurn { get; protected set; } = PieceColor.black;
    public bool IsGameOver { get; protected set; }
    public PieceColor Winner { get; protected set; }

    public bool MovePiece(Cell from, Cell to) {
        return true;
    }

    public bool PutPiece(Cell cell) {
        var newPiece = CreatePiece(cell);
        if (!newPiece.IsRegal()) return false;
        Pieces.Add(newPiece);
        newPiece.Work();

        ColorInTurn = ColorInTurn.Reverse();
        if (NoRegalHands(ColorInTurn)) ColorInTurn = ColorInTurn.Reverse();
        DecideWinner();

        return true;
    }

    public Piece GetPiece(Cell? cell) {
        foreach (var piece in Pieces)
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

    protected bool NoRegalHands(PieceColor color) {
        foreach (var cell in CellExtend.AllCases) {
            var newPiece = CreatePiece(color, cell);
            if (newPiece.IsRegal()) return false;
        }
        return true;
    }

    protected abstract void DecideWinner();
    protected abstract Piece CreatePiece(PieceColor color, Cell cell);
    protected Piece CreatePiece(Cell cell) {
        return CreatePiece(ColorInTurn, cell);
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