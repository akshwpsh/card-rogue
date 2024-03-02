using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance;
    
    public int width;
    public int height;
    public float cellSize;
    
    public GameObject cellPrefab;
    public GameObject playerPrefab;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int x = -width / 2; x < (width % 2 == 0 ? width / 2 : width / 2 + 1); x++)
        {
            for (int y = -height / 2; y < (height % 2 == 0 ? height / 2 : height / 2 + 1); y++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(x + 0.5f * ((width + 1) % 2), y + 0.5f * ((height + 1) % 2), 0) * cellSize, Quaternion.identity);
                cell.name = "Cell " + (x + 0.5f * ((width + 1) % 2)) + ", " + (y + 0.5f * ((height + 1) % 2));

                // 색상 설정
                SpriteRenderer renderer = cell.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    if (x < 0)
                    {
                        renderer.color = Color.blue;
                    }
                    else
                    {
                        renderer.color = Color.red;
                    }
                }

                cell.transform.parent = transform;
            }
        }

        SpawnPlayer();
    }


    public void SpawnPlayer()
    {
        float offsetWidth = ((width + 1) % 2) * cellSize * 0.5f;
        float offsetHeight = ((height + 1) % 2) * cellSize * 0.5f;
        GameObject player = Instantiate(playerPrefab, new Vector3(-offsetWidth, offsetHeight, 0), Quaternion.identity);
    }

    
    public bool IsInsideGrid(Vector3 position)
    {
        float halfWidth = width * cellSize / 2;
        float halfHeight = height * cellSize / 2;
        float offsetWidth = ((width + 1) % 2) * cellSize * 0.5f;
        float offsetHeight = ((height + 1) % 2) * cellSize * 0.5f;

        return position.x > (-halfWidth - offsetWidth) + cellSize && position.x <= 0 && 
               position.y >= (-halfHeight - offsetHeight) && position.y <= (halfHeight - offsetHeight);
    }
    
}
