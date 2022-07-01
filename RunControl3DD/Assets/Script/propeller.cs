using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propeller : MonoBehaviour
{
    public Animator anim;
    public float animCooldown;
    BoxCollider _wind;
    // Start is called before the first frame update
    void Start()
    {
        _wind =GameObject.FindGameObjectWithTag("windarea").GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationStatus(string status)
    {
        if( status  == "true")
        {
             anim.SetBool("start", true);
            _wind.enabled = true;
        }
           
        else
        {
            anim.SetBool("start", false);
            StartCoroutine(AnimationTrigger());
             _wind.enabled = false;

        }
           
 
    }

    IEnumerator AnimationTrigger()
    {
        yield return new WaitForSeconds(animCooldown);
        AnimationStatus("true");



    }












}
