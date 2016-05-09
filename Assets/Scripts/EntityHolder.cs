using UnityEngine;
using System.Collections;

public class EntityHolder : MonoBehaviour {
    private GameObject entity;
    public GameObject selectionRing;
    private GameObject ownRing;
	// Use this for initialization
	void Start () {
        ownRing = Instantiate(selectionRing);
        ownRing.GetComponent<MeshRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetEntity(GameObject obj)
    {
        entity = obj;
    }

    public void MakeSelected(bool selected)
    {
        if (selected)
        {
            ownRing.transform.localPosition = entity.transform.position + new Vector3(0, 0, 0);
            ownRing.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            ownRing.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
