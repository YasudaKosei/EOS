#if UNITY_SWITCH && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace UnityEngine.Switch
{
#if UNITY_SWITCH && !UNITY_EDITOR
    using Message = UnityEngine.Switch.Notification.Message; // UnityEngine.SwitchModule
#endif
    using CommandBuffer = UnityEngine.Rendering.CommandBuffer; // UnityEngine.CoreModule
    using RenderTexture = UnityEngine.RenderTexture; // UnityEngine.CoreModule

    /// <summary>
    /// Low level controls for VR Kit
    /// </summary>
    public static class VRKit
    {
#if UNITY_SWITCH && !UNITY_EDITOR
        public const Message MessageRequestToEndVrMode = (Message)71;
#else
        [System.Obsolete("This value has been defined as 'int' in Editor Mode. (It's still defined as 'Message' in Player Mode.) Please cast to 'Message' or use '#if UNITY_SWITCH && !UNITY_EDITOR' to use this value.")]
        public const int MessageRequestToEndVrMode = 71;
#endif

#if UNITY_SWITCH && !UNITY_EDITOR
        [DllImport ("__Internal", EntryPoint="VRKitSwitchSixAxisSensorStart")]
        extern private static bool StartSixAxisSensor_Internal();
        [DllImport ("__Internal", EntryPoint="VRKitSwitchSixAxisSensorStop")]
        extern private static void StopSixAxisSensor_Internal();
        [DllImport ("__Internal", EntryPoint="VRKitSwitchIsSixAxisSensorAtRest")]
        extern private static bool IsSixAxisSensorAtRest_Internal();
        [DllImport ("__Internal", EntryPoint="VRKitDeviceSwitchSetVRReprojectionMethod")]
        extern private static void SetReprojectionMethod_Internal(int reprojectionMethod);
        [DllImport ("__Internal", EntryPoint="VRKitDeviceSwitchGetVRReprojectionMethod")]
        extern private static int GetReprojectionMethod_Internal();
        [DllImport ("__Internal", EntryPoint="VRKitDeviceSwitchSetVRReprojectionCandidateTime")]
        extern private static void SetReprojectionCandidateTime_Internal(int reprojectionCandidateTime);
        [DllImport ("__Internal", EntryPoint="VRKitDeviceSwitchGetVRReprojectionCandidateTime")]
        extern private static int GetReprojectionCandidateTime_Internal();
        [DllImport ("__Internal", EntryPoint="VRKitDeviceSwitchGetIPD")]
        extern private static float GetIPD_Internal();
        [DllImport ("__Internal", EntryPoint="VRKitDeviceSwitchSetIPD")]
        extern private static void SetIPD_Internal(float ipd);
        [DllImport ("__Internal", EntryPoint="VRKitDeviceSwitchGetDefaultIPD")]
        extern private static float GetDefaultIPD_Internal();
        [DllImport ("__Internal", EntryPoint="VRKitDeviceSwitchGetFrustumShiftRate")]
        extern private static float GetFrustumShiftRate_Internal();
        [DllImport ("__Internal", EntryPoint="VRKitDeviceSwitchSetFrustumShiftRate")]
        extern private static void SetFrustumShiftRate_Internal(float frustumShiftRate);
        [DllImport ("__Internal", EntryPoint="VRKitGetCustomRenderTextureSize")]
        extern private static void _GetCustomRenderTextureSize(out int width, out int height);
        [DllImport ("__Internal", EntryPoint="VRKitSetCustomRenderTextureSize")]
        extern private static void _SetCustomRenderTextureSize(int width, int height);
        [DllImport("__Internal", EntryPoint = "VRKitGetTextureLayout")]
        extern private static int _GetTextureLayout();
        [DllImport("__Internal", EntryPoint = "VRKitSetTextureLayout")]
        extern private static void _SetTextureLayout(int textureLayout);
        [DllImport("__Internal", EntryPoint = "VRKitIsFixedMaxQueuedFrames")]
        extern private static int _IsFixedMaxQueuedFrames();
        [DllImport("__Internal", EntryPoint = "VRKitSetIsFixedMaxQueuedFrames")]
        extern private static void _SetIsFixedMaxQueuedFrames(int isFixedMaxQueuedFrames);
#endif

        /// <summary>
        /// Start SixAxisSensor
        /// </summary>
        /// <returns>Return true if it is successful.</returns>
        public static bool StartSixAxisSensor()
        {
#if UNITY_SWITCH && !UNITY_EDITOR
            return StartSixAxisSensor_Internal();
#else
            return false;
#endif
        }

        /// <summary>
        /// Stop SixAxisSensor
        /// </summary>
        public static void StopSixAxisSensor()
        {
#if UNITY_SWITCH && !UNITY_EDITOR
            StopSixAxisSensor_Internal();
#endif
        }

        /// <summary>
        /// Get status whether SixAxisSensor is stationary.
        /// </summary>
        /// <returns>Return true if SixAxisSensor is stationary. </returns>
        public static bool IsSixAxisSensorAtRest()
        {
#if UNITY_SWITCH && !UNITY_EDITOR
            return IsSixAxisSensorAtRest_Internal();
#else
            return false;
#endif
        }

        /// <summary>
        /// Reprojection methods
        /// </summary>
        public enum ReprojectionMethod
        {
            /// <summary>Disable reprojection</summary>
            Disabled = -1,
            /// <summary>Keep precision</summary>
            Strict = 0,
            /// <summary>Predict nect frame(default)</summary>
            Fast = 1,
        }

        /// <summary>
        /// Texture layout for XR eye textures
        /// </summary>
        public enum TextureLayout
        {
            /// <summary>
            /// Multipass, Side by side drawing. (Only 1 texture)
            /// </summary>
            [System.Obsolete("Experimental. This option will cause the performance issue.")]
            SingleTexture2D = 2,
            /// <summary>
            /// Multipass, Using 2 textures.
            /// </summary>
            SeparateTexture2Ds = 4,
        }

        /// <summary>
        /// Reprojection setting
        /// </summary>
        public static ReprojectionMethod reprojectionMethod
        {
            set
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                SetReprojectionMethod_Internal((int)value);
#endif
            }
            get
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                return (ReprojectionMethod)GetReprojectionMethod_Internal();
#else
                return ReprojectionMethod.Fast;
#endif
            }
        }

        /// <summary>
        /// Rprojection candidate time for prediction
        /// </summary>
        /// <remark>
        /// This value is used for ReprojectionMethod.Fast.
        /// The default value is 16. It means next frame on 60FPS.
        /// </remark>
        public static int reprojectionCandidateTime
        {
            set
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                SetReprojectionCandidateTime_Internal(value);
#endif
            }
            get
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                return GetReprojectionCandidateTime_Internal();
#else
                return 0;
