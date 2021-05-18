using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int happiness;

    public static int Happiness { get => happiness; }

    public static void IncreaseHappiness()
    {
        happiness += 1;
    }

    public static void DecreaseHappiness()
    {
        happiness -= 1;
    }

    public static void ResetGame()
    {
        happiness = 0;
    }
}
