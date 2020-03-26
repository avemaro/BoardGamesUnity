﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    protected List<Piece> pieces = new List<Piece>();
    public PieceColor ColorInTurn { get; protected set; } = PieceColor.black;
    public bool IsGameOver { get; private set; }
    public PieceColor Winner { get; private set; } 

    public Piece GetPiece(Cell? cell) {
        foreach (var piece in pieces)
            if (piece.Position == cell) return piece;
        return null;
    }

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

    public virtual bool PutPiece(Cell cell) {
        var newPiece = new Piece(this, ColorInTurn, cell);

        if (!IsRegal(newPiece)) return false;
        pieces.Add(newPiece);
        newPiece.Work();

        DecideWinner();
        ColorInTurn = ColorInTurn.Reverse();

        return true;
    }

    protected virtual bool IsRegal(Piece newPiece) {
        return GetPiece(newPiece.Position) == null;
    }

    protected virtual void DecideWinner() {
        foreach (var piece in pieces)
            if (piece.IsGomoku) {
                IsGameOver = true;
                Winner = ColorInTurn;
            }
    }
}