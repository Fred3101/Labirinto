using UnityEngine;

public class AudioUpdate : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip novoAudio;
    [SerializeField] private AudioClip audioRecompensa;
    public CalculoHandlerScript calculoHandler;
    bool hasPlayed = false;

    // Exemplo de momento específico: Quando o jogador entra em um gatilho de nova fase
    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed || !other.CompareTag("Player"))
        {
            return;
        }

        if (audioManager == null || calculoHandler == null ||
            novoAudio == null || audioRecompensa == null)
        {
            Debug.LogError("AudioUpdate precisa de AudioManager, CalculoHandlerScript e os dois AudioClips configurados.", this);
            return;
        }

        hasPlayed = true;
        calculoHandler.rewardAudio = audioRecompensa;
        StartCoroutine(TocarAudioAposProcessarContato());
    }

    private System.Collections.IEnumerator TocarAudioAposProcessarContato()
    {
        yield return null;

        while (!audioManager.IntroducaoConcluida)
        {
            yield return null;
        }

        audioManager.AtualizarSomETocar(novoAudio);
    }
}
