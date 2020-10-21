using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AspNetCoreExtensions.Tests
{
    public class ConfigurationTests
    {
        private IConfiguration configuration;
        private Dictionary<string, string> pairs = new Dictionary<string, string>()
            {
                { "Test3", 10.ToString() },
                { "Key3.1.1", "Value3.1.1" },
                { "Test2", false.ToString() },
                { "Test", "Test1" },
                { "", null },
                { "Key4.2", null },
                { "Key4.2.1", null },
            };
        public ConfigurationTests()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("test-appsettings.json").Build();
        }
        [Fact]
        public void TestFind()
        {
            foreach (var pair in pairs)
            {
                Assert.Equal(pair.Value, configuration.Find(pair.Key));
            }
            Assert.Null(configuration.Find(null));
        }
    }
}
