using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolve : MonoBehaviour
{
    public float dissolveStep = 0.0f;
    private Material material;


    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().sharedMaterials[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        material.SetFloat("_Cutoff_Height", dissolveStep);
        
    }
}
