using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDungeon : MonoBehaviour
{
    public Grid grid;
    public GameObject[] tiles;
    public GameObject Wall;
    public GameObject Door;

    void Start()
    {

        RandomFill();
    }
    
    private void RandomFill()
    {
            for (int i = 1; i < grid.RowCount - 1; i++)
            {
                for (int j = 1; j < grid.ColumnCount - 1; j++)
                {
                    int t_MaxTile;
                    if (CheckNeighbour(i + 0.5f, j + 0.5f))
                    t_MaxTile = tiles.Length-1;
                    else
                    {
                    t_MaxTile = 1;
                    }

                    int t_RandomTile = Random.Range(0, t_MaxTile);
                    GameObject t_tile = tiles[t_RandomTile];
                    Sprite t_Sprite = t_tile.GetComponent<SpriteRenderer>().sprite;
                    float t_Scale = 1 / t_Sprite.bounds.size.x;
                    t_tile.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
                    Vector3 t_pos = new Vector3(i + 0.5f, j + 0.5f, 0);
                    Instantiate(t_tile, t_pos, Quaternion.identity);
                }
            }


        /*
        int t_RandomDoor = Random.Range(1, 4);

        //bordure gauche
        for (int i=0; i<1;i++)
        {
            for (int j=0;j<grid.ColumnCount;j++)
            {
                InstantiateWall(i,j);
            }
        }

        //bordure bas
        for (int i=0;i<grid.RowCount;i++)
        {
            for (int j = 0; j < 1; j++)
            {
                InstantiateWall(i, j);
            }
        }

        //bordure haut
        for (int i = 0; i < grid.RowCount; i++)
        {
            InstantiateWall(i, grid.RowCount-1);
        }

        //bordure droit
        for (int i = 0; i < grid.RowCount; i++)
        {
            InstantiateWall(grid.ColumnCount-1, i);
        }

*/
        
    }
    
    private void InstantiateWall(int i, int j)
    {
        GameObject t_tile = Wall;
        Sprite t_Sprite = t_tile.GetComponent<SpriteRenderer>().sprite;
        float t_Scale = 1 / t_Sprite.bounds.size.x;
        t_tile.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
        //Vector3 t_pos = new Vector3(i, j, 0);
        Vector3 t_pos = new Vector3(i + 0.5f, j + 0.5f, 0);
        Instantiate(t_tile, t_pos, Quaternion.identity);
    }


    //TODO Check si les voisins de la case son de tag Wall, si oui return false
    private bool CheckNeighbour(float i, float j)
    {
        bool t_CanPlaceProp;

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(i,j), -Vector2.left);

        if(hit)
        {
            t_CanPlaceProp = false;
        }
        else
        {
            t_CanPlaceProp = true;
        }
        Debug.Log(t_CanPlaceProp);
        Debug.Log(hit.collider);

        return t_CanPlaceProp;
    }
    /*
    private void InstantiateDoor()
    {
        Instantiate(Door, t_pos, Quaternion.identity);
    }
    */
}
