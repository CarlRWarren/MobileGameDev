using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Target", menuName = "Game Objects/Target")]
public class TargetData : ScriptableObject
{
    public int score = 100;
    public float scale = 1.0f;
    public float force = 1.0f;
    public Material material = null;
    public AudioClip audioClip = null;
}
