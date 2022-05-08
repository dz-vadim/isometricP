using System.Collections;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public AudioClip gun;
    public AudioClip pickUpJewel;
    public AudioClip damage;
    public void GunSound() 
    {
        StartCoroutine(SoundPlay(gun, gun.length));
    }
    public void JewelSound() 
    {
        StartCoroutine(SoundPlay(pickUpJewel, pickUpJewel.length));
    }
    public void DamageSound() 
    {
        StartCoroutine(SoundPlay(damage, damage.length));
    }
    IEnumerator SoundPlay(AudioClip audioClip, float time)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = audioClip;
        audio.pitch = Random.Range(.9f, 1f);
        audio.Play();
        yield return new WaitForSeconds(time);
        Destroy(audio);
    }
   
}
