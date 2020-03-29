using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour {
    Board board;
    public CellBehaviour cellPrefab;
    public GameObject piecePrefab;

    // Start is called before the first frame update
    void Start() {
        board = new ReverseBoard();

        foreach (var cell in CellExtend.AllCases) {
            var cellObject = Instantiate(cellPrefab, transform);
            cellObject.model = cell;
            cellObject.board = board;

            var pieceData = board.GetPiece(cell);
            if (pieceData == null) continue;
            cellObject.PutPiece(pieceData.Color);
        }
    }

    // Update is called once per frame
}
