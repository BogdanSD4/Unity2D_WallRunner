using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _up;
    [SerializeField] private BoxCollider2D _down;
    [SerializeField] private BoxCollider2D _right;
    [SerializeField] private BoxCollider2D _left;
}
