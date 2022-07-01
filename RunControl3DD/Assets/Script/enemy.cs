using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public GameObject attack_target;
    NavMeshAgent _NavMesh;
    Animator enemyAnim;
    bool isAttacking;
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _NavMesh = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        
    }
    public void triggerAnimation()
    {
        enemyAnim.SetBool("attack",true);
        isAttacking =true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(isAttacking)
            _NavMesh.SetDestination(attack_target.transform.position);
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("altchar"))
        {
            Vector3 newPos= new Vector3(transform.position.x,0.24f,transform.position.z);
            _gameManager.CreateDestroyEffect(newPos,false,true);
            
            gameObject.SetActive(false);

        }
    }
    
}
