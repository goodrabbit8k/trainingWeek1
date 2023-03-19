using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipRefSO : ScriptableObject
{
    public AudioClip[] chop;
    public AudioClip[] deliverySuccess;
    public AudioClip[] deliveryFailed;
    public AudioClip[] footstep;
    public AudioClip[] ingredientDrop;
    public AudioClip[] ingredientPickup;
    public AudioClip stoveSizzle;
    public AudioClip[] trash;
    public AudioClip[] warning;
}
