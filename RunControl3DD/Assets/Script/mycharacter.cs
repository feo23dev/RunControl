using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mycharacter : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Camera;
    public bool theEnd;
    public Transform standPoint;
    // Start is called before the first frame update
    private void FixedUpdate() 
    {
        if(!theEnd)
            transform.Translate(Vector3.forward * 1f * Time.deltaTime);
        
    }

    
    // Update is called once per frame
    void Update()
    
    {
        if(theEnd)
        {
            transform.position = Vector3.Lerp(transform.position,standPoint.position,0.015f);

        }
        else
        {
            if(Input.GetKey(KeyCode.Mouse0))
        {
            if(Input.GetAxis("Mouse X") < 0)
            {
                transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x -.1f, transform.position.y,transform.position.z),.155f);

            }

             if(Input.GetAxis("Mouse X") > 0)
            {
                transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x + .1f, transform.position.y,transform.position.z),.155f);

            }
        }


        }
        
        
    }
    

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Division") || other.CompareTag("Addition") || other.CompareTag("Multiply")|| other.CompareTag("Substract") )
        {
            int num =int.Parse(other.name);
            gameManager.CreateCharacter(other.tag,num,other.transform);

        }

        if(other.CompareTag("lasttrigger"))
        {
            Camera.GetComponent<CameraScript>().theEnd = true;
            gameManager.TriggerEnemies();
            theEnd=true;
            
        
        }
        if(other.CompareTag("emptychar"))
        {
            gameManager.CharacterPool.Add(other.gameObject);
            

        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.CompareTag("direk") || other.gameObject.CompareTag("ignelikutu") || other.gameObject.CompareTag("pervaneigne"))
        {
            if(transform.position.x > 0)
                transform.position = new Vector3(transform.position.x - .2f,transform.position.y,transform.position.z);
            if(transform.position.x < 0)
                transform.position = new Vector3(transform.position.x + .2f,transform.position.y,transform.position.z);
        }
        
    }
}

