﻿using System.Collections;
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

        DecideWinner(cell);
        ColorInTurn = ColorInTurn.Reverse();

        return true;
    }

    void DecideWinner(Cell cell) {
        foreach (var direction in DirectionExtend.AllCases) {
            var countInRow = 1;
            countInRow += CountSameColorInDirection(cell, direction);
            countInRow += CountSameColorInDirection(cell, direction.Reverse());
            if (countInRow >= 5) {
                IsGameOver = true;
                Winner = ColorInTurn;
                return;
            }
        }
    }

    int CountSameColorInDirection(Cell cell, Direction direction) {
        var nextCell = cell;
        var count = 0;
        while (true) {
            if (nextCell.Next(direction) == null) break;
            nextCell = (Cell)nextCell.Next(direction);
            if (GetColor(nextCell) != GetColor(cell)) break;
            count++;
        }
        return count;
    }
}