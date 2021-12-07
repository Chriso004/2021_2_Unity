using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_generator : MonoBehaviour
{
    //미로를 자동 생성하는 스크립트
    public GameObject wall_tile;
    public GameObject road_tile;
    public GameObject tree;
    public GameObject goal;
    private int size;
    private int[,] map;

    //맵 탐색시 방향   
    enum DIRECTION
    {
        LEFT = 1,
        UP,
        RIGHT,
        DOWN
    };

    //맵 구성요소
    enum MAP_FLAG
    {
        WALL,
        EMPTY,
        VISITED,
        GOAL
    };

    //난이도에 따라 맵 초기설정
    public void map_initializing(int size)
    {
        this.size = size;
        this.map = new int[size, size];
        this.map[size - 2, size - 2] = (int)MAP_FLAG.GOAL;

        generate_map(1, 1);

        int last_path = Random.Range(0, 2);

        if (last_path == 0)
            this.map[size - 3, size - 2] = 1;
        else
            this.map[size - 2, size - 3] = 1;
    }

    //맵 생성시 좌표값이 범위 내에 있는지 확인
    public bool in_range(int x, int y)
    {
        return (x > 0 && x < size - 1) && (y > 0 && y < size - 1);
    }

    //맵 초기설정 완료 후 길 생성
    public void generate_map(int x, int y)
    {
        int next_x = x, next_y = y;
        int[] direction = { 1, 2, 3, 4 };
        direction = get_random(direction, direction.Length);

        this.map[y, x] = (int)MAP_FLAG.VISITED;

        for (int i = 0; i < 4; i++)
        {
            if (direction[i] == (int)DIRECTION.LEFT)
            {
                next_x = x - 2;
                next_y = y;
            }

            else if (direction[i] == (int)DIRECTION.UP)
            {
                next_x = x;
                next_y = y - 2;
            }

            else if (direction[i] == (int)DIRECTION.RIGHT)
            {
                next_x = x + 2;
                next_y = y;
            }

            else if (direction[i] == (int)DIRECTION.DOWN)
            {
                next_x = x;
                next_y = y + 2;
            }

            if (in_range(next_x, next_y) && this.map[next_y, next_x] == (int)MAP_FLAG.WALL)
            {
                generate_map(next_x, next_y);

                if (next_y != y)
                    this.map[(next_y + y) / 2, next_x] = (int)MAP_FLAG.EMPTY;
                else
                    this.map[next_y, (next_x + x) / 2] = (int)MAP_FLAG.EMPTY;

                this.map[next_y, next_x] = (int)MAP_FLAG.EMPTY;
            }
        }
    }

    //맵 랜덤 생성시 필요한 난수 함수
    public int[] get_random(int[] direction, int size)
    {
        int i, r, temp;

        for (i = 0; i < size - 1; ++i)
        {
            r = i + (Random.Range(0, size - i));
            temp = direction[i];
            direction[i] = direction[r];
            direction[r] = temp;
        }
        return direction;
    }


    //맵 설정 후 타일 오브젝트 배치
    public void setTile()
    {
        float start_x = 0.0f;
        float start_z = 0.0f;
        
        map[1, 1] = (int)MAP_FLAG.GOAL;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (map[i, j] != (int)MAP_FLAG.WALL)
                {
                    GameObject road_floor = Instantiate(road_tile) as GameObject;
                    road_floor.transform.parent = GameObject.FindWithTag("Map").transform;
                    road_floor.transform.position = new Vector3(start_x + (i * 10.0f), 0, start_z + (j * 10.0f));

                    int r = Random.Range(0, 4);
                    road_floor.transform.eulerAngles = new Vector3(0, 90 * r, 0);
                }

                else if (map[i, j] == (int)MAP_FLAG.WALL)
                {
                    GameObject wall = Instantiate(tree) as GameObject;
                    GameObject wall_floor = Instantiate(wall_tile) as GameObject;

                    wall.transform.parent = GameObject.FindWithTag("Map").transform;
                    wall.transform.position = new Vector3(start_x + (i * 10.0f), 1.0f, start_z + (j * 10.0f));

                    wall_floor.transform.parent = GameObject.FindWithTag("Map").transform;
                    wall_floor.transform.position = new Vector3(start_x + (i * 10.0f), 0, start_z + (j * 10.0f));
                }

                if (map[i, j] == (int)MAP_FLAG.GOAL)
                {
                    GameObject goal = Instantiate(this.goal) as GameObject;
                    goal.transform.parent = GameObject.FindWithTag("Map").transform;
                    goal.transform.position = new Vector3(start_x + (i * 10.0f), 1.0f, start_z + (j * 10.0f));
                    if (map[i - 1, j] == (int)MAP_FLAG.WALL)
                        goal.transform.localEulerAngles = new Vector3(0, -90, 0);
                }
            }
        }
    }

    //초기설정 값들
    void Start()
    {
        //Game_Manager에 있는 사이즈로 맵 크기 설정
        int map_size = Game_Manager.instance.size;
        map_initializing(map_size);
        setTile();
    }
}
