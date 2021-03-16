using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Health
{
    public interface IDamagable
    {
        void TakeDamage(float damage);

        void Destroy();
    }
}
