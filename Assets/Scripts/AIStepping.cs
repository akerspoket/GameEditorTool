using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AIStepping : MonoBehaviour {
    struct Point
    {
        public int x;
        public int y;
    }
    private GroundCreation script;
    public float stepFreq;
    private float timer = 0;
    private GameObject[] gamePlane;
    private int x;
    private int y;
    private bool Creating = true;
    private bool Playing = false;
    private List<Point> steps = new List<Point>();
	// Use this for initialization
	void Start () {
        script = FindObjectOfType(typeof(GroundCreation)) as GroundCreation;
        gamePlane = script.groundArray;

        transform.position = gamePlane[x + y * 30].transform.position;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayPauseStepControll>().AddEnemy(this.gameObject);
    }

    public void SetPlay()
    {
        Playing = true;
    }

    public void SetPause()
    {
        Playing = false;
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
        else if (Playing)
        {
            timer += Time.deltaTime;
            if (timer > stepFreq)
            {
                TakeStep();
            }
        }
	}
    public void TakeStep()
    {
        // Save previous step
        Point newpoint;
        newpoint.x = x;
        newpoint.y = y;
        steps.Add(newpoint);

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
                    float chargeToCheck = -gamePlane[xToCheck + yToCheck * 30].GetComponent<PotentialFieldCharge>().charge - gamePlane[xToCheck + yToCheck * 30].GetComponent<PotentialFieldCharge>().backgroundCharge;
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
    public void StepBack()
    {
        int last = steps.Count-1;
        if (last > 0)
        {
            x = steps[last].x;
            y = steps[last].y;
            transform.position = gamePlane[x + y * 30].transform.position;
            steps.RemoveAt(last);
        }
        else if (last == 0)
        {
            x = steps[last].x;
            y = steps[last].y;
            transform.position = gamePlane[x + y * 30].transform.position;
        }
    }
}
