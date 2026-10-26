using UnityEngine;

public class BussolaMovimento : MonoBehaviour
{

    public Transform alvo;

    void LateUpdate()
    {
        if (alvo != null) {
            transform.position = alvo.position;
        }
    }

}
