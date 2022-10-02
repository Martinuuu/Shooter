using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPos : MonoBehaviour
{
    public Light direct_Light;
    public GameObject sun;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sun.transform.rotation = direct_Light.transform.rotation;
    }
}
