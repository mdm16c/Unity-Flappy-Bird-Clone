using UnityEngine;
using System.Collections;

public class columnPoolScript : MonoBehaviour 
{
	public GameObject columnPrefab;
	public int columnPoolSize = 5;
    public float columnMax = 3.5f;
	public float spawnRate = 3f;
	public float columnMin = -1f;
	private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2 (-15,-25);
	private int currentColumn = 0;
	private float spawnXPosition = 10f;
	private float timeSinceLastSpawned;

	void Start()
	{
		timeSinceLastSpawned = 0f;
		columns = new GameObject[columnPoolSize];
		for(int i = 0; i < columnPoolSize; i++) {
			columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}

	void Update() {
		timeSinceLastSpawned += Time.deltaTime;
		if (!gameControllerScript.instance.gameOver && timeSinceLastSpawned >= spawnRate) {	
			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range(columnMin, columnMax);
			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			currentColumn ++;
			if (currentColumn >= columnPoolSize) {
				currentColumn = 0;
			}
		}
	}
}