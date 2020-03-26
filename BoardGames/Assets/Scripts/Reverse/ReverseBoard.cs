using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseBoard : Board {
    public ReverseBoard() {
        PutPiece(Cell.d5);
        PutPiece(Cell.d4);
        PutPiece(Cell.e4);
        PutPiece(Cell.e5);
    }
}