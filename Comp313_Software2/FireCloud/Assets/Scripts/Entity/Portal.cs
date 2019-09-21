using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireCloud.Managers;

public class Portal : MonoBehaviour
{
    public Portal Exit;
    public float enterCooldown = 1;
    public bool IsActive = false;
    public bool EnableEnter = false;
    public AudioClip SFX;

    private void Start()
    {
        EnableEnter = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && EnableEnter && Exit != null)
        {
            StartCoroutine(StartCooldown());
            AudioManager.Instance.PlaySFX(SFX);
            other.transform.position = Exit.transform.position;
        }
    }

    public void StartEnterCooldown()
    {
        StartCoroutine(StartCooldown());
    }

    IEnumerator StartCooldown()
    {
        this.EnableEnter = false;
        Exit.EnableEnter = false;
        yield return new WaitForSeconds(enterCooldown);
        this.EnableEnter = true;
        Exit.EnableEnter = true;
    }
}
