using UnityEditor;
using UnityEditor.XR.Management;

namespace UnityEditorInternal.Switch.VRKitEditorLibrary
{
    internal class VRKitBuildProcessor : XRBuildHelper<UnityEngine.Switch.VRKitSettings>
    {
        public override string BuildSettingsKey { get { return "UnityEngine.Switch.VRKitSettings"; } }

        public override UnityEngine.Object SettingsForBuildTargetGroup(BuildTargetGroup buildTargetGroup)
        {
            EditorBuildSettings.TryGetConfigObject<UnityEngine.Switch.VRKitSettings>(BuildSettingsKey, out var buildSettings);

            if (buildSettings == null)
                return null;

            return buildSettings;
        }
    }
}
