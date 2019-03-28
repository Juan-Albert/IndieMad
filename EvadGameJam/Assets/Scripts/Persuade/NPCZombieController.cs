using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCZombieController : MonoBehaviour
{

    public float forwardSpeed = 1f, lateralSpeed = 1f;
    public float redCarpet, blueCarpet;
    public SpriteRenderer letter, body;

    public bool moveToRed = false;

    void Update()
    {
        var layer = (int)(transform.position.y * -100);
        body.sortingOrder = layer;
        letter.sortingOrder = layer - 1;

        transform.Translate(Vector3.left* forwardSpeed * Time.deltaTime);

        Debug.Log("Distancia roja: " + Mathf.Abs(transform.position.y - redCarpet));
        Debug.Log("Distancia azul: " + Mathf.Abs(transform.position.y - blueCarpet));

        if(moveToRed)
        {
            if(Mathf.Abs(transform.position.y - redCarpet) > 0.1f)
            {
                transform.Translate(Vector3.up * lateralSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.y - blueCarpet) > 0.1f)
            {
                transform.Translate(Vector3.down * lateralSpeed * Time.deltaTime);
            }
        }

    }
}
