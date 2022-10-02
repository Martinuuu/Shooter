using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DebugInfo : MonoBehaviour
{
    public Rigidbody rb;
    public TMP_Text speedText;

    string playerSpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        speedText.text = Math.Round(rb.velocity.magnitude, 2).ToString();
    }
}
