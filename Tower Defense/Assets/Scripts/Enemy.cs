using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float speed;  // Velocidade do inimigo
    public int health;   // Vida do inimigo

    public Transform[] waypoints;  // Pontos de curva no caminho
    private int waypointIndex = 0;

    void Update()
    {
        Move();
    }

    // Movimenta o inimigo ao longo dos waypoints
    void Move()
    {
        if (waypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

            // Se o inimigo chegou ao waypoint, avança para o próximo
            if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.2f)
            {
                waypointIndex++;
            }
        }
        else
        {
            // O inimigo chegou ao final do caminho
            Destroy(gameObject);
        }
    }

    // Recebe dano
    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Código para o inimigo morrer (animação, som, etc.)
        Destroy(gameObject);
    }
}