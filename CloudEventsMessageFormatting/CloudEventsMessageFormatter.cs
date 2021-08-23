using System;
using CloudNative.CloudEvents;
using Abstractions;
using CloudNative.CloudEvents.NewtonsoftJson;

namespace CloudEventsMessageFormatting
{
    public class CloudEventsMessageFormatter<TIn> : IMessageFormatter<TIn, String>
    {
        public String Format(TIn message)
        {
            CloudEvent cloudEvent = new CloudEvent(CloudEventsSpecVersion.V1_0)
            {
                DataContentType = "text/plain",
                Data = message,
                Type = "test.type",
                Source = new Uri("urn:a.b.c"),
                Id = Guid.NewGuid().ToString(),
                Time = DateTime.Now
            };

            var jsonFormatter = new JsonEventFormatter();

            var eventMessage = jsonFormatter.EncodeStructuredModeMessage(cloudEvent, out var contentType);
            String encodedMessage = System.Text.Encoding.UTF8.GetString(eventMessage.ToArray(), 0, eventMessage.Length);

            return encodedMessage;

        }
    }
}