using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem enemyExplosionParticles;
    [SerializeField] ParticleSystem enemyHitParticles;
    [SerializeField] int enemyHealth = 10;
    [SerializeField] int enemyHitScore = 10;

    ScoreUIHandler scoreUIHandler;

    void Start()
    {
        scoreUIHandler = FindObjectOfType<ScoreUIHandler>();

        Rigidbody enemyRb = gameObject.AddComponent<Rigidbody>();
        enemyRb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        scoreUIHandler.ScoreBoard(enemyHitScore);

        HitPointEffect();
        KillEnemy();
        
    }

    void HitPointEffect()
    {
        enemyHealth--;
        Instantiate(enemyHitParticles, transform.position, Quaternion.identity);
    }

    void KillEnemy()
    {
        if (enemyHealth < 1)
        {
            Instantiate(enemyExplosionParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
