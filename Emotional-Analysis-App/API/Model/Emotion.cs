using RestSharp;//依赖版本106.15.0 https://www.nuget.org/packages/RestSharp/106.15.0
using Newtonsoft.Json; //https://www.nuget.org/packages/Newtonsoft.Json
using Newtonsoft.Json.Linq;

namespace API
{
    public class Emotion : IEmotion
    {

        const string API_KEY = "4JDCIhOfPqzVR44pLrGmHniY";
        const string SECRET_KEY = "oPJhNpn2OozBLJf6cCpDXeXQFCHNI9wL";
        const string ACCESS_TOKEN = "24.1ab9d536ba6e9e65b2ca521c216e0294.2592000.1733847652.282335-116185072";

        public Emotion() { }

        public async Task<SentimentResult?> GetSentimentAsync(string text)
        {
            var client = new RestClient($"https://aip.baidubce.com/rpc/2.0/nlp/v1/sentiment_classify?charset=UTF-8&access_token={ACCESS_TOKEN}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            var body = $"{{\"text\": \"{text}\"}}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);

            if(!response.IsSuccessful)
            {
                return null;
            }

            var json = JObject.Parse(response.Content);
            var item = json["items"]?[0];  // 获取第一个 item 对象

            if (item != null)
            {
                return item.ToObject<SentimentResult>();
            }
            return null;

        }


        /**
        * 使用 AK，SK 生成鉴权签名（Access Token）
        * @return 鉴权签名信息（Access Token）
        */
        static string GetAccessToken()
        {
            var client = new RestClient($"https://aip.baidubce.com/oauth/2.0/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", API_KEY);
            request.AddParameter("client_secret", SECRET_KEY);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return result.access_token.ToString();
        }

    }
}
