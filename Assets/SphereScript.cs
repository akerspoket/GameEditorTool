using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {
    private bool Creating = false;
    GameObject sphere;
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
                if (hit.transform != sphere.transform)
                {
                    Vector3 derp = hit.transform.position - Camera.main.transform.position;
                    Vector3 newPos = hit.transform.position - derp.normalized;
                    sphere.transform.position = newPos;
                }
            }
            else
            {
                sphere.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x
                    , Input.mousePosition.y, 10));
            }
            if (Input.GetMouseButtonDown(0))
            {
                Creating = false;
            }
        }
	}

    public void CreateSphere()
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x
                , Input.mousePosition.y, 10));
        Creating = true;
    }
}
