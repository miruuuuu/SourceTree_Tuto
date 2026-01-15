using System.Collections;
using UnityEngine;

public class StorageBox : MonoBehaviour, ITriggerEvent
{
    private Animator anim;

    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject storageUI;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void InteractionEnter()
    {
        anim.SetTrigger("Open");
        StartCoroutine(OpenRoutine());
    }

    public void InteractionExit()
    {
        anim.SetTrigger("Close");
        StartCoroutine(CloseRoutine());
    }

    IEnumerator OpenRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        InventoryUI.SetActive(true);
        storageUI.SetActive(true);
    }

    IEnumerator CloseRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        storageUI.SetActive(false);
        InventoryUI.SetActive(false);
    }

}
