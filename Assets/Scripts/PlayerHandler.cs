using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameObject tank01, tankBarrel01,
        tank02, tankBarrel02;
    public float moveSpeed;

    public GameObject tankShell;
    private GameObject turnTimer;
    private bool currentPlayer; // true = player1, false = player 2
    private Vector3 direction, rotation;

    // Start is called before the first frame update
    void Start()
    {
        tank01 = GameObject.Find("Tank01");
        tankBarrel01 = GameObject.Find("BarrelPivot01");

        tank02 = GameObject.Find("Tank02");
        tankBarrel02 = GameObject.Find("BarrelPivot02");
        moveSpeed = 5.0f;

        currentPlayer = true;

        turnTimer = GameObject.Find("ScreenOverlay");
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleShooting()
    {
        // should probably have a grace period for shots to land
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Instantiate(tankShell);

            turnTimer.GetComponent<Timer>().turnTime = -1;
        }
    }
    
    void HandleMovement()
    {
        direction = new Vector3(0, 0, 0);

        // I have little idea why Z moves it properly, but it does (should be X)
        //      might've messed up exporting
        if (Input.GetKey(KeyCode.D))
        {
            direction.z = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction.z = -moveSpeed;
        }

        rotation = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            rotation.x = -40;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rotation.x = 40;
        }

        // should implement something to prevent barrel from going underground
        switch (currentPlayer)
        {
            case true: // player 1
                tank01.transform.Translate(new Vector3(direction.x, direction.y, direction.z) * Time.deltaTime);
                tankBarrel01.transform.Rotate(new Vector3(rotation.x, rotation.y, rotation.z) * Time.deltaTime);
                break;
            case false: // player 2
                tank02.transform.Translate(new Vector3(direction.x, direction.y, direction.z) * Time.deltaTime);
                tankBarrel02.transform.Rotate(new Vector3(rotation.x, rotation.y, rotation.z) * Time.deltaTime);
                break;
        }
    }

    public void SwitchPlayers()
    {
        currentPlayer = !currentPlayer;
    }
}
