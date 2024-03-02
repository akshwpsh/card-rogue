using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Player  instance;
    
    public Transform aim;
    
    private bool isMoveable = true;
    
    private Vector3 originalPosition;
    private void Awake()
    {
        Player.instance = this;
        aim = GameObject.Find("aim").transform;
    }

    void Start()
    {
        SetAim();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2.down);
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
            Move_to_Enemy();
    }

    void Move(Vector2 direction)
    {
        if(isMoveable == false)
            return;
        
        if (Grid.instance.IsInsideGrid(transform.position +
                                       new Vector3(direction.x, direction.y, 0) * Grid.instance.cellSize))
        {
            transform.Translate(direction * Grid.instance.cellSize);
        }
        
        SetAim();  
    }

    void Melee_Attack_Target(Transform target)
    {
        Vector2 originalPosition = transform.position;
        transform.DOMove(target.position, 0.5f).OnComplete(() =>
        {
            transform.DOMove(originalPosition, 0.5f);
        });
    }

    public void Melee_Attack(int damage)
    {
        if(isMoveable == false)
            return;
        isMoveable = false;
        Vector3 originalPosition = transform.position;
        transform.DOMove(aim.position, 0.2f).OnComplete(() =>
        {
            transform.DOMove(originalPosition, 0.2f).OnComplete(() => isMoveable = true);
        });
    }

    public void Move_to_Enemy()
    {
        if(isMoveable == false)
            return;
        isMoveable = false;
        originalPosition = transform.position;
        transform.DOMove(aim.position - (Vector3.right * 0.5f), 0.2f);
    }
    
    public void Return_to_Original_Position()
    {
        if(isMoveable == false)
            return;
        isMoveable = false;
        transform.DOMove(originalPosition, 0.2f).OnComplete(() => isMoveable = true);
    }
    
    
    void SetAim()
    {
        var grid = Grid.instance;
        aim.position = transform.position + Vector3.right * (grid.cellSize * grid.width/2);
    }
    
}
