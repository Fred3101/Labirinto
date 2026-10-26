using UnityEngine;

public class TimerTyleScript : MonoBehaviour
{
    [Header("Settings")]
    public string playerTag = "Player"; // Tag do seu jogador
    public float requiredTime = 3.0f;    // Tempo necessário parado (em segundos)

    private float timer = 0f;
    private CharacterController playerController;
    private bool hasTriggered = false;

    private void OnTriggerStay(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag(playerTag))
        {
            // Pega o Character Controller do jogador se ainda não tiver pegado
            if (playerController == null)
            {
                playerController = other.GetComponent<CharacterController>();
            }

            if (playerController != null)
            {
                // Verifica se a velocidade de movimento do jogador é quase zero
                // sqrMagnitude é mais leve para o processamento do que Magnitude
                if (playerController.velocity.sqrMagnitude < 0.01f)
                {
                    timer += Time.deltaTime; // Avança o timer
                    Debug.Log($"Jogador parado. Tempo: {timer:F1}/{requiredTime}s");

                    if (timer >= requiredTime)
                    {
                        TriggerSuccessEvent();
                    }
                }
                else
                {
                    // Se o jogador se mover enquanto toca no objeto, reseta o timer
                    if (timer > 0)
                    {
                        Debug.Log("Jogador se moveu! Resetando timer.");
                        timer = 0f;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Jogador saiu da área do objeto.");
            timer = 0f;
            playerController = null; // Limpa a referência para o caso de múltiplos jogadores
            hasTriggered = false;
        }
    }

    private void TriggerSuccessEvent()
    {
        hasTriggered = true;

        Debug.Log("Sucesso! O jogador ficou parado por 3 segundos.");
        
        // Insira sua lógica aqui (ex: abrir porta, ativar checkpoint, etc.)
        
    }
}
