

public class AllConst 
{
    public struct Tags
    {
        public const string Wall = "Walls";
    }

    public struct BulletAnimation
    {
        public const string Destroy = "DestroyBullet";
        public const string Pickup = "PickupBullet";
        public const string Spawn = "SpawnBullet";
    }

    public struct PlayerAnimation
    {
        public const string Damage = "GetDamage";
    }

    public struct EnemyAnimation
    {
        public const string Spawn = "Spawn";
        public const string Damage = "GetDamage";
        public const string ChaseBool = "isChase";
        public const string Attack = "Attack";
        public const string Dead = "Dead";
        // public const string Idle = "Idle";
        // public const string Run = "Run";
    }
}
