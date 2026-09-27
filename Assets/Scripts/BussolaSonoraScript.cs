using UnityEngine;

public class BussolaSonoraScript : MonoBehaviour
{

    public AudioSource Norte;
    public AudioSource Leste;
    public AudioSource Oeste;
    public AudioSource Sul;

    public MouseLook player;

    // Update is called once per frame
    void Update()
    {   

        if (player.canComand == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Norte.Play();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Leste.Play();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Oeste.Play();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Sul.Play();
            }
        }
    }
}
