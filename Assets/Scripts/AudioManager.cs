using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clip -----------")]

    public AudioClip background;
    public AudioClip death;
    //public AudioClip checkpoint;
    public AudioClip portalIn;
    public AudioClip running;
    public AudioClip jumpLand;
    public AudioClip jumpSound;
    public AudioClip itemEquipment;
    public AudioClip axeSound;
    public AudioClip pickaxeSound;


    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
