using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseManager : MonoBehaviour
{

    public GameObject thePrefabToSpawn;
    public List<Vector3> spawnPoints;


    // Use this for initialization
    void Start()
    {
        spawnPoints = new List<Vector3>();
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

            Debug.Log("Instatiating");

            foreach (Vector3 v in spawnPoints)
            {
                Instantiate(thePrefabToSpawn, v, Quaternion.identity);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                Debug.Log("Clearing list of objects to Instantiate.");
                spawnPoints.RemoveAt(i);
                Debug.Log("List is now at length " + spawnPoints.Count);
            }
        }


    }

}
