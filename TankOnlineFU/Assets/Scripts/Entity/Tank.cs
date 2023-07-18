using UnityEditor;
using UnityEngine;

namespace Entity
{


    public class Tank
    {
        public Direction Direction { get; set; }
        public string Name { get; set; }
        public int Point { get; set; }
        public int Hp { get; set; }
        public bool IsUpgradeBullet { get; set; }
        public bool IsHaveArmor { get; set; }

        public GUID Guid { get; set; }
        public Vector3 Position { get; set; }
        public bool isActive { get; set; }

        public void Move(float x, float y)
        {
            this.Position = new Vector3(x, y, 0);
        }
    }
}