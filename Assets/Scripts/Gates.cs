using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private int score = 0;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
        else
        {
            Debug.LogWarning("Gates object doesn't have a collider!", this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;

            Debug.Log($"Score: {score}");

            Destroy(other.gameObject);
        }
    }

    public void ResetScore()
    {
        score = 0;
        Debug.Log("Score reset to 0");
    }

    public int GetScore()
    {
        return score;
    }
}
