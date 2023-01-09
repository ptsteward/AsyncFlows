#
# Topic :  sched-primesched-zipcapability-[env]-[public]
#
module "cf-testtopic" {
  source = "../../../../modules/kafka-topic/"

  # Your values go here
  namespace  = "cf"
  app_name   = "corestreams"
  topic_name = "testtopic"

  # Default values - update accordingly if they don't match your use case
  topic_scope                  = var.topic_scope_public
  topic_partitions_count       = 1
  topic_cleanup_policy         = var.topic_compact_cleanup_policy
  topic_max_message_size_bytes = var.topic_max_message_size_bytes
  topic_retention_time_ms      = var.topic_retention_time_indefinite
  topic_min_insync_replicas    = var.topic_min_insync_replicas

  # Do not change the below values
  confluent_config              = var.confluent_config
  confluent_cluster_credentials = var.CONFLUENT_CLUSTER_CREDENTIALS
}


#
# Output: Topic details
# 
output "topic_name" {
  value = module.cf-testtopic.topic_details.topic_name
}
