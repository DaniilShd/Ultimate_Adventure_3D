using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyTrigger : MonoBehaviour
{

    [SerializeField] public UnityEvent Enter;
    [SerializeField] public GameObject messageBox;
    [SerializeField] public int amountKeyActive;

    private bool isActive;
    protected void OnTriggerEnter(Collider other)
    {
        if (isActive) return;
       
        Bag bag = other.GetComponent<Bag>();

        if (bag != null)
        {
            if (bag.DrawKey(amountKeyActive) == true)
            {
                Enter.Invoke();
                isActive = true;
            }
            else
            {
                messageBox.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        messageBox.SetActive(false);
    }
}
