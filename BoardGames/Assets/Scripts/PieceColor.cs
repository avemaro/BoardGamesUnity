using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceColor {
    none, black, white
}

public static class PieceColorExtend {
    public static PieceColor Reversed(this PieceColor color) {
        if (color == PieceColor.black) return PieceColor.white;
        else if (color == PieceColor.white) return PieceColor.black;
        return PieceColor.none;
    }
}