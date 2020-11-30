using UnityEngine;
using UnityEngine.Rendering;

public class RP1 : RenderPipeline
{
    CommandBuffer commandbuffer = new CommandBuffer() { name="RP1Command"};
    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        for(int i = 0; i < cameras.Length; ++i)
        {
            Camera camera = cameras[i];
            CameraClearFlags flags = camera.clearFlags;
            if (flags == CameraClearFlags.Skybox)
            {
                context.DrawSkybox(camera);
            }
            else
            {
                commandbuffer.ClearRenderTarget(
                    flags <= CameraClearFlags.Depth,
                    flags <= CameraClearFlags.SolidColor,
                    new Color(0.1f, 0.4f, 0.6f)
                );
                context.ExecuteCommandBuffer(commandbuffer);
                commandbuffer.Clear();
            }
            context.SetupCameraProperties(camera);
            ShaderTagId rp1ShaderTagID = new ShaderTagId("RP1Shader");

            var sortingSettings = new SortingSettings(camera)
            {
                criteria = SortingCriteria.CommonOpaque
            };
            var drawingSettings = new DrawingSettings(rp1ShaderTagID, sortingSettings);
            var filteringSettings = new FilteringSettings(RenderQueueRange.opaque);
            CullingResults cullingResults;
            if (camera.TryGetCullingParameters(out ScriptableCullingParameters p))
            {
                cullingResults = context.Cull(ref p);
                context.DrawRenderers(cullingResults, ref drawingSettings, ref filteringSettings);
            }
            context.Submit();
        }
    }
}
