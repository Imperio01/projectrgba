using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCaneController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            print("Item picked up");
        }
    }

}
