using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public interface IXmlEditor
    {
        /// <summary>
        /// Updates the name of all nodes, with a given old name, to a new one.
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
        string ReplaceNodeName(string xml, string oldName, string newName);

        /// <summary>
        /// Removes all nodes with a given name.
        /// If a node being removed has children, they should also be removed (recursively).
        /// Searching for nodes is case-sensitive.
        /// If, after removal, some nodes are empty (have no content and no children), then
        /// they should formatted without explicitly closing tags.
        /// </summary>
        /// <param name="xml">A document to update</param>
        /// <param name="name">A name of nodes to be removed</param>
        /// <returns>An updated document</returns>
        /// <exception cref="ArgumentNullException">xml is null</exception>
        /// <exception cref="ArgumentNullException">name is null</exception>
        /// <exception cref="ArgumentException">xml is empty</exception>
        /// <exception cref="ArgumentException">name is empty</exception>
        /// <exception cref="CannotRemoveRootElementException">If you try to delete a root element</exception>
        string RemoveNodesByName(string xml, string name);
    }
}
