using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SeanWelton.GameSettings;

[ExecuteAlways]
public class CharacterGenerator : MonoBehaviour
{
    [SerializeField] private List<Character> characterList = new List<Character>();

    [Range(1, 20)]
    [SerializeField] private int count = 5;

    [Min(1)]
    [SerializeField] private int charactersToKeep = 3;

    public IReadOnlyList<Character> Characters => characterList;

    public static event Action<List<Character>> OnCharactersCreated;

    public void GenerateCharacters(bool triggerEvent = true)
    {
        GenerateRandomCharacters(triggerEvent);
    }

    [EasyButtons.Button]
    public List<Character> GenerateRandomCharacters(bool triggerEvent = true)
    {
        characterList.Clear();

        for (int i = 0; i < count; i++)
        {
            Character character = CharacterFactory.CreateRandomCharacter();
            SetInitialDescription(character);

            characterList.Add(character);
        }

        characterList = characterList
            .OrderByDescending(character => character.Stats.Sum)
            .Take(charactersToKeep)
            .ToList();

        characterList.Shuffle();

        if (triggerEvent)
        {
            OnCharactersCreated?.Invoke(characterList);
        }

        return characterList;
    }

    private void SetInitialDescription(Character character)
    {
        if (Settings.Gameplay.UseAiDescriptions)
        {
            character.SetDescription("Generating description...");
        }
        else
        {
            string prompt = CharacterPromptBuilder.BuildPrompt(character);
            character.SetDescription(prompt);
        }
    }
}