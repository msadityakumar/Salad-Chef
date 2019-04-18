using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] Customers;

    // Start is called before the first frame update
    void Start()
    {
        if(Customers.Length == 0)
            Debug.LogError("No Customers");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
