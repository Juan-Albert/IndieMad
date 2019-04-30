using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Absorption : MonoBehaviour
{

    public GameObject focus;
    private Rigidbody2D rb2D;
    public float speed;
    public bool isBeenAbsorbed;
    public int moneyCounter;

    public bool hasMoney;
    
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
        if (isBeenAbsorbed)
        {
            //Hacemos check de la dirección hasta el centro del vórtice
            var heading = focus.transform.position - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            
            //Velocidad a la que vamos a ser desplazados
            float step = (speed * Time.deltaTime);
            
            //Fuerza que nos desplaza
            if(distance <= focus.GetComponent<BH>().radius)
                rb2D.AddForce (direction * step);

            if (distance <= 1)
            {
                //Aqui mandamos al PlayerController de Juanse que se ha muerto y que reinicie
                print("Muerto");
            }

            
            
            Debug.DrawLine(focus.transform.position, transform.position, Color.green);
        }
    }
}
