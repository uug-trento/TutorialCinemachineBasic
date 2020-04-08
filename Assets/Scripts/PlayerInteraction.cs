using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Cinemachine;


public class PlayerInteraction : MonoBehaviour
{
    public Animator animator;
    public PlayableDirector playableDirector;
    public TimelineAsset timeline;
    public CinemachineFreeLook playerCam;
    public CinemachineStateDrivenCamera statedriven;
    //public 
    private bool isPlaying;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "buttonTrigger")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("isOpen", true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "enemyTrigger")
        {
            if (animator.GetBool("isOpen") == true)
            {
                Debug.Log("Deactivating");
                statedriven.gameObject.SetActive(false);
                Debug.Log(statedriven.gameObject.activeSelf);
                playableDirector.Play();

            }
        }
    }

    private void OnEnable()
    {
        playableDirector.stopped += OnPlayableDirectorStopped;

    }
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (playableDirector == aDirector)
            statedriven.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        playableDirector.stopped -= OnPlayableDirectorStopped;
    }
}
