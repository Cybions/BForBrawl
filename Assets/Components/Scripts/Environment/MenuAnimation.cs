using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField]
    private List<Material> ListSkybox;

    [SerializeField]
    private Material CurrentSkybox;

    float RotationSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, ListSkybox.Count);
        CurrentSkybox = ListSkybox[rand];
        RenderSettings.skybox = CurrentSkybox;
        RenderSettings.skybox.SetFloat("_Rotation", Random.Range(0, 360));
    }



    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationSpeed);
    }
}
