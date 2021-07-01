using UnityEngine;
using UnityEngine.UI;

namespace CurioLab.UI
{
	public class InventoryView : View
	{
		[Header("UI References")]
		[SerializeField] private Button returnButton;
		[SerializeField] private GameObject holder;
		
		[Header("UI Templates")]
		[SerializeField] private GameObject itemPreviewTemplate;
		public void Initialize()
		{
			returnButton.onClick.AddListener(Hide);
		}

		public override void Show()
		{
			base.Show();
			foreach (Transform t in holder.transform) Destroy(t.gameObject);

			foreach (var item in GameController.instance.inventory)
			{
				var a = Instantiate(itemPreviewTemplate, holder.transform);
				a.GetComponent<Image>().sprite = item.image;
			}
		}
	}
}