using UnityEngine;
using UnityEngine.UI;

public class ObjectiveHint : MonoBehaviour
{
    [SerializeField] private string objectiveText = "Соберите 3 ключа и доберитесь до замка";
    [SerializeField] private GameObject hintPanel;
    [SerializeField] private Text hintText;
    [SerializeField] private float showTime = 3f;

    void Start()
    {
        hintText.text = objectiveText;
        Invoke("ShowHint", 1f);
    }

    void ShowHint()
    {
        hintPanel.SetActive(true);
        Invoke("HideHint", showTime);
    }

    void HideHint()
    {
        hintPanel.SetActive(false);
    }

    // Можно вызвать из других скриптов при изменении цели
    public void UpdateObjective(string newObjective)
    {
        objectiveText = newObjective;
        hintText.text = objectiveText;
        ShowHint();
    }
}