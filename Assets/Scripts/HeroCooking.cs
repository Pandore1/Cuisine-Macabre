using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCooking : MonoBehaviour
{

    [SerializeField] private List<AudioClip> _toolSounds;
    [SerializeField] private Animator _ovenAnimator;
    private Animator _heroAnimator;
    private AudioSource _heroSource;
    //Action du personnage
    private bool _heating = false;
    private bool _whipping = false;
    private bool _measuring = false;
    // Start is called before the first frame update
    void Start()
    {
        _heroSource = GetComponent<AudioSource>();
        _heroAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _heating = Input.GetKey(KeyCode.DownArrow);
        _whipping = Input.GetKey(KeyCode.UpArrow);
        _measuring = Input.GetKey(KeyCode.Space);
        _heroAnimator.SetBool("Whipping", _whipping);
        _heroAnimator.SetBool("Measuring", _measuring);
        _heroAnimator.SetBool("Heating", _heating);
        _ovenAnimator.SetBool("Heating", _heating);

        if (!_whipping && !_measuring)
        {
            _heroSource.Stop(); 
        }
    }

    public void PlaySoundFromList(int type)
    {
        //Récupérer l'index aléatoire d'un des clips
        _heroSource.PlayOneShot(_toolSounds[type]);
    }
    public void Mistake()
    {
        _heroAnimator.SetTrigger("Mistake");
    }

}
