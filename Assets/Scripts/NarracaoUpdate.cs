using UnityEngine;

public class NarracaoUpdate : MonoBehaviour
{

    public NarradorController narraController;
    public int narraCode;
    public bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isActive == true) 
        {
            if(other.CompareTag("Player"))
            {
                narraController.narracaoAtual = narraController.narracoes[narraCode];
                narraController.narracaoAtual.Play();
                isActive = false;
            }
        }
    }
}
