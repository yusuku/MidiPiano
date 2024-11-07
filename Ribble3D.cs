using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ribble3D : MonoBehaviour
{
    public GameObject cube;
    GameObject[] cubes;
    public Transform parent;
    public float springConstant = 10f;
    public float naturalLength = 1f;
    Vector3 baseline = Vector3.zero;
    private Vector3[] velocities;
    float mass=10f;
    // Start is called before the first frame update
    void Start()
    {
        int length = 50;
        cubes = new GameObject[length];
        velocities = new Vector3[length];
        for (int i = 0; i < length; i++)
        {
            
                var obj=Instantiate(cube,new Vector3(i,0,0), Quaternion.identity);
                cubes[i] = obj;
            
        }
        cubes[20].transform.position += new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            Vector3 force = Vector3.zero;
            var Pi = cubes[i].transform.position;
            // バネの力（隣接キューブとの相互作用）
            if (i > 0)
            {
                
                var Pim1 = cubes[i - 1].transform.position;
                Vector3 springForceLeft = springConstant * (Vector3.Distance(Pi, Pim1))*(Vector3.Dot(Vector3.up,(Pim1- Pi))*Vector3.up);
                
                force += springForceLeft;
               
            }
            if (i < cubes.Length - 1)
            {
             
                var Pip1 = cubes[i + 1].transform.position;
                Vector3 springForceRight = springConstant * (Vector3.Distance(Pi, Pip1)) * (Vector3.Dot(Vector3.up, (Pip1 - Pi)) * Vector3.up);
                force += springForceRight;
            }
             // ベースへの引き寄せ力（重力を下向きに作用させる）
            force += springConstant*(new Vector3(0,-Pi.y,0));
            

            // 加速度計算
            Vector3 acceleration = force / mass;

            // 速度と位置の更新
            velocities[i] += acceleration * Time.deltaTime;
            cubes[i].transform.position += velocities[i] * Time.deltaTime;
        }
    }
}
