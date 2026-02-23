using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        // Вращение по выбранной оси
        targetTransform.Rotate(rotationAxis, speed * Time.deltaTime, Space.Self);
    }
}