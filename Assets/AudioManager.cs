using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public GameObject[] sources;

    void Start()
    {

        //Get every single audio sources in the scene.
        //sources = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        //print(sources[1].name);
    }

    void Update()
    {

       //print( sources[0].GetComponent<Character>().activeChild.name);
       // sources[0].transform.GetChild(int.Parse(sources[0].GetComponent<Character>().activeChild.name)).gameObject.GetComponent<AudioSource>().Play();
       
    }


}
