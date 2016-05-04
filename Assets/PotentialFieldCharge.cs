using UnityEngine;
using System.Collections;

public class PotentialFieldCharge : MonoBehaviour
{

    public float charge;

    // Use this for initialization
    void Start()
    {
        charge = 0;
        AddCharge(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCharge(float p_charge)
    {
        charge += p_charge;
        if (charge > 0)
            GetComponent<Renderer>().material.color = new Color(0.5f + charge, 0.5f - charge, 0.5f - charge, 1);
        else if (charge < 0)
            GetComponent<Renderer>().material.color = new Color(0.5f + charge, 0.5f - charge, 0.5f + charge, 1);
    }

}
