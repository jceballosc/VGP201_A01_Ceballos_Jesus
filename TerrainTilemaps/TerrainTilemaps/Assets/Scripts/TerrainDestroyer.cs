using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainDestroyer : MonoBehaviour
{
    public Tilemap terrain;

    public static TerrainDestroyer instance;

    public TileBase explodedTile;
    Tilemap destroyedTerrain;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //destroyedTerrain = GameObject.FindWithTag("destroyedTerrain").GetComponent<Tilemap>();
    }
    public void DestroyTerrain(Vector3 explosionLocation, float radius)
    {
        for (int x = -(int)radius; x < radius; x++)
        {
            for (int y = -(int)radius; y < radius; y++)
            {
                Vector3Int tilePos = terrain.WorldToCell(explosionLocation + new Vector3(x, y, 0));
                if (terrain.GetTile(tilePos) != null)
                {
                    DestroyTile(tilePos);
                }
            }
        }
    }

    void DestroyTile(Vector3Int tilePos)
    {
        terrain.SetTile(tilePos, null);
        //destroyedTerrain.SetTile(tilePos, explodedTile);
    }
}
