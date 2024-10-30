using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
/// <summary>
/// Prefab de zombie
/// </summary>
public class Zombie : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private float _walkingSpeed = 2f;
    [SerializeField] private ParticleSystem _zombieParticule;
    [SerializeField] private List<AudioClip> _zombieSounds;
    private Animator _animator;
    private Rigidbody2D _body;
    private AudioSource _source;

    private bool _healed = false;
    private bool _walking = false;
    private int _randomNess; //vitesse random assigné au zombie
    

    // Start is called before the first frame update
    void Start()
    {
        _randomNess = UnityEngine.Random.Range(1, 5);

        //récupérer le héros
        //Récupérer composant 
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_healed) return;
            _walking = true;
            _animator.SetBool("Walking", _walking);
        // Get the current position of the prefab
        Vector2 newPosition = transform.position;
       
        // Move the prefab only along the Y-axis
        newPosition.y -= (_randomNess *  _walkingSpeed) * Time.deltaTime; // Time.deltaTime ensures smooth movement across different frame rates
        // Update the position of the prefab
        transform.position = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cupcake")
        {   
            collision.gameObject.SetActive(false);
            Heal();
        }
    }
    public void Heal()
    {
        GameManager.Instance.ZombieLeft--;
        _healed = true;
        
        _animator.SetTrigger("Healed");
        _body.bodyType = RigidbodyType2D.Static;
        _zombieParticule.Stop();
        GetComponent<Collider2D>().enabled = false;
        
    }
    public void PlayRandomSoundFromList()
    {
        //Récupérer l'index aléatoire d'un des clips
        int randomZombieIndex = UnityEngine.Random.Range(1, _zombieSounds.Count);
        _source.PlayOneShot(_zombieSounds[randomZombieIndex]);
    }

}
