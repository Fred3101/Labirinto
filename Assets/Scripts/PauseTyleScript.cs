using UnityEngine;

public class PauseTyleScript : MonoBehaviour
{
    private AudioSource audioSource;
    public MouseLook player; 
    public NarradorController narrador;
    public bool isActive = true;
    public bool ending = false;
    private bool hasTriggered = false;
    private bool audioHasPlayed = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Detectando fim do audio:
        if (audioHasPlayed && !audioSource.isPlaying && !hasTriggered)
        {
            hasTriggered = true;
            player.canMove = true;

            if (gameObject.CompareTag("Desativável"))
            {
                enabled = false;
            }

            if (ending) {
                Application.Quit();

                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
        }

        if (audioSource.isPlaying && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Parando áudio");
            audioSource.Stop();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player") && !hasTriggered)
        {
            
            if( narrador.narracaoAtual.isPlaying )
            {
                narrador.narracaoAtual.Stop();
            }

            player.canMove = false;
            Debug.Log("Contato");
            audioSource.PlayDelayed(1.0f);
            audioHasPlayed = true;
                    
        }

    }
}
