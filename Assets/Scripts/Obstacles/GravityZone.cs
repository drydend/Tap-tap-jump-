using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GravityZone : MonoBehaviour
{
    private HashSet<Rigidbody2D> _affectedBodies = new HashSet<Rigidbody2D>();
    private Rigidbody2D componentRigidbody;

    [SerializeField]
    private float _strength = 10f;


    private void Awake()
    {
        componentRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody != null)
        {
            _affectedBodies.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody != null)
        {
            _affectedBodies.Remove(other.attachedRigidbody);
        }
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody2D body in _affectedBodies)
        {
            Vector2 forceDirection = ((Vector2)transform.position - body.position).normalized;

            body.AddForce(forceDirection * _strength);
        }
    }
}