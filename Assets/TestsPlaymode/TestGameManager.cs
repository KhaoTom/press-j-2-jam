using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestGameManager
{
    [Test]
    public void TestHappinessIncreases()
    {
        
        var start_happiness = GameManager.Happiness;
        GameManager.IncreaseHappiness();
        var end_happiness = GameManager.Happiness;
        Assert.Greater(end_happiness, start_happiness);
    }

    [Test]
    public void TestHappinessDecreases()
    {

        var start_happiness = GameManager.Happiness;
        GameManager.DecreaseHappiness();
        var end_happiness = GameManager.Happiness;
        Assert.Less(end_happiness, start_happiness);
    }

    [Test]
    public void TestResetGame()
    {
        GameManager.IncreaseHappiness();
        GameManager.ResetGame();
        Assert.Zero(GameManager.Happiness);
    }
}
