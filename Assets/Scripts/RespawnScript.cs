using UnityEngine;

public class RespawnScript : MonoBehaviour
{

    public Transform spawnpoint;

    private CharacterController charac;
    private AudioSource respawnSound;
    private MouseLook player;

    public NarradorController narrador;

    public SoundTyle tyleDesativavelA;
    public SoundTyle tyleDesativavelB;
    public SoundTyle tyleDesativavelC;
    public SoundTyle tyleDesativavelD;
    public NarracaoUpdate narrDesativavelA;
    public NarracaoUpdate narrDesativavelB;
    public NarracaoUpdate narrDesativavelC;
    public NarracaoUpdate narrDesativavelD;

    public bool reativarFlags = true;
    
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

                if (reativarFlags)
                {
                    Reativar();
                }

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

        MouseLook mouseLook = GetComponent<MouseLook>();
        if (mouseLook != null)
        {
            float anguloY = spawnpoint.eulerAngles.y;
            mouseLook.RedefineRotation(anguloY);
        }

        if (charac != null) 
        {
            charac.enabled = true;
        }
    
        Debug.Log("Teleportado");
    }

    void Reativar()
    {
        if (tyleDesativavelA.isActive == false) 
        {
            tyleDesativavelA.isActive = true;
        }
        if (tyleDesativavelB.isActive == false) 
        {
            tyleDesativavelB.isActive = true;
        }
        if (tyleDesativavelC.isActive == false) 
        {
            tyleDesativavelC.isActive = true;
        }
        if (tyleDesativavelD.isActive == false) 
        {
            tyleDesativavelD.isActive = true;
        }

        if (narrDesativavelA.isActive == false) 
        {
            narrDesativavelA.isActive = true;
        }
        if (narrDesativavelB.isActive == false) 
        {
            narrDesativavelB.isActive = true;
        }
        if (narrDesativavelC.isActive == false) 
        {
            narrDesativavelC.isActive = true;
        }
        if (narrDesativavelD.isActive == false) 
        {
            narrDesativavelD.isActive = true;
        }
    }

}
