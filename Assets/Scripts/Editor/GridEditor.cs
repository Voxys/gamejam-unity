using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;
using System;

// Ajouter la bibliothèque UnityEditor
// Ajouter le type d'objet à associer
// Changer le MonoBeavior en Editor

[CustomEditor(typeof(Grid))]
[CanEditMultipleObjects]
public class GridEditor : Editor
{

    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown && Event.current.shift)
        {

            GUIUtility.hotControl = GUIUtility.GetControlID(FocusType.Passive);

            Vector3 t_ClickPos = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
            Vector2Int t_GridPos = ((Grid)target).WorldToGrid(t_ClickPos);
            Vector3 t_WorldPos = ((Grid)target).GridToWorld(t_GridPos);



            // Faire apparaître la tile sur la grille

            int t_SelectedTile = ((Grid)target).SelectedTileId;

            if (t_SelectedTile >= ((Grid)target).AvailableTiles.Length || t_SelectedTile < 0)
                throw new GridException("Out of bounds");

            // Supprimer l'ancienne tuile
            List<Tile> t_Tiles = ((Grid)target).GetComponentsInChildren<Tile>().ToList();
            Tile t_OldTile = t_Tiles.FirstOrDefault(t => t.transform.position == t_WorldPos);
            if (t_OldTile)
            {
                Undo.DestroyObjectImmediate(t_OldTile.gameObject);
            }

            GameObject t_TilePrefab = ((Grid)target).AvailableTiles[t_SelectedTile];

            GameObject t_NewTileGO = (GameObject)PrefabUtility.InstantiatePrefab(t_TilePrefab, ((Grid)target).transform);
            Undo.RegisterCreatedObjectUndo(t_NewTileGO, "Tile created");
            t_NewTileGO.transform.position = t_WorldPos;

            // modifer taille tuile
            float t_CellSize = ((Grid)target).CellSize;
            Sprite t_Sprite = t_NewTileGO.GetComponent<SpriteRenderer>().sprite;
            float t_Scale = t_CellSize / t_Sprite.bounds.size.x;
            t_NewTileGO.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);




            //Debug.Log(t_WorldPos);
        }
        else if (Event.current.type == EventType.MouseDown && Event.current.control)
        {
            GUIUtility.hotControl = GUIUtility.GetControlID(FocusType.Passive);

            Vector3 t_ClickPos = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
            Vector2Int t_GridPos = ((Grid)target).WorldToGrid(t_ClickPos);
            Vector3 t_WorldPos = ((Grid)target).GridToWorld(t_GridPos);

            List<Tile> t_Tiles = ((Grid)target).GetComponentsInChildren<Tile>().ToList();
            Tile t_DeleteTile = t_Tiles.FirstOrDefault(t => t.transform.position == t_WorldPos);
            if (t_DeleteTile)
            {
                Undo.DestroyObjectImmediate(t_DeleteTile.gameObject);
            }
        }

        
    }
}
