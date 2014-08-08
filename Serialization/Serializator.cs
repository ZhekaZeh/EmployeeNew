﻿using System;
using EmployeeViewer.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;


namespace EmployeeViewer.Serialization

{
    [Serializable]
    public class Serializator
    {
        /// <summary>
        /// Serializes the specified object to seriallize.
        /// </summary>
        /// <param name="objectToSeriallize">The object to seriallize.</param>
        /// <returns></returns>
        static public byte[] Serialize(object objectToSeriallize) 
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, objectToSeriallize);
                return stream.ToArray();                                
            }
        }

        /// <summary>
        /// Uns the serialize.
        /// </summary>
        public static ObservableCollection<Employee> Deserialize(byte[] byteArray)
        {
            Stream memoryStream = new MemoryStream();
            BinaryFormatter binFormatter = new BinaryFormatter();

            memoryStream.Write(byteArray, 0, byteArray.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);
            ObservableCollection<Employee> objectEployees = (ObservableCollection<Employee>)binFormatter.Deserialize(memoryStream);
            return objectEployees;
        }
    }
}
