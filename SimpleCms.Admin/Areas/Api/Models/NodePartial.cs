using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCms.Admin.Areas.Api.Models
{
    public class NodePartial
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public NodeType Type { get; set; }

        internal static NodePartial FromNode(Node node)
        {
            return new NodePartial
            {
                Id = node.Id,
                Title = node.Id.ToString(),
                Type = node.Type
            };
        }
    }
}