using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {
    Board board;
    public PieceColor Color { get; private set; }
    public Cell Position { get; private set; }

    public Piece(Board board, PieceColor color, Cell position) {
        this.board = board;
        Color = color;
        Position = position;
    }

    public bool Work() {
        foreach (var direction in DirectionExtend.AllCases) {
            var countInRow = 1;
            countInRow += CountSameColorInDirection(direction);
            countInRow += CountSameColorInDirection(direction.Reverse());
            if (countInRow >= 5) {
                return true;
            }
        }
        return false;
    }

    int CountSameColorInDirection(Direction direction) {
        var nextCell = Position;
        var count = 0;
        while (true) {
            if (nextCell.Next(direction) == null) break;
            nextCell = (Cell)nextCell.Next(direction);
            if (board.GetColor(nextCell) != board.GetColor(Position)) break;
            count++;
        }
        return count;
    }
}
