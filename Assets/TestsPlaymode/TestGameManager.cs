using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestGameManager
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [Test]
    public void TestHappinessIncreases()
    {
        
        var start_happiness = GameManager.Happiness;
        GameManager.AddHappiness();
        var end_happiness = GameManager.Happiness;
        Assert.Greater(start_happiness, end_happiness);
    }
}
