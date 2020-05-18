using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{

    public TileType[] tileTypes;

    public int[,,] tiles;

    int mapSizeX = 10;
    int mapSizeZ = 10;
    int mapHeight = 10; 

    public enum terrainTypes
    {
        GRASS, SWAMP, MOUNTAIN, AIR, WALL
    }


    // Start is called before the first frame update
    void Start()
    {
        GenerateMapData();
        GenerateMapVisual();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMapData()
    {
        // Allocate memory for our map tiles
        tiles = new int[mapSizeX, mapHeight, mapSizeZ];

        int x;
        int y;
        int z;

        // Initialise our map tiles to be grass
        for (y = 0; y < mapHeight - 1; y++)
        {
            for (x = 0; x < mapSizeX; x++)
            {
                for (z = 0; z < mapSizeZ; z++)
                {
                    tiles[x, y, z] = (int)terrainTypes.GRASS;
                }
            }
        }


        // Initialise our second layer to be 'air' blocks.
        for (y = 1; y < mapHeight; y++)
        {
            for (x = 0; x < mapSizeX; x++)
            {
                for (z = 0; z < mapSizeZ; z++)
                {
                    tiles[x, y, z] = (int)terrainTypes.AIR;
                }
            }
        }



        // Make a swamp area
        for (x = 3; x <= 5; x++)
        {
            for (z = 0; z < 4; z++)
            {
                tiles[x, 0, z] = (int)terrainTypes.SWAMP;
            }
        }



        // Make a u-shaped mountain
        tiles[4, 1, 4] = (int)terrainTypes.MOUNTAIN;
        tiles[5, 1, 4] = (int)terrainTypes.MOUNTAIN;
        tiles[6, 1, 4] = (int)terrainTypes.MOUNTAIN;
        tiles[7, 1, 4] = (int)terrainTypes.MOUNTAIN;
        tiles[8, 1, 4] = (int)terrainTypes.MOUNTAIN;

        tiles[4, 1, 5] = (int)terrainTypes.MOUNTAIN;
        tiles[4, 1, 6] = (int)terrainTypes.MOUNTAIN;
        tiles[8, 1, 5] = (int)terrainTypes.MOUNTAIN;
        tiles[8, 1, 6] = (int)terrainTypes.MOUNTAIN;


    }

    void GenerateMapVisual()
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int z = 0; z < mapSizeZ; z++)
                {
                    Debug.Log("assigning tiletype from script");
                    TileType tt = tileTypes[tiles[x, y, z]];
                    GameObject go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
                 

    }

}
