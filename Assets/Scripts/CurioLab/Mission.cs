using System.Collections.Generic;
using UnityEngine;

namespace CurioLab
{
    [CreateAssetMenu(menuName = "CurioLab/Mission", fileName = "Mission", order = 0)]
    public class Mission : ScriptableObject
    {
        public float duration;
        public List<Item> reward;
    }
}