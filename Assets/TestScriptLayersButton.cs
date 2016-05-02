using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScriptLayersButton : MonoBehaviour {
    public Color activeColor;
    public Color inactiveColor;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MakeInactive()
    {
        GetComponent<Button>().image.color = inactiveColor;

    }

    public void MakeActive()
    {
        GetComponent<Button>().image.color = activeColor;
    }
}
