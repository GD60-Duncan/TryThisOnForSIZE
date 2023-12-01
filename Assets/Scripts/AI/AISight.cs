using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class AISight : MonoBehaviour
{
    private RaycastHit2D raycastHit2D;

    
    [SerializeField] private AIBase _aiBase;

    [SerializeField] private LayerMask _layer;

    [SerializeField] private ParticleSystem _particle;

    [SerializeField] private Sprite[] _emoteSprites;

    private bool inRange;

    void Start()
    {
        Debug.Log(_layer + " + ");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.CompareTag("Player"))
       {
            Debug.Log("Here's Scientist");

            //_aiBase.
            
            inRange = true;

       }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
       if(collider.CompareTag("Player"))
       {
            Debug.Log("Gay Mario");
            
            inRange = false;

       }
    }

    void FixedUpdate()
    {
        transform.localScale = new Vector3(GameData.playerMovement.Rigidbody.gameObject.transform.localScale.y, Mathf.Abs(GameData.playerMovement.Rigidbody.gameObject.transform.localScale.x), 1);


        if(inRange)
        {
            
            raycastHit2D = Physics2D.Linecast(transform.position, GameData.PlayerObj.transform.position);

            if(_aiBase.State != AIStates.Chasing)
            {
                _aiBase.State = AIStates.Alerted;
            }
            
            if(raycastHit2D)
            {
                _aiBase.CanSee = raycastHit2D.collider.gameObject.CompareTag("Player");
                
                if(_aiBase.CanSee)
                {
                    if(_aiBase.State == AIStates.Chasing)
                    {
                        _particle.textureSheetAnimation.SetSprite(0, _emoteSprites[(int)_aiBase.State]);
                        return;
                    }

                    if(_aiBase.State == AIStates.Alerted)
                    {
                        _particle.textureSheetAnimation.SetSprite(0, _emoteSprites[(int)_aiBase.State]);
                    }
                    
                    return;
                }

                _aiBase.State = AIStates.Confused;
                _particle.textureSheetAnimation.SetSprite(0, _emoteSprites[(int)_aiBase.State]);
                 return;
                
            }


        }

        _aiBase.CanSee = false;

        if(_aiBase.State != AIStates.Confused)
            {
                _aiBase.State = AIStates.Idle;
            }

        if(_aiBase.State == AIStates.Idle)
        {
            _particle.textureSheetAnimation.SetSprite(0, _emoteSprites[(int)_aiBase.State]);
        }

    }

    void OnDrawGizmos()
    {
        if(Application.isPlaying)
        {
            Debug.DrawLine(transform.position, GameData.PlayerObj.transform.position, Color.blue );
        }
    }
}
