using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    [SerializeField] float particleDestroyDelay = 1f;

    void Start()
    {
        Destroy(gameObject,particleDestroyDelay);
    }
}
