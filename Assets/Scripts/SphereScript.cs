using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {
    private bool Creating = false;
    GameObject m_object;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Creating == true)
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

    public void CreateObject(GameObject objectToCreate)
    {
        m_object = Instantiate(objectToCreate);
        m_object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x
                , Input.mousePosition.y, 10));
        Creating = true;
        GetComponentInParent<Canvas>().GetComponentInChildren<EntitiesList>().AddNewActor(m_object);
    }
}
