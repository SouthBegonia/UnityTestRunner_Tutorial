using NUnit.Framework;

/*
 * GameUtils 测试代码
 */

namespace Game.Tests
{
    public class GameUtilsTests
    {
        // GetTextLength测试null字符串
        [Test]
        public void GetTextLength_NullStr()
        {
            string str = null;
            int result = GameUtils.GetTextLength(str);
            Assert.AreEqual(0, result);
        }

        // 多测试数据的GetTextLength测试
        [TestCase("", 0)]
        [TestCase("Hello World", 11)]
        public void GetTextLength_MultiTestData(string data, int exResult)
        {
            int result = GameUtils.GetTextLength(data);

            Assert.AreEqual(exResult, result);
        }
    }
}
