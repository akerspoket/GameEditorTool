using UnityEngine;
using System.Collections;

public class StartShapeEditor : MonoBehaviour {

    int dimenxionX = 50;
    int dimenxionY = 50;

    int boardSizeX = 250;
    int boardSizeY = 250;

    int offsetY = -50;

    public GameObject pixelObject;

    // Use this for initialization
    void Start () {

        Vector2 pixelSize = new Vector2((boardSizeX / dimenxionX)/2.0f, (boardSizeY / dimenxionY) /2.0f);

        for (int y = 0; y < dimenxionY; y++)
        {
            for (int x = 0; x < dimenxionX; x++)
            {
                GameObject gameObj = (GameObject)Instantiate(pixelObject);
                gameObj.transform.SetParent(transform);
                RectTransform rectTrans = gameObj.transform.GetComponent<RectTransform>();
                rectTrans.localPosition = new Vector3(x* pixelSize.x*2.0f - (boardSizeX /2.0f) + pixelSize.x, y* pixelSize.y*2.0f - (boardSizeY/2.0f) + pixelSize.y + offsetY, 0);
                rectTrans.sizeDelta = pixelSize;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
