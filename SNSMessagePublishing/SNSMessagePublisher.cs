using System;
using System.Threading.Tasks;
using Abstractions;
using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace SNSMessaging
{
    public class SNSMessagePublisher : IPublisher<String,Task>
    {

        private readonly IMessageFormatter<String, String> _formatter;

        public SNSMessagePublisher(IMessageFormatter<String, String> formatter)
        {
            _formatter = formatter;
        }

        public async Task Publish(String message)
        {
            String topicArn = "<your-aws-topicarn>";
            String awsRegion = "<your-aws-region>";
            String accessKey = "<your-aws-accesskey>";
            String secret = "<your-aws-secret>";

            String formattedMessage = _formatter.Format(message);

            BasicAWSCredentials creds = new BasicAWSCredentials(accessKey, secret);
            RegionEndpoint region = RegionEndpoint.GetBySystemName(awsRegion);

            var snsClient = new AmazonSimpleNotificationServiceClient(creds, region);

            PublishRequest publishRequest = new PublishRequest(topicArn, formattedMessage);

            PublishResponse response = await snsClient.PublishAsync(publishRequest);

        }
    }
}