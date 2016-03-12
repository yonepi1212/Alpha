using UnityEngine;
using System.Collections;

[System.Serializable]
public class StatusManager
{
    public int score;
    public int hp;

    public StatusManager()
    {
        score = 0;
        hp = 5;
    }
}
