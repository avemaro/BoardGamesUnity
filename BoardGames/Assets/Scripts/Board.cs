using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    Dictionary<Cell, PieceColor> pieces = new Dictionary<Cell, PieceColor>();
    public PieceColor ColorInTurn { get; private set; } = PieceColor.black;
    public bool IsGameOver { get; private set; }
    public PieceColor Winner { get; private set; } 

    public PieceColor GetColor(Cell cell) {
        pieces.TryGetValue(cell, out PieceColor color);
        return color;
    }

    public bool PutPiece(Cell cell) {
        if (pieces.ContainsKey(cell)) return false;
        pieces.Add(cell, ColorInTurn);
        ColorInTurn = ColorInTurn.Reverse();

        DecideWinner(cell);

        return true;
    }

    void DecideWinner(Cell cell) {
        var nextCell = cell;
        var countInRow = 1;
        while (true) {
            if (nextCell.Next(Direction.up) == null) break;
            nextCell = (Cell)nextCell.Next(Direction.up);
            if (GetColor(nextCell) != GetColor(cell)) break;
            countInRow++;
        }
        nextCell = cell;
        while (true) {
            if (nextCell.Next(Direction.down) == null) break;
            nextCell = (Cell)nextCell.Next(Direction.down);
            if (GetColor(nextCell) != GetColor(cell)) break;
            countInRow++;
        }
        if (countInRow >= 5) {
            IsGameOver = true;
            Winner = GetColor(cell);
            return;
        }

        countInRow = 1;
        nextCell = cell;
        while (true) {
            if (nextCell.Next(Direction.downRight) == null) break;
            nextCell = (Cell)nextCell.Next(Direction.downRight);
            if (GetColor(nextCell) != GetColor(cell)) break;
            countInRow++;
        }
        nextCell = cell;
        while (true) {
            if (nextCell.Next(Direction.upLeft) == null) break;
            nextCell = (Cell)nextCell.Next(Direction.upLeft);
            if (GetColor(nextCell) != GetColor(cell)) break;
            countInRow++;
        }

        if (countInRow >= 5) {
            IsGameOver = true;
            Winner = PieceColor.white;
        }

        //if (GetColor(Cell.a3) == PieceColor.white &&
        //    GetColor(Cell.b4) == PieceColor.white &&
        //    GetColor(Cell.c5) == PieceColor.white &&
        //    GetColor(Cell.d6) == PieceColor.white &&
        //    GetColor(Cell.e7) == PieceColor.white) {
        //    IsGameOver = true;
        //    Winner = PieceColor.white;
        //}
    }
}