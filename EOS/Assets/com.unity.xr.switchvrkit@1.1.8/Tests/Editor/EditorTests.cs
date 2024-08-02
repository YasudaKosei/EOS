using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System;

namespace UnityEditor.XR.Switch.VRKit
{
    public class VRKitPluginTests
    {
        [Test]
        public void CheckPluginsImported()
        {
            bool pluginFound = false;

            var assetPaths = AssetDatabase.GetAllAssetPaths();
            foreach (var assetPath in assetPaths)
            {
                if (assetPath.Contains("VRKitLoader"))
                {
                    pluginFound = true;
                    break;
                }
            }

            Assert.IsTrue(pluginFound, "Plugins failed to import.");
        }
    }
}
