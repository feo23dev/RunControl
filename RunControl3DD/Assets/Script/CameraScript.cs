using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offet;
    public bool theEnd;
    public GameObject camEndPos;
    // Start is called before the first frame update
    void Start()
    {
        target_offet = transform.position - target.position;
        
    }

    // Update is called once per frame
    private void LateUpdate() 
    {
        if(!theEnd)
            transform.position = Vector3.Lerp(transform.position,target.position+target_offet,.125f);
        else
            transform.position = Vector3.Lerp(transform.position,camEndPos.transform.position,.015f);

    }
}
