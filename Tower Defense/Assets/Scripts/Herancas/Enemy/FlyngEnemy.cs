using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    void Start()
    {
        velocidade = 3f;
        vida = 80;
        recompensaOuro = 12;
    }

    void Mover()
    {
        // O inimigo voador pode ter um movimento diferenciado (se necessário)
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);
    }
}