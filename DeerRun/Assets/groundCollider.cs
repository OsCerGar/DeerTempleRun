using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCollider : MonoBehaviour {

    RoadPrefColl parent;

	// Use this for initialization
	void Start () {
        parent = this.transform.parent.GetComponent<RoadPrefColl>();		
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            parent.Destroy = true;
        }
    }
}
