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
        charge = 0;
        AddCharge(0);
    }

    public void AddCharge(float p_charge)
    {
        // Accumulate total charge
        charge += p_charge;

        float colorFactor = charge / 40.0f; // Silly hard-coded value
        // Color the cube properly
        if (charge >= 0)
            GetComponent<Renderer>().material.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f - colorFactor, 1);
        else if (charge < 0)
            GetComponent<Renderer>().material.color = new Color(0.5f + colorFactor, 0.5f - colorFactor, 0.5f + colorFactor, 1);
    }

}
