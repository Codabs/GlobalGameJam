using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class camerapostpro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float hauteur;

    public Volume volume;
    public VolumeProfile volumeProfile1;
    public VolumeProfile volumeProfile2;
    void Update()
    {
        if (transform.position.y <hauteur)
        {
            if (volume.profile != volumeProfile1)
                volume.profile = volumeProfile1;
        }
        else
        {
            if (volume.profile != volumeProfile2)
                volume.profile = volumeProfile2;
        }
    }
}
