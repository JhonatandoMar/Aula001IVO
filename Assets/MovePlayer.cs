using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _moveX;
    [SerializeField] float _moveY;

    [SerializeField] float _jumpF;
    [SerializeField] bool isFacingRight;

    [SerializeField] bool _checkGround;  

    // Start is called before the first frame update
    void Start()
    {
        //_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveX = Input.GetAxisRaw("Horizontal");
        _moveY = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(_moveX * _speed, _rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && _checkGround == true)
        {
            _rb.AddForce(new Vector2(0, _jumpF*10));
        }
        
        if (_moveX > 0 && isFacingRight == false) 
        {
            Flip();
        }
        else if (_moveX < 0 && isFacingRight == true) 
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        // Flip collider over the x-axis

    }
}
