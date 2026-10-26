using UnityEngine;

public class FinalScript : MonoBehaviour
{
    
    public MouseLook player;
    public NarradorController narrador;

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            player.canMove = false;
            player.canComand = false;
            narrador.final = true;
        }

    }
}
