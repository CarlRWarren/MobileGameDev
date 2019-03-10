using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName ="Game Objects/Weapon")]
public class WeaponStats : ScriptableObject
{
    public string weaponName = "Name";
    public string description = "Description";
    public float strength = 100.0f;
    public Sprite sprite = null;
}
