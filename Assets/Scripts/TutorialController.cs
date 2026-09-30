using UnityEngine;

public class TutorialController : MonoBehaviour
{

    private AudioSource audioSource;
    public MouseLook player;
    public bool isActive = true;
    private bool hasTriggered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        player.canComand = false;
        player.canMove = false;

    }

    void Update()
    {
        if (!audioSource.isPlaying && !hasTriggered)
        {
            hasTriggered = true;
            player.canMove = true;
            enabled = false;
        }

        if (audioSource.isPlaying && !hasTriggered && Input.GetKeyDown(KeyCode.E))
        {
            hasTriggered = true;
            player.canMove = true;
            audioSource.Stop();
            enabled = false;
        }
    }

}
