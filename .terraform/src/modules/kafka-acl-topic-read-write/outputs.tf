#
# ACL details
#
output "acl_pattern_type" {
  description = "The pattern set for ACL on the Kafka resource"
  value = confluent_kafka_acl.write.pattern_type
}

output "resource_name" {
  description = "The name of the resource on which the ACL was applied"
  value = confluent_kafka_acl.write.resource_name
}