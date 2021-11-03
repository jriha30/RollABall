using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking_Sound : MonoBehaviour
{
    public playerController player;
    public AudioSource walkingSound;
    [SerializeField]
    float offsetFloor;
    [SerializeField]
    float offsetCeiling;
    float initialPitch;

    // Start is called before the first frame update
    void Start()
    {
        initialPitch = walkingSound.pitch;
    }

    void Update()
    {
        PlaySound();
    }

    public void PlaySound()
    {
        float tempPitch = initialPitch;
        tempPitch = tempPitch + Random.Range(offsetFloor, offsetCeiling);
        if(GetComponent<playerController>().isSprinting)
        {
            tempPitch = tempPitch * 1.5f;
        }
        walkingSound.pitch = tempPitch;
        if(player.isMoving && !walkingSound.isPlaying)
        {
            //if(!walkingSound.isPlaying)
            //{
            //    return;
            //}
            //if(player.isSprinting)
            //{
            //    walkingSound.pitch *= player.sprintMult;
            //}
            walkingSound.Play();
        }
        if(!player.isMoving || player.isFalling)
        {
            walkingSound.Stop();
        }
    }
}
