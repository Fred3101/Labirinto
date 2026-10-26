using UnityEngine;

public class GameController : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && !hasTriggered)
        {
            hasTriggered = true;
            player.canMove = true;
            player.canComand = true;
            enabled = false;
        }

        if (audioSource.isPlaying && !hasTriggered && Input.GetKeyDown(KeyCode.E))
        {
            hasTriggered = true;
            player.canMove = true;
            player.canComand = true;
            audioSource.Stop();
            enabled = false;
        }
    }
}
