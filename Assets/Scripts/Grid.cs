﻿using UnityEngine;

public class Grid : MonoBehaviour
{
    public int RowCount, ColumnCount;
    public float CellSize = 1f;
    public Color GridColor;
    public bool ShowGrid = true;
    private Tile[,] m_Tiles;


#if UNITY_EDITOR
    public GameObject[] AvailableTiles;
    public int SelectedTileId;
#endif

    private void Awake()
    {
        m_Tiles = new Tile[ColumnCount, RowCount];

        var t_AllTiles = GetComponentsInChildren<Tile>();

        foreach (var t_Tile in t_AllTiles)
        {
            Vector2Int t_TilePos = WorldToGrid(t_Tile.transform.position);
            t_Tile.TilePos = t_TilePos;
            m_Tiles[t_TilePos.x, t_TilePos.y] = t_Tile;
        }
    }

    public Tile GetTile(Vector2Int a_GridPos)
    {
        if (a_GridPos.x < 0 || a_GridPos.y < 0 || a_GridPos.x >= ColumnCount || a_GridPos.y >= RowCount)
            throw new GridException("Out of grid!");

        return m_Tiles[a_GridPos.x, a_GridPos.y];
    }

    private void OnDrawGizmosSelected()
    {
        // Pour arrêter d'afficher la grille
        if (!ShowGrid)
            return;

        // Pour donner de la couleur à la grille
        Gizmos.color = GridColor;

        // Lignes horizontales
        float t_StartX = transform.position.x;
        float t_EndX = ColumnCount * CellSize + transform.position.x;
        for (int i = 0; i < RowCount + 1; i++)
        {
            float t_LineY = i * CellSize + transform.position.y;
            Gizmos.DrawLine(new Vector3(t_StartX, t_LineY, 0), new Vector3(t_EndX, t_LineY, 0));
        }

        // Lignes verticales
        float t_StartY = transform.position.y;
        float t_EndY = RowCount * CellSize + transform.position.y;
        for (int j = 0; j < RowCount + 1; j++)
        {
            float t_LineX = j * CellSize + transform.position.x;
            Gizmos.DrawLine(new Vector3(t_LineX, t_StartY, 0), new Vector3(t_LineX, t_EndY, 0));
        }
    }

    public Vector2Int WorldToGrid(Vector3 a_WorldPos)
    {
        int t_PosX = Mathf.FloorToInt((a_WorldPos.x - transform.position.x) / CellSize);
        int t_PosY = Mathf.FloorToInt((a_WorldPos.y - transform.position.y) / CellSize);

        // exception
        if(t_PosX < 0 || t_PosY < 0 || t_PosX >= ColumnCount || t_PosY >= RowCount)
            throw new GridException("Out of grid!");

        return new Vector2Int(t_PosX, t_PosY);
    }

    public Vector3 GridToWorld(Vector2Int a_GridPos)
    {
        // exception
        if (a_GridPos.x < 0 || a_GridPos.y < 0 || a_GridPos.x >= ColumnCount || a_GridPos.y >= RowCount)
            throw new GridException("Out of grid!");

        float t_PosX = a_GridPos.x * CellSize + (CellSize / 2) + transform.position.x;
        float t_PosY = a_GridPos.y * CellSize + (CellSize / 2) + transform.position.y;

        return new Vector3(t_PosX, t_PosY, 0);
    }
}
