using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Custom/PlayerSettings", fileName = "PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        public float MoveTime = 1f;
        public AnimationCurve MoveCurve;
        public float BeginMoveTime = .3f;
        public AnimationCurve BeginMoveCurve;

        public float MaxMoveTime = 2f;
        public float MaxBeginMoveTime = 1f;
        
        public LayerMask collideMask;
        public LayerMask bubbleMask;
    }
}