using UnityEngine;

public class CheckpointScript2 : MonoBehaviour
{

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
        if(other.CompareTag("Player"))
        {
            Debug.Log("Contato");
                
            if (playerRespawn != null)
            {
                playerRespawn.spawnpoint = CheckpointSpawn;
                Debug.LogWarning("Checkpoint!");
            }

            enabled = false;
        }
    }
}
