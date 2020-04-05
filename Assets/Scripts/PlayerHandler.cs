using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public GameObject tank01, tankBarrel01, tankShellPoint01,
        tank02, tankBarrel02, tankShellPoint02;
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
        tankShellPoint01 = GameObject.Find("ShellPoint01");

        tank02 = GameObject.Find("Tank02");
        tankBarrel02 = GameObject.Find("BarrelPivot02");
        tankShellPoint02 = GameObject.Find("ShellPoint02");

        moveSpeed = 5.0f;

        currentPlayer = true;

        turnTimer = GameObject.Find("ScreenOverlay");
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space))
            HandleShooting();
    }

    void HandleShooting()
    {
        float vol = Random.Range(5, 10);
        GameObject activeShell;

        if (currentPlayer)
            activeShell = Instantiate(tankShell, tankShellPoint01.transform.position, tankBarrel01.transform.rotation);
        else
            activeShell = Instantiate(tankShell, tankShellPoint02.transform.position, tankBarrel02.transform.rotation);

        Rigidbody shellRB = activeShell.GetComponent<Rigidbody>();

        shellRB.AddRelativeForce(new Vector3(0, 500, 0));

        // should probably have a grace period for shots to land
        turnTimer.GetComponent<Timer>().turnTime = -1;
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
