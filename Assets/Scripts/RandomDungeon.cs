using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDungeon : MonoBehaviour
{
    public Grid grid;
    public GameObject[] tiles;
    public GameObject Wall;
    // Start is called before the first frame update
    void Start()
    {
        //int t_RandomGrid = Random.Range(10, 20);
        //grid.RowCount = t_RandomGrid;
        //grid.ColumnCount = t_RandomGrid;
        RandomFill();
    }
    
    private void RandomFill()
    {
        for (int i=1; i<grid.RowCount - 1;i++)
        {
            for (int j=1; j<grid.ColumnCount - 1;j++)
            {
                int t_RandomTile = Random.Range(0, tiles.Length);
                GameObject t_tile = tiles[t_RandomTile];
                Sprite t_Sprite = t_tile.GetComponent<SpriteRenderer>().sprite;
                float t_Scale = 1 / t_Sprite.bounds.size.x;
                t_tile.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
                //Vector3 t_pos = new Vector3(i, j, 0);
                Vector3 t_pos = new Vector3(i+0.5f,j+0.5f,0);
                Instantiate(t_tile, t_pos, Quaternion.identity);
            }
        }
        /*
        
        for (int i=0; i<1;i++)
        {
            for (int j=0;j<grid.ColumnCount;j++)
            {
                InstantiateWall(i,j);
            }
        }

        for (int i=0;i<grid.RowCount;i++)
        {
            for (int j = 0; j < 1; j++)
            {
                InstantiateWall(i, j);
            }
        }
        for (int i = 0; i < grid.RowCount; i++)
        {
            InstantiateWall(i, grid.RowCount-1);
        }
        for (int i = 0; i < grid.RowCount; i++)
        {
            InstantiateWall(grid.ColumnCount-1, i);
        }
        */
    }
    
    private void InstantiateWall(int i, int j)
    {
        GameObject t_tile = tiles[2];
        Sprite t_Sprite = t_tile.GetComponent<SpriteRenderer>().sprite;
        float t_Scale = 1 / t_Sprite.bounds.size.x;
        t_tile.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
        //Vector3 t_pos = new Vector3(i, j, 0);
        Vector3 t_pos = new Vector3(i + 0.5f, j + 0.5f, 0);
        Instantiate(t_tile, t_pos, Quaternion.identity);
    }
    

}
