using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;

public class GameState : MonoBehaviour, IService
{
    public List<BoolState> boolStates;
    public List<IntState> intStates;
    public List<FloatState> floatStates;
    private ConfigGameStates configGameStates;

    public void Init()
    {
        configGameStates =
            CMS.GetAll<CMSEntity>().FirstOrDefault(x => x.Is<ConfigGameStates>())!.Get<ConfigGameStates>();
        ReloadGameState();
    }

    public void ReloadGameState()
    {
        boolStates = TakeList<BoolState>();
        intStates = TakeList<IntState>();
        floatStates = TakeList<FloatState>();
    }

    public T GetState<T>(string n)
    {
        if (typeof(T) == typeof(int))
        {
            return (T)(object)intStates.FirstOrDefault(x => x.GetName() == n)!.value;
        }
        if (typeof(T) == typeof(float))
        {
            return (T)(object)floatStates.FirstOrDefault(x => x.GetName() == n)!.value;
        }
        if (typeof(T) == typeof(bool))
        {
            return (T)(object)boolStates.FirstOrDefault(x => x.GetName() == n)!.value;
        }
        throw new Exception("Нет такого типа");
    }
    public void SetState<T>(string n, T newValue)
    {
        if (typeof(T) == typeof(int))
        {
            intStates.FirstOrDefault(x => x.GetName() == n)!.value = (int)(object)newValue;
        }
        else if (typeof(T) == typeof(float))
        {
            floatStates.FirstOrDefault(x => x.GetName() == n)!.value = (float)(object)newValue;
        }
        else if (typeof(T) == typeof(bool))
        {
            boolStates.FirstOrDefault(x => x.GetName() == n)!.value = (bool)(object)newValue;
        }
        else
        {
            throw new Exception("Нет такого типа");
        }
    }

private List<T> TakeList<T>() where T : IGameStateSlot
    {
        List<T> temp = new List<T>();
        foreach (var someValue in configGameStates.StateSlots.FindAll(x => (x is T)).Cast<T>())
        {
            temp.Add((T)someValue.Clone());
        }

        return temp;
    }
}

public interface IGameStateSlot : ICloneable
{
    public string GetName();
}

[Serializable]
public class BoolState : IGameStateSlot
{
    public string name;
    public bool value;

    public string GetName() => name;

    public object Clone() => new BoolState() {name = this.name, value = this.value};
}
[Serializable]
public class IntState : IGameStateSlot
{
    public string name; 
    public int value;
    public string GetName() => name;
    public object Clone() => new IntState() {name = this.name, value = this.value};
}
[Serializable]
public class FloatState : IGameStateSlot
{
    public string name;
    public float value;
    public string GetName() => name;
    public object Clone() => new FloatState() {name = this.name, value = this.value};
}
