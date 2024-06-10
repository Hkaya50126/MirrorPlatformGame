using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerControl : NetworkBehaviour
{
    private Rigidbody rb;
    public float pushPow = 500f;
    private float movement;
    private float movement2;
    private float speed = 5f;
    public Vector3 spawnPoint;
    private GameManager gameManager;
    private CameraController cameraController;
    private Renderer playerRenderer;

    //[SyncVar] private Vector3 syncPosition;

    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        rb=GetComponent<Rigidbody>();
        spawnPoint=this.transform.position;
        gameManager = FindObjectOfType<GameManager>();
        cameraController = FindObjectOfType<CameraController>();
        playerRenderer = GetComponent<Renderer>();

        Color randomColor = new Color(Random.value, Random.value, Random.value);

        playerRenderer.material.color=randomColor;

    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        movement = Input.GetAxis("Horizontal");
        movement2 = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        /*rb.AddForce(0, 0, pushPow * Time.fixedDeltaTime,ForceMode.Force);
        rb.velocity = new Vector3(movement * speed, rb.velocity.y, rb.velocity.z);*/

        //rb.AddForce(0, 0, pushPow * Time.fixedDeltaTime,ForceMode.Force);

        PositionChange();

        FallDetector();
    }
    private void PositionChange()
    {
        Vector3 v3 = new Vector3(movement, 0.0f, movement2);

        transform.Translate(v3 * speed * Time.deltaTime, Space.World);
        cameraController.cameraPositionChanged(transform);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Barier"))
        {
            Debug.Log("Bariyere deðdi");
            gameManager.respawnPlayer();
            TurnSpawnPointCommand();
        }
        else if (collision.collider.CompareTag("EndTrigger"))
        {
            
            gameManager.LevelUp();
        }
    }
    private void FallDetector()
    {
        if (rb.transform.position.y<=-4f)
        {
            //gameManager.respawnPlayer();
            TurnSpawnPointCommand();
        }
    }
    [Command]
    private void TurnSpawnPointCommand()
    {
        SendServer();
    }

    [Server]
    private void SendServer()
    {
        ChangePositionClientRpc();
    }

    [ClientRpc]
    private void ChangePositionClientRpc()
    {  
        transform.position = spawnPoint;
    }


}
