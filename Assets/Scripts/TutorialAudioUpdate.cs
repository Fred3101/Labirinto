using UnityEngine;

public class TutorialAudioUpdate : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CalculoHandlerScript calculoHandler;
    [SerializeField] private AudioSource audioInicialSource;
    [SerializeField] private AudioClip audioInicial;
    [SerializeField] private AudioClip novoAudio;
    [SerializeField] private AudioClip audioRecompensaInicial;
    [SerializeField] private AudioClip audioRecompensa;

    private bool hasTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered || !other.CompareTag("Player"))
        {
            return;
        }

        if (audioManager == null || calculoHandler == null || audioInicialSource == null ||
            audioInicial == null || novoAudio == null ||
            audioRecompensaInicial == null || audioRecompensa == null)
        {
            Debug.LogError("TutorialAudioUpdate precisa dos áudios, AudioSource, AudioManager e CalculoHandlerScript configurados.", this);
            return;
        }

        hasTriggered = true;
        calculoHandler.ConfigurarAudioRecompensaTutorial(
            audioInicialSource,
            audioRecompensaInicial,
            audioRecompensa);
        StartCoroutine(TocarAudioInicial());
    }

    private System.Collections.IEnumerator TocarAudioInicial()
    {
        audioInicialSource.PlayOneShot(audioInicial);
        yield return new WaitWhile(() => audioInicialSource.isPlaying);

        audioManager.AtualizarSom(novoAudio);
        audioManager.TocarSom();
    }
}
