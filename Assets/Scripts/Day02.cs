using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day02 : MonoBehaviour
{
    public TextAsset inputFile;
    // Start is called before the first frame update
    void Start()
    {
        SolvePart1();
        SolvePart2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SolvePart1() {
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
        print(threeOfAKind * twoOfAKind);
    }
    void SolvePart2() {

    }
}
