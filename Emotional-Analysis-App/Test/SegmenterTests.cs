using API;

namespace Test
{
    [TestFixture]
    public class SegmenterTests
    {
        private Segmenter _segmenter;

        [SetUp]
        public void Setup()
        {
            _segmenter = new Segmenter();
        }

        [Test]
        public void SegmentText_GivenChineseText_ReturnsCorrectWords()
        {
            // Arrange
            var inputText = "我爱自然语言处理";

            // Act
            var result = _segmenter.SegmentText(inputText).ToList();

            // Assert
            Assert.That(result, Has.Count.EqualTo(4)); // 期望有 4 个词语
            Assert.That(result, Does.Contain("我")); // 确保分词结果中包含 "我"
            Assert.That(result, Does.Contain("爱")); // 确保分词结果中包含 "爱"
            Assert.That(result, Does.Contain("自然语言")); // 确保分词结果中包含 "自然语言"
            Assert.That(result, Does.Contain("处理")); // 确保分词结果中包含 "处理"
        }

        [Test]
        public void SegmentText_GivenEmptyText_ReturnsEmptyList()
        {
            // Arrange
            var inputText = "";

            // Act
            var result = _segmenter.SegmentText(inputText).ToList();

            // Assert
            Assert.That(result, Is.Empty); // 期望返回空列表
        }

    }
}
