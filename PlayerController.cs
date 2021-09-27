using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Game Settings")]
    [SerializeField] float playerSpeed = 20f;
    [SerializeField] float xRange = 3f;
    [SerializeField] float yRange = 1.75f;

    [Header("Array of Laser Particle Systems")]

    [Tooltip("The array of left and right lasers of the player Spaceship.")]
    [SerializeField] GameObject[] lasers;

    [Header("Player Pitch Yaw and Roll Settings")]
    [SerializeField] float positionpitchfactor = -3f;
    [SerializeField] float controlPitchfactor = -15f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -20f;

    Vector2 movement;

    void Update()
    {
        PlayerMovement();
        PlayerRotation();
        PlayerFiring();
    }

    void PlayerMovement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        float newXPos = transform.localPosition.x + movement.x * playerSpeed * Time.deltaTime;
        float newYPos = transform.localPosition.y + movement.y * playerSpeed * Time.deltaTime;

        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    void PlayerRotation()
    {
        float pitch = transform.localPosition.y * positionpitchfactor + movement.y * controlPitchfactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll=movement.x*controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
    void PlayerFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetActivateLasers(true);
        }
        else
        {
            SetActivateLasers(false);
        }
    }

    void SetActivateLasers(bool setActive)
    {
        foreach(GameObject laser in lasers)
        {
            var particleEmmision = laser.GetComponent<ParticleSystem>().emission;
            particleEmmision.enabled = setActive;
        }
    }
    
}
