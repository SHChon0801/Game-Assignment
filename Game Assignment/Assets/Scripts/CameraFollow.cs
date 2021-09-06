using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    float xWidthC = 53f;
    float yHeightC = 22f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -xWidthC, xWidthC), 
            Mathf.Clamp(player.position.y, -yHeightC, yHeightC), transform.position.z);
    }
}
