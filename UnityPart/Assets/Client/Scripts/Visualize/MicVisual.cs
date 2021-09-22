using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.Visualize
{
    public class MicVisual : VisualizerBase<float>
    {
        [SerializeField] private Image image;
        public override void Visual(float value)
        {
            image.fillAmount = value/100f;
        }
    }
}