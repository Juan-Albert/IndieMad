using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class RandomPositionGenerator : MonoBehaviour
{

    public GameObject item;
    public GameObject generationPoint;

    public int times;
    
    public bool timer;
    public float timeBetweenSpawns;
    private float timeLeft;
    private void Start()
    {
        timeLeft = timeBetweenSpawns;
        
        if (!timer)
        {
            for (int i = 0; i < times; i++)
            {
                GenerateItem();   
            }

        }
    }

    private void Update()
    {
        if (timer && times != 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                GenerateItem();
                times--;
                timeLeft = timeBetweenSpawns;
            }
        }
    }

    void GenerateItem()
    {
        //generationPoint.transform.position = new Vector2(Random.Range(-8.80f, 8.80f), Random.Range(-5f, 2f));
        GameObject itemInvoked = Instantiate(item);
        itemInvoked.transform.position = new Vector2(Random.Range(-8.80f, 8.80f), Random.Range(-5f, 2f));
    }
    
    
    
    
}
