using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "RenderPipeline/RP1")]
public class RP1Asset : RenderPipelineAsset
{
    protected override RenderPipeline CreatePipeline()
    {
        return new RP1();
    }
}
