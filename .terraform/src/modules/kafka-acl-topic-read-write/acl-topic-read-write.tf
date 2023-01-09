locals {
  resource_name = lower(var.resource_name)
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
# ACL on a Kafka resource 
#
resource "confluent_kafka_acl" "read" {
  kafka_cluster {
    id = var.confluent_config["kafka_cluster_id"]
  }

  resource_type = "TOPIC"
  resource_name = local.resource_name
  pattern_type  = "LITERAL"
  principal     = "User:${var.principal}"
  host          = "*"
  operation     = "READ"
  permission    = "ALLOW"
  rest_endpoint = data.confluent_kafka_cluster.public.rest_endpoint

  credentials {
    key    = var.confluent_cluster_credentials["kafka_cluster_key"]
    secret = var.confluent_cluster_credentials["kafka_cluster_secret"]
  }
}

resource "confluent_kafka_acl" "write" {
  kafka_cluster {
    id = var.confluent_config["kafka_cluster_id"]
  }

  resource_type = "TOPIC"
  resource_name = local.resource_name
  pattern_type  = "LITERAL"
  principal     = "User:${var.principal}"
  host          = "*"
  operation     = "WRITE"
  permission    = "ALLOW"
  rest_endpoint = data.confluent_kafka_cluster.public.rest_endpoint

  credentials {
    key    = var.confluent_cluster_credentials["kafka_cluster_key"]
    secret = var.confluent_cluster_credentials["kafka_cluster_secret"]
  }
}

resource "confluent_kafka_acl" "describe" {
  kafka_cluster {
    id = var.confluent_config["kafka_cluster_id"]
  }

  resource_type = "TOPIC"
  resource_name = local.resource_name
  pattern_type  = "LITERAL"
  principal     = "User:${var.principal}"
  host          = "*"
  operation     = "DESCRIBE"
  permission    = "ALLOW"
  rest_endpoint = data.confluent_kafka_cluster.public.rest_endpoint

  credentials {
    key    = var.confluent_cluster_credentials["kafka_cluster_key"]
    secret = var.confluent_cluster_credentials["kafka_cluster_secret"]
  }
}


resource "confluent_kafka_acl" "describe-configs" {
  kafka_cluster {
    id = var.confluent_config["kafka_cluster_id"]
  }

  resource_type = "TOPIC"
  resource_name = local.resource_name
  pattern_type  = "LITERAL"
  principal     = "User:${var.principal}"
  host          = "*"
  operation     = "DESCRIBE_CONFIGS"
  permission    = "ALLOW"
  rest_endpoint = data.confluent_kafka_cluster.public.rest_endpoint

  credentials {
    key    = var.confluent_cluster_credentials["kafka_cluster_key"]
    secret = var.confluent_cluster_credentials["kafka_cluster_secret"]
  }
}