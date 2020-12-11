using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using OpenKnife.Utils;

namespace OpenKnife.Utils.Tests
{
    public class PhysicsUtilsTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestRangeForce()
        {
            // Use the Assert class to test conditions
            Assert.Less(Mathf.Abs(PhysicsUtils.GetRandomForce(16f,32f).x),32f);
            Assert.GreaterOrEqual(Mathf.Abs(PhysicsUtils.GetRandomForce(16f,32f).x),16f);
        }

    }
}
