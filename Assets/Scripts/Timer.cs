using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public double turnTime;
    public Text timerText;

    GameObject playerController;

    // Start is called before the first frame update
    void Start()
    {
        turnTime = 10.0f;
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        playerController = GameObject.Find("PlayerController");
    }

    // Update is called once per frame
    void Update()
    {
        turnTime -= Time.deltaTime;
        turnTime = Math.Round(turnTime, 2);

        timerText.text = "Time Remaining = " + turnTime;

        if(turnTime <= 0)
        {
            playerController.GetComponent<PlayerHandler>().SwitchPlayers();
            turnTime = 10.0f;
        }
    }
}
