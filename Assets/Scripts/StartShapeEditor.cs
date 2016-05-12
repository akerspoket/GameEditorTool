using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartShapeEditor : MonoBehaviour {

    int dimenxionX = 25;
    int dimenxionY = 25;

    int boardSizeX = 250;
    int boardSizeY = 250;

    int offsetX = 5;
    int offsetY = -43;


    public GameObject pixelObject;
    public GameObject arrowMiddle;
    public GameObject templateObject;
    GameObject realObject;
    bool isVisible = false;
    float opacity = 1.0f;

    public Slider mainSlider;


    // Use this for initialization
    void Start () {

        RectTransform ourRect = transform.GetComponent<RectTransform>();

        Vector2 pixelSize = new Vector2((boardSizeX / dimenxionX), (boardSizeY / dimenxionY));

        for (int y = 0; y < dimenxionY; y++)
        {
            for (int x = 0; x < dimenxionX; x++)
            {
                GameObject gameObj = (GameObject)Instantiate(pixelObject);
                gameObj.transform.SetParent(transform);
                RectTransform rectTrans = gameObj.transform.GetComponent<RectTransform>();


                rectTrans.localPosition = new Vector3(x* pixelSize.x - (boardSizeX /2.0f) + offsetX, y* pixelSize.y - (boardSizeY/2.0f) + offsetY, 0);
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pixelSize.x);
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pixelSize.y);
                gameObj.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        realObject = (GameObject)Instantiate(templateObject);
        realObject.transform.SetParent(transform);
        RectTransform objRect = realObject.transform.GetComponent<RectTransform>();
        objRect.localPosition = new Vector3(offsetX - pixelSize.x / 2.0f, offsetY - pixelSize.y / 2.0f, 0);
        objRect.transform.localScale = new Vector3(1, 1, 1);
        Image img = realObject.GetComponent<Image>();
        img.color = new Color(255, 255, 255, 0);


        GameObject arrowObj = (GameObject)Instantiate(arrowMiddle);
        arrowObj.transform.SetParent(transform);
        RectTransform arrowRect = arrowObj.transform.GetComponent<RectTransform>();
        arrowRect.localPosition = new Vector3(offsetX - pixelSize.x/2.0f, offsetY - pixelSize.y/2.0f, 0);
        arrowRect.transform.localScale = new Vector3(1, 1, 1);


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnValueChange()
    {
        isVisible = !isVisible;

        Image img = realObject.GetComponent<Image>();
        if (isVisible)
        {
            img.color = new Color(255, 255, 255, opacity);
        }
        else
        {
            img.color = new Color(255, 255, 255, 0);
        }
    }

    public void OnOpacityChange()
    {
        opacity = mainSlider.value;
        if (isVisible)
        {
            Image img = realObject.GetComponent<Image>();
            img.color = new Color(255, 255, 255, opacity);
        }
    }
}
