using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AudioManager : StaticManager
{
    [SerializeField] private GameObject soundObject;
    public static int activeSoundObjects;
    
    public static AudioManager instance;

    public List<GameObject> soundObjects;

    private SoundObjectControl currentSound;

    [HideInInspector]
    public SoundObjectControl musicSound;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    void Start()
    {

        for (int i = activeSoundObjects - 1; i >= 0 ; i--)
        {
            soundObjects.Add(transform.GetChild(i).gameObject);
            Debug.Log(transform.GetChild(i).gameObject);
        }
        
        
    }

    public void SetNewLimit(int newlimit)
    {
        if(newlimit > activeSoundObjects)
        {
            int amount = newlimit - activeSoundObjects;
            for (int i = amount - 1; i >= 0; i--)
            {
                
                var gameObject = Instantiate(soundObject);
                soundObjects.Add(gameObject); 
            } 
        }

        if(newlimit < activeSoundObjects)
        {
            int amount = newlimit - activeSoundObjects;
            for (int i = amount - 1; i <= 0; i--)
            {
                var Obj = transform.GetChild(activeSoundObjects).gameObject;
                soundObjects.Remove(Obj);
            }
        }
    }

    public SoundObjectControl PlaySound(Vector3 location, SoundData soundData)
    {
        for (int i = activeSoundObjects - 1; i >= 0 ; i--)
        {
            soundObjects[i].TryGetComponent<SoundObjectControl>(out SoundObjectControl compoent);
            compoent.Audio();
            //Debug.Log(compoent);
            if(compoent.AudioIsPlaying == false)
            {
               if(compoent.ReservedForMusic) {continue;}
               
               if(soundData.twoD)
               {
                   compoent.PlaySound2D(soundData.audioClip, soundData.volume, soundData.Priority);
                   return compoent;
               }

               if(soundData.twoD == false)
               {
                   compoent.PlaySound3D(soundData.audioClip, soundData.volume, soundData.Priority, location);
                   return compoent;
               }
            }
        }

        for (int i = activeSoundObjects - 1; i >= 0 ; i--)
        {
            soundObjects[i].TryGetComponent<SoundObjectControl>(out SoundObjectControl compoent);
            compoent.Audio();
            if(compoent.Priority < soundData.Priority)
            {
                if(soundData.twoD)
               {
                   compoent.PlaySound2D(soundData.audioClip, soundData.volume, soundData.Priority);
                   return compoent;
               }

               if(soundData.twoD == false)
               {
                   compoent.PlaySound3D(soundData.audioClip, soundData.volume, soundData.Priority, location);
                   return compoent;
               }
            }

        }

        return currentSound;
    }

    public void PlayMusic(SoundData soundData)
    {
        musicSound.PlaySound2D(soundData.audioClip, soundData.volume, soundData.Priority);
    }

}
