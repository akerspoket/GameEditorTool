﻿using UnityEngine;
using System.Collections;

public class AIStepping : MonoBehaviour {
    private GroundCreation script;
    public float stepFreq;
    private float timer = 0;
    private GameObject[] gamePlane;
    private int x;
    private int y;
    private bool Creating = true;
	// Use this for initialization
	void Start () {
        script = FindObjectOfType(typeof(GroundCreation)) as GroundCreation;
        gamePlane = script.groundArray;

        transform.position = gamePlane[x + y * 30].transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
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
                    for (int i = 0; i < 30; i++)
                    {
                        for (int j = 0; j < 30; j++)
                        {
                            if (hit.transform.gameObject == gamePlane[j + i * 30])
                            {
                                x = j;
                                y = i;
                                transform.position = gamePlane[x + y * 30].transform.position;
                            }
                        }
                    }
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
            timer += Time.deltaTime;
            if (timer > stepFreq)
            {
                int xToCheck = x - 1;
                int yToCheck = y - 1;
                int highestx = x;
                int highesty = y;
                float highestCharge = -gamePlane[x + y * 30].GetComponent<PotentialFieldCharge>().charge;
                for (int i = 0; i < 3; i++)
                {
                    xToCheck = x - 1;
                    for (int j = 0; j < 3; j++)
                    {
                        if (xToCheck >= 0 && xToCheck < 30 && yToCheck >= 0 && yToCheck < 30)
                        {
                            float chargeToCheck = -gamePlane[xToCheck + yToCheck * 30].GetComponent<PotentialFieldCharge>().charge;
                            if (chargeToCheck > highestCharge)
                            {
                                highestx = xToCheck;
                                highesty = yToCheck;
                                highestCharge = chargeToCheck;
                            }
                        }
                        xToCheck++;

                    }

                    yToCheck++;
                }
                x = highestx;
                y = highesty;
                timer = 0;
                transform.position = gamePlane[x + y * 30].transform.position;
            }
        }
	}

}
