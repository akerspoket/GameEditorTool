using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartWithColor : MonoBehaviour {
    public Color colorToStartWith;
	// Use this for initialization
	void Start () {
        GetComponent<Image>().color = colorToStartWith;
    }
	
}
