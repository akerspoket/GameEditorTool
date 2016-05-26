using UnityEngine;
using System.Collections;

public class GroundCreation : MonoBehaviour {
    public GameObject obj;
    public Camera cam;
    public const int dimx = 30;
    public const int dimy = 30;

    public GameObject[] groundArray = new GameObject[dimx*dimy];

	// Use this for initialization
	void Start () {
        cam.transform.position = new Vector3(-15, 18, dimy / 2);
        cam.transform.LookAt(cam.transform.position + new Vector3(1, -1, 0));
        for (int i = 0; i < dimy; i++)
        {
            for (int j = 0; j < dimx; j++)
            {
                GameObject newObj = (GameObject)Instantiate(obj, new Vector3(i, 0, 30 - j), new Quaternion(0, 0, 0, 1));
                groundArray[i * dimy + j] = newObj;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
