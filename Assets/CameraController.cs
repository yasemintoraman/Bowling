using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform takipEdilecekNesne;
    public float uzaklik;

    void LateUpdate()
    {
        // Karakterin konumunu takip etmek için kameranýn konumunu güncelle
        transform.position = takipEdilecekNesne.position - takipEdilecekNesne.forward * uzaklik;
    }

}
