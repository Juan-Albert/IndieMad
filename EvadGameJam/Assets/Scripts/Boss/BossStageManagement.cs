using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageManagement : MonoBehaviour
{

    public List<bool> Stages;

    // Update is called once per frame
    void Update()
    {
        if (Stages[0] == true) 
        {
            //Si la stage 0 está activa, quizas aquí podriamos poner una PRE-BATALLA
        }
        else if (Stages[1] == true)
        {
            
        }
    }
}
