using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class SökScript : MonoBehaviour {
    public GameObject tabort1;
    public GameObject tabort2;
    public GameObject tabort3;
    public GameObject tabort4;
    public GameObject tabort5;
    public GameObject tabort6;
    public GameObject SearchBar;
    Vector3 pos;
    bool dontSetActiveAgain = false;
    string searchText = "";
    // Use this for initialization
    void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        searchText = SearchBar.GetComponent<InputField>().text;
        if (searchText == "")
        {
            tabort1.SetActive(true);
            tabort2.SetActive(true);
            tabort3.SetActive(true);
            tabort4.SetActive(true);
            tabort5.SetActive(true);
            tabort6.SetActive(true);
            if (dontSetActiveAgain)
            {
                SortingOfBlueprints hejsan = GameObject.FindObjectOfType(typeof(SortingOfBlueprints)) as SortingOfBlueprints;
                hejsan.SortList();
                dontSetActiveAgain = false;
            }
        }        
        else {
        GetComponent<RectTransform>().localPosition = new Vector3(0, 163, 0);
        tabort1.SetActive(false);
        tabort2.SetActive(false);
        tabort3.SetActive(false);
        tabort4.SetActive(false);
        tabort5.SetActive(false);
        tabort6.SetActive(false);
        dontSetActiveAgain = true;
        }
    }
    public void Search(UnityEngine.UI.Text text)
    {
        string ast = text.text;
        Debug.Log(ast);
        if (text.text == "")
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
