using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ChangePixelColor : MonoBehaviour
{
    bool isInside = false;
    public float charge = 0.0f;

    GameObject fieldHolder;

	// Use this for initialization
	void Start () {
        fieldHolder = GameObject.FindGameObjectWithTag("ShapeEditor");

    }


    // Update is called once per frame
    void Update () {

        if(isInside)
        {
            bool holdLeft = Input.GetMouseButtonDown(0);
            bool holdRight = Input.GetMouseButtonDown(1);

            if (holdLeft == holdRight)
            {
                return;
            }

            if (holdLeft)
            {
                Image img = GetComponent<Image>();
                img.color = new Color(0, 0, 0);
                charge = 10;

                //if (charge >= 0)
                //    GetComponent<Renderer>().material.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f - colorFactor, 1);
                //else if (charge < 0)
                //    GetComponent<Renderer>().material.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f + colorFactor, 1);
            }
            else
            {
                Image img = GetComponent<Image>();
                img.color = new Color(255, 255, 255);
                charge = 0;
            }
        }
    }


    public void OnHoldChangeColor()
    {
        isInside = true;
        Image img = GetComponent<Image>();

        bool holdLeft = Input.GetMouseButton(0);
        bool holdRight = Input.GetMouseButton(1);

        if (holdLeft == holdRight)
        {
            return;
        }

        if(holdLeft)
        {
            img.color = new Color(0, 0, 0);
            charge = 10;
        }
        else
        {
            img.color = new Color(255, 255, 255);
            charge = 0;
        }
    }

    public void Exit()
    {
        isInside = false;
    }
}
