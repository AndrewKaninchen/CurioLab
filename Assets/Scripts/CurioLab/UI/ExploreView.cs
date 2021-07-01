using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CurioLab.UI
{
	public class ExploreView : View
	{
		[Header("UI References")]
		[SerializeField] private Button returnButton;
		[SerializeField] private List<Button> characterButtons;
		[SerializeField] private Button startMissionButton;
		private Character[] characters = new Character[4];

		private CharacterListView characterListView;

		public void Initialize(CharacterListView characterListView)
		{
			returnButton.onClick.AddListener(Hide);
			this.characterListView = characterListView;

			for (var i = 0; i < characterButtons.Count; i++)
			{
				var characterButton = characterButtons[i];
				var i1 = i;
				characterButton.onClick.AddListener(() => ChangeCharacter(i1));
			}
			
			startMissionButton.onClick.AddListener(StartMission);
		}

		private async void ChangeCharacter(int index)
		{
			var c = await characterListView.DisplayAndPick();
			characters[index] = c;
			var a = characterButtons[index].GetComponent<Image>();
			Debug.Log(a);
			Debug.Log(c);
			a.sprite = c.image;
		}
		
		private void StartMission()
		{
			GameController.instance.StartMission(null, characters.ToList());
			Hide();
		}
	}
}