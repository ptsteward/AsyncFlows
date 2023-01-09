#
# Environment and Cluster Details
#
variable "confluent_config" {
  type = map(string)
}


#
# Kafka Cluster Secrets
#
variable "confluent_cluster_credentials" {
  type = map(string)
}


#
# Topic Details
#
variable "namespace" {
  type        = string
  description = "Domain name in which the topic will be provisioned"

  validation {
    condition     = length(var.namespace) > 1
    error_message = "The namespace specified is not valid"
  }
}

variable "app_name" {
  type        = string
  description = "Application for which the topic will be provisioned"

  validation {
    condition     = length(var.app_name) > 1
    error_message = "The app name specified is not valid"
  }
}

variable "topic_name" {
  type        = string
  description = "Name of the Kafka topic"

  validation {
    condition     = length(var.topic_name) > 1
    error_message = "The topic name specified is not valid"
  }
}

variable "topic_scope" {
  type        = string
  description = "Scope for the Kafka topic"

  validation {
    condition     = length(var.topic_scope) > 1
    error_message = "The topic scope specified is not valid"
  }
}

variable "topic_partitions_count" {
  type        = string
  description = "No of partitons for the Kafka topic"

  validation {
    condition     = length(var.topic_partitions_count) > 0
    error_message = "The topic partitions count specified is not valid"
  }
}


#
#  Topic configurations
#
variable "topic_cleanup_policy" {
  type        = string
  description = "Multiple messages with the same key will exists in a the topic"

  validation {
    condition     = length(var.topic_cleanup_policy) > 1
    error_message = "The topic cleanup policy specified is not valid"
  }
}

variable "topic_max_message_size_bytes" {
  type        = string
  description = "Max message size for the message in the topic in bytes"

  validation {
    condition     = length(var.topic_max_message_size_bytes) > 0
    error_message = "The topic max message size specified is not valid"
  }
}

variable "topic_retention_time_ms" {
  type        = string
  description = "Time in ms for message to be retained for a day in ms"

  validation {
    condition     = length(var.topic_retention_time_ms) > 0
    error_message = "The topic retention time specified is not valid"
  }
}

variable "topic_min_insync_replicas" {
  type        = number
  description = "Insync replicas for topics"

  validation {
    condition     = var.topic_min_insync_replicas > 0
    error_message = "The topic insync replicas specified is not valid"
  }
}


#
# Additional custom topic configurations
#
variable "topic_extra_config" {
  type        = map(string)
  description = "Topic config values that are not defined or defaulted. Users can pass any config key/value pair here. If a config defined through a variable is also defined here, the variable value takes precedence."
  default     = {}
}
