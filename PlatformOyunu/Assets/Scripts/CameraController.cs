using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraController : NetworkBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;

    public void cameraPositionChanged(Transform getTransformPosition)
    {
        this.transform.position = getTransformPosition.position + offset;
    }

}
