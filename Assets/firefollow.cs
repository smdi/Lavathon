using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firefollow : MonoBehaviour
{
  
    public Transform smasher;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(smasher.position);
        transform.position = smasher.position;
    }
}
