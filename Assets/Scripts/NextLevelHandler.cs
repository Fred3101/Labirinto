using UnityEngine;

public class NextLevelHandler : MonoBehaviour
{
    public RespawnScript respawn;

    public SoundTyle stFlag01;
    public NarracaoUpdate narrFlag01;

    public SoundTyle stFlag02;
    public NarracaoUpdate narrFlag02;

    public SoundTyle stFlag03;
    public NarracaoUpdate narrFlag03;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            respawn.tyleDesativavelA = stFlag01;
            respawn.tyleDesativavelB = stFlag02;
            respawn.tyleDesativavelC = stFlag03;
            respawn.narrDesativavelA = narrFlag01;
            respawn.narrDesativavelB = narrFlag02;
            respawn.narrDesativavelC = narrFlag03;
        }
    }
}
