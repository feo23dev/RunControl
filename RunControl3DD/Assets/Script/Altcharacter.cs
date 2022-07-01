using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Altcharacter : MonoBehaviour
{
    GameObject target;
    NavMeshAgent navMesh;
    public GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        target = _gameManager.destinationPoint;
        
    }

    // Update is called once per frame
    private void LateUpdate() 
    {
        navMesh.SetDestination(target.transform.position);
    }
    Vector3 newPos()
    {
        return new Vector3(transform.position.x,0.24f,transform.position.z);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("ignelikutu"))
        {
            _gameManager.CreateDestroyEffect(newPos());
            gameObject.SetActive(false);
        
        }
        if(other.CompareTag("Saw"))
        {
            _gameManager.CreateDestroyEffect(newPos());
            gameObject.SetActive(false);
        
        }

        if(other.CompareTag("proneedle"))
        { 
            _gameManager.CreateDestroyEffect(newPos());
            gameObject.SetActive(false);

        }
        if(other.CompareTag("Hammer"))
        {
            _gameManager.CreateDestroyEffect(newPos(),true);
            gameObject.SetActive(false);

        }
        if(other.CompareTag("Enemy"))
        {
            _gameManager.CreateDestroyEffect(newPos(),false,false);
            gameObject.SetActive(false);

        }
        if(other.CompareTag("emptychar"))
        {
            _gameManager.CharacterPool.Add(other.gameObject);
           
        }
    }
            
        
    
}
