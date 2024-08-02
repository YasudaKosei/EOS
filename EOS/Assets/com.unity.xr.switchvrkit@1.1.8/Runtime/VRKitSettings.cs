using System;

using UnityEngine;
using UnityEngine.XR.Management;

namespace UnityEngine.Switch
{
    using TextureLayout = UnityEngine.Switch.VRKit.TextureLayout;

    [System.Serializable]
    [XRConfigurationData("Switch VR Kit", "UnityEngine.Switch.VRKitSettings")]
    public class VRKitSettings : ScriptableObject
    {
        public enum StereoRenderingMode
        {
            /// <summary>
            /// Unity makes two passes across the scene graph, each one entirely indepedent of the other.
            /// Each pass has its own eye matrices and render target. Unity draws everything twice, which includes setting the graphics state for each pass.
            /// This is a slow and simple rendering method which doesn't require any special modification to shaders.
            /// </summary>
            MultiPass = 0,
            /// <summary>
            /// Unity uses a single texture array with two elements. Unity converts each call into an instanced draw call.
            /// Shaders need to be aware of this. Unity's shader macros handle the situation.
            /// </summary>
            SinglePassInstanced = 1,
        }

        /// <summary>
        /// The current stereo rendering mode selected for desktop-based VRKit platforms
        /// </summary>
        [SerializeField, Tooltip("Set the Stereo Rendering Method")]
        public int m_StereoRenderingMode = (int)StereoRenderingMode.MultiPass;

        /// <summary>
        /// Improve legacy rendering issue on left eye side with HDR.
        /// This issue has been resolved. However it's still selectable just in case.
        /// </summary>
        [SerializeField, Tooltip("Improve legacy rendering issue on HDR (Prevent incorrect left eye side rendering)")]
        public bool m_ImproveLegacyRenderingIssueOnHDR;

        /// <summary>
        /// Default TextureLayout
        /// </summary>
        [SerializeField, Tooltip("Default TextureLayout")]
        public int m_DefaultTextureLayout = (int)TextureLayout.SeparateTexture2Ds;

        public StereoRenderingMode GetStereoRenderingMode()
        {
            return (StereoRenderingMode)m_StereoRenderingMode;
        }

        public bool IsImproveLegacyRenderingIssueOnHDR()
        {
            return m_ImproveLegacyRenderingIssueOnHDR;
        }

        public TextureLayout GetDefaultTextureLayout()
        {
            return (TextureLayout)m_DefaultTextureLayout;
        }

        public static VRKitSettings s_Settings;

        public void Awake()
        {
            s_Settings = this;
        }

    }
}
