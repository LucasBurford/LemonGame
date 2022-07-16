using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAttacks : MonoBehaviour
{
    public PlayableDirector attackAnimation;

    public float attackResetTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<AudioManager>().Play("SwordSwipe1");
            FindObjectOfType<Lightsaber>().colliderActive = true;
            attackAnimation.Play();
            StartCoroutine(WaitToTurnOffCollider());
        }
    }

    IEnumerator WaitToTurnOffCollider()
    {
        yield return new WaitForSeconds(attackResetTime);
        FindObjectOfType<Lightsaber>().colliderActive = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "TrappedApple")
        {
            FindObjectOfType<TrappedApple>().Interaction();
        }
    }
}
