using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController cc;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationSpeed = 20f;

    void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	void Update () {
        Move();
        Rotate();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Token>())
        {
            UIManager.S.AddScore(10);
            Destroy(col.gameObject);
        }
            
    }

    private void Move()
    {
        cc.Move(transform.forward * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0) * rotationSpeed * Time.deltaTime);
    }


}
