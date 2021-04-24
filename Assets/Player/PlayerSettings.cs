using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Custom/PlayerSettings", fileName = "PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        public float MoveTime = 1f;
        public AnimationCurve MoveCurve;
    }
}