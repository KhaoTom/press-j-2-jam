using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int happiness;

    public int Happiness { get => happiness; }

    public void IncreaseHappiness()
    {
        happiness += 1;
    }

    public void DecreaseHappiness()
    {
        happiness -= 1;
    }

    public void ResetGame()
    {
        happiness = 0;
    }
}
