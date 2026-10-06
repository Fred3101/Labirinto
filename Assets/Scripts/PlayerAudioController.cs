using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    // Arraste o GameObject que tem o AudioManager para este campo no Inspector
    [SerializeField] private AudioManager audioManager; 

    void Update()
    {
        // Comando: Sempre que o jogador apertar a tecla "E", repete o áudio
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioManager.TocarSom();
        }
    }
}
