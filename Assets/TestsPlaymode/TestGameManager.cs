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
        PlayerPrefs.DeleteAll();
        var go = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
        gm = go.GetComponent<GameManager>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(gm.gameObject);
        PlayerPrefs.DeleteAll();
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

    [Test]
    public void TestAscend()
    {
        Assert.AreEqual(GameManager.States.Jamming, gm.State);
        gm.AscensionThreshold = 3;
        gm.IncreaseHappiness();
        gm.IncreaseHappiness();
        Assert.AreEqual(GameManager.States.Jamming, gm.State);
        gm.IncreaseHappiness();
        Assert.AreEqual(GameManager.States.Ascended, gm.State);
        Assert.AreEqual("Ascended", PlayerPrefs.GetString("GameState", "default"));
    }

    [Test]
    public void TestAnnihilate()
    {
        Assert.AreEqual(GameManager.States.Jamming, gm.State);
        gm.AnnihilationThreshold = -2;
        gm.DecreaseHappiness();
        Assert.AreEqual(GameManager.States.Jamming, gm.State);
        gm.DecreaseHappiness();
        Assert.AreEqual(GameManager.States.Annihilated, gm.State);
        Assert.AreEqual("Annihilated", PlayerPrefs.GetString("GameState", "default"));
    }

    [UnityTest]
    public IEnumerator TestEnableDisableLoadAnnihilatedState()
    {
        gm.DecreaseHappiness();
        Object.Destroy(gm);
        gm = null;
        yield return null;
        var go = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
        gm = go.GetComponent<GameManager>();
        Assert.AreEqual(GameManager.States.Annihilated, gm.State);
    }

    [UnityTest]
    public IEnumerator TestEnableDisableLoadAscendedState()
    {
        gm.IncreaseHappiness();
        Object.Destroy(gm);
        gm = null;
        yield return null;
        var go = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
        gm = go.GetComponent<GameManager>();
        Assert.AreEqual(GameManager.States.Ascended, gm.State);
    }

    [UnityTest]
    public IEnumerator TestEnableDisableLoadBadState()
    {
        Object.Destroy(gm);
        gm = null;
        PlayerPrefs.SetString("GameState", "fooey");
        yield return null;
        var go = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
        gm = go.GetComponent<GameManager>();
        Assert.AreEqual(GameManager.States.Jamming, gm.State);
    }
}
