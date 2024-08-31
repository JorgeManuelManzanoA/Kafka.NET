using Confluent.Kafka;

var config = new ProducerConfig { BootstrapServers = "kafka:9092" };

using (var producer = new ProducerBuilder<Null, string>(config).Build())
{
    var deliveryResult = await producer.ProduceAsync("hello-world", new Message<Null, string> { Value = "Hola Mundo desde Docker y .NET con Kafka!" });
    Console.WriteLine($"Mensaje enviado a Kafka: {deliveryResult.Value}");
}

var consumerConfig = new ConsumerConfig
{
    GroupId = "test-group",
    BootstrapServers = "kafka:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build())
{
    consumer.Subscribe("hello-world");
    var consumeResult = consumer.Consume();
    Console.WriteLine($"Mensaje recibido desde Kafka: {consumeResult.Message.Value}");
}
