using UnityEngine;

public class MiniAudioUpdate : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip novoAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (audioManager == null || novoAudio == null)
        {
            Debug.LogError("MiniAudioUpdate precisa de um AudioManager e um AudioClip configurados.", this);
            return;
        }

        audioManager.AtualizarSom(novoAudio);
    }
}
