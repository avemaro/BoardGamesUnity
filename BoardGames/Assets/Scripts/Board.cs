using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    public List<Piece> Pieces { get; private set; } = new List<Piece>();
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;
    public bool IsGameOver { get; private set; }
    public PieceColor Winner { get; private set; } = PieceColor.none;

    public Board() {
        Pieces.Add(new Piece(this, PieceColor.black, Cell.d5));
        Pieces.Add(new Piece(this, PieceColor.black, Cell.e4));
        Pieces.Add(new Piece(this, PieceColor.white, Cell.d4));
        Pieces.Add(new Piece(this, PieceColor.white, Cell.e5));
    }

    #region Color
    public PieceColor GetColor(Cell? cell) {
        if (cell == null) return PieceColor.none;

        var piece = GetPiece(cell);
        if (piece == null) return PieceColor.none;
        return piece.Color;
    }

    public bool IsBlack(Cell? cell) {
        return GetColor(cell) == PieceColor.black;
    }

    public bool IsWhite(Cell? cell) {
        return GetColor(cell) == PieceColor.white;
    }

    public bool IsNone(Cell? cell) {
        return GetColor(cell) == PieceColor.none;
    }
    #endregion

    public void PutPiece(params Cell[] cells) {
        foreach (var cell in cells)
            PutPiece(cell);
    }

    public bool PutPiece(Cell cell) {
        if (GetPiece(cell) != null) return false;
        var newPiece = new Piece(this, ColorInTurn, cell);

        if (!IsRegal(newPiece)) return false;
        Pieces.Add(newPiece);
        newPiece.Work();

        ChangeTurn();
        if (NoCellToPut()) ChangeTurn();
        if (NoCellToPut()) DecideWinner();

        return true;
    }

    bool NoCellToPut() {
        foreach (var cell in CellExtend.AllCases) {
            if (!IsNone(cell)) continue;
            var newPiece = new Piece(this, ColorInTurn, cell);
            if (IsRegal(newPiece)) return false;
        }
        return true;
    }

    bool IsRegal(Piece newPiece) {
        var isRegal = false;
        newPiece.CheckReversible();
        foreach (var piece in Pieces) {
            if (piece.IsReversible) isRegal = true;
            piece.Reset();
        }
        return isRegal;
    }

    public Piece GetPiece(Cell? cell) {
        if (cell == null) return null;
        foreach (var piece in Pieces)
            if (piece.Position == cell) return piece;
        return null;
    }

    public bool Check(Cell[] blackCells, Cell[] whiteCells) {
        var noneCells = new List<Cell>(CellExtend.AllCases);
        foreach (Cell cell in blackCells) {
            if (GetColor(cell) != PieceColor.black) return false;
            noneCells.Remove(cell);
        }
        foreach (Cell cell in whiteCells) {
            if (GetColor(cell) != PieceColor.white) return false;
            noneCells.Remove(cell);
        }
        foreach (Cell cell in noneCells)
            if (GetColor(cell) != PieceColor.none) return false;
        return true;
    }

    void ChangeTurn() {
        ColorInTurn = ColorInTurn.Reverse();
    }


    void DecideWinner() {
        IsGameOver = true;
        int numberOfblack = 0;
        int numberOfwhite = 0;
        foreach (var piece in Pieces) {
            if (piece.Color == PieceColor.black) numberOfblack++;
            if (piece.Color == PieceColor.white) numberOfwhite++;
        }
        if (numberOfblack > numberOfwhite) Winner = PieceColor.black;
        if (numberOfblack < numberOfwhite) Winner = PieceColor.white;
        if (numberOfblack == numberOfwhite) Winner = PieceColor.none;
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