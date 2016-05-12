using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ChangePixelColor : MonoBehaviour
{
    bool isInside = false;

	// Use this for initialization
	void Start () {
	
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
            }
            else
            {
                Image img = GetComponent<Image>();
                img.color = new Color(255, 255, 255);
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
        }
        else
        {
            img.color = new Color(255, 255, 255);
        }
    }

    public void Exit()
    {
        isInside = false;
    }
}
