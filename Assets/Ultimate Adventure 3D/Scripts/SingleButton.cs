using SimpleFPS;
using UnityEngine;

public class SingleButton : MonoBehaviour
{
    [SerializeField] private MultiButtonPuzzle puzzleManager;
    [SerializeField] private int buttonIndex;
    [SerializeField] private float cooldown = 2f;

    private bool canPress = true;
    private Renderer buttonRenderer;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null && canPress)
        {
            PressButton();
        }
    }

    void PressButton()
    {
        if (puzzleManager != null)
        {
            puzzleManager.RegisterButtonPress(buttonIndex);
        }

        // Визуальная обратная связь
        buttonRenderer.material.color = Color.green;
        canPress = false;
        Invoke("ResetButton", cooldown);
    }

    void ResetButton()
    {
        buttonRenderer.material.color = Color.red;
        canPress = true;
    }
}