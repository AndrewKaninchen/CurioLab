using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CurioLab.UI
{
	public class CharacterListView : View
	{
		[Header("UI References")]
		[SerializeField] private GameObject holder;
		[SerializeField] private Button returnButton;
		
		[Header("UI Templates")]
		[SerializeField] private GameObject characterPreviewTemplate;
		
		private Action<Character> onCharacterPicked;

		public void Initialize(List<Character> characters)
		{
			foreach (Transform child in holder.transform) Destroy(child.gameObject);
			
			AddCharacters(characters);
			returnButton.onClick.AddListener(Hide);
		}

		private void CharacterPicked(Character character)
		{
			onCharacterPicked?.Invoke(character);
			Debug.Log("uer");
		}

		public void AddCharacter(Character character)
		{
			var characterPreview = Instantiate(characterPreviewTemplate, holder.transform).GetComponent<CharacterPreview>();
			characterPreview.GetComponent<Image>().sprite = character.image;
			characterPreview.character = character;
			characterPreview.button.onClick.AddListener(() =>
			{
				CharacterPicked(character);
			});
		}

		public void AddCharacters(IEnumerable<Character> characters)
		{
			foreach (var character in characters) AddCharacter(character);
		}

		
		
		public async Task<Character> DisplayAndPick()
		{
			Show();

			var completionSource = new TaskCompletionSource<Character>();
			
			var setResult = new Action<Character>(x => completionSource.SetResult(x));
			onCharacterPicked += setResult;

			void SetCanceled() => completionSource.SetResult(null);
			returnButton.onClick.AddListener(SetCanceled);
			
			await completionSource.Task;
			
			Hide();
			onCharacterPicked -= setResult;
			returnButton.onClick.RemoveListener(SetCanceled);

			return completionSource.Task.Result;
		}
	}
}