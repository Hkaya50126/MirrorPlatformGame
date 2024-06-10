using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CoinScript : NetworkBehaviour
{
    private GameManager gameManager;
    public int scoreValue;
    // Start is called before the first frame update
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {  
            gameManager.AddScore(scoreValue);
            Destroy(gameObject);

        }
    }

}
