using UnityEngine;
using System.Collections;

public class SökScript : MonoBehaviour {
    public GameObject tabort1;
    public GameObject tabort2;
    public GameObject tabort3;
    Vector3 pos;
    // Use this for initialization
    void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Search(string text)
    {
        string ast = text;
        Debug.Log(ast);
        if (text == "")
        {
            tabort1.SetActive(true);
            tabort2.SetActive(true);
            tabort3.SetActive(true);
            transform.position = pos;
        }
        transform.position = tabort1.transform.position;
        tabort1.SetActive(false);
        tabort2.SetActive(false);
        tabort3.SetActive(false);
    }
}
