using UnityEngine;
using TMPro;

public class CalculoHandlerScript : MonoBehaviour
{

    [SerializeField] private TMP_InputField numberInputField;
    public MenuPauseScript menuPause;
    public int resultado;

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

            // logica de jogo
            if (playerNumber == resultado) {
                // Despausar jogo
                menuPause.RetomarJogo();

                // play audio
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
}
