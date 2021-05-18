using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestGameManager
{
    private GameManager gm;

    [SetUp]
    public void Setup()
    {
        var go = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
        gm = go.GetComponent<GameManager>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(gm.gameObject);
    }

    [Test]
    public void TestHappinessIncreases()
    {
        var start_happiness = gm.Happiness;
        gm.IncreaseHappiness();
        var end_happiness = gm.Happiness;
        Assert.Greater(end_happiness, start_happiness);
    }

    [Test]
    public void TestHappinessDecreases()
    {
        var start_happiness = gm.Happiness;
        gm.DecreaseHappiness();
        var end_happiness = gm.Happiness;
        Assert.Less(end_happiness, start_happiness);
    }

    [Test]
    public void TestResetGame()
    {
        gm.IncreaseHappiness();
        gm.ResetGame();
        Assert.Zero(gm.Happiness);
    }
}
