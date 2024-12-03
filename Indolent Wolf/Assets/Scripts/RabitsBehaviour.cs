using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabitsBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Cast a ray down from the rabbit to check for collisions with terrain trees
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f, LayerMask.GetMask("Terrain")))
        {
            // Check if the hit object is a terrain tree
            Terrain terrain = hit.collider.GetComponent<Terrain>();
            if (terrain != null && terrain.terrainData.treeInstanceCount > 0)
            {
                // Iterate through all terrain trees
                foreach (TreeInstance tree in terrain.terrainData.treeInstances)
                {
                    // Convert tree position to world space
                    Vector3 treeWorldPosition = Vector3.Scale(tree.position, terrain.terrainData.size) + terrain.transform.position;

                    // Check if the rabbit is close to the tree
                    if (Vector3.Distance(transform.position, treeWorldPosition) < 1.0f)
                    {
                        // Do something when the rabbit is near a terrain tree (bush)
                        Debug.Log("Rabbit is near a bush!");
                    }
                }
            }
        }*/
    }
    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.CompareTag("Walls"))
        {
            Debug.Log("Animation Triggered as " + this.name + " collided with " + col.collider.name);
            transform.Rotate(0f, 115f, 0f);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
