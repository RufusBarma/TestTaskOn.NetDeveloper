using UnityEngine;

namespace Client.Scripts.Visualize
{
    public abstract class VisualizerBase<T> : MonoBehaviour
    {
        public abstract void Visual(T value);
    }
}