using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetCaption : MonoBehaviour {
    private Text captionText;
    public string originalText;
	// Use this for initialization
	void Start () {
        captionText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        captionText.text = originalText;
	}
}
