using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float endSceneDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    private PlayerController pController;
    private bool gameOver = false;
    
    private void Awake() {
        pController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !gameOver) {
            gameOver = true;
            pController.DisableMovement();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene",endSceneDelay);
        }
    }

    private void ReloadScene() {
            SceneManager.LoadScene(0);
    }
}
