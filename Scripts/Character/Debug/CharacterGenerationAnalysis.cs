using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class CharacterGenerationAnalysis : MonoBehaviour
{
    [SerializeField] private CharacterGenerator generator;
    [SerializeField, Range(1000, 100000)] private int iterations = 1000;

    private List<Character> characters = new List<Character>();

    private Coroutine sampleSetGeneration = null;



    [EasyButtons.Button]
    private void GenerateSampleSet()
    {
        if (sampleSetGeneration != null)
            return;

        characters.Clear();
        sampleSetGeneration = StartCoroutine(GenerateSampleSetAsync());
    }

    private IEnumerator GenerateSampleSetAsync()
    {
        if (generator == null)
            yield break;

        for (int i = 1; i <= iterations; i++)
        {
            characters.AddRange(generator.GenerateRandomCharacters(false));
            yield return null;

            if (i % 500 == 0)
            {
                UnityEngine.Debug.Log($"[Analysis] {i} / {iterations} iterations done...");
            }
        }

        Debug.Log("[Analysis] Process successful!");
        sampleSetGeneration = null;
    }

    [EasyButtons.Button]
    private void LogTraits()
    {
        Dictionary<string, int> counter = new Dictionary<string, int>();
        foreach (NarrativeTrait trait in TraitGenerator.traits)
        {
            counter.Add(trait.Name, 0);
        }
        foreach (Character character in characters)
        {
            foreach (NarrativeTrait trait in character.Traits)
            {
                counter[trait.Name]++;
            }
        }

        StringBuilder sb = new StringBuilder($"[Analysis] Trait Counts for {characters.Count} generated characters with {TraitGenerator.traits.Count} individual traits:\n");
        foreach (NarrativeTrait trait in TraitGenerator.traits)
        {
            sb.AppendLine($"{trait.Name}:\t\t{counter[trait.Name]} ({(counter[trait.Name] / (float)characters.Count * 100).ToString("0.0")} %)");
        }
        Debug.Log(sb.ToString());
    }

    [EasyButtons.Button]
    private void LogOccupations()
    {
        Dictionary<string, int> counter = new Dictionary<string, int>();
        foreach (NarrativeOccupation occupation in OccupationGenerator.occupations)
        {
            counter.Add(occupation.Name, 0);
        }
        foreach (Character character in characters)
        {
            counter[character.Occupation.Name]++;
        }

        StringBuilder sb = new StringBuilder($"[Analysis] Occupation Counts for {characters.Count} generated characters with {OccupationGenerator.occupations.Count} individual occupations:\n");
        foreach (NarrativeOccupation occupation in OccupationGenerator.occupations)
        {
            sb.AppendLine($"{occupation.Name}:\t\t{counter[occupation.Name]} ({(counter[occupation.Name] / (float)characters.Count * 100).ToString("0.0")} %)");
        }
        Debug.Log(sb.ToString());
    }

}