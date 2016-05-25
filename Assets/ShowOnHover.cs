using UnityEngine;
using System.Collections;

public class ShowOnHover : MonoBehaviour {

    public GameObject[] hoverObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        var rect = GetComponent<RectTransform>().rect; //new Rect(0, 0, 150, 150);
        rect.position += new Vector2(transform.position.x, transform.position.y);
        if (rect.Contains(Input.mousePosition))
        {
            foreach (var item in hoverObjects)
            {
                item.SetActive(true);
            }
        }
        else
        {
            foreach (var item in hoverObjects)
            {
                item.SetActive(false);
            }
        }       
	}
}
