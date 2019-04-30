using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BH : MonoBehaviour
{
    public int radius;
    
    public bool inside;

    private CircleCollider2D c2D;

    public GameObject[] players;
    
    
    private void Start()
    {
        c2D = GetComponent<CircleCollider2D>();
        c2D.radius = radius;
        players = GameObject.FindGameObjectsWithTag("Player");

    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        //Ha entrado en el area del agujero negro
        inside = true;


        foreach (var player in players)
        {
            if (player.name == other.name)
            {
                print("Entra: " + player.name); //Compruebo quien entra
                other.gameObject.GetComponent<Absorption>().isBeenAbsorbed = true;
                other.gameObject.GetComponent<Absorption>().focus = gameObject;
            }

        }    
        
        
        //other.gameObject.transform.LookAt(this.transform); //Mira hacia el centro del agujero negro

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Ha salido del area del agujero negro
        inside = false;
        foreach (var player in players)
        {
            if (player.name == other.name)
            {
                print("Sale: " + player.name); //Compruebo quien sale
                other.gameObject.GetComponent<Absorption>().isBeenAbsorbed = false;
                other.gameObject.GetComponent<Absorption>().focus = gameObject;
            }

        }  

    }*/
    private void OnTriggerStay2D(Collider2D other)
    {
        //Ha entrado en el area del agujero negro
        inside = true;


        foreach (var player in players)
        {
            if (player.name == other.name)
            {
                print("Entra: " + player.name); //Compruebo quien entra
                other.gameObject.GetComponent<Absorption>().isBeenAbsorbed = true;
                other.gameObject.GetComponent<Absorption>().focus = gameObject;
            }

        }    
        
        
        //other.gameObject.transform.LookAt(this.transform); //Mira hacia el centro del agujero negro

        
    }
    
    
}
