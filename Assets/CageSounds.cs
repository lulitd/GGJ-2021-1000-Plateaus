using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageSounds : MonoBehaviour
{
  [SerializeField]private AudioSource source;
  [SerializeField]private AudioClip shakeCLip; 
  public void PlayOneShot()
  {
    source.PlayOneShot(shakeCLip);
  }
}
