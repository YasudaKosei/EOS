using UnityEngine;
using System;
using System.Collections;

namespace UnityEngine.Switch
{
    public class VRKitAgent : MonoBehaviour
    {
        static VRKitAgent _singleton;

        public static void Create()
        {
            if (_singleton == null)
            {
                GameObject go = new GameObject("VRKitAgent");
                if (go != null)
                {
                    go.hideFlags = HideFlags.HideAndDontSave;
                    GameObject.DontDestroyOnLoad(go);
                    _singleton = go.AddComponent<VRKitAgent>();
                }
            }
        }

        public static void Destroy()
        {
            if (_singleton != null)
            {
                GameObject.Destroy(_singleton.gameObject);
            }
            _singleton = null;
        }

        void Awake()
        {
            StartCoroutine(EndFrame());
        }

        IEnumerator EndFrame()
        {
            for (; ; )
            {
                yield return new WaitForEndOfFrame();
                VRKitInternal.DisableGraphicsBlitOnVR();
            }
        }

        static bool IsStereoCamera(Camera camera)
        {
            if (camera == null)
            {
                return false;
            }

            if (!camera.stereoEnabled)
            {
                return false;
            }

            return true;
        }

        void OnRenderObject()
        {
            if (!IsStereoCamera(Camera.current))
            {
                VRKitInternal.DisableGraphicsBlitOnVR();
                return;
            }

            VRKitInternal.EnableGraphicsBlitOnVR();
        }

        void OnDestroy()
        {
            VRKitInternal.DisableGraphicsBlitOnVR();
        }
    }
}
