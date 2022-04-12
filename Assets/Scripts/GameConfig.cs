using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameConfig : ScriptableObject
{
    public uint PlayerLives;
    public LevelConfig[] Levels;
}
