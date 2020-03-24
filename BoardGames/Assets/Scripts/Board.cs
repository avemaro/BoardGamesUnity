using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board {
    public PieceColor ColorInTurn { get; private set; }

    public PieceColor GetColor(Cell cell) {
        return PieceColor.none;
    }

    public void PutPiece(Cell cell) {

    }
}