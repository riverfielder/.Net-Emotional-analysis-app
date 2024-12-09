using Newtonsoft.Json.Linq;
using API;

namespace Test
{
    [TestFixture]
    public class EmotionServiceTests
    {
        [Test]
        public async Task GetSentimentAsync1()
        {
            // Act
            Emotion service = new();
            var result = await service.GetSentimentAsync("我爱祖国");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.getSentiment(), Is.EqualTo(2));
                Assert.That(result.getConfidence(), Is.EqualTo(0.90).Within(0.1));  // 允许 0.1 的误差
                Assert.That(result.getPostive_prob(), Is.EqualTo(0.9).Within(0.1));
                Assert.That(result.getNegative_prob(), Is.EqualTo(0.1).Within(0.1));
            });
        }

        [Test]
        public async Task GetSentimentAsync2()
        {
            // Act
            Emotion service = new();
            var result = await service.GetSentimentAsync("今天我很倒霉");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.getSentiment(), Is.EqualTo(0));
                Assert.That(result.getConfidence(), Is.EqualTo(0.90).Within(0.1));  // 允许 0.1 的误差
                Assert.That(result.getPostive_prob(), Is.EqualTo(0.1).Within(0.1));
                Assert.That(result.getNegative_prob(), Is.EqualTo(0.9).Within(0.1));
            });
        }
    }
}