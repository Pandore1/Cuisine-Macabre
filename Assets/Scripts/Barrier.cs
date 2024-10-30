using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Barrier : MonoBehaviour
{
    [SerializeField] private Animator _heroAnimator;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Zombie")
        {
            collider.gameObject.SetActive(false);
            _heroAnimator.SetTrigger("Hit");
            GameManager.Instance.LifeScript.LoseLife();
            GameManager.Instance.ZombieLeft--;
        }
    }

}
