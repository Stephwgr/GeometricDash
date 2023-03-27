using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public ParticleSystem ps_ground;


    public void PlayPsGround()
    {
        ps_ground.Play();
    }

    public void StopPsGround()
    {
        ps_ground.Stop();
    }
}
