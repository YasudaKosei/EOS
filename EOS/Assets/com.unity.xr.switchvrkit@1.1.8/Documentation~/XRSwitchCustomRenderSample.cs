using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class XRSwitchCustomRenderSample : MonoBehaviour
{
    CommandBuffer _commandBuffer;
    public RenderTexture _renderTexture;

    void Start()
    {
        _commandBuffer = new CommandBuffer();

        if (UnityEngine.Switch.VRKit.deviceConnected)
        {
            RebuildCommandBuffer();
        }

        StartCoroutine(EndFrameCoroutine());
    }

    float elapsedTime = 0.0f;
    void Update()
    {
        if ((elapsedTime += Time.deltaTime) >= 5.0f)
        {
            elapsedTime = 0.0f;

            UnityEngine.Switch.VRKit.deviceConnected = !UnityEngine.Switch.VRKit.deviceConnected;
            if (UnityEngine.Switch.VRKit.deviceConnected)
            {
                RebuildCommandBuffer();
            }
        }
    }

    void RebuildCommandBuffer()
    {
        _commandBuffer.Clear();
        UnityEngine.Switch.VRKit.AddGraphicsThreadDistortionBlit(_commandBuffer, _renderTexture);
        _commandBuffer.Blit(_renderTexture, -1);
    }

    IEnumerator EndFrameCoroutine()
    {
        for (; ; )
        {
            yield return new WaitForEndOfFrame();
            if (UnityEngine.Switch.VRKit.deviceConnected)
            {
                Graphics.ExecuteCommandBuffer(_commandBuffer);
            }
        }
    }
}
