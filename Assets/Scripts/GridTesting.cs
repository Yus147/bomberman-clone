using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridTesting : MonoBehaviour
{
    private GridSystem grid;

    private void Start()
    {
        grid = new GridSystem(15, 13, 1f,new Vector3(-8, -7));
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
        grid.SetValue(UtilsClass.GetMouseWorldPosition(), 54);
        }
        if(Input.GetMouseButtonDown(1))
        {
        Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    } 

}
