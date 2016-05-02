using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGrey : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().image.color = Color.grey;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
