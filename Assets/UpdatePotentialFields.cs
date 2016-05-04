using UnityEngine;
using System.Collections;

public class UpdatePotentialFields : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] ground = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject cube in ground)
        {
            GetComponent<PotentialFieldCharge>().AddCharge(0.1f);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
