using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EntitiesList : MonoBehaviour {
    public GameObject listItemPrefab;
    public GameObject mouseRightClick;
    public List<GameObject> actors = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddNewActor(GameObject obj)
    {   
        GameObject newObject = (GameObject)Instantiate(listItemPrefab);
        newObject.transform.SetParent(this.transform.FindChild("InsideBody")); // should probably be the entities box or something...
        newObject.GetComponentInChildren<Text>().text = obj.transform.name;
        newObject.transform.localPosition = new Vector3(-6, 165, 0) + new Vector3(0, -(actors.Count) * 30, 0);
        newObject.transform.localScale = new Vector3(1, 1, 1);
        newObject.GetComponent<EntityHolder>().SetEntity(obj);
        actors.Add(newObject);
    }

    public void RemoveActor(GameObject obj)
    {
        for (int i = 0; i < actors.Count; i++)
        {
            if (actors[i].GetComponent<EntityHolder>().GetActor() == obj)
            {
                actors[i].GetComponent<EntityHolder>().DestroyThisEntity();
                actors.RemoveAt(i);          
                i--;
            }
            else
            {
                actors[i].transform.localPosition = new Vector3(-6, 165, 0) + new Vector3(0, -(i) * 30, 0);
                actors[i].transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
    }

    public void RemoveActorWithMouse()
    {
        RemoveActor(mouseRightClick.GetComponent<SetTargetedSource>().GetGameObject());
    }
}
