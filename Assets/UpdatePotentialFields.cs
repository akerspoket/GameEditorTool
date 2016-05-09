using UnityEngine;
using System.Collections;

public class UpdatePotentialFields : MonoBehaviour
{

    //float distanceFactor = 1.0f / 20.0f;
    public float chargeValue = 0;
    public bool Creating = true;

    // Use this for initialization
    void Start()
    {
        //Vector3 thisPosition = transform.position;
        //GameObject[] ground = GameObject.FindGameObjectsWithTag("Respawn");
        //foreach (GameObject cube in ground)
        //{
        //    Vector3 cubePosition = cube.transform.position;
        //    float distance = (cubePosition - thisPosition).magnitude;

        //    float charge = chargeValue / distance;
        //    cube.GetComponent<PotentialFieldCharge>().AddCharge(charge);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Creating)
        {
            // Ensure its moving if we haven't released it yet
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != transform)
                {
                    Vector3 derp = hit.transform.position - Camera.main.transform.position;
                    Vector3 newPos = hit.transform.position - derp.normalized;
                    transform.position = newPos;
                }
            }

            else
            {
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x
                    , Input.mousePosition.y, 10));
            }
            // Check if we've released
            if (Input.GetMouseButtonDown(0))
            {
                Creating = false;
            }
        }
        else
        {
            // Update the ground cubes
            Vector3 thisPosition = transform.position;
            GameObject[] ground = GameObject.FindGameObjectsWithTag("Respawn");
            Debug.Log("Adding charge to thingies");
            foreach (GameObject cube in ground)
            {
                Vector3 cubePosition = cube.transform.position;
                float distance = (cubePosition - thisPosition).magnitude;
                float charge = chargeValue / distance;
                cube.GetComponent<PotentialFieldCharge>().AddCharge(charge);
            }
        }
    }
}