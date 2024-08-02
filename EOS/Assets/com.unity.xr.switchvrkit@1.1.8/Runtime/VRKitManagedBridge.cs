using System;
using UnityEngine;

namespace UnityEngine.Switch
{
    using CommandBuffer = UnityEngine.Rendering.CommandBuffer; // UnityEngine.CoreModule
    using RenderTexture = UnityEngine.RenderTexture; // UnityEngine.CoreModule
    using XRDisplaySubsystem = UnityEngine.XR.XRDisplaySubsystem; // UnityEngine.XRModule

    public static class VRKitManagedBridge
    {
        [RuntimeInitializeOnLoadMethod]
        static void VRKitManagedBridgeBootStrap()
        {
#if UNITY_SWITCH
            VRKit.AddGraphicsThreadDistortionBlitInternal = AddGraphicsThreadDistortionBlit;
            VRKit.SetDeviceConnectedInternal = SetDeviceConnected;
            VRKit.GetDeviceConnectedInternal = GetDeviceConnected;
#if UNITY_2020_1_OR_NEWER
            VRKit.SetTextureLayoutInternal = SetTextureLayout;
            VRKit.GetTextureLayoutInternal = GetTextureLayout;
#endif
#endif
        }

        static void AddGraphicsThreadDistortionBlit(CommandBuffer commandBuffer, RenderTexture renderTexture)
        {
#if UNITY_SWITCH
            if (commandBuffer == null || renderTexture == null)
            {
                return;
            }

            var displaySubsystem = GetXRDisplaySubsystem();
            if (displaySubsystem == null)
            {
                return;
            }

            commandBuffer.SetRenderTarget(renderTexture);
            VRKit.SetCustomRenderTextureSize(renderTexture.width, renderTexture.height);
            displaySubsystem.AddGraphicsThreadMirrorViewBlit(commandBuffer, true, UnityEngine.XR.XRMirrorViewBlitMode.Distort);
#endif
        }

        static XRDisplaySubsystem GetXRDisplaySubsystem()
        {
            var generalSettings = UnityEngine.XR.Management.XRGeneralSettings.Instance;
            if (generalSettings == null)
            {
                return null;
            }

            var manager = generalSettings.Manager;
            if (manager == null)
            {
                return null;
            }

            var activeLoader = manager.activeLoader;
            bool isInitialized = (activeLoader != null) ? manager.isInitializationComplete : false;
            if (!isInitialized)
            {
                return null;
            }

            return activeLoader.GetLoadedSubsystem<UnityEngine.XR.XRDisplaySubsystem>();
        }

        static void SetDeviceConnected(bool value)
        {
            var generalSettings = UnityEngine.XR.Management.XRGeneralSettings.Instance;
            if (generalSettings == null)
            {
                return;
            }

            var manager = generalSettings.Manager;
            if (manager == null)
            {
                return;
            }

            bool isInitialized = (manager.activeLoader != null) ? manager.isInitializationComplete : false;
            if (isInitialized == value)
            {
                return;
            }

            if (isInitialized)
            {
                var activeLoader = manager.activeLoader;
                if (activeLoader != null)
                {
                    manager.StopSubsystems();
                }

                manager.DeinitializeLoader();

                Camera[] cameras = Camera.allCameras;
                if (cameras != null)
                {
                    for (int i = 0, count = cameras.Length; i < count; ++i)
                    {
                        if (cameras[i] != null && cameras[i].stereoTargetEye != StereoTargetEyeMask.None)
                        {
                            cameras[i].ResetProjectionMatrix();
                            cameras[i].ResetAspect();
                        }
                    }
                }
            }
            else
            {
                manager.automaticLoading = false;
                manager.automaticRunning = false;
                var enumerator = manager.InitializeLoader();
                if (enumerator != null)
                {
                    while (enumerator.MoveNext())
                    {
                    }
                }

                var activeLoader = manager.activeLoader;
                if (activeLoader != null)
                {
                    manager.StartSubsystems();
                }
            }
        }

        static bool GetDeviceConnected()
        {
            var generalSettings = UnityEngine.XR.Management.XRGeneralSettings.Instance;
            if (generalSettings == null)
            {
                return false;
            }

            var manager = generalSettings.Manager;
            if (manager == null)
            {
                return false;
            }

            var activeLoader = manager.activeLoader;
            if (activeLoader == null)
            {
                return false;
            }

            return manager.isInitializationComplete;
        }

#if UNITY_SWITCH
#if UNITY_2020_1_OR_NEWER
        static void SetTextureLayout(VRKit.TextureLayout value)
        {
            var display = GetXRDisplaySubsystem();
            if (display == null)
            {
                return;
            }

            display.textureLayout = (XRDisplaySubsystem.TextureLayout)(int)value;
        }

        static bool GetTextureLayout(out VRKit.TextureLayout value)
        {
            value = VRKit.TextureLayout.SeparateTexture2Ds; // Failsafe.
            var display = GetXRDisplaySubsystem();
            if (display == null)
            {
                return false;
            }

            value = (VRKit.TextureLayout)(int)display.textureLayout;
            return true;
        }
#endif
#endif
    }
}
