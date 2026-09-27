using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float snapThreshold = 45f;

    private float accumulatedMouseX = 0f;
    private float currentYRotation = 0f;

    public float moveSpeed = 5f;
    public float gravity = 9.81f;

    public bool canMove = true; 
    public bool canComand = true;
    public bool canLook = true;

    private CharacterController controller;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentYRotation = transform.eulerAngles.y;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if ( canLook ) {

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            accumulatedMouseX += mouseX;

            if (accumulatedMouseX >= snapThreshold)
            {
                currentYRotation += 90f;
                accumulatedMouseX = 0f;
            }

            else if (accumulatedMouseX <= -snapThreshold)
            {
                currentYRotation -= 90f;
                accumulatedMouseX = 0f;
            }

            transform.rotation = Quaternion.Euler(0f, currentYRotation, 0f);

        }

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

    public void RedefineRotation(float newRotationY)
    {
        currentYRotation = newRotationY;
        accumulatedMouseX = 0f;
    }
}