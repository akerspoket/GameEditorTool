using UnityEngine;
using System.Collections;

public class EditScript : MonoBehaviour
{
    SetTargetedSource hejhej;
    UpdatePotentialFields hejhej2;
    GameObject m_objectToAlter;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void IncreaseSource()
    {
        hejhej = GameObject.FindObjectOfType(typeof(SetTargetedSource)) as SetTargetedSource;
        //hejhej2 = GameObject.FindObjectOfType(typeof(UpdatePotentialFields)) as UpdatePotentialFields;
        m_objectToAlter = hejhej.GetGameObject();
        m_objectToAlter.GetComponent<UpdatePotentialFields>().AlterCharge(-10);
        //hejhej2.AlterCharge(-10);
    }

    public void DecreaseSource()
    {
        hejhej = GameObject.FindObjectOfType(typeof(SetTargetedSource)) as SetTargetedSource;
        m_objectToAlter = hejhej.GetGameObject();
        m_objectToAlter.GetComponent<UpdatePotentialFields>().AlterCharge(10);
        //hejhej2.AlterCharge(10);

    }
}
