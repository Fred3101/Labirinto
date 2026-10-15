using UnityEngine;
using TMPro;

public class CalculoHandlerScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField numberInputField;
    [SerializeField] public AudioClip rewardAudio;
    public MenuPauseScript menuPause;
    public AudioManager audioManager;
    public int resultado;

    private AudioSource audioTutorialRecompensaSource;
    private AudioClip audioTutorialRecompensaInicial;
    private bool audioTutorialRecompensaInicialTocada;

    private void OnEnable()
    {
        // Inscreve a função automaticamente quando o script ativa
        numberInputField.onSubmit.AddListener(ProcessarNumero);
    }

    private void OnDisable()
    {
        // Remove a inscrição para evitar erros de memória
        numberInputField.onSubmit.RemoveListener(ProcessarNumero);
    }

    // O evento onSubmit do Unity obrigatoriamente envia o texto digitado junto
    public void ProcessarNumero(string textValue)
    {
        if (int.TryParse(textValue, out int playerNumber))
        {
            Debug.Log("SISTEMA DE EVENTO: O jogador apertou Enter e enviou: " + playerNumber);

            if (playerNumber == resultado)
            {
                menuPause.RetomarJogo();

                if (audioTutorialRecompensaSource != null &&
                    audioTutorialRecompensaInicial != null &&
                    !audioTutorialRecompensaInicialTocada)
                {
                    audioTutorialRecompensaInicialTocada = true;
                    audioManager.TocarAudioInicialDepois(
                        audioTutorialRecompensaSource,
                        audioTutorialRecompensaInicial,
                        rewardAudio);
                }
                else
                {
                    TocarRecompensaAtual();
                }
            }
            else
            {
                Debug.LogWarning("Resposta errada, tente de novo");
            }
        }
        else
        {
            Debug.LogWarning("Input inválido ou vazio.");
        }
    }

    public void ConfigurarAudioRecompensaTutorial(
        AudioSource audioSource,
        AudioClip recompensaInicial,
        AudioClip recompensaRepetivel)
    {
        audioTutorialRecompensaSource = audioSource;
        audioTutorialRecompensaInicial = recompensaInicial;
        rewardAudio = recompensaRepetivel;
        audioTutorialRecompensaInicialTocada = false;
    }

    private void TocarRecompensaAtual()
    {
        audioManager.AtualizarSom(rewardAudio);
        audioManager.TocarSom();
    }
}
