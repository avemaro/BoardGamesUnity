using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceColor {
    none, black, white
}

public static class PieceColorExtend {
    public static PieceColor Reverse(this PieceColor pieceColor) {
        if (pieceColor == PieceColor.black) return PieceColor.white;
        else if (pieceColor == PieceColor.white) return PieceColor.black;
        return PieceColor.none;
    }

    public static string GetString(this PieceColor pieceColor) {
        switch (pieceColor) {
            case PieceColor.black: return "B";
            case PieceColor.white: return "W";
        }
        return "*";
    }
}