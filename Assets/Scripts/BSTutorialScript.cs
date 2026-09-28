using UnityEngine;

public class BSTutorialScript : MonoBehaviour
{
    // audio 4
    private AudioSource audioSource;
    public MouseLook player; 
    public NarradorController narrador;
    public SoundTyle audio3;
    private bool touched = false;
    private bool pressedNorte = false;
    private bool pressedSul = false;
    private bool pressedLeste = false;
    private bool pressedOeste = false;
    private bool hasTriggered = false;
    private bool audioHasPlayed = false;

    public NarradorController narraController;
    public int narraCode;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {  
                Debug.Log("Norte ativado");
                pressedNorte = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Sul ativado");
                pressedSul = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Leste ativado");
                pressedLeste = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Oeste ativado");
                pressedOeste = true;
            }
        }

        if (pressedNorte && pressedSul && pressedLeste && pressedOeste && !audioHasPlayed) {

            if( narrador.narracaoAtual.isPlaying )
            {
                narrador.narracaoAtual.Stop();
            }
            if( audio3.audioSource.isPlaying )
            {
                audio3.audioSource.Stop();
            }

            Debug.Log("Direções ativadas, tocando áudio");
            audioSource.Play();
            narraController.narracaoAtual = narraController.narracoes[narraCode];
            audioHasPlayed = true;

            player.canLook = true;
        }

        if (audioHasPlayed && !audioSource.isPlaying && !hasTriggered)
        {
            hasTriggered = true;
            player.canMove = true;
            enabled = false;
        }

        if (audioSource.isPlaying && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!touched)
        {
            if(other.CompareTag("Player"))
            {
                player.canMove = false;
                Debug.Log("Contato com o BSTutorial");
                touched = true;  
            }
        }
    }
}
