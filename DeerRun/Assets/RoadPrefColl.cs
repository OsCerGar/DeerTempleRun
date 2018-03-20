using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPrefColl : MonoBehaviour {
    private bool Destroy = false;
    RoadManager RM;
    public bool bridge;

    private void Start()
    {
        RM = FindObjectOfType<RoadManager>();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy = true;
        }
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
        yield return new WaitForSeconds(3);
        RM.AddTile();
        print("Nuevo Tile Creado");
        Destroy(transform.gameObject);
    }
}
