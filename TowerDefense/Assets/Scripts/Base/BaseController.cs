using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseController : HealthObject
{
    public delegate void GameOver();
    public static GameOver OnGameOver;

    protected override void OnDeath()
    {
        OnGameOver?.Invoke();
    }
}
