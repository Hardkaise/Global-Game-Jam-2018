﻿using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class Board : MonoBehaviour {

        [Serializable]
        public class Count
        {
            public int minimum;
            public int maximum;

            public Count(int min, int max)
            {
                minimum = min;
                maximum = max;
            }
        }
        public int columns = 10;
        public int rows = 10;
        public Count wallCount = new Count(8, 8);
        public Count enemyCount = new Count(2, 5);
        public Count mineCount = new Count(3, 7);

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] enemyTiles;
        public GameObject[] mineTiles;
        public GameObject[] outerWallTiles;

    private Transform boardHolder;
        private List<Vector2> gridPositions = new List<Vector2>();

        void InitialiseList()
        {
            gridPositions.Clear();
            for (int x = 1; x < columns - 1; x++)
            {
                for (int y = 1; y < rows - 1; y++)
                {
                    gridPositions.Add(new Vector2(x, y));
                }
            }
        }
        void BoardSetup()
        {
            boardHolder = new GameObject("Board").transform;
            for (int x = -1; x < columns + 1; x++)
            {
                for (int y = -1; y < rows + 1; y++)
                {
                    GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                    if (x == -1 || x == columns || y == -1 || y == rows)
                        toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];

                    GameObject instance = Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(boardHolder);
                }
            }
        }
        Vector2 RandomPosition()
        {
            int randomIndex = Random.Range(0, gridPositions.Count);
            Vector2 randomPosition = gridPositions[randomIndex];
            gridPositions.RemoveAt(randomIndex);
            return randomPosition;
        }

        void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
        {
            int objectCount = Random.Range(minimum, maximum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector2 randomPosition = RandomPosition();
            GameObject tileChoise = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoise, randomPosition, Quaternion.identity);
        }
        }

        public void SetupScene()
        {
            BoardSetup();
            InitialiseList();

        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        LayoutObjectAtRandom(mineTiles, mineCount.minimum, mineCount.maximum);
        LayoutObjectAtRandom(enemyTiles, enemyCount.minimum, enemyCount.maximum);
    }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        bool check = true;
        foreach (var enemy in enemyTiles)
        {
            var Human = enemy.gameObject.GetComponent<Enemy>();
            if (Human.isWolf == false)
                check = false;
        }
        if (check == true)
        {
            Debug.Log("end");
            Application.Quit();
        }
    }

}
