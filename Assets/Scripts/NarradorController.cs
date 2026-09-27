using UnityEngine;

public class NarradorController : MonoBehaviour
{

    public AudioSource[] narracoes;
    public AudioSource narracaoAtual;
    public MouseLook player;
    public GlobalAudioDetectorScript audioDetector;
    public bool final = false;
    public bool permitirReset = true;
    
    void Start()
    {
        if (narracoes.Length > 0)
        {
            narracaoAtual = narracoes[0];
        }
    }

    void Update()
    {
        // resetar narração
        if (Input.GetKeyDown(KeyCode.Mouse1) && !narracaoAtual.isPlaying && !audioDetector.IsValidAudioPlaying() && player.canComand == true)
        {
            Debug.Log("click detectado, tocando áudio");
            narracaoAtual.Play();
        }

    }

    public void PararNarracao() 
    { 
        if (narracaoAtual != null && narracaoAtual.isPlaying) 
        { 
            narracaoAtual.Stop(); 
        } 

        permitirReset = false; 
    }

    public void PermitirReset() 
    { 
        permitirReset = true; 
    }

}
