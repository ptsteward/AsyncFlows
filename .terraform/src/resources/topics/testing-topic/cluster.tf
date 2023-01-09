#
# Environment Details 
#
data "confluent_environment" "current" {
  id = var.confluent_config["environment_id"]
}

#
# Output 
#
output "environment_details" {
  value = data.confluent_environment.current
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

output "cluster_details" {
  value = data.confluent_kafka_cluster.public
}

