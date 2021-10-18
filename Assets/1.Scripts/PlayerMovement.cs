using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;

    private Transform tr;
    private Animator anim;
    private Rigidbody rigid;
    private Vector3 movement;
    int floorMask;

    void Awake()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        PlayerMove(h, v);
        Turning();
        PlayerAnimation(h, v);
    }

    private void PlayerMove(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rigid.MovePosition(transform.position + movement);
    }

    private void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, floorMask))
        {
            Vector3 playerToMouse = hit.point - tr.position;
            playerToMouse.y = 0;
            Quaternion rot = Quaternion.LookRotation(playerToMouse);
            rigid.MoveRotation(rot);
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);
    }

    private void PlayerAnimation(float h, float v)
    {
        anim.SetBool("isWalking", h != 0 || v != 0);
    }
}
