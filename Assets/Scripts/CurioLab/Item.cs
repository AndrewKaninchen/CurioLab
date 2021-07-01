using UnityEngine;

namespace CurioLab
{
    [CreateAssetMenu(menuName = "CurioLab/Item", fileName = "New Item")]
    public class Item : ScriptableObject
    {
        public ItemCategory category;
        public new string name;
        public Sprite image;
    }
}