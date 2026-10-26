using UnityEngine;

public class MiniAudioUpdate : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip novoAudio;
    private bool contatoRegistrado;
    private bool audioAtualizado;

    private void Update()
    {
        if (contatoRegistrado && !audioAtualizado &&
            TutorialBSScript.SegundoAudioConcluido &&
            TutorialBSScript.UltimoAudioDaBussolaConcluido)
        {
            audioManager.AtualizarSom(novoAudio);
            audioAtualizado = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (contatoRegistrado || !other.CompareTag("Player"))
        {
            return;
        }

        if (audioManager == null || novoAudio == null)
        {
            Debug.LogError("MiniAudioUpdate precisa de um AudioManager e um AudioClip configurados.", this);
            return;
        }

        contatoRegistrado = true;
    }
}
