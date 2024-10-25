using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : Enemy
{
    void Start()
    {
        velocidade = 1f;
        vida = 200;
        recompensaOuro = 15;
    }
}