using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public GameObject indicator;
    public GameObject plane;
    public float[,] Grid;

    public int vertical, horizontal;
    private int colums, rows;

    private void Start()
    {
        //vertical = (int)plane.transform.localScale.z;
        //horizontal = (int)plane.transform.localScale.x;

        colums = horizontal *2;
        rows = vertical * 2;
        Grid = new float[colums, rows];
        for(int i = 0; i< colums; i++)
        {
            for(int j = 0; j< rows; j++)
            {
                Grid[i, j] = Random.Range(0.0f, 1.0f);
                Spawnfile(i, j, Grid[i, j]);
            }
        }
        gameObject.transform.localScale = new Vector3(0.16615f, 0.16615f, 0.16615f);
        gameObject.transform.position = plane.transform.position;
    }

    private void Update()
    {
        gameObject.transform.position = plane.transform.position;
        gameObject.transform.localRotation = plane.transform.localRotation;
        transform.Rotate(0,180, 0);

    }
    void Spawnfile(int x, int y, float value)
    {
        Vector3 pos = new Vector3(x - (horizontal - 0.5f), 0.05f, y - (vertical - 0.1f));
        GameObject slot = Instantiate(indicator, pos, Quaternion.identity);
        slot.name = x.ToString() + "," + y.ToString();
        slot.tag = "Indicator";
        slot.transform.SetParent(gameObject.transform);

    }

}
