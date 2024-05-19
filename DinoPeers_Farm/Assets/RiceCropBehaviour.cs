using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceCropBehaviour : MonoBehaviour
{
    int RicemaxHP = 100;
    int RiceHP = 100;

    //Time used to determine plant growth stage
    float gameTimer = 1200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RiceHP <= 0)
        {
            Debug.Log("Crop Died");
            DestroyCrop();
        }
    }

    void DestroyCrop()
    {
        Destroy(this.gameObject);
    }
}
