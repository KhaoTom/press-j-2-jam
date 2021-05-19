using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : MonoBehaviour
{
    private bool isJamming = false;
    public bool IsJamming { get => isJamming; }

    private void OnEnable()
    {
        var gm = FindObjectOfType<GameManager>();
        if (gm != null)
            gm.OnJamEvent.AddListener(DoJam);
    }

    private void OnDisable()
    {
        var gm = FindObjectOfType<GameManager>();
        if (gm != null)
            gm.OnJamEvent.RemoveListener(DoJam);
    }

    private void DoJam()
    {
        isJamming = true;
    }


}
