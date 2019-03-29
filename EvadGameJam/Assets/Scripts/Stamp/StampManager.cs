using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampManager : MonoBehaviour
{
    public GameObject envelope;

    private bool keepCreating = true;
    private int layer = 10;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(keepCreating)
        {
            Vector2 spawnPos = Random.insideUnitCircle * 4;

            GameObject new_envelope = Instantiate(envelope, spawnPos + new Vector2(0f, 10f), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            new_envelope.GetComponent<Envelope>().start = true;
            new_envelope.GetComponent<Envelope>().target = spawnPos;
            new_envelope.GetComponent<SpriteRenderer>().sortingOrder = layer;
            layer+= 2;
            var rand = Random.Range(1f, 3f);
            yield return new WaitForSeconds(rand);

        }

    }
}
