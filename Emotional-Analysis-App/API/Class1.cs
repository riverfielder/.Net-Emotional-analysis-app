using RestSharp;//依赖版本106.15.0 https://www.nuget.org/packages/RestSharp/106.15.0
using Newtonsoft.Json; //https://www.nuget.org/packages/Newtonsoft.Json
namespace SampleApplication
{
    public class Sample
    {

        const string API_KEY = "4JDCIhOfPqzVR44pLrGmHniY";
        const string SECRET_KEY = "oPJhNpn2OozBLJf6cCpDXeXQFCHNI9wL";

        public static void Main()
        {
            var client = new RestClient($"https://aip.baidubce.com/rpc/2.0/nlp/v1/sentiment_classify?charset=UTF-8&access_token=24.1ab9d536ba6e9e65b2ca521c216e0294.2592000.1733847652.282335-116185072");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            var body = @"{""text"": ""我爱祖国""}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

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
