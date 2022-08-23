using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj =  ABManager.GetInstance().LoadRes<GameObject>("model","Cube");       
        Instantiate(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
