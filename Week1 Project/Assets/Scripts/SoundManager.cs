using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClipRefSO audioClipRefSO;

    public static SoundManager instance { get; private set; }

    void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        DeliveryManager.instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        CuttingCounterManager.OnAnyCut += CuttingCounterManager_OnAnyCut;
        PlayerManager.Instance.OnPickedSomething += Player_OnPickedSomething;
        BaseCounter.OnAnyIngredientPlacedHere += BaseCounter_OnAnyIngredientPlacedHere;
        TrashCounterManager.OnAnyIngredientTrashed += TrashCounterManager_OnAnyIngredientTrashed;
    }

    private void TrashCounterManager_OnAnyIngredientTrashed(object sender, System.EventArgs e)
    {
        TrashCounterManager trashCounter = sender as TrashCounterManager;
        PlaySoundEffect(audioClipRefSO.trash, trashCounter.transform.position);
    }

    private void BaseCounter_OnAnyIngredientPlacedHere(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySoundEffect(audioClipRefSO.ingredientDrop, baseCounter.transform.position);
    }

    private void Player_OnPickedSomething(object sender, System.EventArgs e)
    {
        PlaySoundEffect(audioClipRefSO.ingredientPickup, PlayerManager.Instance.transform.position);
    }

    private void CuttingCounterManager_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounterManager cuttingCounter = sender as CuttingCounterManager;
        PlaySoundEffect(audioClipRefSO.chop, cuttingCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        DeliveryCounterManager deliveryCounter = DeliveryCounterManager.instance;
        PlaySoundEffect(audioClipRefSO.deliveryFailed, deliveryCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounterManager deliveryCounter = DeliveryCounterManager.instance;
        PlaySoundEffect(audioClipRefSO.deliverySuccess, deliveryCounter.transform.position);
    }

    void PlaySoundEffect(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    void PlaySoundEffect(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    public void PlayFootstepSound(Vector3 position, float volume)
    {
        PlaySoundEffect(audioClipRefSO.footstep, position, volume);
    }
}
