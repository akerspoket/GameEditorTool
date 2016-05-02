using UnityEngine;
using System.Collections;

public class SetPosScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetMousePos()
    {
        transform.position=(Input.mousePosition);
    }
}
