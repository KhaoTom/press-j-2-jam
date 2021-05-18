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
            PlayerPrefs.SetString("GameState", System.Enum.GetName(typeof(States), state));
        }
        else if (happiness <= AnnihilationThreshold)
        {
            state = States.Annihilated;
            PlayerPrefs.SetString("GameState", System.Enum.GetName(typeof(States), state));
        }
    }

    #region Unity Messages

    private void OnEnable()
    {
        var storedState = PlayerPrefs.GetString("GameState", "Jamming");
        try
        {
            state = (States)System.Enum.Parse(typeof(States), storedState);
        }
        catch (System.ArgumentException)
        {
            state = States.Jamming;
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetString("GameState", System.Enum.GetName(typeof(States), state));
    }

    #endregion
}
