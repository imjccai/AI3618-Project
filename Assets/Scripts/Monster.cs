using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    public static UnityAction onMonsterDead;

    public AudioClip deathSound;
    void Start()
    {
        Vector3 target = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(target);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            onMonsterDead?.Invoke();
            Destroy(gameObject);
        }
    }
}

