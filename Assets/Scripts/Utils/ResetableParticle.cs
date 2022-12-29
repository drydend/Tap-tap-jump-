using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(ParticleSystem))]
public class ResetableParticle : MonoBehaviour, IResetable
{
    private ParticleSystem _particleSystem;

    [Inject]
    public void Construct(LevelReseter reseter)
    {
        reseter.Subscribe(this);
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void ResetState()
    {
        _particleSystem.Stop();
        _particleSystem.Clear();
        _particleSystem.Play();
    }
}
