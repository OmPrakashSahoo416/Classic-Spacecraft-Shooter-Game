using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] float levelReloadDelay = 1f;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        explosionParticles.Play();
        GameObject.Find("Physical Parts").SetActive(false);
        Invoke("ReloadLevel", levelReloadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
