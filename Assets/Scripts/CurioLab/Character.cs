using UnityEngine;

namespace CurioLab
{
    [CreateAssetMenu(menuName = "CurioLab/Character", fileName = "New Character")]
    public class Character : ScriptableObject
    {
        public Sprite image;
        public new string name;
    }
}