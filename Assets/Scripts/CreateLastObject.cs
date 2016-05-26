using UnityEngine;
using System.Collections;

public class CreateLastObject : MonoBehaviour
{
    SortingOfBlueprints hejsan;
    SphereScript hejsan2;
    // Use this for initialization
    void Start ()
    {
        hejsan = GameObject.FindObjectOfType(typeof(SortingOfBlueprints)) as SortingOfBlueprints;
        hejsan2 = GameObject.FindObjectOfType(typeof(SphereScript)) as SphereScript;
    }
	
	// Update is called once per frame
    public void CreateLastObjectASD()
    {
        hejsan.getOnTop().GetComponent<SphereScript>().CreateObject();
        // hejsan2.CreateObject();
    }
}
