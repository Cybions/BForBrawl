using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCStats", menuName = "BFB/CharacterStats", order = 1)]
public class CharacterStats : ScriptableObject
{
    public string CharacterName;
    public float MaxLife;
    public int MaxAmmo;
    public float ReloadingSpeed;
}
