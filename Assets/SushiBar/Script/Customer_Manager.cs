
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Manager : MonoBehaviour
{


    [SerializeField]
    List<RectTransform> seat_Transforms = new List<RectTransform>();

    [SerializeField]
    GameObject customer;

    [SerializeField]
    Transform cook_Transform_Parent;

    [SerializeField]
    Sushi_Bar_Time_Check sushi_Bar_Time_Check;

    [SerializeField]
    GameObject close_Start;

    [SerializeField]
    List<GameObject> menus = new List<GameObject>();

    float customer_come_time = 0;
    float random_Customer_Prefab_time = 0;


    public int[] Get_on_Seat()
    {
        return on_Seat;
    }

    int[] on_Seat;



    int seat = 0;

    bool seatCheck = false;

    bool random_Check = false;

    bool close_Check = false;


    int Randoms = 0;

    int random_Customer_Count = 0;

    // Start is called before the first frame update
    void Start()
    {
        on_Seat = new int[seat_Transforms.Count];

        for (int i = 0; i < on_Seat.Length; i++)
        {
            on_Seat[i] = -1;
        }      
    }

    private void OnDisable()
    {
        seat = 0;

        seatCheck = false;

        random_Check = false;

        close_Check = false;

        Randoms = 0;

        random_Customer_Count = 0;

        customer_come_time = 0;

        random_Customer_Prefab_time = 0;

        sushi_Bar_Time_Check.time = 0;

        enabled = false;

    }
    private void OnEnable()
    {
        
    }



    public void Customer_Seat_Check(int _Seat)
    {
        int[] _onSeat = on_Seat;

        for (int i = 0; i < _onSeat.Length; i++)
        {
            if (_onSeat[i] == _Seat)
            {
                _onSeat[i] = -1;
            }
        }
    }

    bool customer_Seat()
    {
        while (true)
        {
            int check = 0;

            for (int i = 0; i < on_Seat.Length; i++)
            {
                if (on_Seat[i] != -1)
                {
                    check++;
                }
            }

            if (check == on_Seat.Length)
            {
                return false;
            }

            // 앉을 자리 인덱스 랜덤으로 구함 

            seat = Random.Range(0, seat_Transforms.Count);

            // 중복 되지 않게 끔 검사 

            for (int i = 0; i < on_Seat.Length; i++)
            {
                if (on_Seat[i] == seat)
                {
                    seatCheck = true;
                    break;
                }

            }

            // 중복됨 다시 돌리기 

            if (seatCheck == true)
            {
                seatCheck = false;
            }

            // 중복 안됨 탈출 

            else
            {

                break;
            }

        }


        if (seatCheck == false)
        {
            // 겹치지 않는 자리 넣기 

            for (int i = 0; i < on_Seat.Length; i++)
            {
                if (on_Seat[i] == -1)
                {
                    on_Seat[i] = seat;
                    return true;
                }
            }
            return false;
        }
        else
        {
            return false;
        }

    }

    void Random_Customer_Prefab()
    {
        if (random_Check == false)
        {
            random_Customer_Count = Random.Range(1, 3);
            random_Check = true;
        }

        if (random_Customer_Count == Randoms)
        {
            return;
        }

        random_Customer_Prefab_time += Time.deltaTime;

        if (random_Customer_Prefab_time > 1)
        {
            random_Customer_Prefab_time = 0;

            Randoms++;
            if (customer_Seat() == true)
            {
                customer.GetComponent<Customer>().Make_Prefab(transform, seat_Transforms[seat], menus, cook_Transform_Parent, seat, Customer_Seat_Check);
            }
        }
    }

    void close()
    {
        if (sushi_Bar_Time_Check.time > 0.38f)
        {
            int temp = 0;

            for (int i = 0; i < on_Seat.Length; i++)
            {
                if (on_Seat[i] == -1)
                {
                    temp++;
                }
            }

            if (temp == on_Seat.Length && close_Check == false)
            {
                close_Start.SetActive(true);
                close_Check = true;

            }
        }

    }

    void Customer_Come_Time()
    {
        customer_come_time += Time.deltaTime;

        if (customer_come_time > 7)
        {
            customer_come_time = 0;
            Randoms = 0;
            random_Check = false;
            random_Customer_Prefab_time = 0;

        }
    }

    // Update is called once per frame
    void Update()
    {
        close();

        if (sushi_Bar_Time_Check.time > 0.3f)
        {        
            return;
        }
      
        Random_Customer_Prefab();
        Customer_Come_Time();
    }
}