#endif
            }
        }

        /// <summary>
        /// Default IPD value for eye(camera) distance.
        /// </summary>
        /// <remark>
        /// The defaultIpd value is 0.063.
        /// </remark>
        public static float defaultIpd
        {
            get
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                return GetDefaultIPD_Internal();
#else
                return 0.063f;
#endif
            }
        }

        /// <summary>
        /// Current IPD value for eye(camera) distance.
        /// </summary>
        /// <remark>
        /// The default ipd value is 0.063.
        /// </remark>
        public static float ipd
        {
            set
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                SetIPD_Internal(value);
#endif
            }
            get
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                return GetIPD_Internal();
#else
                return 0.063f;
#endif
            }
        }

        /// <summary>
        /// Frustum shift rate on projection matrix.
        /// </summary>
        /// <remark>
        /// The default value is 1.0.
        /// </remark>
        public static float frustumShiftRate
        {
            set
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                SetFrustumShiftRate_Internal(value);
#endif
            }
            get
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                return GetFrustumShiftRate_Internal();
#else
                return 1.0f;
#endif
            }
        }

        /// <summary>
        /// Get custom render texture size
        /// </summary>
        /// <remark>
        /// (0, 0) means using a back buffer.
        /// </remark>
        public static void GetCustomRenderTextureSize(out int width, out int height)
        {
#if UNITY_SWITCH && !UNITY_EDITOR
            _GetCustomRenderTextureSize(out width, out height);
#else
            width = 0;
            height = 0;
#endif
        }

        /// <summary>
        /// Set custom render texture size
        /// </summary>
        /// <remark>
        /// (0, 0) means using a back buffer.
        /// </remark>
        public static void SetCustomRenderTextureSize(int width, int height)
        {
#if UNITY_SWITCH && !UNITY_EDITOR
            _SetCustomRenderTextureSize(width, height);
#endif
        }

        public delegate void AddGraphicsThreadDistortionBlitInternalDelegate(CommandBuffer commandBuffer, RenderTexture renderTexture);
        public static AddGraphicsThreadDistortionBlitInternalDelegate AddGraphicsThreadDistortionBlitInternal = null;

        public static void AddGraphicsThreadDistortionBlit(CommandBuffer commandBuffer, RenderTexture renderTexture)
        {
            if (AddGraphicsThreadDistortionBlitInternal != null)
            {
                AddGraphicsThreadDistortionBlitInternal(commandBuffer, renderTexture);
            }
        }

        public delegate void SetDeviceConnectedInternalDelegate(bool value);
        public static SetDeviceConnectedInternalDelegate SetDeviceConnectedInternal = null;

        public delegate bool GetDeviceConnectedInternalDelegate();
        public static GetDeviceConnectedInternalDelegate GetDeviceConnectedInternal = null;

        public delegate void SetTextureLayoutInternalDelegate(TextureLayout value);
        public static SetTextureLayoutInternalDelegate SetTextureLayoutInternal = null;

        public delegate bool GetTextureLayoutInternalDelegate(out TextureLayout value);
        public static GetTextureLayoutInternalDelegate GetTextureLayoutInternal = null;

        /// <summary>
        /// Enable/Disable VR mode on VRKit
        /// </summary>
        public static bool deviceConnected
        {
            set
            {
                if (SetDeviceConnectedInternal != null)
                {
                    SetDeviceConnectedInternal(value);
                }
            }
            get
            {
                if (GetDeviceConnectedInternal != null)
                {
                    return GetDeviceConnectedInternal();
                }

                return false;
            }
        }

        /// <summary>
        /// Set/Get current TextureLayout.
        /// </summary>
        public static TextureLayout textureLayout
        {
            set
            {
                if (SetTextureLayoutInternal != null)
                {
                    SetTextureLayoutInternal(value);
                }

#if UNITY_SWITCH && !UNITY_EDITOR
                _SetTextureLayout((int)value);
#endif
            }
            get
            {
                if (GetTextureLayoutInternal != null)
                {
                    TextureLayout textureLayout;
                    if (GetTextureLayoutInternal(out textureLayout))
                    {
                        return textureLayout;
                    }
                }

#if UNITY_SWITCH && !UNITY_EDITOR
                return (TextureLayout)_GetTextureLayout();
#else
                return TextureLayout.SeparateTexture2Ds;
#endif
            }
        }

        /// <summary>
        /// Set current TextureLayout on initialize.(Internal only)
        /// </summary>
        public static void SetTextureLayoutOnInitialize(TextureLayout textureLayout)
        {
#if UNITY_SWITCH && !UNITY_EDITOR
            _SetTextureLayout((int)textureLayout);
#endif
        }

        /// <summary>
        /// Set/Get is fixed maxQueuedFrames
        /// </summary>
        public static bool isFixedMaxQueuedFrames
        {
            set
            {
#if UNITY_SWITCH && !UNITY_EDITOR
                _SetIsFixedMaxQueuedFrames(value ? 1 : 0);
#endif
            }
            get
            {

#if UNITY_SWITCH && !UNITY_EDITOR
                return _IsFixedMaxQueuedFrames() != 0;
#else
                return false;
#endif
            }
        }
    }
}
