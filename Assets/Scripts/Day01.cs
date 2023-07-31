using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day01 : MonoBehaviour
{
    public TextAsset inputFile;
    ArrayList inputNumbers;
    GameObject flicker;
    float nextActionTime = 0.0f;
    public float period = 0.1f;
    void Start()
    {
        string[] rawData = inputFile.text.Split('\n');
        inputNumbers = new ArrayList();
        foreach (string line in rawData) {
            float number;
            float.TryParse(line, out number);
            inputNumbers.Add(number);
        }
        SolvePart1();
        SolvePart2();
        CreateBarStack();
        flicker = GameObject.Find("Flicker");
    }

    void CreateBarStack() {
        float origin = 0;
        foreach (float width in inputNumbers) {
            GameObject bar = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bar.transform.SetParent(this.transform);
            bar.transform.position = new Vector3(width / 2, origin, 0);
            bar.transform.localScale = new Vector3(Mathf.Abs(width), 1, 1);
            origin += 1.2f;
        }
    }

    void SolvePart1() {
        int solution = 0;
        foreach (float number in inputNumbers) {
            solution += (int) number;
        }
        print("Part 1: " + solution);
    }

    void SolvePart2() {
        HashSet<int> uniqueSums = new HashSet<int>();
        int idx = 0;
        int sum = 0;
        float number;
        do {
            number = (float) inputNumbers[idx];
            sum += (int) number;
            //print(sum);
            idx = (idx + 1) % inputNumbers.Count;
        } while(number != 0 ? uniqueSums.Add(sum) : true);
        print("Part 2: " + sum);
    }

    void Update() {
        if (Time.time > nextActionTime) {
            nextActionTime = Time.time + period;
            int idx = (int) Time.time;
            float newScale = flicker.transform.localScale.y + (float) inputNumbers[idx];
            flicker.transform.position = new Vector3(flicker.transform.position.x, newScale / 2, flicker.transform.position.z);
            flicker.transform.localScale = new Vector3(1, Mathf.Abs(newScale), 1);
        }
    }
}
