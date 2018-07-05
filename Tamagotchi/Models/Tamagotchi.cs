using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{

  public class Lifeform
  {
    private string _name;
    private long _uid;
    private int _hunger;
    private int _restfulness;
    private int _social;

    private static long lastId = 0;
    private static List<Lifeform> _instances = new List<Lifeform>(){};

    public Lifeform(string name)
    {
      _name = name;
      _hunger = 100;
      _restfulness = 100;
      _social = 100;
      _uid = lastId;
      lastId++;
    }

    public string GetName()
    {
      return _name;
    }

    public bool isHungry()
    {
      return (_hunger < 25);
    }

    public bool isSleepy()
    {
      return (_restfulness < 25);
    }

    public bool isLonely()
    {
      return (_social < 25);
    }

    public long GetId()
    {
      return _uid;
    }

    public void Save()
    {
      _instances.Add(this);
    }

    public void Play()
    {
      _social+=50;
      if(_social>100)
      {
        _social=100;
      }
    }

    public void Sleep()
    {
      _restfulness+=50;
      if(_restfulness>100)
      {
        _restfulness=100;
      }
    }

    public void Feed()
    {
      _hunger+=50;
      if(_hunger>100)
      {
        _hunger=100;
      }
    }

    public static List<Lifeform> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Lifeform Find(long Id)
    {
      foreach(Lifeform tama in _instances)
      {
        if(tama.GetId() == Id)
        {
          return tama;
        }
      }
      return null;
    }
  }
}
