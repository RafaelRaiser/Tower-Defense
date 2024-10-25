using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreFogo : TorrePadrao
{
    public override void Atirar()
    {
        // Modifica o comportamento de disparo para a torre de fogo
        base.Atirar(); // Usa o mesmo comportamento de disparo
    }

    public override void FazerUpgrade()
    {
        dano += 10; 
        tempoEntreDisparos -= 0.3f; // Menos tempo entre disparos
    }
}
