using UnityEngine;

public class RespawnScript : MonoBehaviour
{

    public Transform spawnpoint;

    private CharacterController charac;
    private AudioSource respawnSound;
    private MouseLook player;

    public NarradorController narrador;
    
    void Start()
    {
        charac = GetComponent<CharacterController>();
        respawnSound = GetComponent<AudioSource>();
        player = GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.canComand == true)
        {   
            Debug.LogWarning("tecla precionada");

            if (spawnpoint != null)
            {
                Debug.LogWarning("alvo não é nulo, tp solicitado");

                Retornar();

                if (narrador.narracaoAtual.isPlaying)
                {
                    narrador.narracaoAtual.Stop();
                }
                respawnSound.Play();
                // fazer ele costrar narracao tb

            }
            else
            {
                Debug.LogWarning("Deu zebra ai, alvo não encontrado");
            }
        }
    }

    void Retornar()
    {
        if (charac != null) 
        {
            charac.enabled = false;
        }

        transform.position = spawnpoint.position;
        transform.rotation = spawnpoint.rotation;

        if (charac != null) 
        {
            charac.enabled = true;
        }
    
        Debug.Log("Teleportado");
    }

}
