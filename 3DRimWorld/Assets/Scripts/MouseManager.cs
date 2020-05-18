using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class MouseManager : MonoBehaviour
{

    public GameObject thePrefabToSpawn;
    public List<Vector3> spawnPoints;

    TileMap worldTileMap;

    // Use this for initialization
    void Start()
    {
        spawnPoints = new List<Vector3>();
        worldTileMap = FindObjectOfType<TileMap>();
        Debug.Log(worldTileMap);
    }


    // Update is called once per frame
    void Update()
    {

        // Was the mouse pressed down this frame?

        if (Input.GetMouseButton(0))
        {
            // Yes, the left mouse button was pressed this frame
            // Is the mouse over a cube

            Camera theCamera = Camera.main;

            Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log("Yes, we hit: " + hitInfo.collider.gameObject.name);

                // Now let's spawn a new object
                // Add spawn point to list of prefabs we're going to spawn.

                if (!spawnPoints.Contains(hitInfo.collider.transform.position + hitInfo.normal))
                {
                    spawnPoints.Add(hitInfo.collider.transform.position + hitInfo.normal);
                }
                
            }
        }

        // Spawn items in list.

        if (Input.GetMouseButtonUp(0))
        {
            // Spawn

            foreach (Vector3 v in spawnPoints)
            {
                Instantiate(thePrefabToSpawn, v, Quaternion.identity); //TODO make 'thePrafabtoSpawn' a choice.
                
                int x = (int)v.x;
                int y = (int)v.y;
                int z = (int)v.z;
                Debug.Log(x + ", " + y + ", " + z);
                worldTileMap.tiles[x, y, z] = (int)TileMap.terrainTypes.WALL; //TODO Change terrain type to correct opject.  This is hardcoded at the moment
                
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                Debug.Log("Clearing list of objects to Instantiate.");
                spawnPoints.RemoveAt(i);
                Debug.Log("List is now at length " + spawnPoints.Count);
            }

            
        }

        if (Input.GetMouseButtonUp(1))
        {

            Camera theCamera = Camera.main;

            Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log("Yes, we hit: " + hitInfo.collider.gameObject.name);
                
                // Gather info from tile we hit.

                int x = (int)hitInfo.collider.gameObject.transform.position.x;
                int y = (int)hitInfo.collider.gameObject.transform.position.y;
                int z = (int)hitInfo.collider.gameObject.transform.position.z;
                TileType tt = worldTileMap.tileTypes[worldTileMap.tiles[x, y, z]]; ;

                // Display info to debug log.

                Debug.Log("Tile X Pos = " + x);
                Debug.Log("Tile Y Pos = " + y);
                Debug.Log("Tile Z Pos = " + z);
                Debug.Log("Tile type is " + worldTileMap.tiles[x, y, z]);

                Debug.Log("Name of tiletype is " + tt.name);
                Debug.Log("Movement cost for this tile is " + tt.movementCost);
            }
        }

    }

}
