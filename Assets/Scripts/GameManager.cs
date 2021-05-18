using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public enum States { Jamming, Ascended, Annihilated }

    public int AscensionThreshold = 1;
    public int AnnihilationThreshold = -1;

    private States state = States.Jamming;
    public States State { get => state; }

    private int happiness = 0;
    public int Happiness { get => happiness; }

    public void OnJPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            IncreaseHappiness();
    }

    public void IncreaseHappiness()
    {
        happiness += 1;
        ProcessHappiness();
    }

    public void DecreaseHappiness()
    {
        happiness -= 1;
        ProcessHappiness();
    }

    public void ResetGame()
    {
        happiness = 0;
    }

    private void ProcessHappiness()
    {
        if (happiness >= AscensionThreshold)
        {
            state = States.Ascended;
        }
        else if (happiness <= AnnihilationThreshold)
        {
            state = States.Annihilated;
        }
    }
}
