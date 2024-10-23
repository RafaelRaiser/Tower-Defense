using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 2f;

    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // Move o inimigo em direção ao próximo waypoint
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Verifica se o inimigo chegou ao waypoint
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // O inimigo chegou ao final do caminho
            Destroy(gameObject);
        }

    }
}