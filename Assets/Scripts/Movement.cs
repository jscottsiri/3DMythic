using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Transform mover;
    public Transform location;
    public GameObject Target;
    public bool Moved;
    public bool repeat;
    public Pathfinding paths;
    Queue<GameObject> Turn;
    public GameObject CurrentCharacter;
    List<GameObject> CharList;
    List<GameObject> CharList2;
    public GameObject Char1;
    public GameObject Char2;
    public GameObject closeobstacle;
    public List<GameObject> EnemyList;
    public List<GameObject> ObstacleList;
    float roll;
    int state = 1;
    int enemycount=0;
    void Awake()
    {
        CurrentCharacter = Char1;
    }
    void Start()
    {
        Turn = new Queue<GameObject>();
        CharList = new List<GameObject>();
        CharList2 = new List<GameObject>();
        GameObject[] Characters = GatherCharacters();
        
        Moved = true;
        repeat = true;
        
    }

    void Update()
    {
        if (repeat)
        {
            GetAll();
            
            repeat = false;
        }
        if (mover.CompareTag("Enemy"))
        {    
            switch (state)
            {
                case 1:
                    Debug.Log("Move");
                    EnemyList = CharacterCheck(mover.position, 4f, EnemyList);
                    if (EnemyList.Count > 0)
                    {
                        foreach (GameObject i in EnemyList)
                        {
                            if (mover.position.x > i.transform.position.x)
                            {
                                mover.position = new Vector3(mover.position.x - 1, mover.position.y, mover.position.z);
                            }
                            else if (mover.position.x < i.transform.position.x)
                            {
                                mover.position = new Vector3(mover.position.x + 1, mover.position.y, mover.position.z);
                            }
                            if (mover.position.z > i.transform.position.z)
                            {
                                mover.position = new Vector3(mover.position.x, mover.position.y, mover.position.z-1);
                            }
                            else if (mover.position.z < i.transform.position.z)
                            {
                                mover.position = new Vector3(mover.position.x + 1, mover.position.y, mover.position.z+1);
                            }
                        }
                    }
                    roll = Random.Range(1f, 100f);
                    if (roll >= 50)
                    {
                        state = 2;
                    }
                    else if (roll < 50)
                    {
                        state = 3;
                    }
                    break;
                case 2:
                    Debug.Log("Attack");
                    EnemyList = CharacterCheck(mover.position, 2f, EnemyList);
                    if (EnemyList.Count > 0)
                    {
                        foreach (GameObject i in EnemyList)
                        {
                            if (i != null)
                            {
                                i.GetComponent<CharStats>().HP -= 10;
                                if (i.GetComponent<CharStats>().HP <= 0)
                                {
                                    EnemyList.Remove(i);
                                    Destroy(i);
                                }
                            }
                        }
                    }
                    roll = Random.Range(1f, 100f);
                    if (roll >= 75)
                    {
                        state = 1;
                    }
                    else if (roll < 75)
                    {
                        state = 3;
                    }
                    break;
                case 3:
                    Debug.Log("Destroy Obstacle");
                    ObstacleList = ObstacleCheck(mover.position, 2f, ObstacleList);
                    if (ObstacleList.Count > 0)
                    {
                        foreach (GameObject i in ObstacleList)
                        {
                            i.GetComponent<ObstacleDurability>().Durability -= 10;
                            if (i.GetComponent<ObstacleDurability>().Durability <= 0)
                            {
                                ObstacleList.Remove(i);
                                Destroy(i);
                            }
                        }
                    }
                    roll = Random.Range(1f, 100f);
                    if (roll >= 75)
                    {
                        state = 1;
                    }
                    else if (roll < 75)
                    {
                        state = 2;
                    }
                    break;

            }
            paths.seeker = OrderControl(Turn).transform;
            mover = paths.seeker;
            CurrentCharacter = mover.gameObject;
            Moved = true;

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            closeobstacle = ObstaclePush(mover.position, 1f, closeobstacle);
            if (closeobstacle != null)
            {
                if ((mover.position.z > closeobstacle.transform.position.z))
                {
                    closeobstacle.transform.position = new Vector3(closeobstacle.transform.position.x, closeobstacle.transform.position.y, closeobstacle.transform.position.z - 1f);
                }
                if ((mover.position.z < closeobstacle.transform.position.z))
                {
                    closeobstacle.transform.position = new Vector3(closeobstacle.transform.position.x, closeobstacle.transform.position.y, closeobstacle.transform.position.z + 1f);
                }
                if ((mover.position.x > closeobstacle.transform.position.x))
                {
                    closeobstacle.transform.position = new Vector3(closeobstacle.transform.position.x - 1f, closeobstacle.transform.position.y, closeobstacle.transform.position.z);
                }
                if ((mover.position.x < closeobstacle.transform.position.x))
                {
                    closeobstacle.transform.position = new Vector3(closeobstacle.transform.position.x + 1f, closeobstacle.transform.position.y, closeobstacle.transform.position.z);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Moved = true;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
            {
                if (hit.collider.tag == "Ground")
                {
                    int Dist=(int)Vector3.Distance(mover.position,hit.point);
                    if (Dist < mover.gameObject.GetComponent<CharStats>().Movenum(mover.gameObject.GetComponent<CharStats>().Agility))
                    {
                        Target.transform.position = hit.point;
                        Move(mover, location, Moved);
                        paths.seeker = OrderControl(Turn).transform;
                        mover = paths.seeker;
                        CurrentCharacter = mover.gameObject;
                    }
                    
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            EnemyList = RadiusCheck(mover.position, 2f, EnemyList);
            if (EnemyList.Count > 0)
            {
                foreach (GameObject i in EnemyList)
                {
                    i.GetComponent<Enemy>().HP -= 10;
                    if (i.GetComponent<Enemy>().HP <= 0)
                    {
                        EnemyList.Remove(i);
                        Destroy(i);
                        GetAll();

                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ObstacleList = ObstacleCheck(mover.position, 2f, ObstacleList);
            if (ObstacleList.Count > 0)
            {
                foreach (GameObject i in ObstacleList)
                {
                    i.GetComponent<ObstacleDurability>().Durability -= 10;
                    if (i.GetComponent<ObstacleDurability>().Durability <= 0)
                    {
                        ObstacleList.Remove(i);
                    }
                }
            }
        }
    }
    public static void Move(Transform character, Transform location, bool moved)
    {
        Vector3 tomove = new Vector3();
        tomove.x=Mathf.Floor(location.position.x) + 0.5f;
        tomove.z= Mathf.Floor(location.position.z) + 0.5f;
        tomove.y = 0;
        Mathf.Floor(location.position.z);
        character.position = tomove;
        moved = true;
    }
   
    GameObject[] GatherCharacters()
    {
        GameObject[] Characters = GameObject.FindGameObjectsWithTag("Character");
        
        return Characters;
    }
    GameObject[] GatherEnemies()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return Enemies;
    }
    GameObject GetFastest(List<GameObject> CharList)
    {
        int maxSpeed = 0;
        GameObject fastest = new GameObject();
        foreach (GameObject i in CharList)
        {
            if (i.GetComponent<CharStats>().Agility > maxSpeed)
            {
                maxSpeed = i.GetComponent<CharStats>().Agility;
                fastest = i;
            }
        }

        return fastest;
    }
    void GetAll()
    {
        GameObject[] Characters = GatherCharacters();
        foreach (GameObject i in Characters)
        {
            CharList.Add(i);
        }
        foreach (GameObject i in Characters)
        {
            Turn.Enqueue(GetFastest(CharList));
            CharList.Remove(GetFastest(CharList));
        }
        GameObject[] Enemies = GatherEnemies();
        foreach (GameObject i in Enemies)
        {
            CharList2.Add(i);
        }
        foreach (GameObject i in Enemies)
        {
            Turn.Enqueue(GetFastest(CharList2));
            CharList2.Remove(GetFastest(CharList2));
        }
    }
    void CombatOrder(List<GameObject> CharList, Queue<GameObject> Order)
    {
        List<GameObject> AllCharacters = CharList;
        foreach (GameObject i in AllCharacters)
        {
            Order.Enqueue(GetFastest(CharList));
            Debug.Log(GetFastest(CharList).name);
            CharList.Remove(GetFastest(CharList));
        }
    }
    public GameObject OrderControl(Queue<GameObject> Order)
    {
        GameObject Temp;
        Temp = Order.Dequeue();
        Order.Enqueue(Temp);
        return Temp;
    }
    public List<GameObject> RadiusCheck(Vector3 center, float radius, List<GameObject> EnemyList)
    {
        Collider[] inradius = Physics.OverlapSphere(center, radius);
        foreach (Collider i in inradius)
        {
                if (i.CompareTag("Enemy"))
                {
                    Debug.Log("In Range");
                    EnemyList.Add(i.gameObject);

                }
        }
        return EnemyList;
    }
    public List<GameObject> CharacterCheck(Vector3 center, float radius, List<GameObject> EnemyList)
    {
        Collider[] inradius = Physics.OverlapSphere(center, radius);
        foreach (Collider i in inradius)
        {
            if (i.CompareTag("Character"))
            {
                Debug.Log("In Range");
                EnemyList.Add(i.gameObject);

            }
        }
        return EnemyList;
    }
    List<GameObject> ObstacleCheck(Vector3 center, float radius,List<GameObject> ObstacleList) {
        Collider[] inradius = Physics.OverlapSphere(center, radius);
        foreach (Collider i in inradius) {
            if (i.CompareTag("Obstacle"))
                {
                Debug.Log("In Range");
                ObstacleList.Add(i.gameObject);
                }
            }
        return ObstacleList;
            
        }
    GameObject ObstaclePush(Vector3 center, float radius, GameObject Obstacle)
    {
        Collider[] inradius = Physics.OverlapSphere(center, radius);
        foreach (Collider i in inradius)
        {
            if (i.CompareTag("Obstacle"))
            {
                Debug.Log("In Range");
                return i.gameObject;
            }
        }
        return null;

    }

}

    
