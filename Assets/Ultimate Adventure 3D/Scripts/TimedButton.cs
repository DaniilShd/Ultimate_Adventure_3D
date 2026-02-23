using SimpleFPS;
using UnityEngine;
using UnityEngine.Events;

public class TimedButton : MonoBehaviour
{
    [SerializeField] private float activeDuration = 5f;
    [SerializeField] private UnityEvent OnActivate;
    [SerializeField] private UnityEvent OnDeactivate;
    [SerializeField] private Renderer buttonRenderer;
    [SerializeField] private Color activeColor = Color.green;
    [SerializeField] private Color inactiveColor = Color.red;

    private bool isActive = false;
    private float timer = 0f;

    private void Start()
    {
        if (buttonRenderer != null)
            buttonRenderer.material.color = inactiveColor;
    }

    private void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Deactivate();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null && !isActive)
        {
            Activate();
        }
    }

    private void Activate()
    {
        isActive = true;
        timer = activeDuration;

        OnActivate.Invoke();

        if (buttonRenderer != null)
            buttonRenderer.material.color = activeColor;
    }

    private void Deactivate()
    {
        isActive = false;
        OnDeactivate.Invoke();

        if (buttonRenderer != null)
            buttonRenderer.material.color = inactiveColor;
    }
}