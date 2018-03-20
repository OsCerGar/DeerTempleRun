using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {
    [SerializeField]
    protected List<GameObject> roadPrefList = new List<GameObject>();
    [SerializeField]
    protected List<GameObject> bridgePrefList = new List<GameObject>();
    [SerializeField]
    protected GameObject postBridgePref;
    [SerializeField]
    protected  bool PostBridge = false;
    [SerializeField]
    float distTile;
    float roadPos = 0;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 8; i++)
        {
            AddTile();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddTile()
    {
        if (PostBridge)//Para evitar caras invisibles :)
        {
            Debug.Log("post");
            Instantiate(postBridgePref, new Vector3(0, 1, roadPos), Quaternion.identity);
             PostBridge = false;
        }
        else
        {
            
           var tile = Instantiate(roadPrefList[Random.Range(0, roadPrefList.Count)], new Vector3(0, 1, roadPos), Quaternion.identity);
            if (tile.GetComponent<RoadPrefColl>().bridge)
            {
                PostBridge = true;
            }
        }
        roadPos += distTile;
        
    }
}
