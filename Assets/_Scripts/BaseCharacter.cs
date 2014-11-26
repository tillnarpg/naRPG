using UnityEngine;
using System.Collections;
using System;				//added to acces the enum class

public class BaseCharacter : MonoBehaviour
{
    private string _name;
    private int _gender;

    public void Awake()
    {
        _name = String.Empty;
        _gender = 0;

    }

    //getters & setters
    public string Name { get { return _name; } set { _name = value; } }
    public int Gender { get { return _gender; } set { _gender = value; } }
    

}
