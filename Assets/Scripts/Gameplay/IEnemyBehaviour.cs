using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyBehaviour
{
    void OnDeath();
    void OnDamage();
    void OnLineReached();
}
