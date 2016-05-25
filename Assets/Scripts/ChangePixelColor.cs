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
                charge = fieldHolder.GetComponent<StartShapeEditor>().coloringCharge;

                float colorFactor = charge / 40.0f;

                if (charge > 0)
                    img.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f - colorFactor, 1);
                else if (charge < 0)
                    img.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f + colorFactor, 1);
                else
                    img.color = new Color(255, 255, 255);
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
            charge = fieldHolder.GetComponent<StartShapeEditor>().coloringCharge;

            float colorFactor = charge / 40.0f;

            if (charge > 0)
                img.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f - colorFactor, 1);
            else if (charge < 0)
                img.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f + colorFactor, 1);
            else
                img.color = new Color(255, 255, 255);
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
