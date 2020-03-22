using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {
    Board board;
    public PieceColor Color { get; private set; }
    public Cell Position { get; private set; }
    bool isReversible = false;

    public Piece(Board board, PieceColor color, Cell position) {
        this.board = board;
        Color = color;
        Position = position;
    }

    public void Work() {
        CheckReversible();
        Reverse();
    }

    void Reverse() {
        foreach (var piece in board.Pieces) {
            if (piece.isReversible) piece.Color = piece.Color.Reverse();
            piece.isReversible = false;
        }
    }

    void CheckReversible() {
        foreach (var direction in DirectionExtend.AllCases) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) continue;
            nextPiece.CheckReversible(Color, direction);
        }
    }

    void CheckReversible(PieceColor color, Direction direction) {
        if (color.IsSame(Color)) {
            var nextPiece = GetNextPiece(direction.Reverse());
            if (nextPiece == null) return;
            nextPiece.MarkReversible(color, direction.Reverse());
        } else if (color.IsOpposite(Color)) {
            var nextPiece = GetNextPiece(direction);
            if (nextPiece == null) return;
            nextPiece.CheckReversible(color, direction);
        }
    }

    void MarkReversible(PieceColor color, Direction direction) {
        if (!color.IsOpposite(Color)) return;
        isReversible = true;
        var nextPiece = GetNextPiece(direction);
        if (nextPiece == null) return;
        nextPiece.MarkReversible(color, direction);
    }


    Piece GetNextPiece(Direction direction) {
        var nextCell = Position.Next(direction);
        return board.GetPiece(nextCell);
    }
}

public enum PieceColor {
    white, black, none
}

public static class PieceColorExtend {
    public static PieceColor Reverse(this PieceColor pieceColor) {
        switch (pieceColor) {
            case PieceColor.black: return PieceColor.white;
            case PieceColor.white: return PieceColor.black;
        }
        return PieceColor.none;
    }

    public static bool IsSame(this PieceColor pieceColor, PieceColor other) {
        if (pieceColor == PieceColor.none) return false;
        return pieceColor == other;
    }

    public static bool IsOpposite(this PieceColor pieceColor, PieceColor other) {
        switch (pieceColor) {
            case PieceColor.black: return other == PieceColor.white;
            case PieceColor.white: return other == PieceColor.black;
        }
        return false;
    }

    public static string GetString(this PieceColor pieceColor) {
        switch (pieceColor) {
            case PieceColor.black: return "B";
            case PieceColor.white: return "W";
        }
        return "*";
    }
}
