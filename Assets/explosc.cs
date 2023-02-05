using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosc : Singleton<explosc>
{
    public ParticleSystem ps;
    public void lvlup()
    {
        ps.Play();
    }
}
