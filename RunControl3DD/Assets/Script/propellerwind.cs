using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propellerwind : MonoBehaviour
{
    
    
    // Start is called before the first frame update
   private void OnTriggerStay(Collider other) 
    {
        if(other.CompareTag("altchar"))
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(-2,0,0), ForceMode.Impulse);

        }
    }
}
