using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner; // khởi tạo cái này = null
    Animator animator;
    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }    
        else
        {
            animator.SetBool("isAttacking", false);
        }    
    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        
        foreach(AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(IsCloseEnough)// nếu miss tất cả các vòng for ở cái close enough này
            {
                myLaneSpawner = spawner; // thì sẽ ko vào đoạn này
            }    
        }
        // nên myLaneSpawner ra đây vẫn có thể null,
        //Nên check khác null trước rồi hãy gọi thuộc tính
    }
    private bool IsAttackerInLane()
    {

        //if (myLaneSpawner == null)
        //{
        //    return true;
        //}
        if (myLaneSpawner.transform.childCount <= 0) // khác null thì mới .tranform ko thì return luôn như ở trên
        {
            return false;
        }
        else
        {
            return true;
        } 
            
    }    
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
       
    }    
}
