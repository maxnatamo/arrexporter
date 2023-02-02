using Xunit;
using FluentAssertions;

using System.Collections.Generic;

using Newtonsoft.Json;
using ArrExporter.Shared.Converters;

namespace ArrExporter.Shared.Tests
{
    [JsonConverter(typeof(JsonPathConverter))]
    internal class TestModelWithPaths
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "nested.object")]
        public int NestedObject { get; set; }

        [JsonProperty(PropertyName = "nested.nested.object")]
        public string VeryNestedObject { get; set; } = default!;

        [JsonProperty(PropertyName = "nested.list")]
        public List<int> NestedList { get; set; } = default!;
    };

    [JsonConverter(typeof(JsonPathConverter))]
    internal class TestModelWithoutPropertyNames
    {
        public int Id { get; set; }
    };

    public class JsonPathConverterTests
    {
        [Fact]
        public void DeserializeObjectReturnsValidModelWithoutPaths()
        {
            string json = @"{ ""id"": 123 }";

            var model = JsonConvert.DeserializeObject<TestModelWithPaths>(json);

            model.Should().NotBeNull();
            model?.Id.Should().NotBe(null);
            model?.Id.Should().Be(123);
        }

        [Fact]
        public void DeserializeObjectReturnsValidModelWithNestedPaths()
        {
            string json = @"{
                ""id"": 123,
                ""nested"": {
                    ""object"": 456
                }
            }";

            var model = JsonConvert.DeserializeObject<TestModelWithPaths>(json);

            model.Should().NotBeNull();
            model?.NestedObject.Should().NotBe(null);
            model?.NestedObject.Should().Be(456);
        }

        [Fact]
        public void DeserializeObjectReturnsValidModelWithTwoNestedPaths()
        {
            string json = @"{
                ""id"": 123,
                ""nested"": {
                    ""nested"": {
                        ""object"": ""awesome""
                    }
                }
            }";

            var model = JsonConvert.DeserializeObject<TestModelWithPaths>(json);

            model.Should().NotBeNull();
            model?.VeryNestedObject.Should().NotBe(null);
            model?.VeryNestedObject.Should().Be("awesome");
        }

        [Fact]
        public void DeserializeObjectReturnsValidModelWithNestedList()
        {
            string json = @"{
                ""id"": 123,
                ""nested"": {
                    ""list"": [
                        1,
                        2,
                        3,
                        4,
                        5,
                    ]
                }
            }";

            var model = JsonConvert.DeserializeObject<TestModelWithPaths>(json);

            model.Should().NotBeNull();
            model?.NestedList.Should().Contain(new List<int>{ 1, 2, 3, 4, 5 });
            model?.NestedList.Count.Should().Be(5);
        }

        [Fact]
        public void DeserializeObjectReturnsValidModelWithoutPropertyNames()
        {
            string json = @"{
                ""Id"": 123
            }";

            var model = JsonConvert.DeserializeObject<TestModelWithoutPropertyNames>(json);

            model.Should().NotBeNull();
            model?.Id.Should().NotBe(null);
            model?.Id.Should().Be(123);
        }
    }
}