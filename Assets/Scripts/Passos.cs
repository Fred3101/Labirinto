using UnityEngine;

public class Passos : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] passos;

    [SerializeField] private float stepInterval = 0.5f;
    private float stepTimer;

    //private PlayerMovement playerMovement;
    private Vector3 posicaoAnterior;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerMovement = GetComponent<PlayerMovement>();
        posicaoAnterior = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Calcula a distância real que o boneco andou desde o frame passado
        float distanciaPercorrida = Vector3.Distance(transform.position, posicaoAnterior);
        
        // 2. Converte essa distância em uma velocidade estimada por segundo
        float velocidadeVirtual = distanciaPercorrida / Time.deltaTime;

        // 3. Atualiza a posição para o próximo frame
        posicaoAnterior = transform.position;

        // 4. Só toca o som se o boneco estiver realmente mudando de posição no espaço
        // (Se ele colidir com a parede, a distância percorrida vira 0 e o som para!)
        if (velocidadeVirtual > 1.5f) 
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0)
            {
                PlayFootstepSound();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0; // Reseta o timer ao parar ou colidir
        }
    }

    void PlayFootstepSound()
    {
        if (passos.Length > 0)
        {
            int randomIndex = Random.Range(0, passos.Length);
            audioSource.PlayOneShot(passos[randomIndex]);
        }
    }
}
