using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyPos : MonoBehaviour
{
    public Transform skydome;
    public Transform player;
    
    void Update()
    {
        skydome.position = new Vector3(player.position.x, skydome.position.y, player.position.z);
    }
}
