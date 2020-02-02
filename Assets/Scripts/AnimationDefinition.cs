  
using UnityEngine;

[CreateAssetMenu(fileName = "mew animation", menuName = "Animations")]
public class AnimationDefinition : ScriptableObject
{
    [Range(0.1f, 5f)]
    [SerializeField] private float _duration;
    [SerializeField] private AnimationCurve _curve;
    
    public float duration => _duration;
    public AnimationCurve curve => _curve;
}
