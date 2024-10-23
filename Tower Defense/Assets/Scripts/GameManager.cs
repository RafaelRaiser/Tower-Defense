using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    public static GameManager instance;
    public Transform[] path;
    public Transform startPoint;

    #region Singleton
    private void Awake()
    {
        instance = this;
    }
    #endregion

}
