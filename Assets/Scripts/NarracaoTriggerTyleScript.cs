using UnityEngine;

public class NarracaoTriggerTyleScript : MonoBehaviour
{
    //Responsabilidade: travar o jogo e rodar uma narração ao colidir. Destravar apenas após o fim da narração.
    public AudioSource audioSource;
    private bool aguardandoFimDaNarracao;
    private bool isActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying && Input.GetKey(KeyCode.E))
        {
            audioSource.Stop();
        }

        if (aguardandoFimDaNarracao && !audioSource.isPlaying)
        {
            Time.timeScale = 1f;
            aguardandoFimDaNarracao = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && isActive)
        {
            Time.timeScale = 0f;
            audioSource.Play();
            aguardandoFimDaNarracao = true;
            isActive = false;
        }
    }
}
