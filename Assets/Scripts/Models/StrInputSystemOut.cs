namespace Models {

    public struct StrInputSystemOut
    {
        public StrInputSystemOut(
            UnityEngine.Vector2 direction,
            UnityEngine.Vector2 look,
            bool isShoot,
            bool isChangeWeapon)
        {
            Direction = direction;
            Look = look;
            IsShoot = isShoot;
            IsChangeWeapon = isChangeWeapon;
        }

        public UnityEngine.Vector2 Direction { get; private set; }
        public UnityEngine.Vector2 Look { get; private set; }
        public bool IsShoot { get; private set; }
        public bool IsChangeWeapon { get; private set; }
    }

}

