using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CurioLab.UI
{
	public class LobbyView : MonoBehaviour
	{
		[Header("UI References (Self)")]
		public Button exploreButton;
		public Button labButton;
		public Button shopButton;
		[FormerlySerializedAs("charactersButton")] public Button characterListButton;
		public Button inventoryButton;

		[Header("UI References (External)")] 
		public CharacterListView characterListView;
		public ExploreView exploreView;
		public InventoryView inventoryView;
		
		public void Initialize()
		{
			characterListView.Initialize(GameController.instance.characters);
			characterListButton.onClick.AddListener(characterListView.Show);

			exploreView.Initialize(characterListView);
			exploreButton.onClick.AddListener(exploreView.Show);

			inventoryView.Initialize();
			inventoryButton.onClick.AddListener(inventoryView.Show);
		}
	}
	
}