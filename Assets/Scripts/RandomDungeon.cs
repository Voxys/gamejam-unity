using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDungeon : MonoBehaviour
{
    public Grid grid;
    public GameObject[] tiles;
    public GameObject[] Props;
    public GameObject Door;
    public GameObject[] Monsters;
    public int MaxProps;
    public float MonsterSpawnDelay;

    [SerializeField]
    private int MaxMonsters;

    void Start()
    {
        FillFloor();
        RandomFill();
        StartCoroutine(InstantiateRandomMonster());
        
    }

    private void FillFloor()
    {
        for (int i = 1; i < grid.RowCount - 1; i++)
        {
            for (int j = 1; j < grid.ColumnCount - 1; j++)
            {

                int t_RandomTile = Random.Range(0, 2);
                GameObject t_tile = tiles[t_RandomTile];
                Sprite t_Sprite = t_tile.GetComponent<SpriteRenderer>().sprite;
                float t_Scale = 1 / t_Sprite.bounds.size.x;
                t_tile.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
                Vector3 t_pos = new Vector3(i + 0.5f, j + 0.5f, 0);
                Instantiate(t_tile, t_pos, Quaternion.identity);
            }
        }
    }
    
    private void RandomFill()
    {
        for (int i = 0; i < MaxProps; i++)
        {
            int x = Random.Range(1, grid.RowCount-1);
            int y = Random.Range(1, grid.ColumnCount-1);
            Vector2 t_pos = new Vector2(x, y);
            InstantiateProps(x,y);
        }    
    }
    
    private void InstantiateProps(int x, int y)
    {
        int t_RandomProp = Random.Range(0, Props.Length);
        GameObject t_Prop = Props[t_RandomProp];
        Sprite t_Sprite = t_Prop.GetComponent<SpriteRenderer>().sprite;
        float t_Scale = 1 / t_Sprite.bounds.size.x;
        t_Prop.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
        Vector3 t_pos = new Vector3(x + 0.5f, y + 0.5f, 0);
        Instantiate(t_Prop, t_pos, Quaternion.identity);
    }

    private IEnumerator InstantiateRandomMonster()
    {
        int t_NumberOfMonster = Random.Range(1, MaxMonsters);
        int t_RandomChosenMonster = Random.Range(0, Monsters.Length);

        yield return new WaitForSeconds(MonsterSpawnDelay);

        for (int i = 0; i < t_NumberOfMonster; i++)
        {
            int x = Random.Range(1, grid.RowCount - 1);
            int y = Random.Range(1, grid.ColumnCount - 1);

            GameObject t_Monster = Monsters[t_RandomChosenMonster];

            Sprite t_Sprite = t_Monster.GetComponent<SpriteRenderer>().sprite;
            float t_Scale = 1 / t_Sprite.bounds.size.x;
            t_Monster.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
            Vector3 t_pos = new Vector3(x + 0.5f, y + 0.5f, 0);

            Instantiate(t_Monster, t_pos, Quaternion.identity);
        }
    }


    //Check si les voisins de la case son de tag Wall, si oui return false
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

        return t_CanPlaceProp;
    }
}
