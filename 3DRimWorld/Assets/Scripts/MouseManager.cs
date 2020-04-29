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

        if (Input.GetMouseButtonDown(0))
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

                Vector3 spawnSpot = hitInfo.collider.transform.position + hitInfo.normal;

                Instantiate(thePrefabToSpawn, spawnSpot, Quaternion.identity);

                spawnPoints.Add(spawnSpot);

                if (spawnPoints.Contains(spawnSpot))
                {
                    Debug.Log("Hazzaahh");
                }
            }


        }

        // Could we us Input.GetMouseButton(0))
        // Have an array/list of vector3's for spawn spots.  If array does not already contain hitInfo.collider.transform.position + hitInfo.normal
        // Add this position to list.
        // On mouse up, loop through list and instanstiate.


    }

}
