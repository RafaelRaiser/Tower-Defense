using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float alcance = 5f;
    public float taxaDeAtaque = 1f;
    public GameObject projetilPrefab;
    private float tempoParaProximoAtaque = 0f;

    void Update()
    {
        if (Time.time >= tempoParaProximoAtaque)
        {
            Enemy alvo = EncontrarInimigo();
            if (alvo != null)
            {
                Disparar(alvo);
                tempoParaProximoAtaque = Time.time + 1f / taxaDeAtaque;
            }
        }
    }
    private Enemy EncontrarInimigo()
    {
        Collider2D[] inimigos = Physics2D.OverlapCircleAll(transform.position, alcance);
        Enemy alvo = null;
        foreach (var col in inimigos)
        {
            if (col.CompareTag("Enemy"))
            {
                alvo = col.GetComponent<Enemy>();
                break;
            }
        }
        return alvo;
    }
    private void Disparar(Enemy inimigo)
    {
        GameObject projetilGO = (GameObject)Instantiate(projetilPrefab, transform.position, transform.rotation);
        Projectile projetil = projetilGO.GetComponent<Projectile>();
        if (projetil != null)
        {
            projetil.DefinirAlvo(inimigo.transform);
        }
    }

}