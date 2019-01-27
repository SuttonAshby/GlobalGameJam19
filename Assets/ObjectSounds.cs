using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSounds : MonoBehaviour
{
    public List<AudioClip> Clips;
    private AudioSource _source;
    [Range(-80, 0)]
    public float Volume = 0f;
    [Range(-20, 0)]
    public float RandomVolume = 0f;
    [Range(0, 12)]
    public float Pitch = 0f;
    
    [Range(0f, 1f)]
    public float RandomPitch = 0f;
    
    public bool Loop = false;
    public float Blend = 1f;
    private static float twelfthRootOfTwo = Mathf.Pow(2, 1.0f / 12);

    void Awake()
    {
        _source = GetComponent<AudioSource>();
        if (_source == null)
        {
            _source = gameObject.AddComponent<AudioSource>();
        }
    }
void Start()
    {
        _source.volume = DecibelToLinear(Volume);
        _source.pitch = St2pitch(Pitch);
        _source.loop = Loop;
        _source.spatialBlend = Blend;
       
    }

    // Update is called once per frame
    
    public void PlayRandomSound()
    {
        if (Clips.Count == 0)
        {
            
            Debug.LogWarning("AudioData does not contain any AudioClips.");
          
        }
        int index = 0;
        if (Clips.Count > 1)
        {
            //RandomizePitch();
            //RandomizeVolume();
            index = Random.Range(0, Clips.Count - 1);
            _source.PlayOneShot(Clips[index]);

        }
       
    }
    public void RandomizePitch()
    {
        _source.pitch = St2pitch(Pitch) - Random.Range(RandomPitch, 1);
    }
    public void RandomizeVolume()
    {
        _source.volume = DecibelToLinear(Volume) - Random.Range(0, DecibelToLinear(RandomVolume));
    }
   

    public float St2pitch(float st)

    {
        return Mathf.Clamp(Mathf.Pow(twelfthRootOfTwo, st), 0f, 4f);
    }

    public float Pitch2st(float pitch)
    {
        return Mathf.Log(pitch, twelfthRootOfTwo);
    }
    public float DecibelToLinear(float dB)
    {

        if (dB > -80)
            return Mathf.Clamp01(Mathf.Pow(10.0f, dB / 20.0f));
        else
            return 0;
    }

    public float LinearToDecibel(float linear)

    {
        if (linear > 0)
            return Mathf.Clamp(20.0f * Mathf.Log10(linear), -80f, 0f);
        else
            return -80.0f;
    }
}
