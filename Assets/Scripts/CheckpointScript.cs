using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    private bool ativo = true;
    public Transform CheckpointSpawn;
    public RespawnScript playerRespawn;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (ativo == true) 
        {
            if(other.CompareTag("Player"))
            {
                Debug.Log("Contato");
                audioSource.Play();
                
                if (playerRespawn != null)
                {
                    playerRespawn.spawnpoint = CheckpointSpawn;
                    Debug.LogWarning("Checkpoint!");
                }
            }
        }

    }
}
