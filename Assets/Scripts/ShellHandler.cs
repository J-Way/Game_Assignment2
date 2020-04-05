using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellHandler : MonoBehaviour
{
    public AudioClip[] explosions;
    public AudioClip shootSound;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();

        shootSound = explosions[Random.Range(0, explosions.Length - 1)];

        source.PlayOneShot(shootSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tank01" || other.gameObject.name == "Tank02") { 
            Destroy(this.gameObject);
            other.gameObject.GetComponent<HealthTrack>().DecreaseHealth();
        }
        // destroy self if colliding with ground
        else if(other.gameObject.tag !="Wall")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
