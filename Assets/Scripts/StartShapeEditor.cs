using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartShapeEditor : MonoBehaviour {

    const int dimenxionX = 30;
    const int dimenxionY = 30;

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
    public Slider secondSlider;

    GameObject[] gridArray = new GameObject[dimenxionX * dimenxionY];

    public float coloringCharge = 0.0f;

    // Object to use array on
    GameObject selectedObject;

    GameObject button;

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

                gameObj.SetActive(false);

                // Add to array
                gridArray[y * dimenxionY + x] = gameObj;
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

        button = GameObject.FindGameObjectWithTag("CustomizeButton");

        bool foundText = false;
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Text>() == null || foundText)
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                foundText = true;
            }

        }

        button.SetActive(false);
        OnValueChargeChange();
    }
	
	// Update is called once per frame
	void Update () {

        // If we have a selected object, update the field
        if (selectedObject != null)
        {
            UpdatePotentialFields updateFields = selectedObject.GetComponent<UpdatePotentialFields>();
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    updateFields.customField[y * 30 + x] = gridArray[y * 30 + x].GetComponent<ChangePixelColor>().charge;
                }
            }
        }
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

    public void OnValueChargeChange()
    {
        coloringCharge = (secondSlider.value * 2.0f - 1.0f) * 40.0f;
    }

    public void SetInactive()
    {
        // Set all inactive
        //foreach (Transform child in transform)
        //{
        //    child.gameObject.SetActive(false);
        //}

        //button.SetActive(true);
    }

    public void SetActive(GameObject obj)
    {
        selectedObject = obj;

        bool shouldHide = !selectedObject.GetComponent<UpdatePotentialFields>().IsUsingCustomShape();

        if (shouldHide)
        {
            // Set all inactive, except for the convert to new shape box if shouldn't be active
            bool foundText = false;
            foreach (Transform child in transform)
            {
                if (child.GetComponent<Text>() == null || foundText)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    foundText = true;
                }

            }

            button.SetActive(true);
        }
        else
        {
            // Set all inactive, except for the convert to new shape box if shouldn't be active
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

            UpdatePotentialFields updateFields = selectedObject.GetComponent<UpdatePotentialFields>();
            // Update canvas
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    gridArray[y * 30 + x].GetComponent<ChangePixelColor>().charge = updateFields.customField[y * 30 + x];

                    // change color based on charge
                    if (gridArray[y * 30 + x].GetComponent<ChangePixelColor>().charge > 0)
                    {
                        float colorFactor = gridArray[y * 30 + x].GetComponent<ChangePixelColor>().charge / 40.0f;
                        Image img = gridArray[y * 30 + x].GetComponent<Image>();
                        img.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f - colorFactor, 1);
                    }
                    else if(gridArray[y * 30 + x].GetComponent<ChangePixelColor>().charge < 0)
                    {
                        float colorFactor = gridArray[y * 30 + x].GetComponent<ChangePixelColor>().charge / 40.0f;
                        Image img = gridArray[y * 30 + x].GetComponent<Image>();
                        img.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f + colorFactor, 1);
                    }
                    else
                    {
                        Image img = gridArray[y * 30 + x].GetComponent<Image>();
                        img.color = new Color(255, 255, 255);
                    }
                }
            }

            button.SetActive(false);
        }
    }

    public void EnableCustomization()
    {
        if (selectedObject == null)
        {
            return;
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        button.SetActive(false);

        selectedObject.GetComponent<UpdatePotentialFields>().UseCustomShape();
    }
}
