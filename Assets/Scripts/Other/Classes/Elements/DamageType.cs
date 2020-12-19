using UnityEngine;

namespace Toweristika.Other
{
    public class DamageType : ScriptableObject
    {
        public override bool Equals(object other)
        {
            return other.GetType() == this.GetType();
        }
    }
}