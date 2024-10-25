using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : Enemy
{
    public float raioExplosao = 2f;

    void Start()
    {
        velocidade = 2f;
        vida = 100;
        recompensaOuro = 10;
    }

    void Morrer()
    {
        base.Die();
        // Explode ao morrer e destrói torres ao redor
        Collider2D[] torres = Physics2D.OverlapCircleAll(transform.position, raioExplosao);
        foreach (var torre in torres)
        {
            if (torre.CompareTag("Tower"))
            {
                Destroy(torre.gameObject); // Destrói as torres na área da explosão
            }
        }
    }
}