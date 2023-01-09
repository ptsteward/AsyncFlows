#
# Service account details
# 
output "name" {
  value = confluent_service_account.topic.display_name
}

output "id" {
  value = confluent_service_account.topic.id
}

output "key" {
  value = confluent_api_key.sa-account-kafka-api-key.id
}

output "secret" {
  sensitive = true
  value     = confluent_api_key.sa-account-kafka-api-key.secret
}