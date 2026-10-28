using System.Collections;
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

        if (endingMenu == null)
        {
            Debug.LogError("Configure o GameEndingMenuScript no GameEndingTyleScript.", this);
            return;
        }

        if (endingAudio == null)
        {
            Debug.LogError("Configure o dingle de vitória no GameEndingTyleScript.", this);
            StartCoroutine(endingMenu.AbrirAposAudioDeConquista(audioSource));
            return;
        }

        AudioPlaybackCoordinator.PlayOneShot(audioSource, endingAudio);
        StartCoroutine(AbrirMenuAposDingle());
    }

    private IEnumerator AbrirMenuAposDingle()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        yield return endingMenu.AbrirAposAudioDeConquista(audioSource);
    }
}
