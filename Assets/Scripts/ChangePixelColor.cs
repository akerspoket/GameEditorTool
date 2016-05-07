using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ChangePixelColor : MonoBehaviour
{

    bool filled = false;

	// Use this for initialization
	void Start () {
	
	}


    // Update is called once per frame
    void Update () {

    }

    public void OnHoldChangeColor()
    {
        filled = !filled;
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
}
