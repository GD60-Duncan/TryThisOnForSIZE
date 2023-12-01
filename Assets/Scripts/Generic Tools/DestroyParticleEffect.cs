using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DestroyParticleEffect : MonoBehaviour
{
    [Header("Particle")]
    [SerializeField] private GameObject _particleEffect;

    [SerializeField] private SpriteRenderer _spriteRend;

    [Header("Logic")]

    [SerializeField] private bool _onStart;

    [SerializeField] private bool _sampleSpriteColor;

    [SerializeField] private bool _useRendererColor;
    
    // Start is called before the first frame update

    private ParticleSystem particle;

    void Start()
    {
        if(_onStart)
        {
            DestroyObject();
        }
    }

    public void DestroyObject ()
    {
       particle = Instantiate(_particleEffect, gameObject.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();

       if(_useRendererColor)
       {
            particle.startColor = _spriteRend.color;
       }

    //    #if UNITY_EDITOR

    //    DestroyImmediate(this.gameObject);

    //    #endif

       Destroy(gameObject);
    }

   
}
