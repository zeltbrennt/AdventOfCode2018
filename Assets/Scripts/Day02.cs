using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day02 : MonoBehaviour
{
    public TextAsset inputFile;
    void Start()
    {
        print("Part1 " + SolvePart1());
        print("Part2 " + SolvePart2());
    }

    int SolvePart1() {
        int twoOfAKind = 0;
        int threeOfAKind = 0;
        foreach (string line in inputFile.text.Split('\n')) {
            Dictionary<char, int> charcounter = new Dictionary<char, int>();
            foreach (char c in line.ToCharArray()) {
                if (!charcounter.TryAdd(c, 1)) {
                    charcounter[c]++;
                }
            }
            if (charcounter.ContainsValue(3)) threeOfAKind++;
            if (charcounter.ContainsValue(2)) twoOfAKind++;
        }
        return (threeOfAKind * twoOfAKind);
    }
    string SolvePart2() {
        string[] lines = inputFile.text.Split('\n');
        for (int i = 0; i < lines.Length - 1; i++) {
            for (int j = i + 1; j < lines.Length - 1; j++) {
                int difference = lines[i].Length - 1;
                int idx = 0;
                for (int c = 0; c < lines[i].ToCharArray().Length - 1; c++) {
                    if (lines[i][c] == lines[j][c]) difference--;
                    else idx = c;
                }
                if (difference == 1) return lines[i].Remove(idx, 1);
            }
        }
        return null;
    }
}
