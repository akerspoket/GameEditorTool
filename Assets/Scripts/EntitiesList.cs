using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EntitiesList : MonoBehaviour {
    public GameObject listItemPrefab;
    private List<GameObject> actors = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddNewActor(GameObject obj)
    {
        actors.Add(obj);
        GameObject newObject = (GameObject)Instantiate(listItemPrefab);
        newObject.transform.SetParent(this.transform.FindChild("InsideBody")); // should probably be the entities box or something...
        newObject.GetComponentInChildren<Text>().text = obj.transform.name;
        newObject.transform.localPosition = new Vector3(-6, 165, 0) + new Vector3(0, -(actors.Count - 1) * 30, 0);
        newObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void RemoveActor(GameObject obj)
    {

    }
}
