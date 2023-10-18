using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab3.Student
{
    public record GetStudentsRequest(
        [JsonProperty("limit")] int Limit,
        [JsonProperty("sort")] string Sort,
        [JsonProperty("offset")] int Offset,
        [JsonProperty("minid")] int MinId,
        [JsonProperty("maxid")] int MaxId,
        [JsonProperty("like")] string Like,
        [JsonProperty("globallike")] string GlobalLike,
        [JsonProperty("columns")] string Columns,
        [JsonProperty("format")] string Format
        )
    {
        public GetStudentsRequest() : this(int.MaxValue, "id", 0, 0, int.MaxValue, "", "", "", "json")
        {}
    }
}