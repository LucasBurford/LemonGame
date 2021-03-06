using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraInteraction : MonoBehaviour
{
    public Image crossHair;
    public TMP_Text interactText;
    public Color defaultColour;
    public Color enemyColour;
    public Color interactColour;
    public LayerMask interactLayer;

    public float rayLength;
    public bool enemyInSights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength, interactLayer))
        {
            HandleHit(hit);
        }
        else
        {
            crossHair.color = defaultColour;
            interactText.gameObject.SetActive(false);
        }
    }

    private void HandleHit(RaycastHit hit)
    {
        GameObject go = hit.collider.gameObject;

        switch (go.tag)
        {
            case "Enemy":
                {
                    crossHair.color = enemyColour;
                }
                break;
            case "Grapple":
                {
                    crossHair.color = interactColour;

                    if (Input.GetMouseButtonDown(0))
                    {
                        //FindObjectOfType<PlayerAbilities>().StartGrapple(go.transform.position);
                    }
                }
                break;
            case "Lever":
                {
                    interactText.gameObject.SetActive(true);
                    interactText.text = "E: Pull Lever?";

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        go.SendMessageUpwards("OnInteract");
                        interactText.gameObject.SetActive(false);
                    }
                }
                break;
        }
    }
}
