using UnityEngine;
using System.Runtime.InteropServices;

namespace UnityEngine.Switch
{
    /// <summary>
    /// Low level controls for VR Kit
    /// </summary>
    public static class VRKitInternal
    {
        static bool _enabledGraphicsBlitOnVR;

        /// <summary>
        /// Is enabled Graphics.Blit() on VR
        /// </summary>
        public static bool IsEnabledGraphicsBlitOnVR()
        {
            return _enabledGraphicsBlitOnVR;
        }

        /// <summary>
        /// Enable Graphics.Blit() on VR
        /// </summary>
        public static void EnableGraphicsBlitOnVR()
        {
            if (!_enabledGraphicsBlitOnVR)
            {
                _enabledGraphicsBlitOnVR = true;
                Shader.EnableKeyword("UNITY_SWITCH_VRKIT_AVOID_VP");
            }
        }

        /// <summary>
        /// Disable Graphics.Blit() on VR
        /// </summary>
        public static void DisableGraphicsBlitOnVR()
        {
            if (_enabledGraphicsBlitOnVR)
            {
                _enabledGraphicsBlitOnVR = false;
                Shader.DisableKeyword("UNITY_SWITCH_VRKIT_AVOID_VP");
            }
        }
    }
}
