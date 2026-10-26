using UnityEngine;

public class ActivateComandsTyleScript : MonoBehaviour
{

    public MouseLook player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.canComand = true;
            enabled = false;
        }
    }
}
