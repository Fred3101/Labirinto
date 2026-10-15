using UnityEngine;

public class ChallengeTriggerScript : MonoBehaviour
{
    public MenuPauseScript menuPause;
    public CalculoHandlerScript calculoHandler;
    public int newResultado;
    private bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isActive) {
            if(other.CompareTag("Player"))
            {
                // Ativar menu de resposta
                calculoHandler.resultado = newResultado;
                menuPause.PausarJogo();
                // desativa-se
                isActive = false;
            }
        }
    }
}
