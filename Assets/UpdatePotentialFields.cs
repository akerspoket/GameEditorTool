using UnityEngine;
using System.Collections;

public class UpdatePotentialFields : MonoBehaviour {

    //float distanceFactor = 1.0f / 20.0f;
    public float chargeValue = 0;

    // Use this for initialization
    void Start () {
        Vector3 thisPosition = transform.position;
        GameObject[] ground = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject cube in ground)
        {
            Vector3 cubePosition = cube.transform.position;
            float distance = (cubePosition - thisPosition).magnitude;

            float charge = chargeValue / distance;
            cube.GetComponent<PotentialFieldCharge>().AddCharge(charge);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
