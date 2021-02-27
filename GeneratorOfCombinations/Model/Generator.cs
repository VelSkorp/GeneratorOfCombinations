using System.Collections.Generic;
using System.Text;

namespace GeneratorOfCombinations
{
	public static class Generator
	{
		public static List<string> Generate(List<string> set, int combinationSize)
		{
			var combinations = new List<string>();
			var combinationIndices = new int[combinationSize];
			var combination = new StringBuilder();

			for (int j = 0; j < combinationSize; j++)
			{
				combination.Append($"{set[j]} ");
				combinationIndices[j] = j;
			}

			combinations.Add(combination.ToString());
			combination.Clear();

			while (NextCombination(combinationIndices, set.Count - 1))
			{
				for (int i = 0; i < combinationSize; ++i)
				{
					combination.Append($"{set[combinationIndices[i]]} ");
				}

				combinations.Add(combination.ToString());
				combination.Clear();
			}

			return combinations;
		}

		private static bool NextCombination(int[] combination, int n)
		{
			int combinationSize = combination.Length;

			for (int i = combinationSize - 1; i >= 0; --i)
			{
				if (combination[i] < n - combinationSize + i + 1)
				{
					combination[i]++;

					for (int j = i + 1; j < combinationSize; ++j)
					{
						combination[j] = combination[j - 1] + 1;
					}

					return true;
				}
			}

			return false;
		}
	}
}