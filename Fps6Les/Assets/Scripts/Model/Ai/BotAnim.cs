using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

    public class BotAnim : MonoBehaviour
    {
        private Rigidbody _rg;
        private Animator _anim;
        private int _mouseButton = (int)MouseButton.LeftButton;

        void Start()
        {
            _rg = GetComponent<Rigidbody>();
            _anim = GetComponent<Animator>();
        }

        void Update()
        {
            var speed = Mathf.Abs(_rg.velocity.magnitude);
            _anim.SetFloat("Speed", speed);


            if (Input.GetMouseButton(_mouseButton)) _anim.SetTrigger("Fire");
            if (Input.GetKey(KeyCode.Space)) _anim.SetTrigger("Jump");
        }

    }
}


