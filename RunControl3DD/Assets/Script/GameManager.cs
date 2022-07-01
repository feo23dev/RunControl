using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Efe;

public class GameManager : MonoBehaviour
{
    
    public GameObject destinationPoint;
    // Start is called before the first frame update
    public List <GameObject> CharacterPool;
    public List <GameObject> CreationEffects;
    public List <GameObject> DestroyEffects;
    public List <GameObject> SmashEffects;
    public List <GameObject> EnemyPool;
    public int howManyEnemies;
    [SerializeField]
    public static int currentCharNumber=1;
    public GameObject mainChar;
    public bool isgameended;
    bool endRoad;

    
    void Start()
    {
        CreateEnemies();
        
    }
    public void CreateEnemies()
    {
        for(int i=0; i< howManyEnemies; i++)
        {
            EnemyPool[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void vsState()
    {
        if(endRoad)
        {
            if( currentCharNumber == 1 || howManyEnemies ==0 )
        {
            isgameended=true;
            foreach(var item in EnemyPool)
            {
                if(item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("attack", false);
                }            
            }

            foreach(var item in CharacterPool)
            {
                if(item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("attack", false);
                }            
            }

            mainChar.GetComponent<Animator>().SetBool("attack",false);

           if( currentCharNumber < howManyEnemies || currentCharNumber == howManyEnemies)
           {
                Debug.Log("Kaybetin");
           }
           else
           {
                Debug.Log("Kazandin");
           }
        }
        }
        
    }
    public void TriggerEnemies()
    {
        foreach(var item in EnemyPool)
        {
            if(item.activeInHierarchy)
            {
                item.GetComponent<enemy>().triggerAnimation();
            }

        }
        endRoad= true;
        vsState();
    }

    public void CreateCharacter(string calType, int theNumber, Transform pos)
    {
        switch (calType)
        {
            case "Multiply":
                SpecialLibrary.Multiply(theNumber, CharacterPool, pos,CreationEffects);
                break;

            case "Addition":
                SpecialLibrary.Addition(theNumber, CharacterPool, pos,CreationEffects);
                break;

            case "Substract":
                SpecialLibrary.Substract(theNumber, CharacterPool,DestroyEffects);
                break;


            case "Division":
                SpecialLibrary.Division(theNumber, CharacterPool, pos,DestroyEffects);
                break;

        }

    }

    public void CreateDestroyEffect(Vector3 _pos,bool hammer=false,bool state=false)
    {
        foreach(var item in DestroyEffects)
        {
            if(!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = _pos;
                item.GetComponent<ParticleSystem>().Play();
                if(!state)
                    currentCharNumber--;
                else
                    howManyEnemies--;
                break;
            }
        }
        
        if(hammer)
        {
            foreach(var item in SmashEffects)
            {
                if(!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = _pos;
        
                    break;
                }
            }

        }
        if(!isgameended)
            vsState();
    }

}
