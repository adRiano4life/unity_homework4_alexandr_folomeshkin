using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ArrayCreate : MonoBehaviour
{
    [SerializeField] public bool boolValue;
    [SerializeField] public int arrayLenght;
    [SerializeField] public int intValue;
    [SerializeField] public float floatValue;
    [SerializeField] public string filePath;
    [SerializeField] public string serializeFilePath;
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;
    private string userValueString;

    struct AllValues
    {
        public int intValue;
        public float floatValue;
        public int[] intArray;
        public float[] floatArray;
    }

    [ContextMenu("CheckBoolValue")]
    public void CheckBoolValue()
    {
        if (boolValue)
        {
            int[] intArray = new int[arrayLenght];
            Debug.Log($"Создан массив класса int длинной {arrayLenght} значений");
            userValueString += $"\nint Array Lenght = {arrayLenght}";
            FileCreate(filePath, userValueString);
            _text.color = Color.black;
            _text.text = $"Результат: Создан массив класса int длинной {arrayLenght} значений";
        }
        else
        {
            float[] floatArray = new float[arrayLenght];
            Debug.Log($"Создан массив класса float длинной {arrayLenght} значений");
            userValueString += $"\nfloat Array Lenght = {arrayLenght}";
            FileCreate(filePath, userValueString);
            _text.color = Color.black;
            _text.text = $"Результат: Создан массив класса float длинной {arrayLenght} значений";
        }
    }

    [ContextMenu("CreateArray")]
    public void CreateArray()
    {
        AllValues allValues = new AllValues();
        string arrayString = null;
        if (boolValue)
        {
            int[] intArray = new int[arrayLenght];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = intValue;
                intValue *= intValue;
                arrayString += $"{intArray[i]} ";
            }

            Debug.Log($"Создан массив класса int со значениями: {arrayString}");
            userValueString += $"\nArray int = {arrayLenght}";
            allValues.intArray = intArray;
            FileCreate(filePath, userValueString);
            SerializeFile(serializeFilePath, allValues.intArray);
            _text.color = Color.black;
            _text.text = $"Результат: Создан массив класса int со значениями: {arrayString}";
        }
        else
        {
            float[] floatArray = new float[arrayLenght];
            for (int i = 0; i < floatArray.Length; i++)
            {
                floatArray[i] = floatValue;
                floatValue *= floatValue;
                arrayString += $"{floatArray[i]} ";
                Debug.Log(floatArray[i]);
            }

            Debug.Log($"Создан массив класса float со значениями: {arrayString}");
            userValueString += $"\nМассив класса float = {arrayLenght}";
            allValues.floatArray = floatArray;
            FileCreate(filePath, userValueString);
            SerializeFile(serializeFilePath, allValues.floatArray);
            _text.color = Color.black;
            _text.text = $"Результат: Создан массив класса float со значениями: {arrayString}";
        }
    }

    [ContextMenu("CheckExeption")]
    public void CheckExeption()
    {
        AllValues allValues = new AllValues();
        checked
        {
            try
            {
                int exeptionValue = intValue * intValue;
                Debug.Log($"Полученное число = {exeptionValue}");
                userValueString += $"\nValue = {exeptionValue}";
                FileCreate(filePath, userValueString);
                allValues.intValue = exeptionValue;
                _text.color = Color.black;
                _text.text = $"Результат: Полученное число = {exeptionValue}";
            }
            catch (OverflowException)
            {
                Debug.LogError("Произошло переполнение! Полученное число больше, чем максимальное значение!");
                userValueString += $"\nOverflow Exeption - CheckExeption";
                FileCreate(filePath, userValueString);
                _text.color = Color.red;
                _text.text = $"Результат: Произошло переполнение! Полученное число больше, чем максимальное значение!";
            }
        }
    }

    [ContextMenu("SimpleValue")]
    public void SimpleValue()
    {
        SimpleFunc(intValue);
    }

    [ContextMenu("RefValue")]
    public void RefValue()
    {
        int a = intValue;
        RefFunc(ref a);
    }
    
    [ContextMenu("OutValue")]
    public void OutValue()
    {
        int a;
        OutFunc(out intValue);
    }

    public void SimpleFunc(int a)
    {
        checked
        {
            try
            {
                a *= a;
                Debug.Log($"Полученное число = {a}");
                userValueString += $"\nValue = {a}";
                FileCreate(filePath, userValueString);
                SerializeFile(serializeFilePath, a);
                _text.color = Color.black;
                _text.text = $"Результат: Полученное число = {a}";
            }
            catch (OverflowException)
            {
                Debug.LogError("Произошло переполнение! Полученное число больше, чем максимальное значение!");
                userValueString += $"\nOverflow Exeption - SimpleValue";
                FileCreate(filePath, userValueString);
                _text.color = Color.red;
                _text.text = $"Результат: Произошло переполнение! Полученное число больше, чем максимальное значение!";
            }
        }
    }

    public void RefFunc(ref int a)
    {
        checked
        {
            try
            {
                a *= a;
                Debug.Log($"Полученное число = {a}");
                userValueString += $"\nREF Value = {a}";
                FileCreate(filePath, userValueString);
                SerializeFile(serializeFilePath, a);
                _text.color = Color.black;
                _text.text = $"Результат: Полученное число = {a}";
            }
            catch (OverflowException)
            {
                Debug.LogError("Произошло переполнение! Полученное число больше, чем максимальное значение!");
                userValueString += $"\nOverflow Exeption - RefValue";
                FileCreate(filePath, userValueString);
                _text.color = Color.red;
                _text.text = $"Результат: Произошло переполнение! Полученное число больше, чем максимальное значение!";
            }
        }
    }
    
    public void OutFunc(out int a)
    {
        a = intValue;
        checked
        {
            try
            {
                a *= a;
                Debug.Log($"Полученное число = {a}");
                userValueString += $"\nOUT Value = {a}";
                FileCreate(filePath, userValueString);
                SerializeFile(serializeFilePath, a);
                _text.color = Color.black;
                _text.text = $"Результат: Полученное число = {a}";
            }
            catch (OverflowException)
            {
                Debug.LogError("Произошло переполнение! Полученное число больше, чем максимальное значение!");
                userValueString += $"\nOverflow Exeption - OutValue";
                FileCreate(filePath, userValueString);
                _text.color = Color.red;
                _text.text = $"Результат: Произошло переполнение! Полученное число больше, чем максимальное значение!";
            }
        }
    }

    public void FileCreate(string path, string userValue)
    {
        if (path != null)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, false, Encoding.Default))
            {
                streamWriter.WriteLine(userValue);
            }
        }
    }

    public void SerializeFile(string path, int intValue)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (path != null)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (intValue != null)
                {
                    binaryFormatter.Serialize(fileStream, intValue);
                    Debug.Log("Объект сериализован");
                }
            }

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (intValue != null)
                {
                    int a = (int)binaryFormatter.Deserialize(fileStream);
                    Debug.Log($"Число int = {a}");
                }
            }
        }
    }
    
    public void SerializeFile(string path, float floatValue)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (path != null)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (floatValue != null)
                {
                    binaryFormatter.Serialize(fileStream, floatValue);
                    Debug.Log("Объект сериализован");
                }
            }

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (floatValue != null)
                {
                    float a = (float)binaryFormatter.Deserialize(fileStream);
                    Debug.Log($"Число float = {a}");
                }
            }
        }
    }
    
    public void SerializeFile(string path, int[] intArray)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (path != null)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (intArray != null)
                {
                    binaryFormatter.Serialize(fileStream, intArray);
                    Debug.Log("Объект сериализован");
                }
            }

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (intArray != null)
                {
                    int[] array = (int[])binaryFormatter.Deserialize(fileStream);
                    foreach (var i in intArray)
                    {
                        Debug.Log($"Число массива int = {i}");
                    }
                }
            }
        }
    }
    
    public void SerializeFile(string path, float[] floatArray)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (path != null)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (floatArray != null)
                {
                    binaryFormatter.Serialize(fileStream, floatArray);
                    Debug.Log("Объект сериализован");
                }
            }

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (floatArray != null)
                {
                    float[] array = (float[])binaryFormatter.Deserialize(fileStream);
                    foreach (var f in floatArray)
                    {
                        Debug.Log($"Число массива int = {f}");
                    }
                }
            }
        }
    }
}
