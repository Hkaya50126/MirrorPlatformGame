using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;   

public class PlayerCameraScript : NetworkBehaviour
{
    public Transform player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.position + offset;
        newPosition.y = transform.position.y; 
        transform.position = newPosition;
    }
}
