using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Efe

{
    public class SpecialLibrary : MonoBehaviour
    {


        public static void Multiply(int numbeR, List<GameObject> CharacterPool, Transform pos,List<GameObject> CreationEffects)
        {
            int LoopNumber = (GameManager.currentCharNumber * numbeR) - GameManager.currentCharNumber;
            int number = 0;

            foreach (var item in CharacterPool)
            {
                if (number < LoopNumber)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach(var effects in CreationEffects)
                    {
                        if(!effects.activeInHierarchy)
                        {
                            
                            effects.SetActive(true);
                            effects.transform.position = pos.position;
                            effects.GetComponent<ParticleSystem>().Play();
                            break;
                        }

                    }
                        item.transform.position = pos.position;
                        item.SetActive(true);
                        number++;
                        

                    }
                }
                else
                {
                    number = 0;
                    break;

                }
            }
            GameManager.currentCharNumber *= numbeR;

        }

        public static void Addition(int numbeR, List<GameObject> CharacterPool, Transform pos,List<GameObject> CreationEffects)
        {

            int number = 0;

            foreach (var item in CharacterPool)
            {
                if (number < numbeR)
                {
                    if (!item.activeInHierarchy)
                    {
                           foreach(var effects in CreationEffects)
                    {
                        if(!effects.activeInHierarchy)
                        {
                            
                            effects.SetActive(true);
                            effects.transform.position = pos.position;
                            effects.GetComponent<ParticleSystem>().Play();
                            break;
                        }

                    }
                        item.transform.position = pos.position;
                        item.SetActive(true);
                        number++;

                    }
                }
                else
                {
                    number = 0;
                    break;

                }
            }
            GameManager.currentCharNumber += numbeR;

        }
        public static void Substract(int numbeR, List<GameObject> CharacterPool,List<GameObject> DestroyEffects)
        {
            if (GameManager.currentCharNumber < numbeR)
            {
                foreach (var item in CharacterPool)
                {
                    foreach(var effects in DestroyEffects)
                    {
                        if(!effects.activeInHierarchy)
                        {
                            Vector3 newPos= new Vector3(item.transform.position.x,0.23f,item.transform.position.z);
                            effects.SetActive(true);
                            effects.transform.position = newPos;
                            effects.GetComponent<ParticleSystem>().Play();
                            break;
                        }

                    }

                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }

                GameManager.currentCharNumber = 1;
            }
            else
            {
                int number3 = 0;

                foreach (var item in CharacterPool)
                {
                    if (number3 != numbeR)
                    {
                        if (item.activeInHierarchy)
                        {
                                foreach(var effects in DestroyEffects)
                                {
                                    if(!effects.activeInHierarchy)
                                    {
                                        Vector3 newPos= new Vector3(item.transform.position.x,0.24f,item.transform.position.z);
                                        effects.SetActive(true);
                                        effects.transform.position = newPos;
                                        effects.GetComponent<ParticleSystem>().Play();
                                        break;
                                    }

                                }
                        

                        
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            number3++;

                        }
                    }
                    else
                    {
                        number3 = 0;
                        break;
                    }
                }
                GameManager.currentCharNumber -= numbeR;
            }

        }

        public static void Division(int numbeR, List<GameObject> CharacterPool, Transform pos,List<GameObject> DestroyEffects)
        {
            if (GameManager.currentCharNumber <= numbeR)
            {
                foreach (var item in CharacterPool)
                {
                    foreach(var effects in DestroyEffects)
                                {
                                    if(!effects.activeInHierarchy)
                                    {
                                        Vector3 newPos= new Vector3(item.transform.position.x,0.24f,item.transform.position.z);
                                        effects.SetActive(true);
                                        effects.transform.position = newPos;
                                        effects.GetComponent<ParticleSystem>().Play();
                                        break;
                                    }

                                }
                    item.transform.position = pos.position;
                    item.SetActive(false);
                }
                GameManager.currentCharNumber = 1;

            }
            else
            {
                int divider = GameManager.currentCharNumber / numbeR;
                int number3 = 0;

                foreach (var item in CharacterPool)
                {
                    if (number3 != divider)
                    {
                        if (item.activeInHierarchy)
                        {

                            foreach(var effects in DestroyEffects)
                                {
                                    if(!effects.activeInHierarchy)
                                    {
                                        Vector3 newPos= new Vector3(item.transform.position.x,0.24f,item.transform.position.z);
                                        effects.SetActive(true);
                                        effects.transform.position = newPos;
                                        effects.GetComponent<ParticleSystem>().Play();
                                        break;
                                    }

                                }
                            item.transform.position = pos.position;
                            item.SetActive(false);
                            number3++;

                        }
                    }
                    else
                    {
                        number3 = 0;
                        break;
                    }
                }
                if (GameManager.currentCharNumber % numbeR == 0)
                {
                    GameManager.currentCharNumber /= numbeR;
                }
                else if (GameManager.currentCharNumber % numbeR == 1)
                {
                    GameManager.currentCharNumber /= numbeR;
                    GameManager.currentCharNumber++;
                }

                else if (GameManager.currentCharNumber % numbeR == 2)
                {
                    GameManager.currentCharNumber /= numbeR;
                    GameManager.currentCharNumber += 2;

                }


            }





        }




    }   




}
