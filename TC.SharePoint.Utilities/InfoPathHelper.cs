using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace TC.SharePoint.Utilities
{
    public static class InfoPathHelper
    {
        /// <summary>
        /// Set a value to xml node.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tagNameOfElement"></param>
        /// <param name="valueToField"></param>
        /// <returns></returns>
        public static byte[] SetValueToField(SPListItem item, string tagNameOfElement ,string valueToField)
        {
            XmlDocument xml = new XmlDocument();

            using (Stream s = item.File.OpenBinaryStream())
            {
                xml.Load(s);
            }
            
            XmlNodeList nodes = xml.GetElementsByTagName(tagNameOfElement);
            foreach (XmlNode node in nodes)
            {
                node.InnerText = valueToField;
            }
            
            byte[] xmlData = System.Text.Encoding.UTF8.GetBytes(xml.OuterXml);

            return xmlData;
        }

        /// <summary>
        /// Get value of a xml field
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tagNameOfElement"></param>
        /// <returns></returns>
        public static string GetValueOfField(SPListItem item, string tagNameOfElement)
        {
            XmlDocument xml = new XmlDocument();
            using (Stream s = item.File.OpenBinaryStream())
            {
                xml.Load(s);
            }

            XmlNodeList nodes = xml.GetElementsByTagName(tagNameOfElement);
            return nodes[0].InnerText;    
        }

        /// <summary>
        /// Get value of a xml field
        /// </summary>
        /// <param name="spFile"></param>
        /// <param name="tagNameOfElement"></param>
        /// <returns></returns>
        public static string GetValueOfField(SPFile spFile, string tagNameOfElement)
        {
            XmlDocument xml = new XmlDocument();
            using (Stream s = spFile.OpenBinaryStream())
            {
                xml.Load(s);
            }

            XmlNodeList nodes = xml.GetElementsByTagName(tagNameOfElement);
            return nodes[0].InnerText;
        }

        /// <summary>
        /// Get value of a xml field - InfoPath
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tagNameOfElement"></param>
        /// <returns></returns>
        public static string GetValueOfField(string path, string tagNameOfElement)
        {
            XmlDocument xml = new XmlDocument();
            using (Stream s =  File.OpenRead(path) )
            {
                xml.Load(s);
            }

            XmlNodeList nodes = xml.GetElementsByTagName(tagNameOfElement);
            return nodes[0].InnerText;
        }

    }
}
