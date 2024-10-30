using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private float _walkingSpeed = 1f;
    [SerializeField] private float _brakePower = 3f;
    
   
   
    [Header("Attacking")]
    [SerializeField] private GameObject _cupcakePrefab;
    [SerializeField] private float _throwingPower = 10f;
    [SerializeField] private Rigidbody2D _cupcakeRB;
    [SerializeField] private AudioClip _cupcakeClip;
    private Animator _animator;
    private Rigidbody2D _body;
    private AudioSource _source;

    //Mouvement variable
    private float _dirX = 0f;
    private bool _walking = false;
    private bool _dead = false;
    private bool _shouldThrow = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Cupcake"+GameManager.Instance.CakeMade);
        //Récupéré les components de Hero
        _body = GetComponent<Rigidbody2D>(); 
        _animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();

        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_dead) return;

        _shouldThrow = Input.GetMouseButtonDown(0);
        _dirX = Input.GetAxisRaw("Horizontal");

        _walking = _dirX != 0;
        _animator.SetBool("Walking", _walking);

        if (_shouldThrow)
        {
            _walking = false;
            
            if (GameManager.Instance.CakeMade > 0)
            {
                _animator.SetTrigger("Throw");
                GameObject newCupcake = Instantiate(_cupcakePrefab, transform.position, Quaternion.identity);
                Rigidbody2D rb =newCupcake.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // Set velocity in Y direction
                    rb.velocity = new Vector2(0f, _throwingPower);
                }
                _source.PlayOneShot(_cupcakeClip);
                Destroy(newCupcake, 3f);
                GameManager.Instance.CakeMade -= 1;
            }
        }

        //S'il ne lance pas
        if (!_shouldThrow)
        {

      
            float scaleX = transform.localScale.x;
            if (_dirX > 0)
            {
                scaleX = 1f;
            }
            else if (_dirX < 0)
            {
                scaleX = -1f;
            }
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }
  
    private void FixedUpdate()
    {

        if (_walking)
        {   //Applique la force pour bouger le personnage
            _body.AddForce(Vector2.right*_dirX * _walkingSpeed, ForceMode2D.Impulse);
            //limiter la vitesse
            _body.velocity = new Vector2(Mathf.Clamp(_body.velocity.x, -_walkingSpeed, _walkingSpeed), _body.velocity.y);

        }
        else if(_dirX==0)
        {
            _walking = false;
            //Freiner stoper
            
            _body.velocity = new Vector2(Mathf.Lerp(_body.velocity.x, 0, _brakePower * Time.deltaTime),_body.velocity.y);
        }
    }
}
