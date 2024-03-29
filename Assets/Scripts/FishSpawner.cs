using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public static FishSpawner instance;

    private GameObject[] prefabsFishes;
    private Transform myTransform;
    private PlayerController playerController;
    private int randomFish;
    private float randomFishXPosition;
    [SerializeField] private float _delaySpawnFishTime;

    public float DelaySpawnFishTime { set => _delaySpawnFishTime = value; }

    public void GetFishes()
    {
        prefabsFishes = GameObject.FindGameObjectsWithTag("Fish");
        foreach (var prefab in prefabsFishes)
        {
            prefab.SetActive(false);
            prefab.transform.parent = myTransform;
        }
    }

    public void StartSpawnFishes()
    {
        StartCoroutine(nameof(SpawnFishes));
    }

    public void StopSpawnFishes()
    {
        StopCoroutine(nameof(SpawnFishes));
    }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void SpawnFish()
    {
        randomFish = Random.Range(0, prefabsFishes.Length);
        randomFishXPosition = Random.value;
        float newX = Camera.main.ViewportToWorldPoint(new Vector3(randomFishXPosition, 0, 0)).x;

        if (newX < playerController.LeftViewportLimit)
            newX = playerController.LeftViewportLimit;
        if (newX > playerController.RightViewportLimit)
            newX = playerController.RightViewportLimit;

        GameObject tempFishPrefab = Instantiate
        (
            prefabsFishes[randomFish],
            new Vector3
            (
                newX,
                Camera.main.ViewportToWorldPoint(Vector3.one).y + 2f,
                0
            ),
            Quaternion.identity
        );

        tempFishPrefab.SetActive(true);
    }

    IEnumerator SpawnFishes()
    {
        yield return new WaitForSeconds(2);

        while (true)
        {
            SpawnFish();
            yield return new WaitForSeconds(_delaySpawnFishTime);
        }
    }
}
