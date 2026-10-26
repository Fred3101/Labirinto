using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameEndingTyleScript : MonoBehaviour
{
    [SerializeField] private AudioClip endingAudio;
    [SerializeField] private GameEndingMenuScript endingMenu;

    private AudioSource audioSource;
    private bool hasTriggered;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered || !other.CompareTag("Player"))
        {
            return;
        }

        hasTriggered = true;

        if (endingAudio == null)
        {
            Debug.LogError("Configure o áudio de encerramento no GameEndingTyleScript.", this);
        }
        else
        {
            AudioPlaybackCoordinator.PlayOneShot(audioSource, endingAudio);
        }

        if (endingMenu == null)
        {
            Debug.LogError("Configure o GameEndingMenuScript no GameEndingTyleScript.", this);
            return;
        }

        endingMenu.Abrir();
    }
}
