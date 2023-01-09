locals {
  namespace  = lower(join("", regexall("[a-zA-Z]+", var.namespace)))
  app_name   = lower(var.app_name)
  topic_name = lower(var.topic_name)
}


#
# Topic expert mode default Values
#
locals {
  topic_default_config = {
    "delete.retention.ms"                   = "86400000"
    "max.compaction.lag.ms"                 = "9223372036854775807"
    "message.timestamp.difference.max.ms"   = "9223372036854775807"
    "message.timestamp.type"                = "CreateTime"
    "min.compaction.lag.ms"                 = "0"
    "retention.bytes"                       = "-1"
    "segment.bytes"                         = "104857600"
    "segment.ms"                            = "604800000"
  }
}


#
# Calling module input variables
#
locals {
  topic_req_config = {
    "cleanup.policy"      = var.topic_cleanup_policy,
    "max.message.bytes"   = var.topic_max_message_size_bytes,
    "min.insync.replicas" = var.topic_min_insync_replicas,
    "retention.ms"        = var.topic_retention_time_ms,
  }
}


#
# Cluster Details
#
data "confluent_kafka_cluster" "public" {
  id = var.confluent_config["kafka_cluster_id"]

  environment {
    id = var.confluent_config["environment_id"]
  }
}


#
# Kafka Topic
#
resource "confluent_kafka_topic" "topic" {
  kafka_cluster {
    id = var.confluent_config["kafka_cluster_id"]
  }

  topic_name       = "${local.namespace}-${local.app_name}-${local.topic_name}-${var.confluent_config["environment_name"]}-${var.topic_scope}"
  partitions_count = var.topic_partitions_count
  rest_endpoint    = data.confluent_kafka_cluster.public.rest_endpoint

  config = merge(local.topic_default_config, var.topic_extra_config, local.topic_req_config)

  credentials {
    key    = var.confluent_cluster_credentials["kafka_cluster_key"]
    secret = var.confluent_cluster_credentials["kafka_cluster_secret"]
  }

  lifecycle {
    prevent_destroy = true
  }
}
