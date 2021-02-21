#nullable enable

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChatworkSDK.test {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            var dic = ChatworkSDK.Api.QueryHandler.RequestObjectToStringDictionary(new Product());
            ;
        }

        private class Product
        {
            public string name { get; set; } = "りんご";
            public decimal price { get; set; } = 500;
            public string? nullablevalue { get; set; }
            public Kind kind { get; set; } = Kind.Food;
            public IEnumerable<int> tag_ids { get; set; } = new List<int>() { 1, 2, 3, 4 };
            public IEnumerable<string> alias { get; set; } = new List<string>() { "apple", "Apple" };

            public enum Kind
            {
                Food,
                House,
            }
        }
    }
}
