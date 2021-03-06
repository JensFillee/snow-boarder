using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;

            // Call the (public) DiableControls method of PlayerController-script
            FindObjectOfType<PlayerController>().DisableControls();

            crashEffect.Play();

            // Play a specific audioclip (=> so you can have multiple SFX on same gameobject)
            GetComponent<AudioSource>().PlayOneShot(crashSFX);

            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        // Load "level1" scene (has sceneIndex 0 (see Build Settings))
        SceneManager.LoadScene(0);
    }
}
