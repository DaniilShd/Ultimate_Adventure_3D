using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MultiButtonPuzzle : MonoBehaviour
{
    [SerializeField] private int requiredButtons = 3;
    [SerializeField] private UnityEvent OnAllButtonsPressed;
    [SerializeField] private GameObject progressUI;
    [SerializeField] private Image progressFill;

    private int pressedButtons = 0;
    private float[] buttonTimers;

    void Start()
    {
        buttonTimers = new float[requiredButtons];
        progressUI.SetActive(false);
    }

    void Update()
    {
        // Обновляем таймеры для кнопок
        bool allActive = true;
        float totalProgress = 0f;

        for (int i = 0; i < requiredButtons; i++)
        {
            if (buttonTimers[i] > 0)
            {
                buttonTimers[i] -= Time.deltaTime;
                totalProgress += 1f;
            }
            else
            {
                allActive = false;
            }
        }

        // Обновляем UI прогресса
        if (totalProgress > 0)
        {
            progressUI.SetActive(true);
            progressFill.fillAmount = totalProgress / requiredButtons;
        }
        else
        {
            progressUI.SetActive(false);
        }

        // Проверяем условие победы
        if (allActive && pressedButtons >= requiredButtons)
        {
            OnAllButtonsPressed.Invoke();
        }
    }

    public void RegisterButtonPress(int buttonIndex)
    {
        if (buttonIndex < requiredButtons && buttonTimers[buttonIndex] <= 0)
        {
            pressedButtons++;
            buttonTimers[buttonIndex] = 5f; // 5 секунд активности
        }
    }
}