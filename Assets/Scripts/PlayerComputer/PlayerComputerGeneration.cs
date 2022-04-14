using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComputerGeneration : MonoBehaviour
{
    public GameObject computerPlayerPrefab;

    private float timer;

    private float TIME_DELTA_LOWER_RANGE = 3f;
    private float TIME_DELTA_UPPER_RANGE = 1f;

    private float X_LOWER_RANGE = 0.5f;
    private float X_UPPER_RANGE = 8f;

    private float Y_LOWER_RANGE = 0.5f;
    private float Y_UPPER_RANGE = 2f;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            float randomX = GetRandomX();
            float randomY = GetRandomY();
            Instantiate(computerPlayerPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity, this.transform);
            timer = GetRandomTime();
        }
    }

    private float GetRandomTime()
    {
        return GetRandomBetweenRange(TIME_DELTA_LOWER_RANGE, TIME_DELTA_UPPER_RANGE);
    }

    private float GetRandomX()
    {
        return GetRandomBetweenRange(X_LOWER_RANGE, X_UPPER_RANGE);
    }

    private float GetRandomY()
    {
        return GetRandomBetweenRange(Y_LOWER_RANGE, Y_UPPER_RANGE);
    }

    private float GetRandomBetweenRange(float lowerRange, float upperRange)
    {
        return Random.Range(lowerRange, upperRange);
    }
}
