using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTrack : MonoBehaviour
{
    public int health = 5;
    public Slider healthBar;
    public AudioClip hitAudio;
    public AudioSource source;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        winText = GameObject.Find("WinText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(this.gameObject);
            Destroy(healthBar);
        }
    }

    void playHitSound()
    {
        source.PlayOneShot(hitAudio);
    }

    public void DecreaseHealth()
    {
        health -= 1;
        healthBar.value -= 1;

        playHitSound();
    }
}
