using UnityEngine;
using System.Collections;

public class ShapeColoring : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Check for both right and left click
        bool holdLeft = Input.GetButtonDown("Fire1");
        bool holdRight = Input.GetButtonDown("Fire2");

        if (holdLeft || holdRight)
        {
            // Create ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If hit anything
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit something?");
                //If pixel ? 
                if (hit.collider != null)
                {
                    Debug.Log("collider!");

                    // If pixel
                    GameObject gamObj = (GameObject)hit.transform.gameObject;
                    if (gamObj.GetComponent<ChangePixelColor>() != null)
                    {
                        Debug.Log("Put function here!");
                    }
                }
            }
        }
    }
}
