using UnityEngine;

public class SoundTyle : MonoBehaviour
{

    public AudioSource audioSource;
    public NarradorController narrador;
    public bool isActive = true;
    public bool delay = false;
    public bool cortarNarracao01 = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audioSource.isPlaying && Input.GetKey(KeyCode.E))
        {
            audioSource.Stop();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (isActive == true) {
            if(other.CompareTag("Player"))
            {
                Debug.Log("Contato");

                if( cortarNarracao01 )
                {
                    if (narrador != null && narrador.narracoes[1] != null)
                    {
                        narrador.narracoes[1].Stop();
                    }
                }

                if ( delay )
                {
                    audioSource.PlayDelayed(0.1f);
                }
                else
                {
                    audioSource.Play();
                }
                

                if (gameObject.CompareTag("Desativável"))
                {
                    isActive = false;
                }
            }
        }
    }

}
