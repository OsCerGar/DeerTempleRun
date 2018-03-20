using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPrefColl : MonoBehaviour {
    public bool Destroy = false;
    RoadManager RM;
    public bool bridge;

    private void Start()
    {
        RM = FindObjectOfType<RoadManager>();
    }

    private void FixedUpdate()
    {
        if (Destroy)
        {
            StartCoroutine(DestroyAndCreate());
        }
    }

    IEnumerator DestroyAndCreate()
    {
        yield return new WaitForSeconds(0.5f);
        RM.AddTile();
        print("Nuevo Tile Creado");
        Destroy(transform.gameObject);
    }
}
