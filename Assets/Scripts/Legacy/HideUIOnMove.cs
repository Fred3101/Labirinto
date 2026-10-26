using UnityEngine;

public class HideUIOnMove : MonoBehaviour
{

    public GameObject UI;
    public float minMove = 0.01f;

    private Vector3 lastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;

        if (UI != null)
        {
            UI.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UI == null || !UI.activeSelf) return;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(moveHorizontal) > minMove || Mathf.Abs(moveVertical) > minMove)
        {
            UI.SetActive(false);
        }
    }
}
