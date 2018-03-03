#if FEATURE_SERIALIZATION
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace QiHe.CodeLib
{
    /// <summary>
    /// XmlFile load and save object from and to xml file;
    /// </summary>	
    public class XmlData<DataType>
    {
        /// <summary>
        /// Loads the specified xmlfile.
        /// </summary>
        /// <param name="xmlfile">The xmlfile.</param>
        /// <returns></returns>
        public static DataType Load(string xmlfile)
        {
            DataType data;
            Type datatype = typeof(DataType);
            XmlSerializer mySerializer = new XmlSerializer(datatype);
            if (File.Exists(xmlfile))
            {
                using (XmlTextReader reader = new XmlTextReader(xmlfile))
                {
                    data = (DataType)mySerializer.Deserialize(reader);
                }
            }
            else
            {
                //throw new FileNotFoundException(xmlfile);
                return default(DataType);
            }
            return data;
        }
        /// <summary>
        /// Loads the specified xmldata.
        /// </summary>
        /// <param name="xmldata">The xmldata.</param>
        /// <returns></returns>
        public static DataType Load(Stream xmldata)
        {
            using (XmlTextReader reader = new XmlTextReader(xmldata))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(DataType));
                return (DataType)mySerializer.Deserialize(reader);
            }
        }
        /// <summary>
        /// Loads the specified xmlfile.
        /// </summary>
        /// <param name="xmlfile">The xmlfile.</param>
        /// <param name="root">The root.</param>
        /// <returns></returns>
        public static DataType Load(string xmlfile, string root)
        {
            DataType data;
            Type datatype = typeof(DataType);
            XmlRootAttribute rootattr = new XmlRootAttribute(root);
            XmlSerializer mySerializer = new XmlSerializer(datatype, rootattr);
            if (File.Exists(xmlfile))
            {
                XmlTextReader reader = new XmlTextReader(xmlfile);
                data = (DataType)mySerializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                //throw new FileNotFoundException(xmlfile);
                return default(DataType);
            }
            return data;
        }
        /// <summary>
        /// Saves the specified xmlfile.
        /// </summary>
        /// <param name="xmlfile">The xmlfile.</param>
        /// <param name="data">The data.</param>
        public static void Save(string xmlfile, DataType data)
        {
            XmlSerializer mySerializer = new XmlSerializer(data.GetType());
            XmlTextWriter writer = new XmlTextWriter(xmlfile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            mySerializer.Serialize(writer, data);
            writer.Close();
        }
    }
    /// <summary>
    /// XmlFile load and save object from and to xml file;
    /// </summary>	
    public class XmlFile
    {
        /// <summary>
        /// Loads the specified xmlfile.
        /// </summary>
        /// <param name="xmlfile">The xmlfile.</param>
        /// <param name="datatype">The datatype.</param>
        /// <returns></returns>
        public static object Load(string xmlfile, Type datatype)
        {
            object data = null;
            XmlSerializer mySerializer = new XmlSerializer(datatype);
            if (File.Exists(xmlfile))
            {
                XmlTextReader reader = new XmlTextReader(xmlfile);
                data = mySerializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                //throw new FileNotFoundException(xmlfile);
                return null;
            }
            return data;
        }
        /// <summary>
        /// Saves the specified xmlfile.
        /// </summary>
        /// <param name="xmlfile">The xmlfile.</param>
        /// <param name="data">The data.</param>
        public static void Save(string xmlfile, object data)
        {
            XmlSerializer mySerializer = new XmlSerializer(data.GetType());
            XmlTextWriter writer = new XmlTextWriter(xmlfile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            mySerializer.Serialize(writer, data);
            writer.Close();
        }
        /// <summary>
        /// Saves the specified xmlfile.
        /// </summary>
        /// <param name="xmlfile">The xmlfile.</param>
        /// <param name="root">The root.</param>
        /// <param name="data">The data.</param>
        public static void Save(string xmlfile, string root, object data)
        {
            XmlRootAttribute rootattr = new XmlRootAttribute(root);
            XmlSerializer mySerializer = new XmlSerializer(data.GetType(), rootattr);
            XmlTextWriter writer = new XmlTextWriter(xmlfile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            mySerializer.Serialize(writer, data);
            writer.Close();
        }
    }

    /// <summary>
    /// BinFile
    /// </summary>
    public class BinFile
    {
        /// <summary>
        /// Reads the specified datafile.
        /// </summary>
        /// <param name="datafile">The datafile.</param>
        /// <returns></returns>
        public static object Read(string datafile)
        {
            if (File.Exists(datafile))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(datafile, FileMode.Open, FileAccess.Read, FileShare.Read);
                object obj = formatter.Deserialize(stream);
                stream.Close();
                return obj;
            }
            else
            {
                throw new FileNotFoundException(datafile);
            }
        }
        /// <summary>
        /// Writes the specified datafile.
        /// </summary>
        /// <param name="datafile">The datafile.</param>
        /// <param name="obj">The obj.</param>
        public static void Write(string datafile, object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(datafile, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }
    }
}
#endif