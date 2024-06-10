using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CoinRotate : NetworkBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 180f * Time.deltaTime);
    }
}
