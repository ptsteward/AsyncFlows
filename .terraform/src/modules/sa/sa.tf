locals {
  namespace        = lower(join("", regexall("[a-zA-Z]+", var.namespace)))
  app_name         = lower(join("", regexall("[a-zA-Z]+", var.app_name)))
  environment_name = var.confluent_config["environment_name"]
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
# Service Account 
#
resource "confluent_service_account" "topic" {
  display_name = "${local.namespace}-${local.app_name}-sa-${local.environment_name}"
  description  = var.description

  lifecycle {
    ignore_changes = [
      description
    ]
  }
}


resource "confluent_api_key" "sa-account-kafka-api-key" {
  display_name = "${confluent_service_account.topic.display_name}-key-${local.environment_name}"
  description  = "Kafka API Key that is owned by '${confluent_service_account.topic.display_name}' service account"

  owner {
    id          = confluent_service_account.topic.id
    api_version = confluent_service_account.topic.api_version
    kind        = confluent_service_account.topic.kind
  }

  managed_resource {
    id          = data.confluent_kafka_cluster.public.id
    api_version = data.confluent_kafka_cluster.public.api_version
    kind        = data.confluent_kafka_cluster.public.kind
    environment {
      id = var.confluent_config["environment_id"]
    }
  }
}
