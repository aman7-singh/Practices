using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WordCount
{
    public class XmlEditor : IXmlEditor
    {
        /// <summary>
        /// Updates a name of all nodes, with a given old name, to a new one.
        /// It does not change the order of nodes in an input document.
        /// Searching for nodes is case-sensitive.
        /// </summary>
        /// <param name="xml">A document to update</param>
        /// <param name="oldName">An old node name</param>
        /// <param name="newName">A new node name</param>
        /// <returns>An updated document</returns>
        /// <exception cref="ArgumentNullException">xml is null</exception>
        /// <exception cref="ArgumentNullException">oldName is null</exception>
        /// <exception cref="ArgumentNullException">newName is null</exception>
        /// <exception cref="ArgumentException">xml is empty</exception>
        /// <exception cref="ArgumentException">oldName is empty</exception>
        /// <exception cref="ArgumentException">newName is empty</exception>
        public string ReplaceNodeName(string xml, string oldName, string newName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNode root = doc.DocumentElement;

                XmlNodeList elemList = doc.GetElementsByTagName(oldName);
                var count = elemList.Count;
                foreach (XmlNode node in elemList)
                {
                    XmlElement elem = doc.CreateElement(newName, root.NamespaceURI);

                    foreach (XmlNode n in node.ChildNodes)
                    {
                        XmlElement elem1 = doc.CreateElement(n.Name, n.NamespaceURI);
                        elem1.InnerText = n.InnerText;
                        elem.AppendChild(elem1);
                    }
                    node.ParentNode.AppendChild(elem);
                }
                for (var i = 0; i < count; i++)
                {
                    elemList[0].ParentNode.RemoveChild(elemList[0]);
                }

                return doc.OuterXml;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Removes all nodes with a given name.
        /// If a node being remove has children they also should be removed (recursively).
        /// Searching for nodes is case-sensitive.
        /// If after removal some nodes are empty (have no content and no children), then
        /// they should formatted without explicit closing tags.
        /// </summary>
        /// <param name="xml">A document to update</param>
        /// <param name="name">A name of nodes to be removed</param>
        /// <returns>An updated document</returns>
        /// <exception cref="ArgumentNullException">xml is null</exception>
        /// <exception cref="ArgumentNullException">name is null</exception>
        /// <exception cref="ArgumentException">xml is empty</exception>
        /// <exception cref="ArgumentException">name is empty</exception>
        /// <exception cref="CannotRemoveRootElementException">If you try to delete a root element</exception>
        public string RemoveNodesByName(string xml, string name)
        {
            throw new NotImplementedException();
        }
    }
}
