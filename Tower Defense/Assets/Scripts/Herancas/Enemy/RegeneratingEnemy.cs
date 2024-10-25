using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RegeneratingEnemy : Enemy
{
    public int regeneracaoPorSegundo = 5;

    void Start()
    {
        velocidade = 2f;
        vida = 120;
        InvokeRepeating("RegenerarVida", 1f, 1f);
    }

    void RegenerarVida()
    {
        vida += regeneracaoPorSegundo;
        if (vida > 120) vida = 120;
    }
}