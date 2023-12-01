using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImage : MonoBehaviour
{

    [SerializeField] private SpriteRenderer[] _spritesToSet;

    [SerializeField] private Image[] _imagesToSet;

    [SerializeField] private SpriteRenderer[] _setterSprites;

    [SerializeField] private Image[] _setterImages;


    void OnEnable()
    {
        if(_spritesToSet!=null)
        {
            int sprites = _spritesToSet.Length;

            for (int i = 0; i < sprites; i++)
            {
                Debug.Log(i);
            }
        }

        if(_imagesToSet!= null)
        {
            int images = _imagesToSet.Length;

            for (int i = 0; i < images; i++)
            {
                _imagesToSet[i].sprite = _setterImages[i].sprite;
            }
        }
    }

}
