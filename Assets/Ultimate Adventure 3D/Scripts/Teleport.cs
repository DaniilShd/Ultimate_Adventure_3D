using SimpleFPS;
using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport target;

    private bool isTeleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTeleporting) return;

        FirstPersonController fps = other.GetComponent<FirstPersonController>();
        if (fps == null) return;

        Debug.Log($"Teleporting from {name} to {target.name}");

        isTeleporting = true;
        target.isTeleporting = true;

        // Сохраняем текущую высоту игрока относительно телепорта
        float heightDifference = fps.transform.position.y - transform.position.y;

        // Отключаем CharacterController перед телепортацией
        CharacterController characterController = fps.GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.enabled = false;
        }

        // Телепортируем, сохраняя относительную высоту
        Vector3 newPosition = target.transform.position;
        newPosition.y += heightDifference;

        fps.transform.position = newPosition;
        Debug.Log($"New position: {newPosition} (height diff: {heightDifference})");

        // Включаем CharacterController в следующем кадре
        StartCoroutine(EnableCharacterController(characterController));
        StartCoroutine(ResetTeleport());
    }

    private IEnumerator EnableCharacterController(CharacterController cc)
    {
        yield return new WaitForEndOfFrame();

        if (cc != null)
        {
            cc.enabled = true;
        }
    }

    private IEnumerator ResetTeleport()
    {
        yield return new WaitForSeconds(0.5f);
        isTeleporting = false;
        target.isTeleporting = false;
    }
}