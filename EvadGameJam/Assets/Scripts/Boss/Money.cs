using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!other.gameObject.GetComponent<Absorption>().hasMoney)
            {
                other.gameObject.GetComponent<Absorption>().hasMoney = true;
                Destroy(this.gameObject);
            }

        }
    }
}
