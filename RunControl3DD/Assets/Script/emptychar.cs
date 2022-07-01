using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class emptychar : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public SkinnedMeshRenderer _Renderer;
    public Material materialAssign;
    public Animator anim;
    public GameObject target;
    public GameManager _gameManager;
    bool touched;
    // Start is called before the first frame update
    

    private void LateUpdate() 
    {
        if(touched)
        navMesh.SetDestination(target.transform.position);
    }
    Vector3 newPos()
    {
        return new Vector3(transform.position.x,0.24f,transform.position.z);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("altchar") || other.gameObject.CompareTag("Player"))
        {
            if(gameObject.CompareTag("emptychar"))
            {
                matANDanimation();
                touched= true;

            }
            
        }
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
    }
    
    void matANDanimation()
    {
        Material[] mats= _Renderer.materials;
        mats[0]= materialAssign;
        _Renderer.materials = mats;
        anim.SetBool("attack",true);
        gameObject.tag = "altchar";
        GameManager.currentCharNumber ++;
    }

    
}
