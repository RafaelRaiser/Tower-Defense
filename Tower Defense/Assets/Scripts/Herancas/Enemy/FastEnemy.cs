using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    void Start()
    {
        velocidade = 4f;
        vida = 50;
        recompensaOuro = 8;
    }
}