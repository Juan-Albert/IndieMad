using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope : MonoBehaviour
{
    public float speed;
    public Vector2 target;
    public bool start = false;

    private void Update()
    {
        if(start)
        {
            if(transform.position.y > target.y)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
            }
        }
    }

}
