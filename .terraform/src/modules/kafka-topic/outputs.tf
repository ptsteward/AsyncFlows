output "topic_details" {
  description = "Details of the Kafka topic provisioned"
  value       = confluent_kafka_topic.topic
}