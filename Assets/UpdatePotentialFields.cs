using UnityEngine;
using System.Collections;

public class UpdatePotentialFields : MonoBehaviour
{

    //float distanceFactor = 1.0f / 20.0f;
    public float chargeValue = 0;
    public bool Creating = true;

    // Might need an array of charges for the field here
    bool useNormalShape = true;

    // Custom shape, hard coded also in StartShapeEditor
    public float[] customField = new float[50*50];

    // Use this for initialization
    void Start()
    {
        //customField[30 * 1] = 20.0f;
        //customField[30 * 2] = 20.0f;
        //customField[30 * 3] = 20.0f;
        //customField[30 * 4] = 20.0f;
        //customField[30 * 5] = 20.0f;

        //customField[1] = 20.0f;
        //customField[2] = 20.0f;
        //customField[3] = 20.0f;
        //customField[4] = 20.0f;
        //customField[5] = 20.0f;

        //customField[30 * 5 + 1] = 20.0f;
        //customField[30 * 5 + 2] = 20.0f;
        //customField[30 * 5 + 3] = 20.0f;
        //customField[30 * 5 + 4] = 20.0f;
        //customField[30 * 5 + 5] = 20.0f;
        //customField[30 * 5 + 6] = 20.0f;
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

    public void UseCustomShape()
    {
        useNormalShape = false;
    }

    public bool IsUsingCustomShape()
    {
        return !useNormalShape;
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
            // Always use own values
            EntitiesList entityList = GameObject.FindGameObjectWithTag("Entities").GetComponent<EntitiesList>();

            bool foundSelected = false;
            bool isUs = false;

            foreach (var item in entityList.actors)
            {
                foundSelected = item.GetComponent<EntityHolder>().selected;
                if (foundSelected)
                {
                    if (item.GetComponent<EntityHolder>().GetActor() == gameObject)
                    {
                        isUs = true;
                    }
                    break;
                }
            }
            

            if (useNormalShape)
            {
                // Update the ground cubes
                Vector3 thisPosition = transform.position;
                GameObject[] ground = GameObject.FindGameObjectsWithTag("Respawn");
                foreach (GameObject cube in ground)
                {
                    Vector3 cubePosition = cube.transform.position;
                    float distance = (cubePosition - thisPosition).magnitude;
                    float charge = chargeValue / distance;

                    if (foundSelected)
                    {
                        if (isUs)
                        {
                            cube.GetComponent<PotentialFieldCharge>().AddCharge(charge);
                        }
                        else
                        {
                            cube.GetComponent<PotentialFieldCharge>().AddUnselectedCharge(charge);
                        }
                    }
                    else
                    {
                        cube.GetComponent<PotentialFieldCharge>().AddCharge(charge);
                    }
                    //cube.GetComponent<PotentialFieldCharge>().AddCharge(charge);
                }
            }
            else
            {
                GameObject gridCreator = GameObject.FindGameObjectWithTag("GridCreator");
                GroundCreation groundCreation = gridCreator.GetComponent<GroundCreation>();
                //groundCreation.groundArray;
                int gridX = (int)transform.position.x;
                int gridY = (int)transform.position.y;

                // Start stop cause field can be larger then grid
                int startX = Mathf.Max(gridX - 15, 0);
                int startY = Mathf.Max(gridY - 15, 0);
                int endX = Mathf.Min(gridX + 15, 30);
                int endY = Mathf.Min(gridY + 15, 30);

                // Only loop over grid
                for (int y = 0; y < 30; y++)
                {
                    for (int x = 0; x < 30; x++)
                    {
                        float chargeToAdd = customField[y * 30 + x];

                        if (foundSelected)
                        {
                            if (isUs)
                            {
                                groundCreation.groundArray[y * 30 + x].GetComponent<PotentialFieldCharge>().AddCharge(chargeToAdd);
                            }
                            else
                            {
                                groundCreation.groundArray[y * 30 + x].GetComponent<PotentialFieldCharge>().AddUnselectedCharge(chargeToAdd);
                            }
                        }
                        else
                        {
                            groundCreation.groundArray[y * 30 + x].GetComponent<PotentialFieldCharge>().AddCharge(chargeToAdd);
                        }

                        //groundCreation.groundArray[y * 30 + x].GetComponent<PotentialFieldCharge>().AddCharge(chargeToAdd);
                    }
                }

            }
        }
    }
}