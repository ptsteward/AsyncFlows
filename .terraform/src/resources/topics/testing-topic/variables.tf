#
# Confluent Cloud configurations
#
variable "confluent_config" {
  type = map(string)
}

variable "CONFLUENT_CLUSTER_CREDENTIALS" {
  type = map(string)
}


#
#  Topic configurations
#
variable "topic_delete_cleanup_policy" {
  type        = string
  description = "Multiple messages with the same key will exists in a the topic"
  default     = "delete"
}

variable "topic_compact_cleanup_policy" {
  type        = string
  description = "Retain only the last message fo a given key in a topic"
  default     = "compact"
}

variable "topic_max_message_size_bytes" {
  type        = string
  description = "Max message size for the message in the topic in bytes"
  default     = "1000000"
}

variable "topic_retention_time_day_ms" {
  type        = string
  description = "Time in ms for message to be retained for a day in ms"
  default     = "86400000"
}

variable "topic_retention_time_week_ms" {
  type        = string
  description = "Time in ms for message to be retained for a week in ms"
  default     = "604800000"
}

variable "topic_retention_time_month_ms" {
  type        = string
  description = "Time in ms for message to be retained for a month in ms"
  default     = "2592000000"
}

variable "topic_min_insync_replicas" {
  type        = number
  description = "Insync replicas for topics"
  default     = 2
}

variable "topic_scope_public" {
  type        = string
  description = "Public scope for topic"
  default     = "public"
}

variable "topic_scope_private" {
  type        = string
  description = "Private scope for topic"
  default     = "private"
}
