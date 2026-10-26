using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    
    private AudioSource audioSource;
    public MouseLook player; 
    private bool hasTriggered = false;
    private bool audioHasPlayed = false;
    public int sceneToLoad = 1; // Defina o índice da cena que deseja carregar

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audioHasPlayed && !audioSource.isPlaying && !hasTriggered)
        {
            hasTriggered = true;
            Debug.Log("Mudando de fase");
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !hasTriggered)
        {

            player.canMove = false;
            AudioPlaybackCoordinator.Play(audioSource);
            audioHasPlayed = true;

        }
    }
}
