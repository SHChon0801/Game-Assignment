using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    float xWidthC = 3f;
    float yHeightC = 5f;

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -xWidthC, xWidthC), Mathf.Clamp(player.position.y, -yHeightC, yHeightC), transform.position.z);
    }
}
}
