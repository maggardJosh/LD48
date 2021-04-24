namespace Player.PlayerState
{
    public class PlayerStateReferences
    {
        public PlayerController Owner { get; }

        public PlayerStateReferences(PlayerController owner)
        {
            Owner = owner;
        }
    }
}