using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public List<Enemy> enemy;
    public List<Color> colorList;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject ground;
    float minX, minZ, maxX, maxZ;

    // Use this for initialization

    private void Awake()
    {
        CalculateBounds();  //calculate the boundaries of plane to generate random values for positions of spawning
        InitialiseSpawnData(); //initialise GameObject Data from enemy.json
    }

    private void InitialiseSpawnData()
    {
        string jsonString = JsonController.LoadJsonFile("enemy.json");
        EnemyList enemyList = JsonUtility.FromJson<EnemyList>(jsonString);  //parsing from JSon

        //read and store into a dynamic list
        foreach (Enemy item in enemyList.item)
        {
            enemy.Add(item);
        }

        //Create color values from JSon to Unity.Color
        for (int i = 0; i < enemy.Count; i++)
        {
            Color tempColor = new Color(enemy[i].material[0], enemy[i].material[1], enemy[i].material[2], enemy[i].material[3]);
            colorList.Add(tempColor);
        }
    }

    void Start () {


    }

    private void CalculateBounds(){
        //Get the mesh component and the bounds to calculate the min and max of both X and Y
        Mesh planeMesh = ground.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;


        //Calculate MinX, MaxX, minZ, MaxY
        minX = ground.transform.position.x - ground.transform.localScale.x * bounds.size.x * 0.5f + 1.5f;
        maxX = -minX;
        minZ = ground.transform.position.z - ground.transform.localScale.z * bounds.size.z * 0.5f + 1.5f;
        maxZ = -minZ;
    }

    

    public void StartGame(){

        //Start Spawning
        for (int i = 0; i < 10; i++)
        {
            int cubeSelector = Random.Range(0, enemy.Count);  //Since current enemy.Count is only 2, high probability of same choice
            GameObject tempObject = Instantiate(cube1, GetRandomPosition(), Quaternion.identity); //instantiate the prefab
            tempObject.GetComponent<MeshRenderer>().material.color = colorList[cubeSelector];//switch color 
            tempObject.GetComponent<CubeController>().hitPoints = enemy[cubeSelector].hitPoints; //switch hitPoints
        }
        
    }

    Vector3 GetRandomPosition()
    {

        //Calculate a random position
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX),
                                 1.5f,
                                 Random.Range(minZ, maxZ));                     
        return randomPos;
    }
	
	
}
