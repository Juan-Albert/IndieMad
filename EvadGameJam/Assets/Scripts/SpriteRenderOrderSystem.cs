using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRenderOrderSystem : MonoBehaviour
{
    public SpriteRenderer face, head, body, rArm, lArm, rLeg, lLeg;

    private void Update()
    {
        var layer = (int)(transform.position.y * -100);
        face.sortingOrder = layer;
        head.sortingOrder = layer - 1;
        body.sortingOrder = layer - 2;
        rArm.sortingOrder = layer - 4;
        lArm.sortingOrder = layer - 3;
        rLeg.sortingOrder = layer - 4;
        lLeg.sortingOrder = layer - 3;

    }
}
