using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tank01" || other.gameObject.name == "Tank02") { 
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        // destroy self if colliding with ground
        else
        {
            Destroy(this.gameObject);
        }
    }
}
