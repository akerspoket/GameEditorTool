using UnityEngine;
using System.Collections;

public class EntityHolder : MonoBehaviour {
    private GameObject actor;
    public GameObject selectionRing;
    private GameObject ownRing;
    public bool selected;
	// Use this for initialization
	void Start () {
        ownRing = Instantiate(selectionRing);
        ownRing.GetComponent<MeshRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (selected)
        {
            ownRing.transform.localPosition = actor.transform.position + new Vector3(0, 0, 0);
            ownRing.GetComponent<MeshRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                GetComponentInParent<EntitiesList>().RemoveActor(actor);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayPauseStepControll>().RemoveEnemy(actor);
                Destroy(actor);
                Destroy(ownRing);
                Destroy(this.transform.gameObject);
            }
        }
    }

    public void SetEntity(GameObject obj)
    {
        actor = obj;
    }

    public void MakeSelected(bool selected)
    {
        GameObject shapeEditor = GameObject.FindGameObjectWithTag("ShapeEditor");
        this.selected = selected;
        if (!selected)
        {           
            ownRing.GetComponent<MeshRenderer>().enabled = false;
            shapeEditor.GetComponent<StartShapeEditor>().SetInactive();
        }   
        else
        {
            shapeEditor.GetComponent<StartShapeEditor>().SetActive(actor);
        }
    }

    public GameObject GetActor()
    {
        return actor;
    }
}
