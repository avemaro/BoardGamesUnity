using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{
    public CellBehaviour cellPrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var cell in CellExtend.AllCases) {
            var cellObject = Instantiate(cellPrefab, transform);
            cellObject.model = cell;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
