using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;
using UnityEngine.XR;
#if UNITY_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using Unity.XR.SwitchVRKit.Input;
#endif

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.Switch
{
#if UNITY_INPUT_SYSTEM
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    static class InputLayoutLoader
    {
        static InputLayoutLoader()
        {
            RegisterInputLayouts();
        }

        public static void RegisterInputLayouts()
        {
            UnityEngine.InputSystem.InputSystem.RegisterLayout<SwitchVRKitHMD>(
                matches: new InputDeviceMatcher()
                    .WithInterface(XRUtilities.InterfaceMatchAnyVersion)
                    .WithProduct("^(Switch VR Kit)"));
        }
    }
#endif

    /// <summary>
    /// VR Kit Loader for XR subsystems
    /// </summary>
    public class VRKitLoader : XRLoaderHelper
#if UNITY_EDITOR
    //, IXRLoaderPreInit
#endif
    {
        private static List<XRDisplaySubsystemDescriptor> s_DisplaySubsystemDescriptors = new List<XRDisplaySubsystemDescriptor>();
        private static List<XRInputSubsystemDescriptor> s_InputSubsystemDescriptors = new List<XRInputSubsystemDescriptor>();
        private static string s_DisplayName = "Switch VR Kit Display";
        private static string s_InputName = "Switch VR Kit Input";

        /// <summary>
        /// Get XRDisplaySubsystem
        /// </summary>
        public XRDisplaySubsystem displaySubsystem
        {
            get
            {
                return GetLoadedSubsystem<XRDisplaySubsystem>();
            }
        }

        /// <summary>
        /// Get XRInputSubsystem
        /// </summary>
        public XRInputSubsystem inputSubsystem
        {
            get
            {
                return GetLoadedSubsystem<XRInputSubsystem>();
            }
        }

        /// <summary>
        /// Initialize display / input systems
        /// </summary>
        /// <returns>Return true if it is successful.</returns>
        public override bool Initialize()
        {
#if UNITY_INPUT_SYSTEM
            InputLayoutLoader.RegisterInputLayouts();
#endif

            CreateSubsystem<XRDisplaySubsystemDescriptor, XRDisplaySubsystem>(s_DisplaySubsystemDescriptors, s_DisplayName);
            CreateSubsystem<XRInputSubsystemDescriptor, XRInputSubsystem>(s_InputSubsystemDescriptors, s_InputName);

#if UNITY_2023_3_OR_NEWER
            VRKit.isFixedMaxQueuedFrames = true;
#endif

            var settings = GetSettings();
            if (settings != null) // Failsafe.
            {
                VRKit.SetTextureLayoutOnInitialize((VRKit.TextureLayout)settings.GetDefaultTextureLayout());
            }

            var display = this.displaySubsystem;
            var input = this.inputSubsystem;

            if (display != null)
            {
#if !UNITY_2020_1_OR_NEWER
                display.singlePassRenderingDisabled = true;
#endif
            }

            return display != null && input != null;
        }

        /// <summary>
        /// Start display / input systems
        /// </summary>
        /// <returns>Return true if it is successful.</returns>
        public override bool Start()
        {
            StartSubsystem<XRDisplaySubsystem>();
            StartSubsystem<XRInputSubsystem>();

            var settings = GetSettings();
            if (settings != null) // Failsafe.
            {
                if (settings.IsImproveLegacyRenderingIssueOnHDR())
                {
                    VRKitAgent.Create();
                }
            }

            var display = this.displaySubsystem;
#if UNITY_2020_1_OR_NEWER
            if (display != null && settings != null)
            {
                display.textureLayout = (XRDisplaySubsystem.TextureLayout)(int)settings.GetDefaultTextureLayout();
            }
#endif
            return true;
        }

        /// <summary>
        /// Stop display / input systems
        /// </summary>
        /// <returns>Return true if it is successful.</returns>
        public override bool Stop()
        {
            VRKitAgent.Destroy();
            StopSubsystem<XRDisplaySubsystem>();
            StopSubsystem<XRInputSubsystem>();
            return true;
        }

        /// <summary>
        /// Deinitialize display / input systems
        /// </summary>
        /// <returns>Return true if it is successful.</returns>
        public override bool Deinitialize()
        {
            DestroySubsystem<XRDisplaySubsystem>();
            DestroySubsystem<XRInputSubsystem>();
            return true;
        }

        public static VRKitSettings GetSettings()
        {
            VRKitSettings settings = null;
#if UNITY_EDITOR
            UnityEditor.EditorBuildSettings.TryGetConfigObject<VRKitSettings>("UnityEngine.Switch.VRKitSettings", out settings);
#else
            settings = VRKitSettings.s_Settings;
#endif
            return settings;
        }

#if UNITY_EDITOR
        //public string GetPreInitLibraryName(BuildTarget buildTarget, BuildTargetGroup buildTargetGroup)
        //{
        //    return "SwitchVRKitPlugin";
        //}
#endif
    }
}
