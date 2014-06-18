using System;

namespace SimpleCms
{
    public enum NodeType
    {
        Mvc,
        Redirect,
        External
    }

    public class Node : Base
    {
        #region Core Node Information

        public Node Parent { get; set; }

        public string Title { get; set; }

        public NodeType Type { get; set; }

        public string UrlKey { get; set; }

        #endregion

        #region Redirect Node

        public string Redirect { get; set; }

        #endregion

        #region Document Node

        public string Controller { get; set; }

        public string Action { get; set; }

        public DocumentType DocumentType { get; set; }

        public string DocumentData { get; set; }

        #endregion
    }
}

