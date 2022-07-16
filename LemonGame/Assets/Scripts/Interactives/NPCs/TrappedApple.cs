using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DialogueEditor;

public class TrappedApple : MonoBehaviour
{
    public TMP_Text interactText;

    public NPCConversation firstConvo;

    public enum Convorsations
    {
        First,
    }
    public Convorsations convorsation;

    public bool firstConvoEntered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interaction()
    {
        switch (convorsation)
        {
            case Convorsations.First:
                {
                    if (!firstConvoEntered)
                    {
                        interactText.gameObject.SetActive(true);
                        interactText.text = "E: Interact?";

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            firstConvoEntered = true;
                            ConversationManager.Instance.StartConversation(firstConvo);
                        }
                    }
                }
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactText.gameObject.SetActive(false);
        }
    }
}
