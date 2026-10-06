using UnityEngine;

public class AudioUpdate : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip novoAudio;
    bool hasPlayed = false;

    // Exemplo de momento específico: Quando o jogador entra em um gatilho de nova fase
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Atualiza o som do sistema dinamicamente
            audioManager.AtualizarSom(novoAudio);

            // Som toca automaticamente apenas uma vez
            if (!hasPlayed)
            {
                audioManager.TocarSom();

                hasPlayed = true;
            }
        }
    }
}
