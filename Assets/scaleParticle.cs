using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleParticle : MonoBehaviour
{

    ParticleSystem particleEffect;
    // Start is called before the first frame update
    void Start()
    {
        particleEffect = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    public void expandEffect()
    {   
        for (float i=0f;i<=0.15f; i = i+0.05f)
        {
            particleEffect.startLifetime =  i;
        }
        
    }
}
