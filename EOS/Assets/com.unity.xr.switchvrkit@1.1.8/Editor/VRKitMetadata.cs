using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Switch;

namespace UnityEditorInternal.Switch.VRKitEditorLibrary
{
    using UnityEditor.XR.Management.Metadata;

    internal class VRKitMetadata : IXRPackage
    {
        private class VRKitPackageMetadata : IXRPackageMetadata
        {
            public string packageName => "Switch VRKit XR Plugin";
            public string packageId => "com.unity.xr.switchvrkit";
            public string settingsType => "UnityEngine.Switch.VRKitSettings";
            public List<IXRLoaderMetadata> loaderMetadata => s_LoaderMetadata;

            private readonly static List<IXRLoaderMetadata> s_LoaderMetadata = new List<IXRLoaderMetadata>() { new VRKitLoaderMetadata() };
        }

        private class VRKitLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName => "Switch VR Kit";
            public string loaderType => "UnityEngine.Switch.VRKitLoader";
            public List<BuildTargetGroup> supportedBuildTargets => s_SupportedBuildTargets;

            private readonly static List<BuildTargetGroup> s_SupportedBuildTargets = new List<BuildTargetGroup>()
            {
                BuildTargetGroup.Switch
            };
        }

        private static IXRPackageMetadata s_Metadata = new VRKitPackageMetadata();
        public IXRPackageMetadata metadata => s_Metadata;

        public bool PopulateNewSettingsInstance(ScriptableObject obj)
        {
            var settings = obj as VRKitSettings;
            if (settings != null)
            {
                settings.m_StereoRenderingMode = (int)VRKitSettings.StereoRenderingMode.MultiPass;
                return true;
            }

            return false;
        }
    }
}
