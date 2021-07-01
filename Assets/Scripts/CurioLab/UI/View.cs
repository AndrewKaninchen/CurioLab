using UnityEngine;

namespace CurioLab.UI
{
    public class View : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
            transform.SetAsLastSibling();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}