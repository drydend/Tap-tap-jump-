using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticlePlayeOnEnable : MonoBehaviour
{
    private ParticleSystem _paritcleSystem;

    private void Awake()
    {
        _paritcleSystem = GetComponent<ParticleSystem>();
    }
    private void OnEnable()
    {
        _paritcleSystem.Play();
    }
}
