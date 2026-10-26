using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float gravity = 9.81f;

    public bool canMove = true; 
    public bool canComand = true;

    private CharacterController controller;

    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove == true) {
            MovePlayer();
        } 
    }

    void MovePlayer()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ = 1f;
        if (Input.GetKey(KeyCode.S)) moveZ = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;

        Vector3 direcao = (transform.forward * moveZ) + (transform.right * moveX);

        if (direcao.magnitude > 1f)
        {
            direcao.Normalize();
        }

        Vector3 movimentoFinal = direcao * moveSpeed;

        movimentoFinal.y = -gravity;

        controller.Move(movimentoFinal * Time.deltaTime);
    }
}