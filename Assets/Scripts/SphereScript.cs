using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {
    private bool Creating = false;
    public GameObject m_object;
    GameObject m_objInstance;
    // Use this for initialization
    public int nrOfClicks = 0;
    SortingOfBlueprints hejsan;

    void Start () {
        hejsan = GameObject.FindObjectOfType(typeof(SortingOfBlueprints)) as SortingOfBlueprints;
        if (hejsan.IsFull())
        {
            hejsan.PlaceOnTop(gameObject);
        }
        else
        {
            hejsan.AddToList(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (false)//Creating == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != m_object.transform)
                {
                    Vector3 derp = hit.transform.position - Camera.main.transform.position;
                    Vector3 newPos = hit.transform.position - derp.normalized;
                    m_object.transform.position = newPos;
                }
            }
            else
            {
                m_object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x
                    , Input.mousePosition.y, 10));
            }
            if (Input.GetMouseButtonDown(0))
            {
                Creating = false;
            }
        }
	}

    public void CreateObject()
    {
        m_objInstance = Instantiate(m_object);
        m_objInstance.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x
                , Input.mousePosition.y, 10));
        nrOfClicks++;
        hejsan.SortList();
        hejsan.PlaceOnTop(gameObject);
        Creating = true;


        GetComponentInParent<Canvas>().GetComponentInChildren<EntitiesList>().AddNewActor(m_objInstance);
    }
    public int GetClicks()
    {
        return nrOfClicks;
    }
}
