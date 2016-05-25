using UnityEngine;
using System.Collections;

public class PotentialFieldCharge : MonoBehaviour
{

    public float charge;
    public float backgroundCharge;
    

    // Use this for initialization
    void Start()
    {
        charge = 0;
        backgroundCharge = 0;
        AddCharge(0);
    }

    // Update is called once per frame
    void Update()
    {
        charge = 0;
        backgroundCharge = 0;
        AddCharge(0);
    }

    public void AddCharge(float p_charge)
    {
        // Accumulate total charge
        charge += p_charge;

        float colorFactor = charge / 40.0f; // Silly hard-coded value
        float backGroundFactor = backgroundCharge / 40.0f;

        // Color the cube properly
        if (charge >= 0)
            GetComponent<Renderer>().material.color = new Color(0.5f + colorFactor + backGroundFactor, 0.5f - colorFactor - backGroundFactor, 0.5f - colorFactor, 1);
        else if (charge < 0)
            GetComponent<Renderer>().material.color = new Color(0.5f + colorFactor + backGroundFactor, 0.5f - colorFactor - backGroundFactor, 0.5f + colorFactor, 1);
    }

    public void AddUnselectedCharge(float p_charge)
    {
        // Accumulate total charge
        backgroundCharge += p_charge;

        float colorFactor = charge / 40.0f; // Silly hard-coded value
        float backGroundFactor = backgroundCharge / 40.0f;

        // Color the cube properly
        if (charge >= 0)
            GetComponent<Renderer>().material.color = new Color(0.5f + colorFactor + backGroundFactor, 0.5f - colorFactor - backGroundFactor, 0.5f - colorFactor, 1);
        else if (charge < 0)
            GetComponent<Renderer>().material.color = new Color(0.5f + colorFactor + backGroundFactor, 0.5f - colorFactor - backGroundFactor, 0.5f + colorFactor, 1);
    }
}
