using System.Xml.Serialization;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CloneHelper
{
	public static T clone<T>(T oldObject)
	{
		object newObject;
		using (MemoryStream ms = new MemoryStream())
		{
			XmlSerializer xml = new XmlSerializer(typeof(T));
			xml.Serialize(ms, oldObject);
			ms.Seek(0, SeekOrigin.Begin);
			newObject = xml.Deserialize(ms);
			ms.Close();
		}
		return (T)newObject;
	}
}