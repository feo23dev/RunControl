using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mansmash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(disableSmashEffect());
    }

    IEnumerator disableSmashEffect()
    {

        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    
}
