using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Briefcase : MonoBehaviour
{

    public int totalMoney, bluePoints, redPoints;


    private void Update()
    {
        if (totalMoney == 0)
        {
            if (bluePoints > redPoints) //Si el equipo azul tiene mas puntos que el equipo rojo
            {
                //El equipo azul no pierde vidas
                //El equipo rojo pierde vidas
            }
            else //Al contrario
            {
                //El equipo rojo no pierde vidas
                //El equipo azul pierde vidas
            }
        }
    }


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<Absorption>().hasMoney)
            {

                if (other.gameObject.GetComponent<PlayerMovement>().playerInfo.team == Team.Blue) //Si el jugador es del equipo azul
                    bluePoints++;
                else //Al contrario
                {
                    redPoints++;
                }
                
                
                totalMoney--;
                other.gameObject.GetComponent<Absorption>().hasMoney = false;
                
                //Aqui habria que poner de alguna forma que el equipo X se ha llevado 1 punto
            }

        }
    }
}
